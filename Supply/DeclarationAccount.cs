using Libraries.ExcelSystem;
using Supply.Domain;
using Supply.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class DeclarationAccount : Form
    {
        private int _hostelID, 
                    _tenantTypeID;
        public DeclarationAccount()
        {
            InitializeComponent();
            _hostelID = 0;
            _tenantTypeID = 0;
        }

        private void DeclarationAccount_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(LoadInformation);
            thread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_hostelID != 0)
            {
                Thread thread = new Thread(CreateAccountExcel);
                thread.Start();
                MessageBox.Show("Запущен фоновый процесс создания отчета!");

            }
        }

        private void CB_Hostels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _hostelID = (int)CB_Hostels.SelectedValue;
            }
            catch
            {
                return;
            }
        }

        private void CB_TenantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _tenantTypeID = (int)CB_TenantType.SelectedValue;
            }
            catch
            {
                return;
            }
        }

        private void LoadInformation()
        {
            Action action = () =>
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    CB_Hostels.DataSource = db.Hostels.ToList();
                    CB_Hostels.DisplayMember = "Name";
                    CB_Hostels.ValueMember = "ID";

                    CB_TenantType.DataSource = db.TenantTypes.ToList();
                    CB_TenantType.DisplayMember = "Name";
                    CB_TenantType.ValueMember = "ID";
                }
                
            };

            Invoke(action);
        }

        private void CreateAccountExcel()
        {
            string error = string.Empty;
            try
            {
                using (ExcelHelper excelHelper = new ExcelHelper())
                {
                    if (excelHelper.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: "Отчеты по общежитиям.xlsx", out error))
                    {
                        using (SupplyDbContext db = new SupplyDbContext())
                        {

                            try
                            {
                                excelHelper.Set(columnName: "A", rowNumber: 1, value: "№ общежитие", error: out error);
                                excelHelper.Set(columnName: "B", rowNumber: 1, value: "Комната №", error: out error);
                                excelHelper.Set(columnName: "C", rowNumber: 1, value: "ФИО", error: out error);
                                excelHelper.Set(columnName: "D", rowNumber: 1, value: "Период проживания", error: out error);
                                excelHelper.Set(columnName: "E", rowNumber: 1, value: "Период последнего платежа", error: out error);
                                excelHelper.Set(columnName: "F", rowNumber: 1, value: "Поступило всего средств", error: out error);
                                excelHelper.Set(columnName: "G", rowNumber: 1, value: "Общая задолжность", error: out error);
                                

                                int counter = 2;

                                var hostels = db.Hostels.ToList();
                                foreach (var hostel in hostels)
                                {
                                    var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();
                                    foreach (var enterance in enterances)
                                    {
                                        var flats = db.Flats.Where(x => x.Enterance_ID == enterance.ID).ToList();
                                        foreach (var flat in flats)
                                        {
                                            var rooms = db.Rooms.Where(x => x.FlatID == flat.ID).ToList();
                                            foreach (var room in rooms)
                                            {
                                                var tenants = db.Tenants
                                                    .Where(x => x.RoomID == room.ID)
                                                    .Where(st => st.Status == true)
                                                    .Where(t=>t.TenantTypeID==_tenantTypeID)
                                                    .Include(ident=>ident.Identification)
                                                    .Include(or=>or.Order)
                                                    .ToList();

                                                foreach (Tenant tenant in tenants)
                                                {
                                                    var accountings = db.Accountings.Where(tid => tid.TenantID == tenant.ID).ToList();

                                                    decimal payments = 0;
                                                    excelHelper.Set(columnName: "A", rowNumber: counter, value: $"{hostel.Name}", error: out error);
                                                    excelHelper.Set(columnName: "B", rowNumber: counter, value: room.Name, error: out error);
                                                    excelHelper.Set(columnName: "C", rowNumber: counter, value: tenant.Identification.Surename + " " + tenant.Identification.Name, error: out error);
                                                    excelHelper.Set(columnName: "D", rowNumber: counter, value: tenant.Order.StartDate + "-" + tenant.Order.EndDate, error: out error);
                                                    foreach(Accounting accounting in accountings)
                                                    {
                                                        excelHelper.Set(columnName: "E", rowNumber: counter, value: accounting.PeriodStart + "-" + accounting.PeriodEnd, error: out error);
                                                        payments += Convert.ToDecimal(accounting.Coast);
                                                    }
                                                    
                                                    excelHelper.Set(columnName: "F", rowNumber: counter, value: payments.ToString(), error: out error);

                                                    Payment payment = db.Payments.Where(id => id.ID == tenant.PaymentID).FirstOrDefault();
                                                    Benefit benefit = db.Benefits.Where(oid => oid.OrderID == tenant.Order.ID).FirstOrDefault();
                                                    decimal accountingTotal;
                                                    DateTime orderStartDate = Convert.ToDateTime(tenant.Order.StartDate);
                                                    DateTime orderEndDate = Convert.ToDateTime(tenant.Order.EndDate);

                                                    int totalDate = Math.Abs((orderEndDate.Month - orderStartDate.Month) + 12 * (orderEndDate.Year - orderStartDate.Year));

                                                    accountingTotal = payment.Rent * totalDate;

                                                    DateTime benefitStart;//Benefit start date
                                                    DateTime benefitEnd;//benefit end date

                                                    if (benefit != null)
                                                    {
                                                        benefitStart = Convert.ToDateTime(benefit.StartDate);
                                                        benefitEnd = Convert.ToDateTime(benefit.EndDate);

                                                        int totalPeriodStart = Math.Abs((benefitStart.Month - orderStartDate.Month) + 12 * (benefitStart.Year - orderStartDate.Year));
                                                        accountingTotal = totalPeriodStart * payment.Rent;

                                                        int totalPeriodEnd = Math.Abs((orderEndDate.Month - benefitEnd.Month) + 12 * (orderEndDate.Year - benefitEnd.Year));
                                                        accountingTotal += totalPeriodEnd * payment.Rent;

                                                        int totalBenefitDate = Math.Abs((benefitEnd.Month - benefitStart.Month) + 12 * (benefitEnd.Year - benefitStart.Year));
                                                        accountingTotal += Convert.ToDecimal(benefit.Payment) * totalBenefitDate;

                                                    }

                                                    excelHelper.Set(columnName: "G", rowNumber: counter, value: (accountingTotal-payments).ToString(), error: out error);



                                                    counter++;
                                                }

                                                
                                            }
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }


                        excelHelper.Save();
                    }
                    else
                    {
                        AddLog(error, "AdminOrders.cs.Class: AdminOrders.Method: BTN_CreateExcel_Click.ExcelHelper.Open.");
                    }
                }


                if (error == string.Empty)
                {
                    MessageBox.Show("Файл создан успешно!");
                }
                else
                {
                    MessageBox.Show(error);
                }

            }
            catch (Exception ex)
            {
                AddLog(ex.Message + "." + ex.InnerException, "AdminOrders.cs.Class: AdminOrders.Method: BTN_CreateExcel_Click.");
                MessageBox.Show(ex.Message + "." + ex.InnerException);
            }
        }

        

        private void AddLog(string errorMessage, string caption)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Log logInfo = new Log();
                logInfo.ID = Guid.NewGuid();
                logInfo.Type = "ERROR";
                logInfo.Caption = $"{caption}" + errorMessage;
                logInfo.CreatedAt = DateTime.Now.ToString();
                db.Logs.Add(logInfo);
                db.SaveChanges();
            }
        }
    }
}
