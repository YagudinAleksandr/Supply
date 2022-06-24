using Supply.Domain;
using Supply.Libs;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class DeclarationTerminations : Form
    {
        public DeclarationTerminations()
        {
            InitializeComponent();
        }

        private void DG_View_Terminations_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex==7)
            {
                try
                {
                    int terminationID = 0;
                    if (int.TryParse(DG_View_Terminations.Rows[e.RowIndex].Cells[0].Value.ToString(), out terminationID))
                    {
                        string error;
                        OrdersCreation.CreateTerminationOrder(terminationID, out error);

                        if (!string.IsNullOrEmpty(error))
                            throw new Exception(error);
                    }
                    
                }
                catch(Exception ex)
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        Log logInfo = new Log();
                        logInfo.ID = Guid.NewGuid();
                        logInfo.Type = "ERROR";
                        logInfo.Caption = $"Class: DeclarationTerminations. Method: DG_View_Terminations_CellMouseClick. {ex.Message}.{ex.InnerException}";
                        logInfo.CreatedAt = DateTime.Now.ToString();
                        db.Logs.Add(logInfo);
                        db.SaveChanges();
                    }
                    MessageBox.Show(ex.Message);
                }
            }
            if(e.ColumnIndex==8)
            {
                int terminationID = 0;
                if (int.TryParse(DG_View_Terminations.Rows[e.RowIndex].Cells[0].Value.ToString(), out terminationID))
                {
                    DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить приложение на расторжение?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(dialogResult==DialogResult.Yes)
                    {
                        using (SupplyDbContext db = new SupplyDbContext())
                        {
                            Termination termination = db.Terminations.Where(x => x.ID == terminationID).FirstOrDefault();

                            try
                            {
                                db.Terminations.Remove(termination);
                                db.SaveChanges();
                                Thread thread = new Thread(UpdateInform);
                                thread.Start();
                                MessageBox.Show("Приложение на расторжение удалено успешно!");
                            }
                            catch(Exception ex)
                            {
                                Log logInfo = new Log();
                                logInfo.ID = Guid.NewGuid();
                                logInfo.Type = "ERROR";
                                logInfo.Caption = $"Class: DeclarationTerminations. Method: DG_View_Terminations_CellMouseClick. {ex.Message}.{ex.InnerException}";
                                logInfo.CreatedAt = DateTime.Now.ToString();
                                db.Logs.Add(logInfo);
                                db.SaveChanges();

                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
        }

        private void DeclarationTerminations_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn1.HeaderText = "Создать документ";
            dataGridViewButtonColumn1.Name = "COL_CreateOrder";
            dataGridViewButtonColumn1.Text = "Создать";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            DG_View_Terminations.Columns.Add(dataGridViewButtonColumn1);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_View_Terminations.Columns.Add(dataGridViewButtonColumn3);

            Thread thread = new Thread(UpdateInform);
            thread.Start();
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            
        }
        private void UpdateInform()
        {
            Action action = () =>
              {
                  DG_View_Terminations.Rows.Clear();

                  using (SupplyDbContext db = new SupplyDbContext())
                  {
                      var terminations = db.Terminations.Include(or=>or.Order).ToList();

                      foreach(Termination termination in terminations)
                      {
                          int rowNumber = DG_View_Terminations.Rows.Add();

                          DG_View_Terminations.Rows[rowNumber].Cells[COL_ID.Name].Value = termination.ID;
                          DG_View_Terminations.Rows[rowNumber].Cells[COL_Date.Name].Value = termination.Date;
                          DG_View_Terminations.Rows[rowNumber].Cells[COL_CreatedAt.Name].Value = termination.CreatedAt;
                          DG_View_Terminations.Rows[rowNumber].Cells[COL_UpdatedAt.Name].Value = termination.UpdatedAt;
                          DG_View_Terminations.Rows[rowNumber].Cells[COL_Orer.Name].Value = termination.Order.OrderNumber;

                          Tenant tenant = db.Tenants.Where(x => x.ID == termination.Order.ID).Include(i => i.Identification).FirstOrDefault();
                          ChangePassport changePassport = db.ChangePassports.Where(x => x.TenantID == tenant.ID).Where(s => s.Status == true).FirstOrDefault();

                          if (changePassport != null)
                          {
                              DG_View_Terminations.Rows[rowNumber].Cells[COL_Tenant.Name].Value = changePassport.Surename + " " + changePassport.Name;
                              if (changePassport.Patronymic != null)
                              {
                                  DG_View_Terminations.Rows[rowNumber].Cells[COL_Tenant.Name].Value += " " + changePassport.Patronymic;
                              }
                          }
                          else
                          {
                              DG_View_Terminations.Rows[rowNumber].Cells[COL_Tenant.Name].Value = tenant.Identification.Surename + " " + tenant.Identification.Name;
                              if (tenant.Identification.Patronymic != null)
                              {
                                  DG_View_Terminations.Rows[rowNumber].Cells[COL_Tenant.Name].Value += " " + tenant.Identification.Patronymic;
                              }
                          }

                          if(termination.Status==true)
                          {
                              DG_View_Terminations.Rows[rowNumber].Cells[COL_Status.Name].Value = "Расторгнут";

                          }
                          else
                          {
                              DG_View_Terminations.Rows[rowNumber].Cells[COL_Status.Name].Value = "Ожидает расторжения";
                          }
                      }
                  }
              };
            Invoke(action);
        }
    }
}
