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
        public TenantBenefitAdd(int tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
            _licenseID = _benefitTypeID = _orderID = 0;
        }

        private void TenantBenefitAdd_Load(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                try
                {
                    Tenant tenant = db.Tenants.Where(id => id.ID == _tenantID).Include(ident => ident.Identification).Include(order => order.Order).First();
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
            }
            catch
            {
                return;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            Benefit benefit = new Benefit();
            benefit.BenefitTypeID = _benefitTypeID;
            benefit.CreatedAt = DateTime.Now.ToString();
            benefit.UpdatedAt = DateTime.Now.ToString();
            benefit.Status = true;
            benefit.OrderID = _orderID;
            benefit.ManagerID = _licenseID;
            benefit.Payment = double.Parse(TB_Payment.Text);
            benefit.EndDate = TB_EndDate.Text;
            benefit.StartDate = TB_StartDate.Text;
            benefit.DecreeNumber = TB_DecreeName.Text;
            benefit.DecreeDate = TB_DecreeDate.Text;
            benefit.BasedOn = TB_Decree.Text;

            using(SupplyDbContext db = new SupplyDbContext())
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
                catch(Exception ex)
                {
                    Log log = new Log();
                    log.ID = Guid.NewGuid();
                    log.Type = "ERROR";
                    log.Caption = "TenantBenefitAdd.cs. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException;
                    log.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(log);
                    db.SaveChanges();

                    MessageBox.Show(ex.Message + "." + ex.InnerException);
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
    }
}
