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
    public partial class AdminPaymentsElectricityElements : Form
    {
        private int _paymentID;
        public AdminPaymentsElectricityElements(int paymentID)
        {
            InitializeComponent();
            _paymentID = paymentID;
        }

        private void AdminPaymentsElectricityElements_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_View_Elements.Columns.Add(dataGridViewButtonColumn3);

            using (SupplyDbContext db = new SupplyDbContext())
            {
                DG_View_Elements.Rows.Clear();

                try
                {
                    foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(pid => pid.ElectricityPaymentID == _paymentID).ToList()) 
                    {
                        int rowNumber = DG_View_Elements.Rows.Add();

                        DG_View_Elements.Rows[rowNumber].Cells[COL_ID.Name].Value = electricityElement.ID;
                        DG_View_Elements.Rows[rowNumber].Cells[COL_Name.Name].Value = electricityElement.Name;
                        DG_View_Elements.Rows[rowNumber].Cells[COL_Capacity.Name].Value = electricityElement.Capacity;
                        DG_View_Elements.Rows[rowNumber].Cells[COL_Sum.Name].Value = electricityElement.Payment;
                    }

                }
                catch (Exception ex)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                    thread.Start("Class:AdminPaymentsElectricityElements.cs. Method: AdminPaymentsElectricityElements_Shown." + ex.Message + "." + ex.InnerException);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                foreach(DataGridViewRow dataGridViewRow in DG_View_Elements.Rows)
                {
                    if (dataGridViewRow.Cells[1].Value != null && dataGridViewRow.Cells[2].Value != null && dataGridViewRow.Cells[3].Value != null)
                    {
                        if (dataGridViewRow.Cells[0].Value != null)
                        {
                            int elementID = int.Parse(dataGridViewRow.Cells[0].Value.ToString());
                            ElectricityElement electricityElement = db.ElectricityElements.Where(id => id.ID == elementID).FirstOrDefault();
                            if (electricityElement != null)
                            {
                                electricityElement.Name = dataGridViewRow.Cells[1].Value.ToString();
                                decimal coast = 0;
                                int capacity = 0;

                                if (decimal.TryParse(dataGridViewRow.Cells[3].Value.ToString(), out coast) && int.TryParse(dataGridViewRow.Cells[2].Value.ToString(), out capacity)) 
                                {
                                    electricityElement.Payment = coast;
                                    electricityElement.Capacity = capacity;

                                    electricityElement.UpdatedAt = DateTime.Now.ToString();

                                    try
                                    {
                                        db.Entry(electricityElement).State = System.Data.Entity.EntityState.Modified;
                                        db.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                                        thread.Start("Class:AdminPaymentsElectricityElements.cs. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException);
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                            else
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                                thread.Start("Class: AdminPaymentsElectricityElements. Method: BTN_Save_Click. When update elements information, value in Db was null");
                            }

                            
                        }
                        else
                        {
                            ElectricityElement electricityElement = new ElectricityElement();
                            electricityElement.ElectricityPaymentID = _paymentID;
                            electricityElement.CreatedAt = DateTime.Now.ToString();
                            electricityElement.UpdatedAt = DateTime.Now.ToString();
                            electricityElement.Name = dataGridViewRow.Cells[1].Value.ToString();
                            decimal coast = 0;
                            int capacity = 0;

                            if (decimal.TryParse(dataGridViewRow.Cells[3].Value.ToString(), out coast) && int.TryParse(dataGridViewRow.Cells[2].Value.ToString(), out capacity)) 
                            {
                                electricityElement.Payment = coast;
                                electricityElement.Capacity = capacity;

                                try
                                {
                                    db.ElectricityElements.Add(electricityElement);
                                    db.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                                    thread.Start("Class:AdminPaymentsElectricityElements. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException);
                                    MessageBox.Show($"{ex.Message}");
                                }
                            }

                            
                        }

                    }
                }

                MessageBox.Show("Данные сохранены!");
                UpdateInform();
            }
        }

        private void DG_View_Elements_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить данные?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (DG_View_Elements.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        int id = 0;
                        if (int.TryParse(DG_View_Elements.Rows[e.RowIndex].Cells[0].Value.ToString(), out id))
                        {
                            if (id != 0)
                            {
                                using (SupplyDbContext db = new SupplyDbContext())
                                {
                                    ElectricityElement electricityElement = db.ElectricityElements.Where(x => x.ID == id).FirstOrDefault();
                                    if (electricityElement != null)
                                    {
                                        db.ElectricityElements.Remove(electricityElement);
                                        db.SaveChanges();

                                        DG_View_Elements.Rows.RemoveAt(e.RowIndex);
                                        DG_View_Elements.Refresh();
                                    }
                                }
                            }
                        }
                    }

                }
                else
                {
                    DG_View_Elements.Rows.RemoveAt(e.RowIndex);
                    DG_View_Elements.Refresh();
                }
            }
        }
        private void UpdateInform()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                DG_View_Elements.Rows.Clear();

                try
                {
                    foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(pid => pid.ElectricityPaymentID == _paymentID).ToList())
                    {
                        int rowNumber = DG_View_Elements.Rows.Add();

                        DG_View_Elements.Rows[rowNumber].Cells[COL_ID.Name].Value = electricityElement.ID;
                        DG_View_Elements.Rows[rowNumber].Cells[COL_Name.Name].Value = electricityElement.Name;
                        DG_View_Elements.Rows[rowNumber].Cells[COL_Capacity.Name].Value = electricityElement.Capacity;
                        DG_View_Elements.Rows[rowNumber].Cells[COL_Sum.Name].Value = electricityElement.Payment;
                    }

                }
                catch (Exception ex)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                    thread.Start("Class:AdminPaymentsElectricityElements.cs. Method: AdminPaymentsElectricityElements_Shown." + ex.Message + "." + ex.InnerException);
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void AddLog(object error)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Log logInfo = new Log();
                logInfo.ID = Guid.NewGuid();
                logInfo.Type = "ERROR";
                logInfo.Caption = (string)error;
                logInfo.CreatedAt = DateTime.Now.ToString();
                db.Logs.Add(logInfo);
                db.SaveChanges();
            }
        }
    }
}
