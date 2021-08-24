using Supply.Domain;
using Supply.Libs;
using Supply.Models;
using System;
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
                if (_hostelID != 0)
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
                                    foreach (Tenant tenant in db.Tenants.Where(x => x.RoomID == room.ID).Include(p => p.Payment).ToList()) 
                                    {
                                        string error = string.Empty;
                                        if (!OrdersCreation.CreatePaymentOrder(tenant.ID, TB_StartDate.Text, TB_EndDate.Text, TB_Action.Text, out error))
                                        {
                                            MessageBox.Show(error);
                                        }
                                        else
                                        {
                                            Accounting accounting = new Accounting();
                                            accounting.CreatedAt = DateTime.Now.ToString();
                                            accounting.PeriodStart = TB_StartDate.Text;
                                            accounting.PeriodEnd = TB_EndDate.Text;
                                            accounting.TenantID = tenant.ID;
                                            accounting.Coast = (tenant.Payment.House + tenant.Payment.Service + tenant.Payment.Rent).ToString();

                                            try
                                            {
                                                db.Accountings.Add(accounting);
                                                db.SaveChanges();
                                            }
                                            catch(Exception ex)
                                            {
                                                Log log = new Log();
                                                log.Caption = "Class: DeclarationPaymentOrder. Method: CreatePayOrder. "+ex.Message+". "+ex.InnerException;
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

                        Accounting accounting = new Accounting();
                        accounting.CreatedAt = DateTime.Now.ToString();
                        accounting.PeriodStart = TB_StartDate.Text;
                        accounting.PeriodEnd = TB_EndDate.Text;
                        accounting.TenantID = tenant.ID;
                        accounting.Coast = (tenant.Payment.House + tenant.Payment.Service + tenant.Payment.Rent).ToString();

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
                
                

                MessageBox.Show("Платежное поручение создано!");
            }
        }

    }
}
