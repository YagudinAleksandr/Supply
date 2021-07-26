using Supply.Domain;
using Supply.Libs;
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
                    ChangePassport changePassport = db.ChangePassports.Where(x => x.TenantID == tenant.ID).Where(s => s.Status == true).FirstOrDefault();

                    if (changePassport != null)
                    {
                        this.Text = changePassport.Surename + " " + changePassport.Name;
                        LB_TenantIdentName.Text = changePassport.Surename + " " + changePassport.Name;
                        if (changePassport.Patronymic != null)
                        {
                            LB_TenantIdentName.Text += " " + changePassport.Patronymic;
                        }

                        LB_DateOfBirth.Text = changePassport.DateOfBirth;
                        LB_Citizenship.Text = changePassport.Citizenship;
                        LB_GivenDate.Text = changePassport.GivenDate;
                        LB_Number.Text = changePassport.Number;
                        LB_Series.Text = changePassport.Series;
                        LB_Issued.Text = changePassport.Issued;
                        LB_Address.Text = changePassport.Address;
                        if (changePassport.Code != null)
                        {
                            LB_Code.Text = changePassport.Code;
                        }
                        else
                        {
                            LB_Code.Text = "";
                        }

                        DocumentType documentType = db.DocumentTypes.Where(x => x.ID == changePassport.DocumentTypeID).FirstOrDefault();

                        LB_DocType.Text = documentType.Name;
                    }
                    else
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

                        DocumentType documentType = db.DocumentTypes.Where(x => x.ID == tenant.Identification.DocumentTypeID).FirstOrDefault();

                        LB_DocType.Text = documentType.Name;
                    }
                    

                    


                    Order order = db.Orders.Where(x => x.ID == _tenantID).FirstOrDefault();
                    if (order != null)
                    {
                        LB_OrderNumber.Text = order.OrderNumber;
                        LB_OrderStartDate.Text = order.StartDate;
                        LB_OrderEndDate.Text = order.EndDate;
                    }
                    else
                    {
                        Log logInfo = new Log();
                        logInfo.ID = Guid.NewGuid();
                        logInfo.Type = "ERROR";
                        logInfo.Caption = $"Class: TenantCard. Method:TenantCard_Load. Any information in database about order";
                        logInfo.CreatedAt = DateTime.Now.ToString();
                        db.Logs.Add(logInfo);
                        db.SaveChanges();

                        MessageBox.Show("Договора не найдено!");
                        this.Close();
                    }

                    LB_Phone.Text = OrdersCreation.AdditionalInf(1, _tenantID);
                    LB_Faculty.Text = OrdersCreation.AdditionalInf(3, _tenantID);
                    LB_EduType.Text = OrdersCreation.AdditionalInf(5, _tenantID);
                    LB_Group.Text = OrdersCreation.AdditionalInf(4, _tenantID);
                    LB_Degree.Text = OrdersCreation.AdditionalInf(6, _tenantID);
                    LB_EndDate.Text = "";
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
