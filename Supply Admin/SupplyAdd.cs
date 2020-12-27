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
    public partial class SupplyAdd : Form
    {
        private static SupplyDbContext _db;
        public SupplyAdd(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void SupplyAdd_Load(object sender, EventArgs e)
        {
            var hostels = _db.Hostels.ToList();
            
            CB_Hostels.DataSource = hostels;
            CB_Hostels.DisplayMember = "Name";
            CB_Hostels.ValueMember = "Id";
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Supply supply = new Supply();

                supply.Surename = TB_Surename.Text;
                supply.Name = TB_Name.Text;
                supply.Patronimic = TB_Patronimic.Text;
                supply.HostelsId = (int)CB_Hostels.SelectedValue;
                supply.Proxy = TB_Proxy.Text;
                supply.ProxyDate = TB_ProxyDate.Text;

                _db.Supplies.Add(supply);
                _db.SaveChanges();

                MessageBox.Show("Заведующий общежитием добавлен успешно!");

                Close();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка!");

                Close();
            }
        }
    }
}
