using Supply.Domain;
using Supply.Libs;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class DeclarationPaymentOrder : Form
    {
        private int _hostelID;
        private int _tenantID;
        private bool _flag;
        private List<int> _tenants;
        public DeclarationPaymentOrder()
        {
            InitializeComponent();
            _hostelID = 0;
            _flag = false;
        }

        public DeclarationPaymentOrder(int tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
            _flag = true;
            CB_Hostels.Enabled = false;
        }
        public DeclarationPaymentOrder(List<int> tenants)
        {
            InitializeComponent();
            _flag = false;
            _tenants = tenants;
            CB_Hostels.Enabled = false;
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(CreatePayOrder);
            thread.Start();
            MessageBox.Show("Запущен фоновый процесс создания платежных поручений!");
        }

        private void DeclarationPaymentOrder_Shown(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                CB_Hostels.DataSource = db.Hostels.ToList();
                CB_Hostels.ValueMember = "ID";
                CB_Hostels.DisplayMember = "Name";

            }
        }

        private void CB_Hostels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _hostelID = (int)CB_Hostels.SelectedValue;
            }
            catch
            {
                return;
            }
        }

        private void CreatePayOrder()
        {
            if (_flag == false)
            {
                if (_hostelID != 0 && _tenants.Count == 0) 
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        var enterances = db.Enterances.Where(x => x.HostelId == _hostelID).ToList();

                        foreach (Enterance enterance in enterances)
                        {
                            foreach (Flat flat in db.Flats.Where(x => x.Enterance_ID == enterance.ID).ToList())
                            {
                                foreach (Room room in db.Rooms.Where(x => x.FlatID == flat.ID).ToList())
                                {
                                    foreach (Tenant tenant in db.Tenants.Where(x => x.RoomID == room.ID).Where(s=>s.Status==true).Include(p => p.Payment).Include(o => o.Order).ToList()) 
                                    {
                                        string error = string.Empty;
                                        if (!OrdersCreation.CreatePaymentOrder(tenant.ID, TB_StartDate.Text, TB_EndDate.Text, TB_Action.Text, out error))
                                        {
                                            MessageBox.Show(error);
                                        }
                                        else
                                        {
                                            DateTime periodStart = Convert.ToDateTime(TB_StartDate.Text);
                                            DateTime periodEnd = Convert.ToDateTime(TB_EndDate.Text);

                                            int totalDate = Math.Abs((periodEnd.Month - periodStart.Month) + 12 * (periodEnd.Year - periodStart.Year));

                                            Accounting accounting = db.Accountings
                                                .Where(t => t.TenantID == tenant.ID)
                                                .Where(ps=>ps.PeriodStart==TB_StartDate.Text)
                                                .Where(pe=>pe.PeriodEnd==TB_EndDate.Text)
                                                .FirstOrDefault();

                                            

                                            if (accounting == null)
                                            {

                                                

                                                accounting = new Accounting();
                                                accounting.CreatedAt = DateTime.Now.ToString();
                                                accounting.PeriodStart = TB_StartDate.Text;
                                                accounting.PeriodEnd = TB_EndDate.Text;
                                                accounting.TenantID = tenant.ID;
                                                accounting.Coast = "0";

                                                decimal rent, house, service;

                                                OrdersCreation.SpecialPayments(tenant.ID, out rent, out house, out service);

                                                decimal electricityPay = 0;
                                                if (tenant.TenantTypeID != 2 || tenant.TenantTypeID != 3)
                                                {
                                                    OrdersCreation.SpecialPaymentsElectricity(tenant.ID, out electricityPay);
                                                }
                                                if (OrdersCreation.AdditionalInf(10, tenant.ID) != string.Empty)
                                                {
                                                    electricityPay = 0;
                                                }

                                                if (OrdersCreation.AdditionalInf(5, tenant.ID) != "Заочная")
                                                {
                                                    int days, month, daysInMonth;

                                                    if (periodEnd.Month == periodStart.Month && periodEnd.Year == periodStart.Year)
                                                    {
                                                        days = periodEnd.Day;
                                                        daysInMonth = DateTime.DaysInMonth(periodEnd.Year, periodEnd.Month);

                                                        rent = (rent / daysInMonth) * days;
                                                        house = (house / daysInMonth) * days;
                                                        service = (service / daysInMonth) * days;
                                                        electricityPay = (electricityPay / daysInMonth) * days;
                                                    }
                                                    else
                                                    {
                                                        OrdersCreation.SpecialDateCheck(periodStart, periodEnd, out days, out month, out daysInMonth);

                                                        if (days != 0)
                                                        {
                                                            decimal tempHouse, tempService, tempRent, tempElPay;

                                                            tempHouse = house * month;
                                                            tempRent = rent * month;
                                                            tempService = service * month;
                                                            tempElPay = electricityPay * month;

                                                            house = (house / daysInMonth) * days + tempHouse;
                                                            rent = (rent / daysInMonth) * days + tempRent;
                                                            service = (service / daysInMonth) * days + tempService;
                                                            electricityPay = (electricityPay / daysInMonth) * days + tempElPay;
                                                        }
                                                        else
                                                        {
                                                            rent *= month;
                                                            house *= month;
                                                            service *= month;
                                                            electricityPay *= month;
                                                        }
                                                    }

                                                    decimal payment = 0;
                                                    if (OrdersCreation.BenefitCheck(tenant.ID, house + service, periodStart, periodEnd, out payment))
                                                    {
                                                        accounting.Debt = ((Math.Round(payment, 2) + Math.Round(service, 2) + Math.Round(electricityPay, 2))).ToString();
                                                    }
                                                    else
                                                    {
                                                        accounting.Debt = ((Math.Round(house, 2) + Math.Round(rent, 2) + Math.Round(service, 2) + Math.Round(electricityPay, 2))).ToString();
                                                    }
                                                }
                                                else
                                                {
                                                    accounting.Debt = ((rent + service + house) * (periodEnd - periodStart).Days).ToString();
                                                }
                                                

                                                try
                                                {
                                                    db.Accountings.Add(accounting);
                                                    db.SaveChanges();
                                                }
                                                catch (Exception ex)
                                                {
                                                    Log log = new Log();
                                                    log.Caption = "Class: DeclarationPaymentOrder. Method: CreatePayOrder. " + ex.Message + ". " + ex.InnerException;
                                                    log.CreatedAt = DateTime.Now.ToString();
                                                    log.Type = "ERROR";
                                                    log.ID = Guid.NewGuid();

                                                    db.Logs.Add(log);
                                                    db.SaveChanges();

                                                    MessageBox.Show(ex.Message);
                                                }
                                            }

                                            
                                        }
                                    }
                                }
                            }
                        }


                    }

                    MessageBox.Show("Платежные поручения сформированы!");
                }
                else if(_tenants.Count!=0)
                {
                    using(SupplyDbContext db = new SupplyDbContext())
                    {
                        foreach (int tenantID in _tenants)
                        {
                            Tenant tenant = db.Tenants.Where(x => x.ID == tenantID).Include(p => p.Payment).Include(o => o.Order).FirstOrDefault();

                            string error = string.Empty;
                            if (!OrdersCreation.CreatePaymentOrder(tenant.ID, TB_StartDate.Text, TB_EndDate.Text, TB_Action.Text, out error))
                            {
                                MessageBox.Show(error);
                            }
                            else
                            {
                                DateTime periodStart = Convert.ToDateTime(TB_StartDate.Text);
                                DateTime periodEnd = Convert.ToDateTime(TB_EndDate.Text);

                                int totalDate = Math.Abs((periodEnd.Month - periodStart.Month) + 12 * (periodEnd.Year - periodStart.Year));

                                Accounting accounting = db.Accountings
                                    .Where(t => t.TenantID == tenant.ID)
                                    .Where(ps => ps.PeriodStart == TB_StartDate.Text)
                                    .Where(pe => pe.PeriodEnd == TB_EndDate.Text)
                                    .FirstOrDefault();



                                if (accounting == null)
                                {



                                    accounting = new Accounting();
                                    accounting.CreatedAt = DateTime.Now.ToString();
                                    accounting.PeriodStart = TB_StartDate.Text;
                                    accounting.PeriodEnd = TB_EndDate.Text;
                                    accounting.TenantID = tenant.ID;
                                    accounting.Coast = "0";

                                    decimal rent, house, service;

                                    OrdersCreation.SpecialPayments(tenant.ID, out rent, out house, out service);

                                    decimal electricityPay = 0;
                                    if (tenant.TenantTypeID != 2 || tenant.TenantTypeID != 3)
                                    {
                                        OrdersCreation.SpecialPaymentsElectricity(tenant.ID, out electricityPay);
                                    }
                                    if (OrdersCreation.AdditionalInf(10, tenant.ID) != string.Empty)
                                    {
                                        electricityPay = 0;
                                    }

                                    if (OrdersCreation.AdditionalInf(5, tenant.ID) != "Заочная")
                                    {
                                        int days, month, daysInMonth;

                                        if (periodEnd.Month == periodStart.Month && periodEnd.Year == periodStart.Year)
                                        {
                                            days = periodEnd.Day;
                                            daysInMonth = DateTime.DaysInMonth(periodEnd.Year, periodEnd.Month);

                                            rent = (rent / daysInMonth) * days;
                                            house = (house / daysInMonth) * days;
                                            service = (service / daysInMonth) * days;
                                            electricityPay = (electricityPay / daysInMonth) * days;
                                        }
                                        else
                                        {
                                            OrdersCreation.SpecialDateCheck(periodStart, periodEnd, out days, out month, out daysInMonth);

                                            if (days != 0)
                                            {
                                                decimal tempHouse, tempService, tempRent, tempElPay;

                                                tempHouse = house * month;
                                                tempRent = rent * month;
                                                tempService = service * month;
                                                tempElPay = electricityPay * month;

                                                house = (house / daysInMonth) * days + tempHouse;
                                                rent = (rent / daysInMonth) * days + tempRent;
                                                service = (service / daysInMonth) * days + tempService;
                                                electricityPay = (electricityPay / daysInMonth) * days + tempElPay;
                                            }
                                            else
                                            {
                                                rent *= month;
                                                house *= month;
                                                service *= month;
                                                electricityPay *= month;
                                            }
                                        }

                                        decimal payment = 0;
                                        if (OrdersCreation.BenefitCheck(tenant.ID, house + service, periodStart, periodEnd, out payment))
                                        {
                                            accounting.Debt = ((Math.Round(payment, 2) + Math.Round(service, 2) + Math.Round(electricityPay, 2))).ToString();
                                        }
                                        else
                                        {
                                            accounting.Debt = ((Math.Round(house, 2) + Math.Round(rent, 2) + Math.Round(service, 2) + Math.Round(electricityPay, 2))).ToString();
                                        }
                                    }
                                    else
                                    {
                                        accounting.Debt = ((rent + service + house) * (periodEnd - periodStart).Days).ToString();
                                    }


                                    try
                                    {
                                        db.Accountings.Add(accounting);
                                        db.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        Log log = new Log();
                                        log.Caption = "Class: DeclarationPaymentOrder. Method: CreatePayOrder. " + ex.Message + ". " + ex.InnerException;
                                        log.CreatedAt = DateTime.Now.ToString();
                                        log.Type = "ERROR";
                                        log.ID = Guid.NewGuid();

                                        db.Logs.Add(log);
                                        db.SaveChanges();

                                        MessageBox.Show(ex.Message);
                                    }
                                }


                            }
                        }
                    }
                    MessageBox.Show("Платежные поручения сформированы!");
                }
                else
                {
                    MessageBox.Show("ID общежития равно 0");
                }

            }
            else
            {
                string error = string.Empty;
                if (!OrdersCreation.CreatePaymentOrder(_tenantID, TB_StartDate.Text, TB_EndDate.Text, TB_Action.Text, out error))
                {
                    MessageBox.Show(error);
                }
                else
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        Tenant tenant = db.Tenants.Where(id => id.ID == _tenantID).Include(p => p.Payment).FirstOrDefault();

                        DateTime periodStart = Convert.ToDateTime(TB_StartDate.Text);
                        DateTime periodEnd = Convert.ToDateTime(TB_EndDate.Text);

                        int totalDate = Math.Abs((periodEnd.Month - periodStart.Month) + 12 * (periodEnd.Year - periodStart.Year));

                        Accounting accounting = db.Accountings
                                                .Where(t => t.TenantID == tenant.ID)
                                                .Where(ps => ps.PeriodStart == TB_StartDate.Text)
                                                .Where(pe => pe.PeriodEnd == TB_EndDate.Text)
                                                .FirstOrDefault();

                        if (accounting == null)
                        {
                            accounting = new Accounting();
                            accounting.CreatedAt = DateTime.Now.ToString();
                            accounting.PeriodStart = TB_StartDate.Text;
                            accounting.PeriodEnd = TB_EndDate.Text;
                            accounting.TenantID = tenant.ID;
                            accounting.Coast = "0";

                            decimal rent, house, service;

                            OrdersCreation.SpecialPayments(tenant.ID, out rent, out house, out service);

                            decimal electricityPay = 0;
                            if (tenant.TenantTypeID != 2 || tenant.TenantTypeID != 3)
                            {
                                OrdersCreation.SpecialPaymentsElectricity(tenant.ID, out electricityPay);
                            }
                            if (OrdersCreation.AdditionalInf(10, tenant.ID) != string.Empty)
                            {
                                electricityPay = 0;
                            }
                            

                            if (OrdersCreation.AdditionalInf(5, tenant.ID) != "Заочная")
                            {
                                int days, month, daysInMonth;

                                if (periodEnd.Month == periodStart.Month && periodEnd.Year == periodStart.Year)
                                {
                                    days = periodEnd.Day;
                                    daysInMonth = DateTime.DaysInMonth(periodEnd.Year, periodEnd.Month);

                                    rent = (rent / daysInMonth) * days;
                                    house = (house / daysInMonth) * days;
                                    service = (service / daysInMonth) * days;
                                    electricityPay = (electricityPay / daysInMonth) * days;
                                }
                                else
                                {
                                    OrdersCreation.SpecialDateCheck(periodStart, periodEnd, out days, out month, out daysInMonth);

                                    if (days != 0)
                                    {
                                        decimal tempHouse, tempService, tempRent, tempElPay;

                                        tempHouse = house * month;
                                        tempRent = rent * month;
                                        tempService = service * month;
                                        tempElPay = electricityPay * month;

                                        house = (house / daysInMonth) * days + tempHouse;
                                        rent = (rent / daysInMonth) * days + tempRent;
                                        service = (service / daysInMonth) * days + tempService;
                                        electricityPay = (electricityPay / daysInMonth) * days + tempElPay;
                                    }
                                    else
                                    {
                                        rent *= month;
                                        house *= month;
                                        service *= month;
                                        electricityPay *= month;
                                    }
                                }
                                decimal payment = 0;
                                if (OrdersCreation.BenefitCheck(tenant.ID, house + service, periodStart, periodEnd, out payment))
                                {
                                    accounting.Debt = ((Math.Round(payment, 2) + Math.Round(service, 2) + Math.Round(electricityPay, 2))).ToString();
                                }
                                else
                                {
                                    accounting.Debt = ((Math.Round(house, 2) + Math.Round(rent, 2) + Math.Round(service, 2) + Math.Round(electricityPay, 2))).ToString();
                                }
                            }
                            else
                            {
                                accounting.Debt = ((rent + service + house) * (periodEnd - periodStart).Days).ToString();
                            }


                            try
                            {
                                db.Accountings.Add(accounting);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Log log = new Log();
                                log.Caption = "Class: DeclarationPaymentOrder. Method: CreatePayOrder. " + ex.Message + ". " + ex.InnerException;
                                log.CreatedAt = DateTime.Now.ToString();
                                log.Type = "ERROR";
                                log.ID = Guid.NewGuid();

                                db.Logs.Add(log);
                                db.SaveChanges();

                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
                
                

                MessageBox.Show("Платежное поручение создано!");
            }
        }
        
    }
}
