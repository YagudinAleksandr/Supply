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
    public partial class TenantBenefitAdd : Form
    {
        private int _tenantID;
        private int _licenseID;
        private int _benefitTypeID;
        private int _orderID;
        private int _hostelId;
        private Benefit _benefit;
        public TenantBenefitAdd(int tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
            _licenseID = _benefitTypeID = _orderID = _hostelId = 0;
            _benefit = null;
        }

        public TenantBenefitAdd(Benefit benefit)
        {
            InitializeComponent();
            _benefit = benefit;
        }

        private void TenantBenefitAdd_Load(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                if (_benefit == null) 
                {
                    try
                    {
                        Tenant tenant = db.Tenants
                            .Where(id => id.ID == _tenantID)
                            .Include(ident => ident.Identification)
                            .Include(r => r.Room)
                            .Include(order => order.Order)
                            .FirstOrDefault();

                        if (tenant == null)
                        {
                            MessageBox.Show("Жилец не найден!");
                            this.Close();
                        }

                        Flat flat = db.Flats
                            .Where(x => x.ID == tenant.Room.FlatID)
                            .Include(ent => ent.Enterance)
                            .FirstOrDefault();

                        Hostel hostel = db.Hostels
                            .Where(x => x.ID == flat.Enterance.HostelId)
                            .FirstOrDefault();

                        _hostelId = hostel.ID;

                        LB_TenantInf.Text = tenant.Identification.Surename + " " + tenant.Identification.Name;
                        if (tenant.Identification.Patronymic != null)
                        {
                            LB_TenantInf.Text += " " + tenant.Identification.Patronymic;
                        }

                        if (tenant.Order.OrderNumber != null)
                        {
                            LB_OrderNumb.Text = tenant.Order.OrderNumber;
                            _orderID = tenant.Order.ID;
                        }

                    }
                    catch (Exception ex)
                    {
                        Log log = new Log();
                        log.ID = Guid.NewGuid();
                        log.Type = "ERROR";
                        log.Caption = "TenantBenefitAdd.cs. Method: TenantBenefitAdd_load." + ex.Message + "." + ex.InnerException;
                        log.CreatedAt = DateTime.Now.ToString();
                        db.Logs.Add(log);
                        db.SaveChanges();
                    }
                }
                

                try
                {
                    var licenses = db.Licenses.ToList();

                    for (int i = 0; i < licenses.Count; i++)
                    {
                        licenses[i].Name = licenses[i].Manager.Surename + " " + licenses[i].Manager.Name + " " + licenses[i].Manager.Patronymic + " " + licenses[i].Name + $"({licenses[i].StartDate})";
                    }

                    CB_ManagersLicenses.DataSource = licenses;
                    CB_ManagersLicenses.DisplayMember = "Name";
                    CB_ManagersLicenses.ValueMember = "ID";

                    
                    CB_BenefitsTypes.DataSource = db.BenefitTypes.ToList();
                    CB_BenefitsTypes.DisplayMember = "Name";
                    CB_BenefitsTypes.ValueMember = "ID";
                }
                catch(Exception ex)
                {
                    Log log = new Log();
                    log.ID = Guid.NewGuid();
                    log.Type = "ERROR";
                    log.Caption = "TenantBenefitAdd.cs. Method: TenantBenefitAdd_load." + ex.Message + "." + ex.InnerException;
                    log.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(log);
                    db.SaveChanges();
                }

                if (_benefit != null) 
                {
                    CB_BenefitsTypes.SelectedValue = _benefitTypeID = _benefit.BenefitTypeID;
                    CB_ManagersLicenses.SelectedValue = _licenseID = _benefit.LicenseID;
                    _orderID = _benefit.OrderID;

                    Order order = db.Orders.Where(id => id.ID == _benefit.OrderID).FirstOrDefault();
                    Tenant tenant = db.Tenants.Where(id => id.ID == order.ID).Include(ident => ident.Identification).FirstOrDefault();

                    LB_OrderNumb.Text = order.OrderNumber;

                    ChangePassport changePassport = db.ChangePassports.Where(tid => tid.TenantID == tenant.ID).Where(s => s.Status == true).FirstOrDefault();

                    if (changePassport == null)
                    {
                        LB_TenantInf.Text = tenant.Identification.Surename + " " + tenant.Identification.Name;
                        if (tenant.Identification.Patronymic != null)
                        {
                            LB_TenantInf.Text += " " + tenant.Identification.Patronymic;
                        }
                    }
                    else
                    {
                        LB_TenantInf.Text = changePassport.Surename + " " + changePassport.Name;
                        if (changePassport.Patronymic != null)
                        {
                            LB_TenantInf.Text += " " + changePassport.Patronymic;
                        }
                    }

                    TB_Decree.Text = _benefit.BasedOn;
                    TB_DecreeName.Text = _benefit.DecreeNumber;
                    TB_DecreeDate.Text = _benefit.DecreeDate;
                    TB_EndDate.Text = _benefit.EndDate;
                    TB_StartDate.Text = _benefit.StartDate;
                    TB_Payment.Text = _benefit.Payment.ToString();
                    TB_House.Text = _benefit.House.ToString();
                    TB_Service.Text = _benefit.Service.ToString();
                    TB_Electricity.Text = _benefit.Electricity.ToString();
                }
                
            }
        }

        private void CB_ManagersLicenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _licenseID = (int)CB_ManagersLicenses.SelectedValue;
            }
            catch
            {
                return;
            }
        }

        private void CB_BenefitsTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _benefitTypeID = (int)CB_BenefitsTypes.SelectedValue;

                Thread thread = new Thread(LoadPaymentBenefit);
                thread.Start();
            }
            catch
            {
                return;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (_benefit == null) 
            {
                Benefit benefit = new Benefit();
                benefit.BenefitTypeID = _benefitTypeID;
                benefit.CreatedAt = DateTime.Now.ToString();
                benefit.UpdatedAt = DateTime.Now.ToString();
                benefit.Status = true;
                benefit.OrderID = _orderID;
                benefit.LicenseID = _licenseID;
                benefit.Payment = double.Parse(TB_Payment.Text);
                benefit.House = double.Parse(TB_House.Text);
                benefit.Electricity = double.Parse(TB_Electricity.Text);
                benefit.Service = double.Parse(TB_Service.Text);
                benefit.EndDate = TB_EndDate.Text;
                benefit.StartDate = TB_StartDate.Text;
                benefit.DecreeNumber = TB_DecreeName.Text;
                benefit.DecreeDate = TB_DecreeDate.Text;
                benefit.BasedOn = TB_Decree.Text;

                using (SupplyDbContext db = new SupplyDbContext())
                {
                    try
                    {
                        db.Benefits.Add(benefit);
                        db.SaveChanges();
                        MessageBox.Show("Льгота добавлена успешно!");

                        Button saveButton = (Button)sender;
                        if ((string)saveButton.Tag == "SaveAndCreate")
                        {
                            Thread thread = new Thread(CreateBenefitOrder);
                            thread.Start();
                            this.Close();
                        }
                        else
                        {
                            this.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        Log log = new Log();
                        log.ID = Guid.NewGuid();
                        log.Type = "ERROR";
                        log.Caption = "TenantBenefitAdd.cs. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException;
                        log.CreatedAt = DateTime.Now.ToString();
                        db.Logs.Add(log);
                        db.SaveChanges();

                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                
                _benefit.BenefitTypeID = _benefitTypeID;
                _benefit.UpdatedAt = DateTime.Now.ToString();
                _benefit.OrderID = _orderID;
                _benefit.LicenseID = _licenseID;
                _benefit.Payment = double.Parse(TB_Payment.Text);
                _benefit.House = double.Parse(TB_House.Text);
                _benefit.Electricity = double.Parse(TB_Electricity.Text);
                _benefit.Service = double.Parse(TB_Service.Text);
                _benefit.EndDate = TB_EndDate.Text;
                _benefit.StartDate = TB_StartDate.Text;
                _benefit.DecreeNumber = TB_DecreeName.Text;
                _benefit.DecreeDate = TB_DecreeDate.Text;
                _benefit.BasedOn = TB_Decree.Text;

                using (SupplyDbContext db = new SupplyDbContext())
                {
                    try
                    {
                        db.Entry(_benefit).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Льгота изменена успешно!");

                        Button saveButton = (Button)sender;
                        if ((string)saveButton.Tag == "SaveAndCreate")
                        {
                            Thread thread = new Thread(CreateBenefitOrder);
                            thread.Start();
                            this.Close();
                        }
                        else
                        {
                            this.Close();
                        }
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        Log log = new Log();
                        log.ID = Guid.NewGuid();
                        log.Type = "ERROR";
                        log.Caption = "TenantBenefitAdd.cs. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException;
                        log.CreatedAt = DateTime.Now.ToString();
                        db.Logs.Add(log);
                        db.SaveChanges();

                        MessageBox.Show(ex.Message);
                    }
                }
                
            }
        }

        private void CreateBenefitOrder()
        {
            Order order;
            using (SupplyDbContext db = new SupplyDbContext())
            {
                order = db.Orders.Where(x => x.ID == _orderID).FirstOrDefault();
            }

            if (order != null)
            {
                string error = string.Empty;
                if (OrdersCreation.BenefitCreation(_orderID, out error))
                {
                    MessageBox.Show($"Приложение о льготе создано к договору №{order.OrderNumber}");
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            else
            {
                MessageBox.Show("Договор не существует!");
            }
        }

        private void LoadPaymentBenefit()
        {
            Action action = () =>
              {
                  if (_hostelId != 0 && _benefitTypeID != 0)
                  {
                      using(SupplyDbContext db = new SupplyDbContext())
                      {
                          BenefitPayment benefitPayment = db.BenefitPayments
                          .Where(x => x.BenefitTypeID == _benefitTypeID)
                          .Where(y => y.HostelID == _hostelId)
                          .FirstOrDefault();

                          if(benefitPayment!=null)
                          {
                              TB_Payment.Text = benefitPayment.Price.ToString();
                          }
                      }
                  }
              };
            Invoke(action);
            
        }
    }
}
