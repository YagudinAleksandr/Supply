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
    public partial class AdminPropertiesForm : Form
    {
        private int _roomID;
        public AdminPropertiesForm(int roomID)
        {
            InitializeComponent();
            _roomID = roomID;
        }

        private void AdminPropertiesForm_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn1.HeaderText = "Настройки";
            dataGridViewButtonColumn1.Name = "COL_Settings";
            dataGridViewButtonColumn1.Text = "Настройки";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            DG_Properties.Columns.Add(dataGridViewButtonColumn1);

            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Удалить";
            dataGridViewButtonColumn2.Name = "COL_Delete";
            dataGridViewButtonColumn2.Text = "Удалить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_Properties.Columns.Add(dataGridViewButtonColumn2);

            Room room = new Room();

            using(SupplyDbContext db = new SupplyDbContext())
            {
                room = db.Rooms.Where(x => x.ID == _roomID).First();
            }

            L_RoomNumber.Text = room.Name;

            UpdateInfo();
        }

        private void DG_Properties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void BTN_OpenAddForm_Click(object sender, EventArgs e)
        {
            AdminPropertiesFormAdd adminPropertiesFormAdd = new AdminPropertiesFormAdd(_roomID);
            adminPropertiesFormAdd.ShowDialog();
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                DG_Properties.Rows.Clear();

                try
                {
                    

                    foreach (var property in db.PropertiesR.Where(x=>x.RoomID==_roomID).ToList())
                    {
                        int rowNumber = DG_Properties.Rows.Add();

                        DG_Properties.Rows[rowNumber].Cells[COL_ID.Name].Value = property.ID;
                        DG_Properties.Rows[rowNumber].Cells[COL_Name.Name].Value = property.Name;
                        DG_Properties.Rows[rowNumber].Cells[COL_Count.Name].Value = property.Count;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
