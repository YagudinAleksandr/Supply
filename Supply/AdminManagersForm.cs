using Supply.Domain;
using Supply.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminManagersForm : Form
    {
        public AdminManagersForm()
        {
            InitializeComponent();
        }

        private void AdminManagersForm_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.HeaderText = "Лицензии";
            dataGridViewButtonColumn.Name = "COL_Licenses";
            dataGridViewButtonColumn.Text = "Лицензии";
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;
            DG_Managers.Columns.Add(dataGridViewButtonColumn);

            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Настройки";
            dataGridViewButtonColumn2.Name = "COL_Settings";
            dataGridViewButtonColumn2.Text = "Изменить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_Managers.Columns.Add(dataGridViewButtonColumn2);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_Managers.Columns.Add(dataGridViewButtonColumn3);
            UpdateInfo();
        }
        private void UpdateInfo()
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                DG_Managers.Rows.Clear();

                try
                {
                    var managers = db.Managers.ToList();

                    foreach (var manager in managers)
                    {
                        int rowNumber = DG_Managers.Rows.Add();

                        DG_Managers.Rows[rowNumber].Cells[COL_ID.Name].Value = manager.ID;
                        DG_Managers.Rows[rowNumber].Cells[COL_Name.Name].Value = manager.Name;
                        DG_Managers.Rows[rowNumber].Cells[COL_Surename.Name].Value = manager.Surename;
                        DG_Managers.Rows[rowNumber].Cells[COL_Patronymic.Name].Value = manager.Patronymic;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DG_Managers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==4)
            {
                AdminManagersLicenses adminManagersLicenses = new AdminManagersLicenses(int.Parse(DG_Managers.Rows[e.RowIndex].Cells[0].Value.ToString()));
                adminManagersLicenses.ShowDialog();
            }
            if(e.ColumnIndex==5)
            {

            }
            if(e.ColumnIndex==6)
            {
                DialogResult result = MessageBox.Show($"Удалить менеджера {DG_Managers.Rows[e.RowIndex].Cells[1].Value.ToString()} {DG_Managers.Rows[e.RowIndex].Cells[2].Value.ToString()}", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    using(SupplyDbContext db = new SupplyDbContext())
                    {
                        int id = int.Parse(DG_Managers.Rows[e.RowIndex].Cells[0].Value.ToString());
                        Manager manager = db.Managers.Include(c=>c.Licenses).Where(x=>x.ID==id).First();
                        if(manager!=null)
                        {
                            
                            db.Managers.Remove(manager);
                            db.SaveChanges();
                            MessageBox.Show("Менеджер удален!");
                            UpdateInfo();
                        }
                    }
                    
                }
            }
        }

        private void BTN_OpenManagersAdd_Click(object sender, EventArgs e)
        {
            AdminManagersFormAdd adminAddressesFormAdd = new AdminManagersFormAdd();
            adminAddressesFormAdd.ShowDialog();
            UpdateInfo();
        }
    }
}
