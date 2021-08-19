using Supply.Domain;
using Supply.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class TenantContinueOrder : Form
    {
        private int _tenantId;
        private Order _order;
        private int _licenseID;
        private int _continueOrderID;
        public TenantContinueOrder(int tenantId)
        {
            InitializeComponent();
            _tenantId = tenantId;
            _licenseID = 0;
        }

        public TenantContinueOrder(int tenantID, int continueOrderId)
        {
            InitializeComponent();
            _tenantId = tenantID;
            _continueOrderID = continueOrderId;
            _licenseID = 0;
        }

        private void CB_Licenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _licenseID = (int)CB_Licenses.SelectedValue;
            }
            catch
            {
                return;
            }
        }

        private void TenantContinueOrder_Load(object sender, EventArgs e)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                Tenant tenant = db.Tenants
                    .Where(x => x.ID == _tenantId)
                    .Include(ident => ident.Identification)
                    .Include(ordr => ordr.Order)
                    .FirstOrDefault();

                if (tenant == null)
                {
                    MessageBox.Show("Жилец не найден!");
                    this.Close();
                }

                ContinueOrder continueOrder = db.ContinueOrders.Where(x => x.OrderID == tenant.Order.ID).FirstOrDefault();

                if (continueOrder != null)
                {
                    MessageBox.Show("Для данного жильца уже есть продление договора!");
                    this.Close();
                }

                _order = tenant.Order;

                LB_OrderEndDate.Text = _order.EndDate;
                LB_OrderNumber.Text = _order.OrderNumber;
                LB_Tenant.Text = tenant.Identification.Surename + " " + tenant.Identification.Name[0] + ".";
                if (tenant.Identification.Patronymic != null)
                {
                    LB_Tenant.Text += tenant.Identification.Patronymic[0]+".";
                }

                var licenses = db.Licenses
                    .Where(s => s.Status == true)
                    .Include(m => m.Manager)
                    .ToList();

                for (int i = 0; i < licenses.Count; i++)
                {
                    licenses[i].Name = licenses[i].Manager.Surename + " " + licenses[i].Manager.Name + " " + licenses[i].Manager.Patronymic + " (" + licenses[i].Name + ")";
                }

                CB_Licenses.DataSource = licenses;
                CB_Licenses.DisplayMember = "Name";
                CB_Licenses.ValueMember = "ID";
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (_licenseID == 0) 
            {
                MessageBox.Show("Выбирите ответственное лицо!");
                return;
            }

            DateTime continuerOrderDate;

            if (!DateTime.TryParse(TB_OrderContinueDate.Text, out continuerOrderDate))
            {
                MessageBox.Show("Дата продления несоответствует значению даты!");
                return;
            }

            ContinueOrder continueOrder;

            if (_continueOrderID == 0)
            {
                continueOrder = new ContinueOrder();
                continueOrder.CreatedAt = DateTime.Now.ToString();
                continueOrder.UpdatedAt = DateTime.Now.ToString();
                continueOrder.LicenseID = _licenseID;
                continueOrder.OrderID = _order.ID;
                continueOrder.StartDate = _order.EndDate;
                continueOrder.EndDate = continuerOrderDate.ToShortDateString();
                

                using(SupplyDbContext db = new SupplyDbContext())
                {
                    try
                    {
                        db.ContinueOrders.Add(continueOrder);
                        db.SaveChanges();
                        MessageBox.Show("Продлеение добавлено успешно!");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        Log logInfo = new Log();
                        logInfo.ID = Guid.NewGuid();
                        logInfo.Type = "ERROR";
                        logInfo.Caption = $"Class: TenantContinueOrder. Method: BTN_Save_Click. {ex.Message}. {ex.InnerException}";
                        logInfo.CreatedAt = DateTime.Now.ToString();
                        db.Logs.Add(logInfo);
                        db.SaveChanges();
                    }
                }
            }
            else
            {

            }
        }
    }
}
