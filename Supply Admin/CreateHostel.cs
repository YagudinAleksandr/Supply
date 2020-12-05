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
    public partial class CreateHostel : Form
    {
        SupplyDbContext _db;
        public CreateHostel(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            Hostels hostel = new Hostels { Name = Convert.ToInt32(TB_Name.Text), Address = RTB_Address.Text, SupplyManager = TB_Supply.Text };
            _db.Hostels.Add(hostel);
            int hostelId = _db.SaveChanges();

            for (int i = 0; i < Convert.ToInt32(TB_Flats.Text); i++)
            {
                Flat flat = new Flat();

                flat.Name = i + 1;
                flat.HostelsId = hostelId;

                _db.Flats.Add(flat);
                _db.SaveChanges();
            }

            MessageBox.Show("Общежитие добавлено успешно!");

            Close();
        }
    }
}
