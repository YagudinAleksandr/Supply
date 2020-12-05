using Supply_Admin.Domain;
using Supply_Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply_Admin
{
    public partial class SupplyManagers : Form
    {
        SupplyDbContext _db;
        private static int index = 0;
        public SupplyManagers(SupplyDbContext db)
        {
            InitializeComponent();

            _db = db;

            LB_Hostel.Visible = false;
            LB_Name.Visible = false;
            CB_Hostel.Visible = false;
            TB_Name.Visible = false;
            BTN_Save.Visible = false;
        }

        private void SupplyManagers_Load(object sender, EventArgs e)
        {
            var hostels = _db.Hostels.ToList();
            DataGridViewInformation();
            CB_Hostel.DataSource = hostels;
            CB_Hostel.DisplayMember = "Name";
            CB_Hostel.ValueMember = "Id";
            
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            LB_Hostel.Visible = true;
            LB_Name.Visible = true;
            CB_Hostel.Visible = true;
            TB_Name.Visible = true;
            BTN_Save.Visible = true;
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Supply supply = new Supply()
                {
                    Name = TB_Name.Text,
                    HostelsId = index
                };

                _db.Supplies.Add(supply);
                _db.SaveChanges();

                MessageBox.Show("Запись добавлена успешно");

                LB_Name.Text = "";

                LB_Hostel.Visible = false;
                LB_Name.Visible = false;
                CB_Hostel.Visible = false;
                TB_Name.Visible = false;
                BTN_Save.Visible = false;

                DataGridViewInformation();
            }
            catch
            {
                MessageBox.Show("Возникли проблемы с добавлением");
            }
            
        }

        private void CB_Hostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = (int)CB_Hostel.SelectedValue;
        }

        private void DataGridViewInformation()
        {
            DGV_Supplies.Rows.Clear();

            try
            {
                var supplies = _db.Supplies.ToList();


                foreach (var supply in supplies)
                {
                    int rowNumber = DGV_Supplies.Rows.Add();
                    DGV_Supplies.Rows[rowNumber].Cells[COL_Id.Name].Value = supply.Id;
                    DGV_Supplies.Rows[rowNumber].Cells[COL_Name.Name].Value = supply.Name;
                    DGV_Supplies.Rows[rowNumber].Cells[COL_Hostel.Name].Value = supply.hostels.Name;
                }
            }
            catch
            {
                MessageBox.Show("В базе данных нет сведений!");
            }
        }
    }
}
