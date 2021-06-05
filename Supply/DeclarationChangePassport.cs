using Supply.Domain;
using Supply.Libs;
using Supply.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class DeclarationChangePassport : Form
    {
        public DeclarationChangePassport()
        {
            InitializeComponent();
        }

        private void DeclarationChangePassport_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn1.HeaderText = "Создать документ";
            dataGridViewButtonColumn1.Name = "COL_CreateOrder";
            dataGridViewButtonColumn1.Text = "Создать";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            DG_View_ChangePassport.Columns.Add(dataGridViewButtonColumn1);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_View_ChangePassport.Columns.Add(dataGridViewButtonColumn3);

            Thread thread = new Thread(UpdateInfo);
            thread.Start();
        }

        private void DG_View_ChangePassport_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int id = int.Parse(DG_View_ChangePassport.Rows[e.RowIndex].Cells[0].Value.ToString());
                Thread thread = new Thread(new ParameterizedThreadStart(CreateChangePassportOrder));
                thread.Start(id);
            }

            if (e.ColumnIndex == 6)
            {
                DialogResult result = MessageBox.Show($"Удалить {DG_View_ChangePassport.Rows[e.RowIndex].Cells[0].Value.ToString()}", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        int id = int.Parse(DG_View_ChangePassport.Rows[e.RowIndex].Cells[0].Value.ToString());
                        ChangePassport changePassport = db.ChangePassports.Where(x => x.ID == id).FirstOrDefault();
                        if (changePassport != null)
                        {
                            try
                            {
                                db.ChangePassports.Remove(changePassport);
                                db.SaveChanges();
                                MessageBox.Show("Приложение на смену паспорта удалено успешно");
                                Thread thread = new Thread(UpdateInfo);
                                thread.Start();
                            }
                            catch (Exception ex)
                            {
                                Log logInfo = new Log();
                                logInfo.ID = Guid.NewGuid();
                                logInfo.Type = "ERROR";
                                logInfo.Caption = $"Class: DeclarationChangePassport. Method: DG_View_ChangePassport_CellMouseClick. {ex.Message}.{ex.InnerException}";
                                logInfo.CreatedAt = DateTime.Now.ToString();
                                db.Logs.Add(logInfo);
                                db.SaveChanges();

                                MessageBox.Show(ex.Message);
                            }

                        }
                    }

                }
            }
        }

        private void BTN_CreateOrdersChangePassport_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(CreateChangesPassportsOrders);
            thread.Start();
            MessageBox.Show("Запущен фоновый процесс создания приложений!");
        }

        private void UpdateInfo()
        {
            Action action = () =>
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    DG_View_ChangePassport.Rows.Clear();
                    try
                    {
                        var changePassports = db.ChangePassports.ToList();

                        foreach (var changePassport in changePassports)
                        {
                            int rowNumber = DG_View_ChangePassport.Rows.Add();

                            DG_View_ChangePassport.Rows[rowNumber].Cells[COL_ID.Name].Value = changePassport.ID;
                            DG_View_ChangePassport.Rows[rowNumber].Cells[COL_StartDate.Name].Value = changePassport.StartDate;

                            Tenant tenant = db.Tenants.Where(x => x.ID == changePassport.TenantID).Include(or => or.Order).FirstOrDefault();
                            DG_View_ChangePassport.Rows[rowNumber].Cells[COL_Order.Name].Value = tenant.Order.OrderNumber;

                            if (changePassport.Status == true)
                            {
                                DG_View_ChangePassport.Rows[rowNumber].Cells[COL_Status.Name].Value = "Действителен";
                            }
                            else
                            {
                                DG_View_ChangePassport.Rows[rowNumber].Cells[COL_Status.Name].Value = "Не действителен";
                            }

                            
                            string tenantName = changePassport.Surename + " " + changePassport.Name;
                            if (changePassport.Patronymic != null)
                            {
                                tenantName += " " + changePassport.Patronymic;
                            }
                            DG_View_ChangePassport.Rows[rowNumber].Cells[COL_Tenant.Name].Value = tenantName;
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
        private void CreateChangePassportOrder(object id)
        {
            if (id != null)
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    ChangePassport changePassport = db.ChangePassports.Where(x => x.ID == (int)id).Where(s => s.Status == true).FirstOrDefault();
                    if (changePassport != null)
                    {
                        string error = string.Empty;

                        Order order = db.Orders.Where(x => x.ID == changePassport.TenantID).FirstOrDefault();

                        if (OrdersCreation.ChangePassportCreate(changePassport.ID, out error))
                        {
                            MessageBox.Show($"Приложение к договору № {order.OrderNumber} на переселение сформирован");
                        }
                        else
                        {
                            Log logInfo = new Log();
                            logInfo.ID = Guid.NewGuid();
                            logInfo.Type = "WARNING";
                            logInfo.Caption = $"DeclarationChangePassport.cs Method: CreateChangePassportOrder. {error}";
                            logInfo.CreatedAt = DateTime.Now.ToString();
                            db.Logs.Add(logInfo);
                            db.SaveChanges();

                            MessageBox.Show(error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("У данного приложения к договору статус активности - Не активна");
                    }

                }
            }
            else
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Log logInfo = new Log();
                    logInfo.ID = Guid.NewGuid();
                    logInfo.Type = "WARNING";
                    logInfo.Caption = $"Class: DeclarationChangePassport.cs. Method: CreateChangePassportOrder. Null value in id";
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(logInfo);
                    db.SaveChanges();
                }

                MessageBox.Show("ID приложения на переселение равен NULL!");
            }
        }
        private void CreateChangesPassportsOrders()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                var changePassports = db.ChangePassports.Where(x => x.Status == true).ToList();

                if (changePassports.Count > 0)
                {
                    int counter = 0;
                    foreach (ChangePassport changePassport in changePassports)
                    {
                        string error = string.Empty;

                        if (!OrdersCreation.ChangePassportCreate(changePassport.ID, out error))
                        {
                            Log logInfo = new Log();
                            logInfo.ID = Guid.NewGuid();
                            logInfo.Type = "WARNING";
                            logInfo.Caption = $"DeclarationChangePassport.cs Method: CreateChangesPassportsOrders. {error}";
                            logInfo.CreatedAt = DateTime.Now.ToString();
                            db.Logs.Add(logInfo);
                            db.SaveChanges();

                            MessageBox.Show(error);
                        }
                        else
                        {
                            counter++;
                        }
                    }

                    MessageBox.Show($"{counter} приложений на смену паспортов сформированы!");
                }
                else
                {
                    MessageBox.Show("Нет активных приложений к договорам по смене паспортов!");
                }
            }
        }
    }
}
