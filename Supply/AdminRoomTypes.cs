using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminRoomTypes : Form
    {
        public AdminRoomTypes()
        {
            InitializeComponent();
        }

        private void AdminRoomTypes_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn1.HeaderText = "Настройки";
            dataGridViewButtonColumn1.Name = "COL_Settings";
            dataGridViewButtonColumn1.Text = "Изменить";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            DG_RoomTypes.Columns.Add(dataGridViewButtonColumn1);

            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Настройки";
            dataGridViewButtonColumn2.Name = "COL_Delete";
            dataGridViewButtonColumn2.Text = "Удалить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_RoomTypes.Columns.Add(dataGridViewButtonColumn2);

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                DG_RoomTypes.Rows.Clear();

                try
                {
                    foreach (RoomType roomType in db.RoomTypes.ToList())
                    {
                        int rowNumber = DG_RoomTypes.Rows.Add();

                        DG_RoomTypes.Rows[rowNumber].Cells[COL_ID.Name].Value = roomType.ID;
                        DG_RoomTypes.Rows[rowNumber].Cells[COL_Name.Name].Value = roomType.Name;
                        
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            AdminRoomTypesAdd adminRoomTypesAdd = new AdminRoomTypesAdd();
            adminRoomTypesAdd.ShowDialog();
            UpdateInfo();
        }
    }
}
