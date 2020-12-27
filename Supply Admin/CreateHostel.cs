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
            try
            {
                Hostels hostel = new Hostels { Name = Convert.ToInt32(TB_Name.Text), Address = RTB_Address.Text,FlatCount = Convert.ToInt32(TB_Flats.Text) };
                _db.Hostels.Add(hostel);
                _db.SaveChanges();

                int hostelId = hostel.Id;

                for (int i = 0; i < Convert.ToInt32(TB_Enterances.Text); i++)
                {
                    Enterance enterance = new Enterance();

                    enterance.Name = i + 1;
                    enterance.HostelsId = hostelId;

                    _db.Enterances.Add(enterance);
                    _db.SaveChanges();

                    int enteranceId = enterance.Id;

                    for (int j = 0; j < Convert.ToInt32(TB_Flats.Text); j++)
                    {
                        Flat flat = new Flat();

                        flat.Name = j + 1;
                        flat.EnteranceId = enteranceId;

                        _db.Flats.Add(flat);
                        _db.SaveChanges();
                    }
                }

                MessageBox.Show("Общежитие добавлено успешно!");
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }

            Close();
        }
    }
}
