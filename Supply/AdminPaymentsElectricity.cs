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
    public partial class AdminPaymentsElectricity : Form
    {
        public AdminPaymentsElectricity()
        {
            InitializeComponent();
        }

        private void AdminPaymentsElectricity_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn1.HeaderText = "Элементы";
            dataGridViewButtonColumn1.Name = "COL_Elements";
            dataGridViewButtonColumn1.Text = "Элементы";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            DG_View_Electricity.Columns.Add(dataGridViewButtonColumn1);

            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Настройки";
            dataGridViewButtonColumn2.Name = "COL_Settings";
            dataGridViewButtonColumn2.Text = "Изменить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_View_Electricity.Columns.Add(dataGridViewButtonColumn2);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_View_Electricity.Columns.Add(dataGridViewButtonColumn3);

            Thread thread = new Thread(UpdateInformation);
            thread.Start();
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            AdminPaymentsElectricityPaymentAdd adminPaymentsElectricityPaymentAdd = new AdminPaymentsElectricityPaymentAdd();
            adminPaymentsElectricityPaymentAdd.ShowDialog();
            Thread thread = new Thread(UpdateInformation);
            thread.Start();
        }

        private void UpdateInformation()
        {
            Action action = () =>
              {
                  using (SupplyDbContext db = new SupplyDbContext())
                  {
                      DG_View_Electricity.Rows.Clear();

                      try
                      {
                          foreach(ElectricityPayment electricityPayment in db.ElectricityPayments.Include(hostel=>hostel.Hostel).ToList())
                          {
                              int rowNumber = DG_View_Electricity.Rows.Add();

                              DG_View_Electricity.Rows[rowNumber].Cells[COL_ID.Name].Value = electricityPayment.ID;
                              DG_View_Electricity.Rows[rowNumber].Cells[COL_Name.Name].Value = electricityPayment.Name;
                              DG_View_Electricity.Rows[rowNumber].Cells[COL_Hostel.Name].Value = electricityPayment.Hostel.Name;
                              DG_View_Electricity.Rows[rowNumber].Cells[COL_Status.Name].Value = electricityPayment.Status;
                              DG_View_Electricity.Rows[rowNumber].Cells[COL_CreatedAt.Name].Value = electricityPayment.CreatedAt;
                              DG_View_Electricity.Rows[rowNumber].Cells[COL_UpdatedAt.Name].Value = electricityPayment.UpdatedAt;
                          }
                          

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }
              };
            Invoke(action);
        }

        private void DG_View_Electricity_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                int paymentID = 0;
                int.TryParse(DG_View_Electricity.Rows[e.RowIndex].Cells[0].Value.ToString(), out paymentID);
                if (paymentID != 0)
                {
                    AdminPaymentsElectricityElements adminPaymentsElectricityElements = new AdminPaymentsElectricityElements(paymentID);
                    adminPaymentsElectricityElements.ShowDialog();
                }
                
            }

            if (e.ColumnIndex == 7)
            {
                int paymentID = 0;
                int.TryParse(DG_View_Electricity.Rows[e.RowIndex].Cells[0].Value.ToString(), out paymentID);
                if (paymentID != 0)
                {
                    AdminPaymentsElectricityPaymentAdd adminPaymentsElectricityPaymentAdd = new AdminPaymentsElectricityPaymentAdd(paymentID);
                    adminPaymentsElectricityPaymentAdd.ShowDialog();
                    UpdateInformation();
                }
            }

            if (e.ColumnIndex == 8)
            {
                DialogResult result = MessageBox.Show("Удалить тарифный план?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        int paymentID = 0;
                        int.TryParse(DG_View_Electricity.Rows[e.RowIndex].Cells[0].Value.ToString(), out paymentID);

                        if (paymentID != 0)
                        {
                            ElectricityPayment electricityPayment = db.ElectricityPayments.Where(x => x.ID == paymentID).FirstOrDefault();
                            if (electricityPayment != null)
                            {
                                try
                                {
                                    db.ElectricityPayments.Remove(electricityPayment);
                                    db.SaveChanges();
                                    MessageBox.Show("Тарифный план удален успешно");
                                    UpdateInformation();
                                }
                                catch (Exception ex)
                                {
                                    //Создаем LOG запись об удалении!
                                    Log logInfo = new Log();
                                    logInfo.ID = Guid.NewGuid();
                                    logInfo.CreatedAt = DateTime.Now.ToString();
                                    logInfo.Type = "ERROR";
                                    logInfo.Caption = $"Class:AdminPaymentsElectricity.cs. Method: DG_View_Electricity_CellMouseClick. {ex.Message}. {ex.InnerException}";
                                    db.Logs.Add(logInfo);
                                    db.SaveChanges();

                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
