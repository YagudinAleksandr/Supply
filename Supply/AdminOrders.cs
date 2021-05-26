using Libraries.ExcelSystem;
using Supply.Domain;
using Supply.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminOrders : Form
    {
        public AdminOrders()
        {
            InitializeComponent();
        }

        private void AdminOrders_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(UpdateInfo);
            thread.Start();
        }

        private void UpdateInfo()
        {
            Action action = () =>
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    DG_View_Orders.Rows.Clear();

                    try
                    {
                        foreach (Order order in db.Orders.Include(r => r.Room).Include(t => t.Tenant).ToList())
                        {
                            int rowNumber = DG_View_Orders.Rows.Add();

                            var tenantIdetification = db.Identifications.Where(x => x.ID == order.Tenant.ID).FirstOrDefault();
                            var benefit = db.Benefits.Where(x => x.OrderID == order.ID).Where(j => j.Status == true).ToList();
                            Flat flat = db.Flats.Where(x => x.ID == order.Room.FlatID).Include(x => x.Enterance).FirstOrDefault();
                            Hostel hostel = db.Hostels.Where(x => x.ID == flat.Enterance.HostelId).FirstOrDefault();
                            TenantType tenantType = db.TenantTypes.Where(x => x.ID == order.Tenant.TenantTypeID).FirstOrDefault();
                            Payment payment = db.Payments.Where(x => x.ID == order.Tenant.PaymentID).FirstOrDefault();

                            DG_View_Orders.Rows[rowNumber].Cells[COL_OrderNumber.Name].Value = order.OrderNumber;
                            DG_View_Orders.Rows[rowNumber].Cells[COL_StartOrder.Name].Value = order.StartDate;
                            DG_View_Orders.Rows[rowNumber].Cells[COL_CreatedAt.Name].Value = order.CreatedAt;
                            DG_View_Orders.Rows[rowNumber].Cells[COL_OrderEnd.Name].Value = order.EndDate;
                            DG_View_Orders.Rows[rowNumber].Cells[COL_Room.Name].Value = order.Room.Name;
                            DG_View_Orders.Rows[rowNumber].Cells[COL_Payment.Name].Value = payment.Name;
                            DG_View_Orders.Rows[rowNumber].Cells[COL_Hostel.Name].Value = hostel.Name;
                            DG_View_Orders.Rows[rowNumber].Cells[COL_TenantType.Name].Value = tenantType.Name;
                            DG_View_Orders.Rows[rowNumber].Cells[COL_Tenant.Name].Value = tenantIdetification.Surename + " " + tenantIdetification.Name;
                            if (benefit.Count > 0)
                            {
                                DG_View_Orders.Rows[rowNumber].Cells[COL_Benefit.Name].Value = "Есть";
                            }
                            else
                            {
                                DG_View_Orders.Rows[rowNumber].Cells[COL_Benefit.Name].Value = "Нет";
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            };

            Invoke(action);
        }

        private void BTN_CreateExcel_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            try
            {
                using(ExcelHelper excelHelper = new ExcelHelper())
                {
                    if (excelHelper.Open(filePath: AppSettings.GetTemplateSetting("outfileDir"), name: "Договора отчет.xlsx", out error)) 
                    {
                        using (SupplyDbContext db = new SupplyDbContext())
                        {
                            

                            try
                            {
                                excelHelper.Set(columnName: "A", rowNumber: 1, value: "№ договора", error: out error);
                                excelHelper.Set(columnName: "B", rowNumber: 1, value: "Жилец", error: out error);
                                excelHelper.Set(columnName: "C", rowNumber: 1, value: "Комната", error: out error);
                                excelHelper.Set(columnName: "D", rowNumber: 1, value: "Общежитие", error: out error);
                                excelHelper.Set(columnName: "E", rowNumber: 1, value: "Льгота", error: out error);
                                excelHelper.Set(columnName: "F", rowNumber: 1, value: "Тип жильца", error: out error);
                                excelHelper.Set(columnName: "G", rowNumber: 1, value: "Тарифный план", error: out error);
                                excelHelper.Set(columnName: "H", rowNumber: 1, value: "Дата начала договора", error: out error);
                                excelHelper.Set(columnName: "I", rowNumber: 1, value: "Дата окончания договора", error: out error);
                                excelHelper.Set(columnName: "J", rowNumber: 1, value: "Дата создания договра", error: out error);

                                int rowNumber = 1;
                                foreach (Order order in db.Orders.Include(r => r.Room).Include(t => t.Tenant).ToList())
                                {
                                    rowNumber++;

                                    var tenantIdetification = db.Identifications.Where(x => x.ID == order.Tenant.ID).FirstOrDefault();
                                    var benefit = db.Benefits.Where(x => x.OrderID == order.ID).Where(j => j.Status == true).ToList();
                                    Flat flat = db.Flats.Where(x => x.ID == order.Room.FlatID).Include(x => x.Enterance).FirstOrDefault();
                                    Hostel hostel = db.Hostels.Where(x => x.ID == flat.Enterance.HostelId).FirstOrDefault();
                                    TenantType tenantType = db.TenantTypes.Where(x => x.ID == order.Tenant.TenantTypeID).FirstOrDefault();
                                    Payment payment = db.Payments.Where(x => x.ID == order.Tenant.PaymentID).FirstOrDefault();


                                    excelHelper.Set(columnName: "A", rowNumber: rowNumber, value: order.OrderNumber, error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: rowNumber, value: tenantIdetification.Surename + " " + tenantIdetification.Name, error: out error);
                                    excelHelper.Set(columnName: "C", rowNumber: rowNumber, value: order.Room.Name, error: out error);
                                    excelHelper.Set(columnName: "D", rowNumber: rowNumber, value: hostel.Name, error: out error);
                                    if (benefit.Count > 0)
                                    {
                                        excelHelper.Set(columnName: "E", rowNumber: rowNumber, value: "Есть", error: out error);
                                       
                                    }
                                    else
                                    {
                                        excelHelper.Set(columnName: "E", rowNumber: rowNumber, value: "Нет", error: out error);
                                    }
                                    
                                    excelHelper.Set(columnName: "F", rowNumber: rowNumber, value: tenantType.Name, error: out error);
                                    excelHelper.Set(columnName: "G", rowNumber: rowNumber, value: payment.Name, error: out error);
                                    excelHelper.Set(columnName: "H", rowNumber: rowNumber, value: order.StartDate, error: out error);
                                    excelHelper.Set(columnName: "I", rowNumber: rowNumber, value: order.EndDate, error: out error);
                                    excelHelper.Set(columnName: "J", rowNumber: rowNumber, value: order.CreatedAt, error: out error);

                                   
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


                if(error==string.Empty)
                {
                    MessageBox.Show("Файл создан успешно!");
                }
                else
                {
                    MessageBox.Show(error);
                }

            }
            catch(Exception ex)
            {
                AddLog(ex.Message+"."+ex.InnerException, "AdminOrders.cs.Class: AdminOrders.Method: BTN_CreateExcel_Click.");
                MessageBox.Show(ex.Message + "." + ex.InnerException);
            }
        }
        private void AddLog(string errorMessage,string caption)
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
