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
using System.Threading.Tasks;
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
            UpdateInfo();
        }

        private void BTN_OpenRoomAddForm_Click(object sender, EventArgs e)
        {
            AdminRoomsFormAdd adminRoomsFormAdd = new AdminRoomsFormAdd(_hostelId);
            adminRoomsFormAdd.ShowDialog();
            UpdateInfo();
        }

        private void UpdateInfo()
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
        }

        private void DG_Rooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==6)
            {

                int id = int.Parse(DG_Rooms.Rows[e.RowIndex].Cells[0].Value.ToString());

                AdminPropertiesForm adminPropertiesForm = new AdminPropertiesForm(id);
                adminPropertiesForm.ShowDialog();

                UpdateInfo();
            }
        }
    }
}
