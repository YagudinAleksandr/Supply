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
    public partial class AdminPropertiesFormAdd : Form
    {
        private int _roomID;
        public AdminPropertiesFormAdd(int roomID)
        {
            InitializeComponent();
            _roomID = roomID;
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (TB_Name.Text == "") 
            {
                MessageBox.Show("Введите название!");
                return;
            }
            if (!int.TryParse(TB_Count.Text, out count)) 
            {
                MessageBox.Show("Введите количество!");
                return;
            }
            if (count == 0)
            {
                MessageBox.Show("Колличество должно быть целым числом и не равным нулю!");
                return;
            }

            using(SupplyDbContext db = new SupplyDbContext())
            {
                Property propery = new Property();
                propery.Name = TB_Name.Text;
                propery.Count = count;
                propery.RoomID = _roomID;

                try
                {
                    db.PropertiesR.Add(propery);
                    db.SaveChanges();

                    MessageBox.Show("Объект добавлен успешно!");
                    TB_Count.Text = "";
                    TB_Name.Text = "";

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
            }
        }
    }
}
