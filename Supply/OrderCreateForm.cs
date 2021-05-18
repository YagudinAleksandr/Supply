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
using Libraries.WordSystem;
using System.Data.Entity;

namespace Supply
{
    public partial class OrderCreateForm : Form
    {
        private int _hostelIndex;
        public OrderCreateForm()
        {
            InitializeComponent();
        }

        private void OrderCreateForm_Load(object sender, EventArgs e)
        {
            _hostelIndex = 0;
            using(SupplyDbContext db = new SupplyDbContext())
            {
                CB_Hostels.DataSource = db.Hostels.ToList();
                CB_Hostels.ValueMember = "ID";
                CB_Hostels.DisplayMember = "Name";
            }
        }

        private void CB_Hostels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _hostelIndex = int.Parse(CB_Hostels.SelectedValue.ToString());
            }
            catch
            {
                return;
            }
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            if(_hostelIndex==0)
            {
                MessageBox.Show("Выбирете общежитие!");
                return;
            }
            
            using(SupplyDbContext db = new SupplyDbContext())
            {
                var enterances = db.Enterances.Where(x => x.HostelId == _hostelIndex).ToList();
                foreach(var enterance in enterances)
                {
                    var flats = db.Flats.Where(x => x.Enterance_ID == enterance.ID).ToList();
                    foreach(var flat in flats)
                    {
                        var rooms = db.Rooms.Where(x => x.FlatID == flat.ID).ToList();
                        foreach(var room in rooms)
                        {
                            var orders = db.Orders.Where(x => x.RoomID == room.ID).Where(y => y.StartDate == TB_StartOrder.Text).ToList();
                            foreach(var order in orders)
                            {
                                WordDocument orderModel = new WordDocument();
                                
                            }
                        }
                    }
                }
            }
            GC.Collect();
        }
    }
}
