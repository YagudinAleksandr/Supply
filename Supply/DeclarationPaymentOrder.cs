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
            DateTime date;
            if(!DateTime.TryParse(TB_StartDate.Text,out date))
            {
                MessageBox.Show("Неверная дата начала платежного поручения!");
                return;
            }
            if (!DateTime.TryParse(TB_EndDate.Text, out date))
            {
                MessageBox.Show("Неверная дата окончания платежного поручения!");
                return;
            }
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
                                    foreach (Tenant tenant in db.Tenants.Where(x => x.RoomID == room.ID).Where(s => s.Status == true).Include(or => or.Order).Include(r => r.Room).Include(p => p.Payment).ToList()) 
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


                                                DateTime orderStartDate = Convert.ToDateTime(periodStart);
                                                DateTime orderEndDate = Convert.ToDateTime(periodEnd);


                                                DateTime startBenefit = DateTime.Now;
                                                DateTime endBenefit = DateTime.Now;

                                                decimal rent = 0;
                                                decimal house = 0;
                                                decimal service = 0;
                                                decimal electricity = 0;

                                                int days = 0;
                                                int monthes = 0;
                                                int daysInMonth = 0;

                                                if (tenant.TenantTypeID != 2 && tenant.TenantTypeID != 3)
                                                {

                                                    if (OrdersCreation.AdditionalInf(5, tenant.ID) != "Заочная")
                                                    {
                                                        if (OrdersCreation.BenefitCheck(tenant.ID, orderStartDate, orderEndDate, out rent, out house, out service, out electricity, out startBenefit, out endBenefit))
                                                        {
                                                            decimal tempRent = 0;
                                                            decimal tempHouse = 0;
                                                            decimal tempService = 0;
                                                            decimal tempElectricity = 0;

                                                            if (startBenefit <= orderStartDate && endBenefit < orderEndDate)
                                                            {
                                                                OrdersCreation.SpecialDateCheck(endBenefit, orderEndDate, out days, out monthes, out daysInMonth);

                                                                tempRent = Convert.ToDecimal(tenant.Payment.Rent);
                                                                tempHouse = Convert.ToDecimal(tenant.Payment.House);
                                                                tempService = Convert.ToDecimal(tenant.Payment.Service);

                                                                foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(pid => pid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                                                                {
                                                                    tempElectricity += electricityElement.Payment;
                                                                }

                                                                OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref tempRent, ref tempHouse, ref tempService, ref electricity);

                                                                rent += tempRent;
                                                                service += tempService;
                                                                house += tempHouse;
                                                                electricity += tempElectricity;
                                                            }

                                                            if (orderStartDate < startBenefit && endBenefit > orderEndDate)
                                                            {
                                                                OrdersCreation.SpecialDateCheck(orderStartDate, startBenefit, out days, out monthes, out daysInMonth);

                                                                tempRent = Convert.ToDecimal(tenant.Payment.Rent);
                                                                tempHouse = Convert.ToDecimal(tenant.Payment.House);
                                                                tempService = Convert.ToDecimal(tenant.Payment.Service);

                                                                foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(pid => pid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                                                                {
                                                                    tempElectricity += electricityElement.Payment;
                                                                }

                                                                OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref tempRent, ref tempHouse, ref tempService, ref electricity);

                                                                rent += tempRent;
                                                                service += tempService;
                                                                house += tempHouse;
                                                                electricity += tempElectricity;
                                                            }

                                                            if (startBenefit > orderStartDate && endBenefit < orderEndDate)
                                                            {
                                                                OrdersCreation.SpecialDateCheck(orderStartDate, startBenefit, out days, out monthes, out daysInMonth);

                                                                tempRent = Convert.ToDecimal(tenant.Payment.Rent);
                                                                tempHouse = Convert.ToDecimal(tenant.Payment.House);
                                                                tempService = Convert.ToDecimal(tenant.Payment.Service);

                                                                foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(pid => pid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                                                                {
                                                                    tempElectricity += electricityElement.Payment;
                                                                }

                                                                OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref tempRent, ref tempHouse, ref tempService, ref electricity);

                                                                rent += tempRent;
                                                                service += tempService;
                                                                house += tempHouse;
                                                                electricity += tempElectricity;

                                                                OrdersCreation.SpecialDateCheck(endBenefit, orderEndDate, out days, out monthes, out daysInMonth);

                                                                OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref tempRent, ref tempHouse, ref tempService, ref electricity);

                                                                rent += tempRent;
                                                                service += tempService;
                                                                house += tempHouse;
                                                                electricity += tempElectricity;
                                                            }

                                                        }
                                                        else
                                                        {
                                                            OrdersCreation.SpecialDateCheck(orderStartDate, orderEndDate, out days, out monthes, out daysInMonth);

                                                            OrdersCreation.SpecialPayments(tenant.ID, out rent, out house, out service);
                                                            OrdersCreation.SpecialPaymentsElectricity(tenant.ID, out electricity);

                                                            OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref rent, ref house, ref service, ref electricity);

                                                            
                                                        }

                                                        if (OrdersCreation.AdditionalInf(10, tenant.ID) != string.Empty)
                                                        {
                                                            electricity = 0;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        rent = Convert.ToDecimal(tenant.Payment.Rent);
                                                        service = Convert.ToDecimal(tenant.Payment.Service);
                                                        house = Convert.ToDecimal(tenant.Payment.House);

                                                        rent *= (orderEndDate - orderStartDate).Days+1;
                                                        service *= (orderEndDate - orderStartDate).Days+1;
                                                        house *= (orderEndDate - orderStartDate).Days+1;
                                                    }
                                                }
                                                else
                                                {

                                                    OrdersCreation.SpecialDateCheck(orderStartDate, orderEndDate, out days, out monthes, out daysInMonth);

                                                    OrdersCreation.SpecialPayments(tenant.ID, out rent, out house, out service);
                                                    OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref rent, ref house, ref service, ref electricity);

                                                   
                                                }


                                                accounting.Debt = (Math.Round(rent, 2) + Math.Round(house, 2) + Math.Round(electricity, 2) + Math.Round(service, 2)).ToString();

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
                            Tenant tenant = db.Tenants.Where(x => x.ID == tenantID).Include(or => or.Order).Include(r => r.Room).Include(p => p.Payment).FirstOrDefault();

                            string error = string.Empty;
                            if (!OrdersCreation.CreatePaymentOrder(tenant.ID, TB_StartDate.Text, TB_EndDate.Text, TB_Action.Text, out error))
                            {
                                MessageBox.Show(error);
                            }
                            else
                            {
                                DateTime periodStart = Convert.ToDateTime(TB_StartDate.Text);
                                DateTime periodEnd = Convert.ToDateTime(TB_EndDate.Text);


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


                                    DateTime orderStartDate = Convert.ToDateTime(periodStart);
                                    DateTime orderEndDate = Convert.ToDateTime(periodEnd);


                                    DateTime startBenefit = DateTime.Now;
                                    DateTime endBenefit = DateTime.Now;

                                    decimal rent = 0;
                                    decimal house = 0;
                                    decimal service = 0;
                                    decimal electricity = 0;

                                    int days = 0;
                                    int monthes = 0;
                                    int daysInMonth = 0;

                                    if (tenant.TenantTypeID != 2 && tenant.TenantTypeID != 3)
                                    {

                                        if (OrdersCreation.AdditionalInf(5, tenant.ID) != "Заочная")
                                        {
                                            if (OrdersCreation.BenefitCheck(tenant.ID, orderStartDate, orderEndDate, out rent, out house, out service, out electricity, out startBenefit, out endBenefit))
                                            {
                                                decimal tempRent = 0;
                                                decimal tempHouse = 0;
                                                decimal tempService = 0;
                                                decimal tempElectricity = 0;

                                                if (startBenefit <= orderStartDate && endBenefit < orderEndDate)
                                                {
                                                    OrdersCreation.SpecialDateCheck(endBenefit, orderEndDate, out days, out monthes, out daysInMonth);

                                                    tempRent = Convert.ToDecimal(tenant.Payment.Rent);
                                                    tempHouse = Convert.ToDecimal(tenant.Payment.House);
                                                    tempService = Convert.ToDecimal(tenant.Payment.Service);

                                                    foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(pid => pid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                                                    {
                                                        tempElectricity += electricityElement.Payment;
                                                    }

                                                    OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref tempRent, ref tempHouse, ref tempService, ref electricity);

                                                    rent += tempRent;
                                                    service += tempService;
                                                    house += tempHouse;
                                                    electricity += tempElectricity;
                                                }

                                                if (orderStartDate < startBenefit && endBenefit > orderEndDate)
                                                {
                                                    OrdersCreation.SpecialDateCheck(orderStartDate, startBenefit, out days, out monthes, out daysInMonth);

                                                    tempRent = Convert.ToDecimal(tenant.Payment.Rent);
                                                    tempHouse = Convert.ToDecimal(tenant.Payment.House);
                                                    tempService = Convert.ToDecimal(tenant.Payment.Service);

                                                    foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(pid => pid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                                                    {
                                                        tempElectricity += electricityElement.Payment;
                                                    }

                                                    OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref tempRent, ref tempHouse, ref tempService, ref electricity);

                                                    rent += tempRent;
                                                    service += tempService;
                                                    house += tempHouse;
                                                    electricity += tempElectricity;
                                                }

                                                if (startBenefit > orderStartDate && endBenefit < orderEndDate)
                                                {
                                                    OrdersCreation.SpecialDateCheck(orderStartDate, startBenefit, out days, out monthes, out daysInMonth);

                                                    tempRent = Convert.ToDecimal(tenant.Payment.Rent);
                                                    tempHouse = Convert.ToDecimal(tenant.Payment.House);
                                                    tempService = Convert.ToDecimal(tenant.Payment.Service);

                                                    foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(pid => pid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                                                    {
                                                        tempElectricity += electricityElement.Payment;
                                                    }

                                                    OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref tempRent, ref tempHouse, ref tempService, ref electricity);

                                                    rent += tempRent;
                                                    service += tempService;
                                                    house += tempHouse;
                                                    electricity += tempElectricity;

                                                    OrdersCreation.SpecialDateCheck(endBenefit, orderEndDate, out days, out monthes, out daysInMonth);

                                                    OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref tempRent, ref tempHouse, ref tempService, ref electricity);

                                                    rent += tempRent;
                                                    service += tempService;
                                                    house += tempHouse;
                                                    electricity += tempElectricity;
                                                }

                                            }
                                            else
                                            {
                                                OrdersCreation.SpecialDateCheck(orderStartDate, orderEndDate, out days, out monthes, out daysInMonth);

                                                OrdersCreation.SpecialPayments(tenant.ID, out rent, out house, out service);
                                                OrdersCreation.SpecialPaymentsElectricity(tenant.ID, out electricity);

                                                OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref rent, ref house, ref service, ref electricity);
                                            }

                                            if (OrdersCreation.AdditionalInf(10, tenant.ID) != string.Empty)
                                            {
                                                electricity = 0;
                                            }
                                        }
                                        else
                                        {
                                            rent = Convert.ToDecimal(tenant.Payment.Rent);
                                            service = Convert.ToDecimal(tenant.Payment.Service);
                                            house = Convert.ToDecimal(tenant.Payment.House);

                                            rent *= (orderEndDate - orderStartDate).Days+1;
                                            service *= (orderEndDate - orderStartDate).Days+1;
                                            house *= (orderEndDate - orderStartDate).Days+1;
                                        }
                                    }
                                    else
                                    {

                                        OrdersCreation.SpecialDateCheck(orderStartDate, orderEndDate, out days, out monthes, out daysInMonth);

                                        OrdersCreation.SpecialPayments(tenant.ID, out rent, out house, out service);

                                        OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref rent, ref house, ref service, ref electricity);
                                    }


                                    accounting.Debt = (Math.Round(rent, 2) + Math.Round(house, 2) + Math.Round(electricity, 2) + Math.Round(service, 2)).ToString();

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
                        Tenant tenant = db.Tenants.Where(id => id.ID == _tenantID).Include(or => or.Order).Include(r => r.Room).Include(p => p.Payment).FirstOrDefault();

                        DateTime periodStart = Convert.ToDateTime(TB_StartDate.Text);
                        DateTime periodEnd = Convert.ToDateTime(TB_EndDate.Text);


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

                            DateTime orderStartDate = Convert.ToDateTime(periodStart);
                            DateTime orderEndDate = Convert.ToDateTime(periodEnd);


                            DateTime startBenefit = DateTime.Now;
                            DateTime endBenefit = DateTime.Now;

                            decimal rent = 0;
                            decimal house = 0;
                            decimal service = 0;
                            decimal electricity = 0;

                            int days = 0;
                            int monthes = 0;
                            int daysInMonth = 0;

                            if (tenant.TenantTypeID != 2 && tenant.TenantTypeID != 3)
                            {

                                if (OrdersCreation.AdditionalInf(5, tenant.ID) != "Заочная")
                                {
                                    OrdersCreation.BenefitCheck(tenant.ID, orderStartDate, orderEndDate, ref rent, out house, out service, out electricity);


                                    if (OrdersCreation.AdditionalInf(10, tenant.ID) != string.Empty)
                                    {
                                        electricity = 0;
                                    }

                                    
                                }
                                else
                                {
                                    rent = Convert.ToDecimal(tenant.Payment.Rent);
                                    service = Convert.ToDecimal(tenant.Payment.Service);
                                    house = Convert.ToDecimal(tenant.Payment.House);

                                    rent *= (orderEndDate - orderStartDate).Days + 1;
                                    service *= (orderEndDate - orderStartDate).Days + 1;
                                    house *= (orderEndDate - orderStartDate).Days + 1;
                                }
                                if (OrdersCreation.AdditionalInf(10, tenant.ID) != string.Empty)
                                {
                                    electricity = 0;
                                }
                            }
                            else
                            {

                                OrdersCreation.SpecialDateCheck(orderStartDate, orderEndDate, out days, out monthes, out daysInMonth);

                                Termination termination = db.Terminations.Where(t => t.OrderID == tenant.ID).FirstOrDefault();
                                if(termination==null)
                                {
                                    if (days != 0)
                                        days += 1;
                                }
                                

                                OrdersCreation.SpecialPayments(tenant.ID, out rent, out house, out service);


                                OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref rent, ref house, ref service, ref electricity);
                            }


                            accounting.Debt = (Math.Round(rent, 2) + Math.Round(house, 2) + Math.Round(electricity, 2) + Math.Round(service, 2)).ToString();


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
