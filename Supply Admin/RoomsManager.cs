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
    public partial class RoomsManager : Form
    {
        private static SupplyDbContext _db;
        public RoomsManager(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void RoomsManager_Shown(object sender, EventArgs e)
        {
            DataGridViewInformation();
        }

        private void DataGridViewInformation()
        {
            DGV_Rooms.Rows.Clear();

            try
            {
                var rooms = _db.Rooms.ToList();

                foreach (var room in rooms)
                {
                    int rowNumber = DGV_Rooms.Rows.Add();
                    DGV_Rooms.Rows[rowNumber].Cells[COL_Id.Name].Value = room.Id;
                    DGV_Rooms.Rows[rowNumber].Cells[COL_Name.Name].Value = room.Name;
                    DGV_Rooms.Rows[rowNumber].Cells[COL_Places.Name].Value = room.Places;
                    DGV_Rooms.Rows[rowNumber].Cells[COL_Type.Name].Value = room.Type;
                    
                    var flat = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
                    DGV_Rooms.Rows[rowNumber].Cells[COL_FlatId.Name].Value = flat.Name;
                    var hostel = _db.Hostels.Where(x => x.Id == flat.HostelsId).FirstOrDefault();
                    DGV_Rooms.Rows[rowNumber].Cells[COL_HostelId.Name].Value = hostel.Name;
                }
            }
            catch
            {
                MessageBox.Show("В базе данных нет сведений!");
            }
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            RoomsAdd roomsAdd = new RoomsAdd(_db);
            roomsAdd.ShowDialog();
            DataGridViewInformation();
        }
    }
}
