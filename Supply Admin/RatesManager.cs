using Supply_Admin.Domain;
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
    public partial class RatesManager : Form
    {
        private static SupplyDbContext _db;
        public RatesManager(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void RatesManager_Shown(object sender, EventArgs e)
        {
            DataGridViewInformation();
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            RatesAdd ratesAdd = new RatesAdd(_db);
            ratesAdd.ShowDialog();
            DataGridViewInformation();
        }

        private void DataGridViewInformation()
        {
            DGV_Rates.Rows.Clear();

            try
            {
                var rates = _db.Rates.ToList();

                foreach (var rate in rates)
                {
                    int rowNumber = DGV_Rates.Rows.Add();
                    DGV_Rates.Rows[rowNumber].Cells[COL_Id.Name].Value = rate.Id;
                    DGV_Rates.Rows[rowNumber].Cells[COL_Name.Name].Value = rate.Name;
                    DGV_Rates.Rows[rowNumber].Cells[COL_Price.Name].Value = rate.Price;
                    
                    DGV_Rates.Rows[rowNumber].Cells[COL_Description.Name].Value = rate.Description;
                    if(rate.Taks == 1)
                    {
                        DGV_Rates.Rows[rowNumber].Cells[COL_Taks.Name].Value = "Да";
                        DGV_Rates.Rows[rowNumber].Cells[COL_TaksPercent.Name].Value = rate.TaksProcent;
                    }
                    else
                    {
                        DGV_Rates.Rows[rowNumber].Cells[COL_Taks.Name].Value = "Нет";
                        DGV_Rates.Rows[rowNumber].Cells[COL_TaksPercent.Name].Value = "";
                    }
                    var hostel = _db.Hostels.Where(x => x.Id == rate.HostelsId).FirstOrDefault();
                    DGV_Rates.Rows[rowNumber].Cells[COL_Hostel.Name].Value = hostel.Name;
                    var rent = _db.Rents.Where(x => x.Id == rate.RentId).FirstOrDefault();
                    DGV_Rates.Rows[rowNumber].Cells[COL_Rent.Name].Value = rent.Name;
                }
            }
            catch
            {
                MessageBox.Show("В базе данных нет сведений!");
            }
        }
    }
}
