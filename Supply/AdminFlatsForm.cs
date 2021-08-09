using Supply.Domain;
using Supply.Models;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminFlatsForm : Form
    {
        private int _enteranceID;
        public AdminFlatsForm(int enteranceID)
        {
            InitializeComponent();
            _enteranceID = enteranceID;
        }
        private void LogCreate(object information)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Log logInfo = new Log();
                logInfo.ID = Guid.NewGuid();
                logInfo.Type = "ERROR";
                logInfo.Caption = (string)information;
                logInfo.CreatedAt = DateTime.Now.ToString();
                db.Logs.Add(logInfo);
                db.SaveChanges();
            }
        }

        private void LoadInf()
        {
            Action action = () =>
            {
                try
                {
                    DG_View_Flats.Rows.Clear();

                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        var flats = db.Flats.Where(x => x.Enterance_ID == _enteranceID).ToList();


                        foreach (Flat flat in flats)
                        {
                            int rowNumber = DG_View_Flats.Rows.Add();

                            DG_View_Flats.Rows[rowNumber].Cells[COL_ID.Name].Value = flat.ID;
                            DG_View_Flats.Rows[rowNumber].Cells[COL_Name.Name].Value = flat.Name;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(LogCreate));
                    thread.Start($"Class: AdminFlatsForm. Method: LoadInf. {ex.Message}. {ex.InnerException}");
                    MessageBox.Show(ex.Message);
                }
            };

            Invoke(action);
        }

        private void AdminFlatsForm_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Изменить";
            dataGridViewButtonColumn3.Name = "COL_Edit";
            dataGridViewButtonColumn3.Text = "Изменить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_View_Flats.Columns.Add(dataGridViewButtonColumn3);

            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Удалить";
            dataGridViewButtonColumn2.Name = "COL_Delete";
            dataGridViewButtonColumn2.Text = "Удалить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_View_Flats.Columns.Add(dataGridViewButtonColumn2);

            Thread thread = new Thread(LoadInf);
            thread.Start();
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            AdminFlatsFormAdd adminFlatsFormAdd = new AdminFlatsFormAdd(_enteranceID);
            adminFlatsFormAdd.ShowDialog();
            LoadInf();
        }

        private void DG_View_Flats_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int flatID = 0;
                if (int.TryParse(DG_View_Flats.Rows[e.RowIndex].Cells[0].Value.ToString(), out flatID))
                {
                    AdminFlatsFormAdd adminEnteranceFormAdd = new AdminFlatsFormAdd(_enteranceID, flatID);
                    adminEnteranceFormAdd.ShowDialog();
                    LoadInf();
                }
            }
            if (e.ColumnIndex == 3)
            {
                int flatID = 0;

                if (int.TryParse(DG_View_Flats.Rows[e.RowIndex].Cells[0].Value.ToString(), out flatID))
                {
                    DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить этаж и всё его содержимое?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        using (SupplyDbContext db = new SupplyDbContext())
                        {
                            try
                            {
                                Flat flat = db.Flats.Where(x => x.ID == flatID).FirstOrDefault();

                                if (flat == null)
                                {
                                    MessageBox.Show("Этаж не найден!");
                                    return;
                                }

                                db.Flats.Remove(flat);
                                db.SaveChanges();

                                MessageBox.Show("Этаж удален успешно!");

                                LoadInf();
                            }
                            catch (Exception ex)
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(LogCreate));
                                thread.Start($"Class:AdminFlatsForm. Method: DG_View_Flats_CellMouseClick. {ex.Message}. {ex.InnerException}");
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
        }
    }
}
