using Supply.Domain;
using Supply.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class TenantCard : Form
    {
        private int _tenantID;
        public TenantCard(int tenanID)
        {
            InitializeComponent();
            _tenantID = tenanID;
        }

        private void TenantCard_Load(object sender, EventArgs e)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                Tenant tenant = db.Tenants.Where(x => x.ID == _tenantID).Include(i => i.Identification).FirstOrDefault();

                if (tenant != null) 
                {
                    this.Text = tenant.Identification.Surename + " " + tenant.Identification.Name;
                    LB_TenantIdentName.Text = tenant.Identification.Surename + " " + tenant.Identification.Name;
                    if (tenant.Identification.Patronymic != null)
                    {
                        LB_TenantIdentName.Text += " " + tenant.Identification.Patronymic;
                    }

                    LB_DateOfBirth.Text = tenant.Identification.DateOfBirth;
                    LB_Citizenship.Text = tenant.Identification.Cityzenship;
                    LB_GivenDate.Text = tenant.Identification.GivenDate;
                    LB_Number.Text = tenant.Identification.DocumentNumber;
                    LB_Series.Text = tenant.Identification.DocumentSeries;
                    LB_Issued.Text = tenant.Identification.Issued;
                    LB_Address.Text = tenant.Identification.Address;
                    if (tenant.Identification.Code != null)
                    {
                        LB_Code.Text = tenant.Identification.Code;
                    }
                    else
                    {
                        LB_Code.Text = "";
                    }
                }
                else
                {
                    Log logInfo = new Log();
                    logInfo.ID = Guid.NewGuid();
                    logInfo.Type = "ERROR";
                    logInfo.Caption = $"Class: TenantCard. Method:TenantCard_Load. Any information in database about tenant";
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(logInfo);
                    db.SaveChanges();
                    
                    MessageBox.Show("Жильца не найдено");
                    this.Close();
                }
            }
        }
    }
}
