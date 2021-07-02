using Supply.Domain;
using Supply.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class DeclarationElectricityPaymentOrders : Form
    {
        public DeclarationElectricityPaymentOrders()
        {
            InitializeComponent();
        }

        private void DeclarationElectricityPaymentOrders_Shown(object sender, EventArgs e)
        {
            

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_View_ElectricityOrders.Columns.Add(dataGridViewButtonColumn3);


            Thread thread = new Thread(UpdateInf);
            thread.Start();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateInf()
        {
            Action action = () =>
              {
                  using (SupplyDbContext db = new SupplyDbContext())
                  {
                      DG_View_ElectricityOrders.Rows.Clear();

                      try
                      {
                          foreach (ElecricityOrder order in db.ElecricityOrders.Include(t=>t.Tenant).ToList())
                          {
                              int rowNumber = DG_View_ElectricityOrders.Rows.Add();

                              Identification identification = db.Identifications.Where(x => x.ID == order.Tenant.ID).FirstOrDefault();
                              ChangePassport changePassport = db.ChangePassports.Where(x => x.Status == true).Where(t => t.TenantID == order.Tenant.ID).FirstOrDefault();

                              DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_ID.Name].Value = order.ID;
                              if (changePassport != null)
                              {
                                  DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_Tenant.Name].Value = changePassport.Surename + " " + changePassport.Name;
                              }
                              else
                              {
                                  DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_Tenant.Name].Value = identification.Surename + " " + identification.Name;
                              }
                              
                              DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_EndDate.Name].Value = order.EndDate;
                              DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_StartDate.Name].Value = order.StartDate;
                              DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_Status.Name].Value = order.Status;

                              Room room = db.Rooms.Where(x => x.ID == order.Tenant.RoomID).Include(f=>f.Flat).FirstOrDefault();

                              DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_Room.Name].Value = room.Name;

                              Enterance enterance = db.Enterances.Where(x => x.ID == room.Flat.Enterance_ID).Include(h => h.Hostel).FirstOrDefault();

                              DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_Hostel.Name].Value = enterance.Hostel.Name;

                          }
                      }
                      catch (Exception ex)
                      {
                          Log logInfo = new Log();
                          logInfo.ID = Guid.NewGuid();
                          logInfo.CreatedAt = DateTime.Now.ToString();
                          logInfo.Type = "ERROR";
                          logInfo.Caption = $"Class:DeclarationElectricityPaymentOrders. Method: UpdateInf. {ex.Message}. {ex.InnerException}";
                          db.Logs.Add(logInfo);
                          db.SaveChanges();

                          MessageBox.Show(ex.Message);
                      }
                  }
              };
            Invoke(action);
        }

        private void DG_View_ElectricityOrders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                int electricityOrderID = 0;

                if (int.TryParse(DG_View_ElectricityOrders.Rows[e.RowIndex].Cells[0].Value.ToString(), out electricityOrderID))
                {
                    DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить договор электроэнергии?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        using (SupplyDbContext db = new SupplyDbContext())
                        {
                            if (electricityOrderID != 0)
                            {
                                ElecricityOrder elecricityOrder = db.ElecricityOrders.Where(x => x.ID == electricityOrderID).FirstOrDefault();

                                if (elecricityOrder != null)
                                {
                                    try
                                    {
                                        db.ElecricityOrders.Remove(elecricityOrder);
                                        db.SaveChanges();

                                        MessageBox.Show("Договор удален успешно!");

                                        UpdateInf();
                                    }
                                    catch(Exception ex)
                                    {
                                        Log logInfo = new Log();
                                        logInfo.ID = Guid.NewGuid();
                                        logInfo.CreatedAt = DateTime.Now.ToString();
                                        logInfo.Type = "ERROR";
                                        logInfo.Caption = $"Class:DeclarationElectricityPaymentOrders. Method: DG_View_ElectricityOrders_CellMouseClick. {ex.Message}. {ex.InnerException}";
                                        db.Logs.Add(logInfo);
                                        db.SaveChanges();

                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                {
                                    Log logInfo = new Log();
                                    logInfo.ID = Guid.NewGuid();
                                    logInfo.CreatedAt = DateTime.Now.ToString();
                                    logInfo.Type = "WARNING";
                                    logInfo.Caption = $"Class:DeclarationElectricityPaymentOrders. Method: DG_View_ElectricityOrders_CellMouseClick. Значение ID не может быть равным 0";
                                    db.Logs.Add(logInfo);
                                    db.SaveChanges();

                                    MessageBox.Show("Значение ID не может быть равным 0");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
