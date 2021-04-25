using Supply.Domain;
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
    public partial class AdminHostelsForm : Form
    {
        public AdminHostelsForm()
        {
            InitializeComponent();
        }

        private void AdminHostelsForm_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Настройки";
            dataGridViewButtonColumn2.Name = "COL_Settings";
            dataGridViewButtonColumn2.Text = "Изменить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_Hostels.Columns.Add(dataGridViewButtonColumn2);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_Hostels.Columns.Add(dataGridViewButtonColumn3);
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                DG_Hostels.Rows.Clear();

                try
                {
                    var hostels = db.Hostels.ToList();

                    foreach (var hostel in hostels)
                    {
                        int rowNumber = DG_Hostels.Rows.Add();

                        DG_Hostels.Rows[rowNumber].Cells[COL_ID.Name].Value = hostel.ID;
                        DG_Hostels.Rows[rowNumber].Cells[COL_Name.Name].Value = hostel.Name;
                        DG_Hostels.Rows[rowNumber].Cells[COL_Address.Name].Value = hostel.Manager.Surename+" "+hostel.Manager.Name+" "+hostel.Manager.Patronymic;
                        DG_Hostels.Rows[rowNumber].Cells[COL_Address.Name].Value = hostel.Address.ZipCode + ", " + hostel.Address.Country + "," + hostel.Address.Region + "," + hostel.Address.City + "," + hostel.Address.Street + "," + hostel.Address.House;
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BTN_OpenHostelAddWindow_Click(object sender, EventArgs e)
        {
            AdminHostelsFormAdd adminHostelsFormAdd = new AdminHostelsFormAdd();
            adminHostelsFormAdd.ShowDialog();
            UpdateInfo();
        }
    }
}
