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
    public partial class RentMenegers : Form
    {
        private static SupplyDbContext _db;
        public RentMenegers(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Rent rent = new Rent();
                rent.Name = TB_Name.Text;
                _db.Rents.Add(rent);
                _db.SaveChanges();

                TB_Name.Text = "";
                DataGridViewInformation();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
            
        }

        private void RentMenegers_Shown(object sender, EventArgs e)
        {
            DataGridViewInformation();
        }

        private void DataGridViewInformation()
        {
            DGV_Rents.Rows.Clear();

            try
            {
                var rents = _db.Rents.ToList();

                int counter = 1;
                foreach (var rent in rents)
                {
                    int rowNumber = DGV_Rents.Rows.Add();
                    DGV_Rents.Rows[rowNumber].Cells[COL_Number.Name].Value = counter;
                    DGV_Rents.Rows[rowNumber].Cells[COL_Name.Name].Value = rent.Name;
                    counter++;
                }
            }
            catch
            {
                MessageBox.Show("В базе данных нет сведений!");
            }
        }
    }
}
