using Supply.Domain;
using Supply.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class TenantSpecialPayments : Form
    {
        private int _tenantID;
        public TenantSpecialPayments(int tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
        }

        private void TenantSpecialPayments_Shown(object sender, EventArgs e)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                Tenant tenant = db.Tenants
                    .Where(id => id.ID == _tenantID)
                    .Include(ident=>ident.Identification)
                    .Include(r => r.Room)
                    .Include(or => or.Order)
                    .FirstOrDefault();

                if (tenant == null)
                {
                    MessageBox.Show("Жилец не найден!");
                    this.Close();
                }
                else
                {
                    ChangePassport changePassport = db.ChangePassports
                        .Where(x => x.TenantID == tenant.ID)
                        .Where(s=>s.Status==true)
                        .FirstOrDefault();

                    LB_Order.Text = tenant.Order.OrderNumber;

                    if (changePassport != null)
                    {
                        LB_Tenant.Text = changePassport.Surename + " " + changePassport.Name[0]+".";
                        if (changePassport.Patronymic != null)
                        {
                            LB_Tenant.Text += " " + changePassport.Patronymic[0] + ".";
                        }
                    }
                    else
                    {
                        LB_Tenant.Text = tenant.Identification.Surename + " " + tenant.Identification.Name[0] + ".";
                        if (tenant.Identification.Patronymic != null)
                        {
                            LB_Tenant.Text += " " + tenant.Identification.Patronymic[0] + ".";
                        }
                    }
                }

            }
        }
    }
}
