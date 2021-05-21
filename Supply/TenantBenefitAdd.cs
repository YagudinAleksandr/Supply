using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
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
                
            }
        }

        private void CB_ManagersLicenses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CB_BenefitsTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {

        }
    }
}
