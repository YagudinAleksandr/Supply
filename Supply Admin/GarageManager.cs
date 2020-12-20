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
    public partial class GarageManager : Form
    {
        private SupplyDbContext _db;
        public GarageManager(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void GarageManager_Shown(object sender, EventArgs e)
        {
            DataGridViewInformation_Update();
        }

        private void DataGridViewInformation_Update()
        {
            DG_ViewGarage.Rows.Clear();

            try
            {
                var garages = _db.Garages.ToList();


                foreach (var garage in garages)
                {
                    int rowNumber = DG_ViewGarage.Rows.Add();
                    DG_ViewGarage.Rows[rowNumber].Cells[COL_Name.Name].Value = garage.Name;
                    DG_ViewGarage.Rows[rowNumber].Cells[COL_Number.Name].Value = garage.Numeric;
                    DG_ViewGarage.Rows[rowNumber].Cells[COL_StartDate.Name].Value = garage.DateStart;
                    DG_ViewGarage.Rows[rowNumber].Cells[COL_EndDate.Name].Value = garage.DateEnd;

                    var room = _db.Rooms.Where(x => x.Id == garage.RoomsId).FirstOrDefault();
                    DG_ViewGarage.Rows[rowNumber].Cells[COL_Room.Name].Value = room.Name;

                    var flats = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
                    var enterance = _db.Enterances.Where(x => x.Id == flats.EnteranceId).FirstOrDefault();
                    var hostel = _db.Hostels.Where(x => x.Id == enterance.HostelsId).FirstOrDefault();

                    DG_ViewGarage.Rows[rowNumber].Cells[COL_Hostel.Name].Value = hostel.Name;
                }
            }
            catch
            {
                MessageBox.Show("В базе данных нет сведений!");
            }
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            GarageAdd garageAdd = new GarageAdd(_db);
            garageAdd.ShowDialog();
            DataGridViewInformation_Update();
        }
    }
}
