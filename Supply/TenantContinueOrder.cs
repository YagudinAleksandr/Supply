using Supply.Domain;
using Supply.Libs;
using Supply.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class TenantContinueOrder : Form
    {
        private int _tenantId;
        private Order _order;
        private int _licenseID;
        private ContinueOrder _continueOrder;
        public TenantContinueOrder(int tenantId)
        {
            InitializeComponent();
            _tenantId = tenantId;
            _licenseID = 0;
            _continueOrder = null;
        }

        public TenantContinueOrder(ContinueOrder continueOrder)
        {
            InitializeComponent();
            _continueOrder = continueOrder;

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
                try
                {
                    Tenant tenant;

                    if (_continueOrder == null)
                    {
                        tenant = db.Tenants
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
                    }
                    else
                    {
                        _order = db.Orders.Where(x => x.ID == _continueOrder.OrderID).FirstOrDefault();

                        if(_order==null)
                        {
                            MessageBox.Show("Договор не найден!");
                            this.Close();
                        }

                        tenant = db.Tenants
                            .Where(x => x.ID == _order.ID)
                            .Include(ident => ident.Identification)
                            .FirstOrDefault();

                        if (tenant == null)
                        {
                            MessageBox.Show("Жилец не найден!");
                            this.Close();
                        }
                    }

                    

                    LB_OrderEndDate.Text = _order.EndDate;
                    LB_OrderNumber.Text = _order.OrderNumber;
                    LB_Tenant.Text = tenant.Identification.Surename + " " + tenant.Identification.Name[0] + ".";
                    if (tenant.Identification.Patronymic != null)
                    {
                        LB_Tenant.Text += tenant.Identification.Patronymic[0] + ".";
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


                    if (_continueOrder != null)
                    {
                        CB_Licenses.SelectedValue = _continueOrder.License.ID;
                        TB_OrderContinueDate.Text = _continueOrder.EndDate;
                    }
                }
                catch(Exception ex)
                {
                    Thread logThread = new Thread(new ParameterizedThreadStart(LogCreation));
                    logThread.Start($"TenantContinueOrder_Load. {ex.Message}. {ex.InnerException}");
                }
                
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

            if (_continueOrder == null)
            {
                _continueOrder = new ContinueOrder();
                _continueOrder.CreatedAt = _continueOrder.UpdatedAt = DateTime.Now.ToString();
                _continueOrder.OrderID = _order.ID;
                _continueOrder.EndDate = continuerOrderDate.ToShortDateString();
                _continueOrder.StartDate = _order.EndDate;
                _continueOrder.LicenseID = _licenseID;

                using(SupplyDbContext db = new SupplyDbContext())
                {
                    try
                    {
                        db.ContinueOrders.Add(_continueOrder);
                        db.SaveChanges();

                        MessageBox.Show("Приложение к договору на продление проживания добавлено успешно!");

                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        Thread logThread = new Thread(new ParameterizedThreadStart(LogCreation));
                        logThread.Start($"BTN_Save_Click. {ex.Message}. {ex.InnerException}");

                        MessageBox.Show(ex.Message);
                        this.Close();
                    }
                }
            }
            else
            {
                _continueOrder.UpdatedAt = DateTime.Now.ToString();
                _continueOrder.EndDate = continuerOrderDate.ToShortDateString();
                _continueOrder.LicenseID = _licenseID;

                using(SupplyDbContext db = new SupplyDbContext())
                {
                    try
                    {
                        db.Entry(_continueOrder).State = EntityState.Modified;
                        db.SaveChanges();
#if DEBUG
                        string errorMessage = string.Empty;

                        if(!OrdersCreation.CreateContinueOrder(_continueOrder.ID, out errorMessage))
                        {
                            MessageBox.Show(errorMessage);
                        }
#endif
                        MessageBox.Show("Данные изменены успешно!");

                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        Thread logThread = new Thread(new ParameterizedThreadStart(LogCreation));
                        logThread.Start($"BTN_Save_Click. {ex.Message}. {ex.InnerException}");

                        MessageBox.Show(ex.Message);
                        this.Close();
                    }
                }    
            }
            
        }

        private void LogCreation(object information)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Log logInfo = new Log();
                logInfo.ID = Guid.NewGuid();
                logInfo.Type = "ERROR";
                logInfo.Caption = $"Class: TenantContinueOrder. Method: " + (string)information;
                logInfo.CreatedAt = DateTime.Now.ToString();
                db.Logs.Add(logInfo);
                db.SaveChanges();
            }
        }
    }
}
