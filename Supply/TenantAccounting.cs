using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class TenantAccounting : Form
    {
        private int _tenantID;
        private decimal _accountingTotal;
        public TenantAccounting(int tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
        }

        private void TenantAccounting_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(LoadInformation);
            thread.Start();
        }

        private void LoadInformation()
        {
            Action action = () =>
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Tenant tenant = db.Tenants.Where(id => id.ID == _tenantID).Include(ident => ident.Identification).FirstOrDefault();
                    ChangePassport changePassport = db.ChangePassports.Where(tid => tid.TenantID == tenant.ID).Where(s => s.Status == true).FirstOrDefault();
                    Order order = db.Orders.Where(id => id.ID == tenant.ID).FirstOrDefault();
                    Payment payment = db.Payments.Where(id => id.ID == tenant.PaymentID).FirstOrDefault();
                    Benefit benefits = db.Benefits.Where(oid => oid.OrderID == order.ID).FirstOrDefault();
                    var accountings = db.Accountings.Where(tid => tid.TenantID == tenant.ID).ToList();

                    if (changePassport != null) 
                    {
                        LB_TenantName.Text = changePassport.Surename + " " + changePassport.Name;
                        if(changePassport.Patronymic!=null)
                        {
                            LB_TenantName.Text += " " + changePassport.Patronymic;
                        }
                    }
                    else
                    {
                        LB_TenantName.Text = tenant.Identification.Surename + " " + tenant.Identification.Name;
                        if (tenant.Identification.Patronymic != null)
                        {
                            LB_TenantName.Text += " " + tenant.Identification.Patronymic;
                        }
                    }

                    DateTime orderStartDate = Convert.ToDateTime(order.StartDate);
                    DateTime orderEndDate = Convert.ToDateTime(order.EndDate);

                    int totalDate = Math.Abs((orderEndDate.Month - orderStartDate.Month) + 12 * (orderEndDate.Year - orderStartDate.Year));


                    _accountingTotal = payment.Rent * totalDate;

                    foreach (var accounting in accountings)
                    {
                        _accountingTotal -= Convert.ToDecimal(accounting.Coast);
                    }

                    LB_TotalSum.Text = _accountingTotal.ToString();
                }
            };

            Invoke(action);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(TB_Payment.Text=="")
            {
                LB_TotalSum.Text = _accountingTotal.ToString();

            }
            else
            {
                LB_TotalSum.Text = (_accountingTotal - Convert.ToDecimal(TB_Payment.Text)).ToString();
            }
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            if(TB_Payment.Text!="")
            {
                decimal sum = 0;
                if (decimal.TryParse(TB_Payment.Text, out sum))
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        Accounting accounting = new Accounting();
                        accounting.Coast = sum.ToString();
                        accounting.CreatedAt = DateTime.Now.ToString();
                        accounting.TenantID = _tenantID;
                        accounting.PeriodStart = TB_AccountingStartDate.Text;
                        accounting.PeriodEnd = TB_AccountingEndDate.Text;


                        try
                        {
                            db.Accountings.Add(accounting);
                            db.SaveChanges();

                            MessageBox.Show("Платеж внесен успешно!");
                            this.Close();
                        }
                        catch(Exception ex)
                        {
                            Log log = new Log();
                            log.ID = Guid.NewGuid();
                            log.Type = "ERROR";
                            log.CreatedAt = DateTime.Now.ToString();
                            log.Caption = $"Class: TenantAccounting. Method: BTN_Add_Click." + ex.Message + "." + ex.InnerException;

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
