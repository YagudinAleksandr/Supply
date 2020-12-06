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
    public partial class RatesAdd : Form
    {
        private static SupplyDbContext _db;
        public RatesAdd(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            Rate rate = new Rate();
            try
            {
                rate.Name = TB_Name.Text;
                rate.Price = Convert.ToDouble(TB_Rate.Text);
                rate.RentId = (int)CB_RentId.SelectedValue; ;
                rate.HostelsId = (int)CB_HostelId.SelectedValue; ;
                rate.CreationDate = DateTime.Now.ToString();
                if(CB_Taks.Checked)
                {
                    rate.Taks = 1;
                    rate.TaksProcent = Convert.ToDouble(TB_TaksPercent.Text);
                }
                else
                {
                    rate.Taks = 0;
                }
                rate.Description = RTB_Description.Text;

                _db.Rates.Add(rate);
                _db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!");
                Close();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка!");
            }
        }

        private void RatesAdd_Shown(object sender, EventArgs e)
        {
            var hostels = _db.Hostels.ToList();
            var rents = _db.Rents.ToList();

            CB_HostelId.DataSource = hostels;
            CB_HostelId.DisplayMember = "Name";
            CB_HostelId.ValueMember = "Id";

            CB_RentId.DataSource = rents;
            CB_RentId.DisplayMember = "Name";
            CB_RentId.ValueMember = "Id";
        }

      
    }
}
