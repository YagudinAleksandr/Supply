﻿using Supply.Domain;
using Supply.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminRoomsForm : Form
    {
        private int _hostelId;
        public AdminRoomsForm(int hostelId)
        {
            InitializeComponent();
            _hostelId = hostelId;
        }

        private void AdminRoomsForm_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn1.HeaderText = "Инвентаризация";
            dataGridViewButtonColumn1.Name = "COL_Properties";
            dataGridViewButtonColumn1.Text = "Настройки";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            DG_Rooms.Columns.Add(dataGridViewButtonColumn1);

            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Настройки";
            dataGridViewButtonColumn2.Name = "COL_Settings";
            dataGridViewButtonColumn2.Text = "Изменить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_Rooms.Columns.Add(dataGridViewButtonColumn2);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_Rooms.Columns.Add(dataGridViewButtonColumn3);

            Thread thread = new Thread(UpdateInfo);
            thread.Start();
        }

        private void BTN_OpenRoomAddForm_Click(object sender, EventArgs e)
        {
            AdminRoomsFormAdd adminRoomsFormAdd = new AdminRoomsFormAdd(_hostelId);
            adminRoomsFormAdd.ShowDialog();
            Thread thread = new Thread(UpdateInfo);
            thread.Start();
        }

        private void UpdateInfo()
        {
            Action action = () => 
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    DG_Rooms.Rows.Clear();

                    try
                    {
                        foreach (Enterance enterance in db.Enterances.Where(id => id.HostelId == _hostelId).ToList())
                        {
                            int enteranceId = enterance.ID;
                            foreach (Flat flat in db.Flats.Where(x => x.Enterance_ID == enteranceId).ToList())
                            {
                                int flatId = flat.ID;
                                foreach (Room room in db.Rooms.Include(roomType => roomType.RoomType).Where(x => x.FlatID == flatId))
                                {
                                    int rowNumber = DG_Rooms.Rows.Add();

                                    DG_Rooms.Rows[rowNumber].Cells[COL_ID.Name].Value = room.ID;
                                    DG_Rooms.Rows[rowNumber].Cells[COL_Name.Name].Value = room.Name;
                                    DG_Rooms.Rows[rowNumber].Cells[COL_Places.Name].Value = room.Places;
                                    DG_Rooms.Rows[rowNumber].Cells[COL_Type.Name].Value = room.RoomType.Name;
                                    DG_Rooms.Rows[rowNumber].Cells[COL_Enterance.Name].Value = enterance.Name;
                                    DG_Rooms.Rows[rowNumber].Cells[COL_Flat.Name].Value = flat.Name;
                                }
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

        private void DG_Rooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                int roomID = 0;

                int.TryParse(DG_Rooms.Rows[e.RowIndex].Cells[0].Value.ToString(), out roomID);

                if (roomID != 0)
                {
                    AdminRoomsFormAdd adminRoomsFormAdd = new AdminRoomsFormAdd(roomID, true, _hostelId);
                    adminRoomsFormAdd.ShowDialog();
                    Thread thread = new Thread(UpdateInfo);
                    thread.Start();
                }
                else
                {
                    MessageBox.Show("Значение ID не может быть равным 0");
                }
            }

            if (e.ColumnIndex == 6) 
            {

                int id = int.Parse(DG_Rooms.Rows[e.RowIndex].Cells[0].Value.ToString());

                AdminPropertiesForm adminPropertiesForm = new AdminPropertiesForm(id);
                adminPropertiesForm.ShowDialog();

                UpdateInfo();
            }
            if (e.ColumnIndex == 8)
            {
                int roomId = 0;
                if (int.TryParse(DG_Rooms.Rows[e.RowIndex].Cells[0].Value.ToString(), out roomId))
                {
                    if (roomId != 0)
                    {
                        using(SupplyDbContext db = new SupplyDbContext())
                        {
                            Room room = db.Rooms.Where(x => x.ID == roomId).FirstOrDefault();
                            if(room!=null)
                            {
                                try
                                {
                                    db.Rooms.Remove(room);
                                    db.SaveChanges();
                                    MessageBox.Show("Комната удалена успешно!");
                                    DG_Rooms.Rows.Remove(DG_Rooms.Rows[e.RowIndex]);
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    Log logInfo = new Log();
                                    logInfo.ID = Guid.NewGuid();
                                    logInfo.Type = "ERROR";
                                    logInfo.Caption = "Class: AdminRoomsForm. Method: DG_Rooms_CellClick."+ex.Message+"."+ex.InnerException;
                                    logInfo.CreatedAt = DateTime.Now.ToString();
                                    db.Logs.Add(logInfo);
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
