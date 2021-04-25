using Supply.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supply.Models;

namespace Supply
{
    public partial class AdminManagersLicensesAdd : Form
    {
        private int _managerId;
        public AdminManagersLicensesAdd(int managerId)
        {
            InitializeComponent();
            _managerId = managerId;
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                Models.License license = new Models.License()
                {
                    Name = TB_Name.Text,
                    Type = CB_Types.SelectedItem.ToString(),
                    StartDate = TB_StartDate.Text,
                    EndDate = TB_EndDate.Text,
                    ManagerId = _managerId
                };
                try
                {
                    db.Licenses.Add(license);
                    db.SaveChanges();
                    MessageBox.Show("Лицензия добавлена успешно!");
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
