using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminUsersForm : Form
    {
        private int _userID;
        public AdminUsersForm(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void BTN_OpenUserAddForm_Click(object sender, EventArgs e)
        {
            AdminUsersFormAdd adminUsersFormAdd = new AdminUsersFormAdd();
            adminUsersFormAdd.ShowDialog();
            UpdateInfo();
        }

        private void AdminUsersForm_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Настройки";
            dataGridViewButtonColumn2.Name = "COL_Settings";
            dataGridViewButtonColumn2.Text = "Изменить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_Users.Columns.Add(dataGridViewButtonColumn2);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_Users.Columns.Add(dataGridViewButtonColumn3);
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                DG_Users.Rows.Clear();

                try
                {
                    foreach (User user in db.Users.Include(role=>role.Role))
                    {
                        if(_userID!=user.ID)
                        {
                            int rowNumber = DG_Users.Rows.Add();
                        
                            DG_Users.Rows[rowNumber].Cells[COL_ID.Name].Value = user.ID;
                            DG_Users.Rows[rowNumber].Cells[COL_Name.Name].Value = user.Name;
                            DG_Users.Rows[rowNumber].Cells[COL_Login.Name].Value = user.Login;
                            DG_Users.Rows[rowNumber].Cells[COL_Role.Name].Value = user.Role.Title;
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
