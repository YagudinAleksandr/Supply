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
    public partial class AdminManagersFormAdd : Form
    {
        public AdminManagersFormAdd()
        {
            InitializeComponent();
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            if (TB_Surename.Text == String.Empty)
            {
                MessageBox.Show("Заполните поле Фамилия");
                return;
            }
            if (TB_Name.Text == String.Empty)
            {
                MessageBox.Show("Заполните поле Имя");
                return;
            }

            using(SupplyDbContext db = new SupplyDbContext())
            {
                Manager manager = new Manager()
                {
                    Surename = TB_Surename.Text,
                    Name = TB_Name.Text,
                    Patronymic = TB_Patronymic.Text
                };
                try
                {
                    db.Managers.Add(manager);
                    db.SaveChanges();
                    MessageBox.Show("Менеджер добавлен!");
                    this.Close();
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
