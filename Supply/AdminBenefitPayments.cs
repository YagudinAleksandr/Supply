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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminBenefitPayments : Form
    {
        public AdminBenefitPayments()
        {
            InitializeComponent();
        }

        private void AdminBenefitPayments_Shown(object sender, EventArgs e)
        {

            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Настройки";
            dataGridViewButtonColumn2.Name = "COL_Settings";
            dataGridViewButtonColumn2.Text = "Изменить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_View_BenefitPayments.Columns.Add(dataGridViewButtonColumn2);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_View_BenefitPayments.Columns.Add(dataGridViewButtonColumn3);

            Thread thread = new Thread(LoadInformation);
            thread.Start();
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            AdminBenefitPaymentAdd adminBenefitPaymentAdd = new AdminBenefitPaymentAdd();
            adminBenefitPaymentAdd.ShowDialog();

            Thread thread = new Thread(LoadInformation);
            thread.Start();

        }

        private void DG_View_BenefitPayments_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int paymentID = 0;

            if (e.ColumnIndex == 5)
            {
                if (int.TryParse(DG_View_BenefitPayments.Rows[e.RowIndex].Cells[0].Value.ToString(), out paymentID)) 
                {
                    AdminBenefitPaymentAdd adminBenefitPaymentAdd = new AdminBenefitPaymentAdd(paymentID);
                    adminBenefitPaymentAdd.ShowDialog();

                    Thread thread = new Thread(LoadInformation);
                    thread.Start();
                }
            }

            if (e.ColumnIndex == 6)
            {
                if (int.TryParse(DG_View_BenefitPayments.Rows[e.RowIndex].Cells[0].Value.ToString(), out paymentID))
                {
                    DialogResult dialogResult = MessageBox.Show("Вы уверины, что хотите удалить тариф?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        using(SupplyDbContext db = new SupplyDbContext())
                        {
                            BenefitPayment benefitPayment = db.BenefitPayments.Where(x => x.ID == paymentID).FirstOrDefault();
                            if(benefitPayment==null)
                            {
                                MessageBox.Show("Тарифный план не найден!");
                            }

                            try
                            {
                                db.BenefitPayments.Remove(benefitPayment);
                                db.SaveChanges();
                                MessageBox.Show("Тарифный план удален успешно!");

                                Thread thread = new Thread(LoadInformation);
                                thread.Start();
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);

                                Log logInfo = new Log();
                                logInfo.ID = Guid.NewGuid();
                                logInfo.Type = "ERROR";
                                logInfo.Caption = $"Class: AdminBenefitPayments. Method: DG_View_BenefitPayments_CellMouseClick. {ex.Message}. {ex.InnerException}";
                                logInfo.CreatedAt = DateTime.Now.ToString();
                                db.Logs.Add(logInfo);
                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        private void LoadInformation()
        {
            Action action = () =>
              {

                  using (SupplyDbContext db = new SupplyDbContext())
                  {
                      DG_View_BenefitPayments.Rows.Clear();

                        foreach (BenefitPayment benefitPayment in db.BenefitPayments.Include(x => x.Hostel).Include(y => y.BenefitType).ToList())
                        {
                          int rowNumber = DG_View_BenefitPayments.Rows.Add();

                          DG_View_BenefitPayments.Rows[rowNumber].Cells[COL_ID.Name].Value = benefitPayment.ID;
                          DG_View_BenefitPayments.Rows[rowNumber].Cells[COL_Hostel.Name].Value = benefitPayment.Hostel.Name;
                          DG_View_BenefitPayments.Rows[rowNumber].Cells[COL_Price.Name].Value = benefitPayment.Price;
                          DG_View_BenefitPayments.Rows[rowNumber].Cells[COL_Status.Name].Value = benefitPayment.Status;
                          DG_View_BenefitPayments.Rows[rowNumber].Cells[COL_BenefitType.Name].Value = benefitPayment.BenefitType.Name;
                        }
                  }

              };
            Invoke(action);
            
        }
    }
}
