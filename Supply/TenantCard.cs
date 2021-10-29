using Supply.Domain;
using Supply.Libs;
using Supply.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
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
                Tenant tenant = db.Tenants.Where(x => x.ID == _tenantID).Include(i => i.Identification).Include(t=>t.TenantType).FirstOrDefault();

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


                    LB_TenantType.Text = tenant.TenantType.Name;


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

                    Thread thread = new Thread(new ParameterizedThreadStart(LoadBenefitsCard));
                    thread.Start(order.ID);

                    thread = new Thread(new ParameterizedThreadStart(LoadSpecialPayments));
                    thread.Start(tenant.ID);
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

        private void LoadBenefitsCard(object orderId)
        {
            Action action = () =>
              {
                  DG_View_Benefits.Rows.Clear();

                  int id = (int)orderId;
                  using(SupplyDbContext db = new SupplyDbContext())
                  {
                      var benefits = db.Benefits.Where(x => x.OrderID == id).ToList();

                      foreach(Benefit benefit in benefits)
                      {
                          int rowNumber = DG_View_Benefits.Rows.Add();

                          DG_View_Benefits.Rows[rowNumber].Cells[COL_ID.Name].Value = benefit.ID;
                          DG_View_Benefits.Rows[rowNumber].Cells[COL_Status.Name].Value = benefit.Status;
                          DG_View_Benefits.Rows[rowNumber].Cells[COL_Order.Name].Value = benefit.BasedOn + " №" + benefit.DecreeNumber + " от " + benefit.DecreeDate;
                          DG_View_Benefits.Rows[rowNumber].Cells[COL_StartAt.Name].Value = benefit.StartDate;
                          DG_View_Benefits.Rows[rowNumber].Cells[COL_EndAt.Name].Value = benefit.EndDate;
                      }
                  }
              };

            Invoke(action);
        }

        private void LoadSpecialPayments(object tenantID)
        {
            Action action = () =>
              {
                  DG_View_SpecialPayments.Rows.Clear();

                  int id = (int)tenantID;

                  using(SupplyDbContext db = new SupplyDbContext())
                  {
                      foreach (SpecialPayment specialPayment in db.SpecialPayments.Where(x => x.TenantID == id).Include(el => el.ElectricityPayment).ToList())
                      {
                          int rowNumber = DG_View_SpecialPayments.Rows.Add();

                          DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_IDSP.Name].Value = specialPayment.ID;
                          DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_Places.Name].Value = specialPayment.Places;
                          DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_StartDate.Name].Value = specialPayment.StartDate;
                          DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_EndDate.Name].Value = specialPayment.EndDate;
                          DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_El.Name].Value = specialPayment.ElectricityPayment.Name;
                          DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_ElPlaces.Name].Value = specialPayment.ElectricityPaymentPlaces;
                      }
                  }
              };

            Invoke(action);
        }
    }
}
