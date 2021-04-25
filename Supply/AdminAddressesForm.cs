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
    public partial class AdminAddressesForm : Form
    {
        public AdminAddressesForm()
        {
            InitializeComponent();
        }
        private void UpdateInformation()
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                DG_Addresses.Rows.Clear();
                try
                {
                    var addresses = db.Adresses.ToList();

                    foreach(var address in addresses)
                    {
                        int rowNumber = DG_Addresses.Rows.Add();

                        DG_Addresses.Rows[rowNumber].Cells[COL_ID.Name].Value = address.ID;
                        DG_Addresses.Rows[rowNumber].Cells[COL_ZipCode.Name].Value = address.ZipCode;
                        DG_Addresses.Rows[rowNumber].Cells[COL_Country.Name].Value = address.Country;
                        DG_Addresses.Rows[rowNumber].Cells[COL_Region.Name].Value = address.Region;
                        DG_Addresses.Rows[rowNumber].Cells[COL_City.Name].Value = address.City;
                        DG_Addresses.Rows[rowNumber].Cells[COL_House.Name].Value = address.House;
                        DG_Addresses.Rows[rowNumber].Cells[COL_Housing.Name].Value = address.Housing;
                        DG_Addresses.Rows[rowNumber].Cells[COL_Street.Name].Value = address.Street;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AdminAddressesForm_Shown(object sender, EventArgs e)
        {
            UpdateInformation();
        }

        private void BNT_OpenAddForm_Click(object sender, EventArgs e)
        {
            AdminAddressesFormAdd adminAddressesFormAdd = new AdminAddressesFormAdd();
            adminAddressesFormAdd.ShowDialog();
            UpdateInformation();
        }
    }
}
