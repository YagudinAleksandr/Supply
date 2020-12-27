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

        }

        private void SupplyManagers_Load(object sender, EventArgs e)
        {
            DataGridViewInformation();
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            SupplyAdd supplyAdd = new SupplyAdd(_db);
            supplyAdd.ShowDialog();
            DataGridViewInformation();
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
                    DGV_Supplies.Rows[rowNumber].Cells[COL_Surename.Name].Value = supply.Surename;
                    DGV_Supplies.Rows[rowNumber].Cells[COL_Patronimuc.Name].Value = supply.Patronimic;
                    DGV_Supplies.Rows[rowNumber].Cells[COL_Name.Name].Value = supply.Name;
                    DGV_Supplies.Rows[rowNumber].Cells[COL_Proxy.Name].Value = supply.Proxy;
                    DGV_Supplies.Rows[rowNumber].Cells[COL_Start.Name].Value = supply.ProxyDate;
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
