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

namespace Supply
{
    public partial class AdminManagersLicenses : Form
    {
        private int _managerId;
        public AdminManagersLicenses(int managerId)
        {
            InitializeComponent();
            _managerId = managerId;
        }

        private void UpdateInfo()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                DG_Licenses.Rows.Clear();

                try
                {
                    var licenses = db.Licenses.Where(x=>x.ManagerId== _managerId).ToList();

                    foreach (var license in licenses)
                    {
                        int rowNumber = DG_Licenses.Rows.Add();

                        DG_Licenses.Rows[rowNumber].Cells[COL_ID.Name].Value = license.ID;
                        DG_Licenses.Rows[rowNumber].Cells[COL_Name.Name].Value = license.Name;
                        DG_Licenses.Rows[rowNumber].Cells[COL_Type.Name].Value = license.Type;
                        DG_Licenses.Rows[rowNumber].Cells[COL_StartDate.Name].Value = license.StartDate;
                        DG_Licenses.Rows[rowNumber].Cells[COL_EndDate.Name].Value = license.EndDate;
                        DG_Licenses.Rows[rowNumber].Cells[COL_Status.Name].Value = license.Status;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AdminManagersLicenses_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Настройки";
            dataGridViewButtonColumn2.Name = "COL_Settings";
            dataGridViewButtonColumn2.Text = "Изменить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_Licenses.Columns.Add(dataGridViewButtonColumn2);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_Licenses.Columns.Add(dataGridViewButtonColumn3);

            using (SupplyDbContext db = new SupplyDbContext())
            {
                var manager = db.Managers.Where(x => x.ID == _managerId).First();
                LB_Manager.Text = manager.Surename + " " + manager.Name + " " + manager.Patronymic;
            }

            UpdateInfo();
        }

        private void BTN_OpenAddWindow_Click(object sender, EventArgs e)
        {
            AdminManagersLicensesAdd adminManagersLicensesAdd = new AdminManagersLicensesAdd(_managerId);
            adminManagersLicensesAdd.ShowDialog();
            UpdateInfo();
        }

        private void DG_Licenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7) 
            {
                DialogResult result = MessageBox.Show($"Удалить {DG_Licenses.Rows[e.RowIndex].Cells[2].Value.ToString()} {DG_Licenses.Rows[e.RowIndex].Cells[3].Value.ToString()}", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        int id = int.Parse(DG_Licenses.Rows[e.RowIndex].Cells[0].Value.ToString());
                        Models.License license = db.Licenses.Where(x => x.ID == id).First();
                        if (license != null)
                        {
                            db.Licenses.Remove(license);
                            db.SaveChanges();
                            MessageBox.Show("Лицензия удалена успешно!");
                            UpdateInfo();
                        }
                    }

                }
            }
        }
    }
}
