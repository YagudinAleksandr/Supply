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
    public partial class RoomsAdd : Form
    {
        private static SupplyDbContext _db;
        public RoomsAdd(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
            var hostels = _db.Hostels.ToList();
            CB_Hostels.DataSource = hostels;
            CB_Hostels.DisplayMember = "Name";
            CB_Hostels.ValueMember = "Id";
        }

        private void CB_Hostels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var enterances = _db.Enterances.Where(x => x.HostelsId == (int)CB_Hostels.SelectedValue).ToList();
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
                int Id = (int)CB_Enterance.SelectedValue;
                var flats = _db.Flats.Where(x => x.EnteranceId == Id).ToList();
                CB_Flats.DataSource = flats;
                CB_Flats.DisplayMember = "Name";
                CB_Flats.ValueMember = "Id";
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
                Rooms room = new Rooms();
                room.FlatId = (int)CB_Flats.SelectedValue;
                room.Name = Convert.ToInt32(TB_Name.Text);
                room.Type = CB_Type.SelectedItem.ToString();
                room.Places = Convert.ToInt32(TB_Places.Text);

                _db.Rooms.Add(room);
                _db.SaveChanges();
                MessageBox.Show("Данные добавлены успешно");

                Close();
            }
            catch
            {
                MessageBox.Show("Ошибка при добавление данных");
            }
        }

        
    }
}
