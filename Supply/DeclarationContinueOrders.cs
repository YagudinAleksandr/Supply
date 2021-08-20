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
    public partial class DeclarationContinueOrders : Form
    {
        public DeclarationContinueOrders()
        {
            InitializeComponent();
        }

        private void DG_View_ContinueOrders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int continueOrderId = 0;

            if (e.ColumnIndex == 5)
            {

            }

            if (e.ColumnIndex == 6)
            {
                if (int.TryParse(DG_View_ContinueOrders.Rows[e.RowIndex].Cells[0].Value.ToString(), out continueOrderId))
                {
                    ContinueOrder continueOrder;

                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        continueOrder = db.ContinueOrders.Where(x => x.ID == continueOrderId).Include(or => or.Order).Include(l=>l.License).FirstOrDefault();
                    }
                    

                    TenantContinueOrder tenantContinueOrder = new TenantContinueOrder(continueOrder);
                    tenantContinueOrder.ShowDialog();

                    Thread thread = new Thread(LoadInformation);
                    thread.Start();
                }
            }

            if (e.ColumnIndex == 7)
            {
                if (int.TryParse(DG_View_ContinueOrders.Rows[e.RowIndex].Cells[0].Value.ToString(), out continueOrderId)) 
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите удалить приложение к договору на продление?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        using(SupplyDbContext db = new SupplyDbContext())
                        {
                            ContinueOrder continueOrder = db.ContinueOrders.Where(x => x.ID == continueOrderId).FirstOrDefault();

                            if (continueOrder == null) 
                            {
                                MessageBox.Show("Приложение не найдено!");
                                return;
                            }

                            try
                            {
                                db.ContinueOrders.Remove(continueOrder);
                                db.SaveChanges();

                                MessageBox.Show("Приложение удалено успешно!");

                                DG_View_ContinueOrders.Rows.Remove(DG_View_ContinueOrders.Rows[e.RowIndex]);
                            }
                            catch(Exception ex)
                            {
                                Thread logThread = new Thread(new ParameterizedThreadStart(LogCreation));

                                logThread.Start($"DG_View_ContinueOrders_CellMouseClick. {ex.Message}. {ex.InnerException}");
                            }
                        }
                    }
                }
            }
        }

        private void DeclarationContinueOrders_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn1.HeaderText = "Создать документ";
            dataGridViewButtonColumn1.Name = "COL_CreateOrder";
            dataGridViewButtonColumn1.Text = "Создать";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            DG_View_ContinueOrders.Columns.Add(dataGridViewButtonColumn1);

            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Изменить";
            dataGridViewButtonColumn2.Name = "COL_Edit";
            dataGridViewButtonColumn2.Text = "Изменить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_View_ContinueOrders.Columns.Add(dataGridViewButtonColumn2);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_View_ContinueOrders.Columns.Add(dataGridViewButtonColumn3);

            Thread thread = new Thread(LoadInformation);
            thread.Start();
        }

        private void LoadInformation()
        {
            Action action = () =>
            {
                try
                {
                    DG_View_ContinueOrders.Rows.Clear();

                    using(SupplyDbContext db = new SupplyDbContext())
                    {
                        var continueOrders = db.ContinueOrders.Include(o => o.Order).ToList();

                        foreach(ContinueOrder continueOrder in continueOrders)
                        {
                            int rowNumber = DG_View_ContinueOrders.Rows.Add();

                            DG_View_ContinueOrders.Rows[rowNumber].Cells[COL_ID.Name].Value = continueOrder.ID;
                            DG_View_ContinueOrders.Rows[rowNumber].Cells[COL_OrderEndDate.Name].Value = continueOrder.Order.EndDate;
                            DG_View_ContinueOrders.Rows[rowNumber].Cells[COL_OrderNumber.Name].Value = continueOrder.Order.OrderNumber;
                            DG_View_ContinueOrders.Rows[rowNumber].Cells[COL_ContinueDate.Name].Value = continueOrder.EndDate;

                            Tenant tenant = db.Tenants.Where(x => x.ID == continueOrder.Order.ID).Include(i => i.Identification).FirstOrDefault();

                            if (tenant == null)
                            {
                                throw new Exception("Жилец не найден!");
                            }

                            ChangePassport changePassport = db.ChangePassports.Where(x => x.TenantID == tenant.ID).Where(s => s.Status == true).FirstOrDefault();

                            if (changePassport != null)
                            {
                                DG_View_ContinueOrders.Rows[rowNumber].Cells[COL_Tenant.Name].Value = changePassport.Surename + " " + changePassport.Name;
                                if (changePassport.Patronymic != null)
                                {
                                    DG_View_ContinueOrders.Rows[rowNumber].Cells[COL_Tenant.Name].Value += " " + changePassport.Patronymic;
                                }
                            }
                            else
                            {
                                DG_View_ContinueOrders.Rows[rowNumber].Cells[COL_Tenant.Name].Value = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                if (tenant.Identification.Patronymic != null)
                                {
                                    DG_View_ContinueOrders.Rows[rowNumber].Cells[COL_Tenant.Name].Value += " " + tenant.Identification.Patronymic;
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    Thread logThread = new Thread(new ParameterizedThreadStart(LogCreation));

                    logThread.Start($"LoadInformation. {ex.Message}. {ex.InnerException}");
                }
            };

            Invoke(action);
        }

        private void LogCreation(object information)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                Log logInfo = new Log();
                logInfo.ID = Guid.NewGuid();
                logInfo.Type = "ERROR";
                logInfo.Caption = $"Class: DeclarationContinueOrders. Method: " + (string)information;
                logInfo.CreatedAt = DateTime.Now.ToString();
                db.Logs.Add(logInfo);
                db.SaveChanges();
            }
        }
    }
}
