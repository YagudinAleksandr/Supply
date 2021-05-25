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
            try
            {
                using(ExcelHelper excelHelper = new ExcelHelper())
                {

                }
            }
            catch(Exception ex)
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    Log logInfo = new Log();
                    logInfo.ID = Guid.NewGuid();
                    logInfo.Type = "ERROR";
                    logInfo.Caption = $"AdminOrders.cs. Class: AdminOrders. Method: BTN_CreateExcel_Click." + ex.Message + "." + ex.InnerException;
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(logInfo);
                    db.SaveChanges();
                }
            }
        }
    }
}
