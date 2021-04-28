using Supply.Domain;
using Supply.Models;
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
    public partial class AdminRoomsFormAdd : Form
    {
        private int _hostelID;
        private int _flatIndex;
        private int _roomType;
        public AdminRoomsFormAdd(int hostelID)
        {
            InitializeComponent();
            _hostelID = hostelID;
        }

        private void AdminRoomsFormAdd_Shown(object sender, EventArgs e)
        {
            _flatIndex = 0;
            _roomType = 0;

            using(SupplyDbContext db = new SupplyDbContext())
            {
                CB_RoomType.DataSource = db.RoomTypes.ToList();
                CB_RoomType.DisplayMember = "Name";
                CB_RoomType.ValueMember = "ID";

                CB_Enterances.DataSource = db.Enterances.Where(x => x.HostelId == _hostelID).ToList();
                CB_Enterances.DisplayMember = "Name";
                CB_Enterances.ValueMember = "ID";
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if(TB_Name.Text=="")
            {
                MessageBox.Show("Введите название комнаты!");
                return;
            }
            if (TB_Places.Text == "")
            {
                MessageBox.Show("Введите кол-во мест!");
                return;
            }
            if(_flatIndex==0)
            {
                MessageBox.Show("Выбирите этаж!");
                return;
            }
            if (_roomType == 0)
            {
                MessageBox.Show("Выбирите тип комнаты!");
                return;
            }

            using(SupplyDbContext db = new SupplyDbContext())
            {
                Room room = new Room();
                room.Name = TB_Name.Text;
                room.Places = int.Parse(TB_Places.Text);
                room.RoomTypeID = _roomType;
                room.FlatID = _flatIndex;

                db.Rooms.Add(room);
                db.SaveChanges();
            }
            MessageBox.Show("Комната добавлена успешно!");
            this.Close();
        }

        private void CB_RoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _roomType = (int)CB_RoomType.SelectedValue;

            }
            catch
            {
                return;
            }
        }

        private void CB_Enterances_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    int i = 0;
                    int.TryParse(CB_Enterances.SelectedValue.ToString(), out i);
                    if(i!=0)
                    {
                        CB_Flat.DataSource = db.Flats.Where(x => x.Enterance_ID == i).ToList();
                        CB_Flat.DisplayMember = "Name";
                        CB_Flat.ValueMember = "ID";
                    }
                    
                }
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
                _flatIndex = (int)CB_Flat.SelectedValue;

            }
            catch
            {
                return;
            }
        }
    }
}
