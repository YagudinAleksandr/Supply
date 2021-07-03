using Supply.Domain;
using Supply.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class TenantTerminationForm : Form
    {
        private int _tenantID;
        private int _orderID;
        public TenantTerminationForm(int tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
        }

        private void TenantTerminationForm_Shown(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Tenant tenant = db.Tenants.Where(x => x.ID == _tenantID).Include(ident => ident.Identification).FirstOrDefault();

                if (tenant != null) 
                {
                    Order order = db.Orders.Where(x => x.ID == _tenantID).FirstOrDefault();
                    if (order == null)
                    {
                        MessageBox.Show("Для данного жильца не существует договора!");
                        this.Close();
                    }
                    _orderID = order.ID;

                    ChangePassport changePassport = db.ChangePassports.Where(x => x.TenantID == _tenantID).Where(s => s.Status == true).FirstOrDefault();

                    if (changePassport != null)
                    {
                        LB_Tenant.Text = changePassport.Surename + " " + changePassport.Name;
                        if (changePassport.Patronymic != null)
                        {
                            LB_Tenant.Text += " " + changePassport.Patronymic;
                        }
                    }
                    else
                    {
                        LB_Tenant.Text = tenant.Identification.Surename + " " + tenant.Identification.Name;
                        if (tenant.Identification.Patronymic != null)
                        {
                            LB_Tenant.Text += " " + tenant.Identification.Patronymic;
                        }
                    }

                    LB_OrderNumber.Text = order.OrderNumber;
                }
            }
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Termination termination = db.Terminations.Where(x => x.OrderID == _orderID).FirstOrDefault();
                if (termination != null)
                {
                    MessageBox.Show("Для данного договора уже есть запись расторжения договора!");
                    return;
                }

                Order order = db.Orders.Where(x => x.ID == _orderID).FirstOrDefault();

                DateTime date = DateTime.Now;
                DateTime orderEndDate = DateTime.Now;
                try
                {
                    date = Convert.ToDateTime(TB_Date.Text);
                    orderEndDate = Convert.ToDateTime(order.EndDate);
                }
                catch(Exception ex)
                {
                    Log logInfo = new Log();
                    logInfo.ID = Guid.NewGuid();
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    logInfo.Type = "WARNING";
                    logInfo.Caption = $"Class:TenantTerminationForm.cs. Method: BTN_Create_Click. {ex.Message}. {ex.InnerException}";
                    db.Logs.Add(logInfo);
                    db.SaveChanges();

                    MessageBox.Show(ex.Message);
                    return;
                }

                if (date > orderEndDate) 
                {
                    MessageBox.Show("Дата расторжения договора не может быть позже даты окончания договора!");
                    return;
                }

                termination = new Termination();
                termination.CreatedAt = DateTime.Now.ToString();
                termination.UpdatedAt = DateTime.Now.ToString();
                termination.Status = false;
                termination.OrderID = _orderID;
                termination.Date = TB_Date.Text;

                if (date.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    Tenant tenant = db.Tenants.Where(x => x.ID == order.ID).FirstOrDefault();
                    tenant.Status = false;
                    tenant.UpdatedAt = DateTime.Now.ToString();
                    termination.Status = true;

                    db.Entry(tenant).State = EntityState.Modified;
                    db.SaveChanges();
                }

                

                try
                {
                    db.Terminations.Add(termination);
                    db.SaveChanges();
                    MessageBox.Show("Расторжение добавлно успешно!");
                    this.Close();
                }
                catch(Exception ex)
                {
                    //Создаем LOG запись об удалении!
                    Log logInfo = new Log();
                    logInfo.ID = Guid.NewGuid();
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    logInfo.Type = "ERROR";
                    logInfo.Caption = $"Class:TenantTerminationForm. Method: BTN_Create_Click. {ex.Message}. {ex.InnerException}";
                    db.Logs.Add(logInfo);
                    db.SaveChanges();

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
