using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminEnteranceForm : Form
    {
        private int _hostelID;
        public AdminEnteranceForm(int hostelID)
        {
            InitializeComponent();
            _hostelID = hostelID;
        }

        private void AdminEnteranceForm_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn1.HeaderText = "Этажи";
            dataGridViewButtonColumn1.Name = "COL_Flats";
            dataGridViewButtonColumn1.Text = "Этажы";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            DG_View_Enterances.Columns.Add(dataGridViewButtonColumn1);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Изменить";
            dataGridViewButtonColumn3.Name = "COL_Edit";
            dataGridViewButtonColumn3.Text = "Изменить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_View_Enterances.Columns.Add(dataGridViewButtonColumn3);

            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Удалить";
            dataGridViewButtonColumn2.Name = "COL_Delete";
            dataGridViewButtonColumn2.Text = "Удалить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_View_Enterances.Columns.Add(dataGridViewButtonColumn2);

            Thread thread = new Thread(LoadInf);
            thread.Start();
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            AdminEnteranceFormAdd adminEnteranceFormAdd = new AdminEnteranceFormAdd(_hostelID);
            adminEnteranceFormAdd.ShowDialog();
            LoadInf();
        }

        private void DG_View_Enterances_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int enteranceID = 0;

                if (int.TryParse(DG_View_Enterances.Rows[e.RowIndex].Cells[0].Value.ToString(), out enteranceID))
                {
                    AdminFlatsForm adminEnteranceFormAdd = new AdminFlatsForm(enteranceID);
                    adminEnteranceFormAdd.Show();
                }
            }
            if (e.ColumnIndex == 3)
            {
                int enteranceID = 0;

                if (int.TryParse(DG_View_Enterances.Rows[e.RowIndex].Cells[0].Value.ToString(), out enteranceID))
                {
                    AdminEnteranceFormAdd adminEnteranceFormAdd = new AdminEnteranceFormAdd(enteranceID, _hostelID);
                    adminEnteranceFormAdd.ShowDialog();
                    LoadInf();
                }

            }
            if (e.ColumnIndex == 4) 
            {
                int enteranceID = 0;

                if (int.TryParse(DG_View_Enterances.Rows[e.RowIndex].Cells[0].Value.ToString(), out enteranceID))
                {
                    DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить подъезд и всё его содержимое?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if(dialogResult == DialogResult.Yes)
                    {
                        using (SupplyDbContext db = new SupplyDbContext())
                        {
                            try
                            {
                                Enterance enterance = db.Enterances.Where(x => x.ID == enteranceID).FirstOrDefault();

                                if (enterance == null)
                                {
                                    MessageBox.Show("Подъезд не найден!");
                                    return;
                                }

                                db.Enterances.Remove(enterance);
                                db.SaveChanges();

                                MessageBox.Show("Подъезд удален успешно!");

                                LoadInf();
                            }
                            catch(Exception ex)
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(LogCreate));
                                thread.Start($"Class:AdminEnteranceForm. Method: DG_View_Enterances_CellMouseClick. {ex.Message}. {ex.InnerException}");
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
        }

        private void LoadInf()
        {
            Action action = () =>
              {
                  try
                  {
                      DG_View_Enterances.Rows.Clear();

                      using(SupplyDbContext db = new SupplyDbContext())
                      {
                          var enterances = db.Enterances.Where(x => x.HostelId == _hostelID).ToList();


                          foreach(Enterance enterance in enterances)
                          {
                              int rowNumber = DG_View_Enterances.Rows.Add();

                              DG_View_Enterances.Rows[rowNumber].Cells[COL_ID.Name].Value = enterance.ID;
                              DG_View_Enterances.Rows[rowNumber].Cells[COL_Name.Name].Value = enterance.Name;
                          }
                      }
                  }
                  catch(Exception ex)
                  {
                      Thread thread = new Thread(new ParameterizedThreadStart(LogCreate));
                      thread.Start($"Class:AdminEnteranceForm. Method: LoadInf. {ex.Message}. {ex.InnerException}");
                      MessageBox.Show(ex.Message);
                  }
              };

            Invoke(action);
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
    }
}
