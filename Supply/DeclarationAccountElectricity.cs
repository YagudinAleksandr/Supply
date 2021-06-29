using Libraries.ExcelSystem;
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
    public partial class DeclarationAccountElectricity : Form
    {
        private int _hostelID;
        public DeclarationAccountElectricity()
        {
            InitializeComponent();
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

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(CreateAccountExcel);
            thread.Start();
        }

        private void DeclarationAccountElectricity_Shown(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                CB_Hostels.DataSource = db.Hostels.ToList();
                CB_Hostels.DisplayMember = "Name";
                CB_Hostels.ValueMember = "ID";
            }
                
        }

        private void CreateAccountExcel()
        {
            string error = string.Empty;
            try
            {
                using (ExcelHelper excelHelper = new ExcelHelper())
                {
                    if (excelHelper.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: "Отчеты по общежитиям (эл.энергия).xlsx", out error))
                    {
                        using (SupplyDbContext db = new SupplyDbContext())
                        {

                            try
                            {
                                excelHelper.Set(columnName: "A", rowNumber: 1, value: "№ общежитие", error: out error);
                                excelHelper.Set(columnName: "B", rowNumber: 1, value: "Комната №", error: out error);
                                excelHelper.Set(columnName: "C", rowNumber: 1, value: "ФИО", error: out error);
                                excelHelper.Set(columnName: "D", rowNumber: 1, value: "Период договора", error: out error);
                                excelHelper.Set(columnName: "E", rowNumber: 1, value: "Период последнего платежа", error: out error);
                                excelHelper.Set(columnName: "F", rowNumber: 1, value: "Поступило всего средств", error: out error);
                                excelHelper.Set(columnName: "G", rowNumber: 1, value: "Общая задолжность", error: out error);


                                int counter = 2;

                                Hostel hostel = db.Hostels.Where(x=>x.ID==_hostelID).FirstOrDefault();
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
                                                .Include(ident => ident.Identification)
                                                .ToList();

                                            foreach (Tenant tenant in tenants)
                                            {
                                                var additionalInformations = db.AdditionalInformation.Where(x => x.TenantID == tenant.ID).ToList();
                                                bool flag = false;
                                                foreach(AdditionalInformation additionalInformation in additionalInformations)
                                                {
                                                    if (additionalInformation.AdditionalInformationTypeID == 5)
                                                    {
                                                        if (additionalInformation.Value == "Заочная" || additionalInformation.Value == "заочная")
                                                        {
                                                            flag = true;
                                                        }
                                                    }
                                                }
                                                if (flag == false)
                                                {
                                                    ElecricityOrder elecricityOrder = db.ElecricityOrders.Where(t => t.TenantID == tenant.ID).Where(s => s.Status == true).FirstOrDefault();

                                                    var accountingsElectricity = db.AccountingElectricities.Where(or => or.ElecricityOrderID == elecricityOrder.ID).ToList();

                                                    decimal payments = 0;
                                                    excelHelper.Set(columnName: "A", rowNumber: counter, value: $"{hostel.Name}", error: out error);
                                                    excelHelper.Set(columnName: "B", rowNumber: counter, value: room.Name, error: out error);
                                                    excelHelper.Set(columnName: "C", rowNumber: counter, value: tenant.Identification.Surename + " " + tenant.Identification.Name, error: out error);
                                                    excelHelper.Set(columnName: "D", rowNumber: counter, value: elecricityOrder.StartDate + "-" + elecricityOrder.EndDate, error: out error);
                                                    foreach (AccountingElectricity accounting in accountingsElectricity)
                                                    {
                                                        excelHelper.Set(columnName: "E", rowNumber: counter, value: accounting.PeriodStart + "-" + accounting.PeriodEnd, error: out error);
                                                        payments += Convert.ToDecimal(accounting.Coast);
                                                    }

                                                    excelHelper.Set(columnName: "F", rowNumber: counter, value: payments.ToString(), error: out error);

                                                    ElectricityPayment electricityPayment = db.ElectricityPayments.Where(r => r.ID == (int)room.ElectricityPaymentID).FirstOrDefault();

                                                    var electricityElements = db.ElectricityElements.Where(x => x.ElectricityPaymentID == electricityPayment.ID).ToList();

                                                    decimal accountingTotal = 0;

                                                    foreach (ElectricityElement electricityElement in electricityElements)
                                                    {
                                                        accountingTotal += electricityElement.Payment;
                                                    }


                                                    DateTime orderStartDate = Convert.ToDateTime(elecricityOrder.StartDate);
                                                    DateTime orderEndDate = Convert.ToDateTime(elecricityOrder.EndDate);

                                                    int totalDate = Math.Abs((orderEndDate.Month - orderStartDate.Month) + 12 * (orderEndDate.Year - orderStartDate.Year));

                                                    accountingTotal = accountingTotal * totalDate;



                                                    excelHelper.Set(columnName: "G", rowNumber: counter, value: (accountingTotal - payments).ToString(), error: out error);
                                                }
                                                


                                                counter++;
                                                flag = false;
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
