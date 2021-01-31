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
    public partial class ChangeHouse : Form
    {
        private SupplyDbContext _db;
        private int _humanId;
        public ChangeHouse(SupplyDbContext db, int humanId)
        {
            InitializeComponent();
            _db = db;
            _humanId = humanId;

            var hostels = _db.Hostels.ToList();
            CB_Hostel.DataSource = hostels;
            CB_Hostel.DisplayMember = "Name";
            CB_Hostel.ValueMember = "Id";
        }

        private void CB_Hostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var enterances = _db.Enterances.Where(x => x.HostelsId == (int)CB_Hostel.SelectedValue).ToList();

                CB_Enterance.DataSource = enterances;
                CB_Enterance.DisplayMember = "Name";
                CB_Enterance.ValueMember = "Id";

            }
            catch
            {
                return;
            }

        }
        private void CB_Enterance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var flats = _db.Flats.Where(x => x.EnteranceId == (int)CB_Enterance.SelectedValue).ToList();
                CB_Flat.DataSource = flats;
                CB_Flat.DisplayMember = "Name";
                CB_Flat.ValueMember = "Id";
            }
            catch
            {
                return;
            }
        }
        private void CB_Flat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var rooms = _db.Rooms.Where(x => x.FlatId == (int)CB_Flat.SelectedValue).ToList();
                CB_Room.DataSource = rooms;
                CB_Room.DisplayMember = "Name";
                CB_Room.ValueMember = "Id";
            }
            catch
            {
                return;
            }
        }

        private void ChangeHouse_Load(object sender, EventArgs e)
        {
            var human = _db.Humen.Where(x => x.Id == _humanId).First();
            var order = _db.Orders.Where(x => x.HumanId == _humanId).First();

            LB_OrderNumber.Text = order.Id.ToString();
            LB_RoomNumber.Text = human.Room.Name.ToString();
            LB_HostelName.Text = human.Room.Flat.Enterance.Hostels.Name.ToString();
            LB_Human.Text = human.Surename + " " + human.Name + " " + human.Patronymic;
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            try
            {
                var human = _db.Humen.Where(x => x.Id == _humanId).First();
                human.RoomId = (int)CB_Room.SelectedValue;

                _db.Entry(human).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                var order = _db.Orders.Where(x => x.HumanId == _humanId).First();
                order.HostelsId = (int)CB_Hostel.SelectedValue;

                _db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                bool flag = WordExcelIO.CreateChangeHouse(_db, _humanId);
                MessageBox.Show("Житель перемещен успешно!");
                if(flag==true)
                {
                    MessageBox.Show("Дополнение сформировано!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Возникла ошибка формирования документа!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка! Обратитесь к системному администратору");
                return;
            }
            
            
        }
    }
}
