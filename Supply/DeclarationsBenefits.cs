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
    public partial class DeclarationsBenefits : Form
    {
        public DeclarationsBenefits()
        {
            InitializeComponent();
        }

        private void DeclarationsBenefits_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn1.HeaderText = "Создать документ";
            dataGridViewButtonColumn1.Name = "COL_Create";
            dataGridViewButtonColumn1.Text = "Создать";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            DG_View_Benefits.Columns.Add(dataGridViewButtonColumn1);

            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Изменить";
            dataGridViewButtonColumn2.Name = "COL_Settings";
            dataGridViewButtonColumn2.Text = "Изменить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_View_Benefits.Columns.Add(dataGridViewButtonColumn2);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_View_Benefits.Columns.Add(dataGridViewButtonColumn3);

            Thread thread = new Thread(UpdateInfo);
            thread.Start();
        }

        private void UpdateInfo()
        {
            Action action = () =>
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    DG_View_Benefits.Rows.Clear();

                    try
                    {
                        var benefits = db.Benefits.Include(x => x.Order).Include(y=>y.BenefitType).ToList();

                        foreach (var benefit in benefits)
                        {
                            int rowNumber = DG_View_Benefits.Rows.Add();

                            DG_View_Benefits.Rows[rowNumber].Cells[COL_ID.Name].Value = benefit.ID;
                            DG_View_Benefits.Rows[rowNumber].Cells[COL_OrderNumb.Name].Value = benefit.Order.OrderNumber;
                            DG_View_Benefits.Rows[rowNumber].Cells[COL_Rent.Name].Value = benefit.Payment;
                            DG_View_Benefits.Rows[rowNumber].Cells[COL_Decree.Name].Value = benefit.BasedOn + " от " + benefit.DecreeDate + " №" + benefit.DecreeNumber;
                            DG_View_Benefits.Rows[rowNumber].Cells[COL_StartDate.Name].Value = benefit.StartDate;
                            DG_View_Benefits.Rows[rowNumber].Cells[COL_EndDate.Name].Value = benefit.EndDate;
                            DG_View_Benefits.Rows[rowNumber].Cells[COL_BenefitType.Name].Value = benefit.BenefitType.Name;
                            DG_View_Benefits.Rows[rowNumber].Cells[COL_Status.Name].Value = benefit.Status;

                            Tenant tenant = db.Tenants.Where(x => x.ID == benefit.Order.ID).Include(y => y.Identification).FirstOrDefault();

                            DG_View_Benefits.Rows[rowNumber].Cells[COL_TenantName.Name].Value = tenant.Identification.Surename + " " + tenant.Identification.Name;
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

        private void BTN_CreateBenefits_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(CreateBenefitsDocuments);
            thread.Start();

            MessageBox.Show("Запущен фоновый процесс создания приложений! По окнчанию Вы получите оповещение!");
        }

        private void DG_View_Benefits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==9)
            {
                int idBenefit = int.Parse(DG_View_Benefits.Rows[e.RowIndex].Cells[0].Value.ToString());
                Thread thread = new Thread(new ParameterizedThreadStart(CreateBenefitDocument));
                thread.Start(idBenefit);
                
            }

            if(e.ColumnIndex==10)
            {
                int id = int.Parse(DG_View_Benefits.Rows[e.RowIndex].Cells[0].Value.ToString());

                using(SupplyDbContext db = new SupplyDbContext())
                {
                    Benefit benefit = db.Benefits.Where(x => x.ID == id).First();

                    
                    try
                    {

                        TenantBenefitAdd tenantBenefitAdd = new TenantBenefitAdd(benefit);
                        tenantBenefitAdd.ShowDialog();

                        Thread thread = new Thread(UpdateInfo);
                        thread.Start();
                    }
                    catch(Exception ex)
                    {
                        Log logInfo = new Log();
                        logInfo.ID = Guid.NewGuid();
                        logInfo.Type = "ERROR";
                        logInfo.Caption = $"LoginForm.cs. Class: DeclarationsBenefits. Method: DG_View_Benefits_CellContentClick." + ex.Message + "." + ex.InnerException;
                        logInfo.CreatedAt = DateTime.Now.ToString();
                        db.Logs.Add(logInfo);
                        db.SaveChanges();

                        MessageBox.Show(ex.Message);
                    }
                }

            }

            if(e.ColumnIndex==11)
            {
                
                DialogResult result = MessageBox.Show($"Удалить {DG_View_Benefits.Rows[e.RowIndex].Cells[0].Value.ToString()}", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        int id = int.Parse(DG_View_Benefits.Rows[e.RowIndex].Cells[0].Value.ToString());
                        Models.Benefit benefit = db.Benefits.Where(x => x.ID == id).First();
                        if (benefit != null)
                        {
                            try
                            {
                                db.Benefits.Remove(benefit);
                                db.SaveChanges();
                                MessageBox.Show("Льгота удалена успешно!");
                                Thread thread = new Thread(UpdateInfo);
                                thread.Start();
                            }
                            catch(Exception ex)
                            {
                                Log logInfo = new Log();
                                logInfo.ID = Guid.NewGuid();
                                logInfo.Type = "ERROR";
                                logInfo.Caption = $"Class: DeclarationsBenefits. Method: DG_View_Benefits_CellContentClick. {ex.Message}.{ex.InnerException}";
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

        private void CreateBenefitDocument(object benefitID)
        {
            if (benefitID != null)
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    Benefit benefit = db.Benefits.Where(x => x.ID == (int)benefitID).Where(s => s.Status == true).Include(j => j.Order).FirstOrDefault();
                    if(benefit!=null)
                    {
                        string error = string.Empty;

                        if (OrdersCreation.BenefitCreation(benefit.Order.ID, out error))
                        {
                            MessageBox.Show($"Приложение к договору № {benefit.Order.OrderNumber} на льготу сформирован");
                        }
                        else
                        {
                            Log logInfo = new Log();
                            logInfo.ID = Guid.NewGuid();
                            logInfo.Type = "WARNING";
                            logInfo.Caption = $"DeclarationsBenefits.cs Method: CreateBenefitDocument. {error}";
                            logInfo.CreatedAt = DateTime.Now.ToString();
                            db.Logs.Add(logInfo);
                            db.SaveChanges();

                            MessageBox.Show(error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("У данного приложения к договору статус активности - Не активна");
                    }
                    
                }
            }
            else
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Log logInfo = new Log();
                    logInfo.ID = Guid.NewGuid();
                    logInfo.Type = "WARNING";
                    logInfo.Caption = $"Class: DeclarationsBenefits. Method: CreateBenefitDocument. Null value in benefitID";
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(logInfo);
                    db.SaveChanges();
                }
                
                MessageBox.Show("ID льготы равен NULL!");
            }
            
        }
        private void CreateBenefitsDocuments()
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                var benefits = db.Benefits.Where(x => x.Status == true).Include(o=>o.Order).ToList();

                if(benefits.Count>0)
                {
                    int counter = 0;
                    foreach(Benefit benefit in benefits)
                    {
                        string error = string.Empty;

                        if (!OrdersCreation.BenefitCreation(benefit.Order.ID, out error)) 
                        {
                            Log logInfo = new Log();
                            logInfo.ID = Guid.NewGuid();
                            logInfo.Type = "WARNING";
                            logInfo.Caption = $"DeclarationsBenefits.cs Method: CreateBenefitDocument. {error}";
                            logInfo.CreatedAt = DateTime.Now.ToString();
                            db.Logs.Add(logInfo);
                            db.SaveChanges();

                            MessageBox.Show(error);
                        }
                        else
                        {
                            counter++;
                        }
                    }

                    MessageBox.Show($"{counter} приложений на льготу сформированы!");
                }
                else
                {
                    MessageBox.Show("Нет активных приложений к договорам по льготам!");
                }
            }
        }
    }
}
