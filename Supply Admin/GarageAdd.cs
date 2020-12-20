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
    public partial class GarageAdd : Form
    {
        private SupplyDbContext _db;
        public GarageAdd(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
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
        private void BTN_Save_Click(object sender, EventArgs e)
        {
            try 
            {
                Garage garage = new Garage();
                garage.Name = TB_Name.Text;
                garage.Numeric = TB_Number.Text;
                garage.DateStart = TB_StartDate.Text;
                garage.DateEnd = TB_EndDate.Text;
                garage.RoomsId = (int)CB_Room.SelectedValue;
                _db.Garages.Add(garage);
                _db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка! Обратитесь к системному администратору");
                return;
            }
            MessageBox.Show("Объект добавлен успешно!");
            TB_Name.Clear();
            TB_Number.Clear();
            TB_StartDate.Clear();
            TB_EndDate.Clear();
        }

        
    }
}
