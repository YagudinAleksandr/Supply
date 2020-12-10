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
using Supply_Admin.Models;

namespace Supply_Admin
{
    public partial class HumanCreate : Form
    {
        SupplyDbContext _db;
        private static int _roomId;
        
        public HumanCreate(SupplyDbContext db, int roomId)
        {
            InitializeComponent();
            _db = db;
            _roomId = roomId;
        }

        private void BTN_SaveHuman_Click(object sender, EventArgs e)
        {

        }

        private void HumanCreate_Shown(object sender, EventArgs e)
        {
            var room = _db.Rooms.Where(x => x.Id == _roomId).FirstOrDefault();
            var flat = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
            var enterance = _db.Enterances.Where(x => x.Id == flat.EnteranceId).FirstOrDefault();
            var hostel = _db.Hostels.Where(x => x.Id == enterance.HostelsId).FirstOrDefault();

            LB_Room.Text = $"Комната № {room.Name}";
            LB_Hostel.Text = $"Общежитие № {hostel.Name}";
        }
    }
}
