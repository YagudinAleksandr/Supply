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
    public partial class AdminAddressesFormAdd : Form
    {
        public AdminAddressesFormAdd()
        {
            InitializeComponent();
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            if(TB_ZipCode.Text == String.Empty)
            {
                MessageBox.Show("Заполните поле 'Код'");
                return;
            }
            if (TB_Country.Text == String.Empty)
            {
                MessageBox.Show("Заполните поле 'Страна'");
                return;
            }
            if (TB_Region.Text == String.Empty)
            {
                MessageBox.Show("Заполните поле 'Регион/Область'");
                return;
            }
            if (TB_City.Text == String.Empty)
            {
                MessageBox.Show("Заполните поле 'Город/Населенный пункт'");
                return;
            }
            if (TB_Street.Text == String.Empty)
            {
                MessageBox.Show("Заполните поле 'Улица'");
                return;
            }
            if (TB_House.Text == String.Empty)
            {
                MessageBox.Show("Заполните поле 'Постройка'");
                return;
            }
            

            using (SupplyDbContext db = new SupplyDbContext())
            {
                Address adress = new Address()
                {
                    ZipCode = int.Parse(TB_ZipCode.Text),
                    Country = TB_Country.Text,
                    Region = TB_Region.Text,
                    City = TB_City.Text,
                    Street = TB_Street.Text,
                    House = TB_House.Text,
                    Housing = TB_Housing.Text
                };

                try
                {
                    db.Adresses.Add(adress);
                    db.SaveChanges();
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
