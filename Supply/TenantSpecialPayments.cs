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
                    .Include(or => or.Order)
                    .Include(ident => ident.Identification)
                    .Include(r => r.Room)
                    .FirstOrDefault();

                if (tenant == null) 
                {
                    MessageBox.Show("Жильца не найдено!");
                    this.Close();
                }
                else
                {
                    ChangePassport changePassport = db.ChangePassports
                    .Where(tid => tid.TenantID == tenant.ID)
                    .Where(s => s.Status == true)
                    .FirstOrDefault();

                    if (changePassport != null)
                    {
                        LB_Tenant.Text = changePassport.Surename + " " + changePassport.Name[0] + ".";
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

                    LB_Order.Text = tenant.Order.OrderNumber;

                    TB_StartDate.Text = tenant.Order.StartDate;
                    TB_EndDate.Text = tenant.Order.EndDate;
                    TB_CountBeds.Text = tenant.Room.Places.ToString();
                }

                

            }
        }
    }
}
