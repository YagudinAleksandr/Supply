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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class TenantElectricityAccount : Form
    {
        private int _tenantID;
        private decimal _accountingTotal;
        private int _electricityOrder;
        public TenantElectricityAccount(int tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
        }

        private void TenantElectricityAccount_Shown(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                ElecricityOrder elecricityOrder = db.ElecricityOrders.Where(x => x.TenantID == _tenantID).Where(s => s.Status == true).FirstOrDefault();

                if (elecricityOrder != null)
                {
                    _electricityOrder = elecricityOrder.ID;
                    Tenant tenant = db.Tenants.Where(x => x.ID == _tenantID).Include(ident => ident.Identification).Include(r=>r.Room).FirstOrDefault();

                    ChangePassport changePassport = db.ChangePassports.Where(x => x.TenantID == _tenantID).Where(s => s.Status == true).FirstOrDefault();

                    if (changePassport != null)
                    {
                        LB_TenantName.Text = changePassport.Surename + " " + changePassport.Name;
                    }
                    else
                    {
                        LB_TenantName.Text = tenant.Identification.Surename + " " + tenant.Identification.Name;
                    }

                    //Payment part
                    DateTime orderStartDate = Convert.ToDateTime(elecricityOrder.StartDate);
                    DateTime orderEndDate = Convert.ToDateTime(elecricityOrder.EndDate);

                    int totalDate = Math.Abs((orderEndDate.Month - orderStartDate.Month) + 12 * (orderEndDate.Year - orderStartDate.Year));

                    ElectricityPayment electricityPayment = db.ElectricityPayments.Where(x => x.ID == (int)tenant.Room.ElectricityPaymentID).FirstOrDefault();
                    var elElements = db.ElectricityElements.Where(x => x.ElectricityPaymentID == electricityPayment.ID).ToList();

                    foreach(ElectricityElement electricityElement in elElements)
                    {
                        _accountingTotal += electricityElement.Payment * totalDate;
                    }

                    var accounts = db.AccountingElectricities.Where(x => x.ElecricityOrderID == elecricityOrder.ID).ToList();

                    foreach(AccountingElectricity accountingElectricity in accounts)
                    {
                        _accountingTotal -= Convert.ToDecimal(accountingElectricity.Coast);
                    }

                    LB_TotalSum.Text = _accountingTotal.ToString();
                }
                else
                {
                    MessageBox.Show("На данного жильца не существует договора на электроэнергию!");
                    this.Close();
                }
            }
        }

        private void TB_Payment_TextChanged(object sender, EventArgs e)
        {
            if (TB_Payment.Text == "")
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
            if(TB_Payment.Text=="")
            {
                MessageBox.Show("Укажите сумму платежа!");
                return;
            }

            AccountingElectricity accountingElectricity = new AccountingElectricity();
            accountingElectricity.PeriodStart = TB_AccountingStartDate.Text;
            accountingElectricity.PeriodEnd = TB_AccountingEndDate.Text;
            accountingElectricity.ElecricityOrderID = _electricityOrder;
            accountingElectricity.CreatedAt = DateTime.Now.ToString();
            accountingElectricity.Coast = TB_Payment.Text;

            using (SupplyDbContext db = new SupplyDbContext())
            {
                try
                {
                    db.AccountingElectricities.Add(accountingElectricity);
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
                this.Close();
            }
        }
    }
}
