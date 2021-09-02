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
    public partial class DeclarationChangeRoom : Form
    {
        public DeclarationChangeRoom()
        {
            InitializeComponent();
        }

        private void DG_View_ChangeRooms_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex==7)
            {
                int id = int.Parse(DG_View_ChangeRooms.Rows[e.RowIndex].Cells[0].Value.ToString());
                Thread thread = new Thread(new ParameterizedThreadStart(CreateChangeRoomOrder));
                thread.Start(id);
            }
            if(e.ColumnIndex==8)
            {
                DialogResult result = MessageBox.Show($"Удалить {DG_View_ChangeRooms.Rows[e.RowIndex].Cells[0].Value.ToString()}", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        int id = int.Parse(DG_View_ChangeRooms.Rows[e.RowIndex].Cells[0].Value.ToString());
                        ChangeRoom changeRoom = db.ChangeRooms.Where(x => x.ID == id).FirstOrDefault();
                        if (changeRoom != null)
                        {
                            try
                            {
                                db.ChangeRooms.Remove(changeRoom);
                                db.SaveChanges();
                                MessageBox.Show("Приложение на переселение удалено успешно");
                                Thread thread = new Thread(UpdateInfo);
                                thread.Start();
                            }
                            catch (Exception ex)
                            {
                                Log logInfo = new Log();
                                logInfo.ID = Guid.NewGuid();
                                logInfo.Type = "ERROR";
                                logInfo.Caption = $"Class: DeclarationChangeRoom. Method: DG_View_ChangeRooms_CellMouseClick. {ex.Message}.{ex.InnerException}";
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

        private void DeclarationChangeRoom_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn1.HeaderText = "Создать документ";
            dataGridViewButtonColumn1.Name = "COL_CreateOrder";
            dataGridViewButtonColumn1.Text = "Создать";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            DG_View_ChangeRooms.Columns.Add(dataGridViewButtonColumn1);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_View_ChangeRooms.Columns.Add(dataGridViewButtonColumn3);

            Thread thread = new Thread(UpdateInfo);
            thread.Start();
        }
        private void CreateChangeRoomOrder(object idChangeRoom)
        {
            if (idChangeRoom != null)
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    ChangeRoom changeRoom = db.ChangeRooms.Where(x => x.ID == (int)idChangeRoom).Include(j => j.Order).FirstOrDefault();
                    if (changeRoom != null)
                    {
                        string error = string.Empty;

                        if (OrdersCreation.ChangeRoomCreate(changeRoom.ID, out error))
                        {
                            MessageBox.Show($"Приложение к договору № {changeRoom.Order.OrderNumber} на переселение сформирован");
                        }
                        else
                        {
                            Log logInfo = new Log();
                            logInfo.ID = Guid.NewGuid();
                            logInfo.Type = "WARNING";
                            logInfo.Caption = $"DeclarationChangeRoom.cs Method: CreateChangeRoomOrder. {error}";
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
                    logInfo.Caption = $"Class: DeclarationChangeRoom.cs. Method: CreateChangeRoomOrder. Null value in idChangeRoom";
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(logInfo);
                    db.SaveChanges();
                }

                MessageBox.Show("ID приложения на переселение равен NULL!");
            }
        }
        private void CreateChangeRoomOrders()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                
                var changeRooms = db.ChangeRooms.Where(x => x.Status == true).Include(o => o.Order).ToList();

                if (changeRooms.Count > 0)
                {
                    int counter = 0;
                    foreach (ChangeRoom changeRoom in changeRooms)
                    {
                        string error = string.Empty;

                        if (!OrdersCreation.ChangeRoomCreate(changeRoom.ID, out error))
                        {
                            Log logInfo = new Log();
                            logInfo.ID = Guid.NewGuid();
                            logInfo.Type = "WARNING";
                            logInfo.Caption = $"DeclarationChangeRoom.cs Method: CreateChangeRoomOrders. {error}";
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

                    MessageBox.Show($"{counter} приложений на переселений сформированы!");
                }
                else
                {
                    MessageBox.Show("Нет активных приложений к договорам по переселению!");
                }
            }
        }
        private void UpdateInfo()
        {
            Action action = () =>
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    DG_View_ChangeRooms.Rows.Clear();
                    try
                    {
                        var changeRooms = db.ChangeRooms.Include(or => or.Order).Include(r => r.Room).ToList();

                        foreach (var changeRoom in changeRooms)
                        {
                            int rowNumber = DG_View_ChangeRooms.Rows.Add();

                            DG_View_ChangeRooms.Rows[rowNumber].Cells[COL_ID.Name].Value = changeRoom.ID;
                            DG_View_ChangeRooms.Rows[rowNumber].Cells[COL_NewRoom.Name].Value = changeRoom.Room.Name;
                            DG_View_ChangeRooms.Rows[rowNumber].Cells[COL_StartDate.Name].Value = changeRoom.StartDate;
                            DG_View_ChangeRooms.Rows[rowNumber].Cells[COL_Order.Name].Value = changeRoom.Order.OrderNumber;
                            if(changeRoom.Status == true)
                            {
                                DG_View_ChangeRooms.Rows[rowNumber].Cells[COL_Status.Name].Value = "Переселение назначено";
                            }
                            else
                            {
                                DG_View_ChangeRooms.Rows[rowNumber].Cells[COL_Status.Name].Value = "Переселен";
                            }

                            Room room = db.Rooms.Where(x => x.ID == changeRoom.Order.RoomID).FirstOrDefault();
                            DG_View_ChangeRooms.Rows[rowNumber].Cells[COL_OldRoom.Name].Value = room.Name;

                            Tenant tenant = db.Tenants.Where(x => x.ID == changeRoom.Order.ID).Include(ident => ident.Identification).FirstOrDefault();
                            string tenantName = tenant.Identification.Surename + " " + tenant.Identification.Name;
                            if(tenant.Identification.Patronymic!=null)
                            {
                                tenantName += " " + tenant.Identification.Patronymic;
                            }
                            DG_View_ChangeRooms.Rows[rowNumber].Cells[COL_Tenant.Name].Value = tenantName;
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

        private void BTN_CreateChangeRoomOrders_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(CreateChangeRoomOrders);
            thread.Start();
            MessageBox.Show("Запущен фоновый процес создания приложений к договорам!");
        }
    }
}
