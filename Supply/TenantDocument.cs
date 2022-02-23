using Supply.Domain;
using Supply.Models;
using System;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class TenantDocument : Form
    {
        private readonly int tenantID;
        private string documentType;

        public TenantDocument(int tenantID)
        {
            InitializeComponent();
            this.tenantID = tenantID;
            this.documentType = string.Empty;
        }

        private void TenantDocument_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Удалить",
                Name = "COL_Delete",
                Text = "Удалить",
                UseColumnTextForButtonValue = true
            };
            DG_View_Documents.Columns.Add(dataGridViewButtonColumn);

            new Thread(LoadInf).Start();
        }

        private void BTNAdd_Click(object sender, EventArgs e)
        {
            if (documentType == string.Empty)
            {
                MessageBox.Show("Выбирите документ!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(tbStartDate.Text,out _))
            {
                MessageBox.Show("Дата начала не соответсвует реальной дате!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(tbEndDate.Text, out _))
            {
                MessageBox.Show("Дата окончания не соответсвует реальной дате!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Models.TenantDocument tenantDocument = new Models.TenantDocument
                {
                    TenantID = tenantID,
                    Type = documentType,
                    StartDate = tbStartDate.Text,
                    EndDate = tbEndDate.Text,
                    Status = "Действителен"
                };

                using(SupplyDbContext db = new SupplyDbContext())
                {
                    tenantDocument = db.TenantDocuments.Add(tenantDocument);
                    db.SaveChanges();
                }

                int rowCountre = DG_View_Documents.Rows.Add();
                DG_View_Documents.Rows[rowCountre].Cells[COL_ID.Name].Value = tenantDocument.ID;
                DG_View_Documents.Rows[rowCountre].Cells[COL_Type.Name].Value = tenantDocument.Type;
                DG_View_Documents.Rows[rowCountre].Cells[COL_StartDate.Name].Value = tenantDocument.StartDate;
                DG_View_Documents.Rows[rowCountre].Cells[COL_EndDate.Name].Value = tenantDocument.EndDate;
                DG_View_Documents.Rows[rowCountre].Cells[COL_Status.Name].Value = tenantDocument.Status;

                tbEndDate.Text = tbStartDate.Text = string.Empty;

                MessageBox.Show("Документ добавлен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    using(SupplyDbContext db = new SupplyDbContext())
                    {
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            Log logInfo = new Log();
                            logInfo.ID = Guid.NewGuid();
                            logInfo.Type = "ERROR";
                            logInfo.Caption = $"Class: TenantDocument. Method: BTNAdd_Click. {err.ErrorMessage}";
                            logInfo.CreatedAt = DateTime.Now.ToString();
                            db.Logs.Add(logInfo);
                            db.SaveChanges();
                        }
                    }
                }

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Log logInfo = new Log();
                    logInfo.ID = Guid.NewGuid();
                    logInfo.Type = "ERROR";
                    logInfo.Caption = $"Class: TenantDocument. Method: BTNAdd_Click. {ex.InnerException}";
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(logInfo);
                    db.SaveChanges();
                }

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LoadInf()
        {
            try
            {
                Action action = () =>
                {
                    DG_View_Documents.Rows.Clear();

                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        var tenantsDocuments = db.TenantDocuments.Where(x => x.TenantID == tenantID).ToList();

                        foreach(Models.TenantDocument tenantDocument in tenantsDocuments)
                        {
                            int rowCountre = DG_View_Documents.Rows.Add();

                            DG_View_Documents.Rows[rowCountre].Cells[COL_ID.Name].Value = tenantDocument.ID;
                            DG_View_Documents.Rows[rowCountre].Cells[COL_Type.Name].Value = tenantDocument.Type;
                            DG_View_Documents.Rows[rowCountre].Cells[COL_StartDate.Name].Value = tenantDocument.StartDate;
                            DG_View_Documents.Rows[rowCountre].Cells[COL_EndDate.Name].Value = tenantDocument.EndDate;
                            DG_View_Documents.Rows[rowCountre].Cells[COL_Status.Name].Value = tenantDocument.Status;
                        }
                    }
                };
                Invoke(action);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void DG_View_Documents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int tenantDocID = int.Parse(DG_View_Documents.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (tenantDocID != 0 && DialogResult.Yes == MessageBox.Show($"Вы действительно хотите удалить {DG_View_Documents.Rows[e.RowIndex].Cells[1].Value.ToString()}?", "Предупрежденеи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    try
                    {
                        using(SupplyDbContext db = new SupplyDbContext())
                        {
                            Models.TenantDocument tenantDocument = db.TenantDocuments.Where(x => x.ID == tenantDocID).FirstOrDefault();

                            if (tenantDocument == null)
                            {
                                MessageBox.Show("Не найден в базе!");
                                return;
                            }
                            else
                            {
                                db.TenantDocuments.Remove(tenantDocument);
                                db.SaveChanges();

                                DG_View_Documents.Rows.Remove(DG_View_Documents.Rows[e.RowIndex]);

                                MessageBox.Show("Документ успешно удален!");
                            }
                        }
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            using (SupplyDbContext db = new SupplyDbContext())
                            {
                                foreach (DbValidationError err in validationError.ValidationErrors)
                                {
                                    Log logInfo = new Log();
                                    logInfo.ID = Guid.NewGuid();
                                    logInfo.Type = "ERROR";
                                    logInfo.Caption = $"Class: TenantDocument. Method: DG_View_Documents_CellContentClick. {err.ErrorMessage}";
                                    logInfo.CreatedAt = DateTime.Now.ToString();
                                    db.Logs.Add(logInfo);
                                    db.SaveChanges();
                                }
                            }
                        }

                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    catch (Exception ex)
                    {
                        using (SupplyDbContext db = new SupplyDbContext())
                        {
                            Log logInfo = new Log();
                            logInfo.ID = Guid.NewGuid();
                            logInfo.Type = "ERROR";
                            logInfo.Caption = $"Class: TenantDocument. Method: DG_View_Documents_CellContentClick. {ex.InnerException}";
                            logInfo.CreatedAt = DateTime.Now.ToString();
                            db.Logs.Add(logInfo);
                            db.SaveChanges();
                        }

                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void CbDocuments_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                documentType = (string)cbDocuments.SelectedItem;
            }
            catch
            {
                return;
            }
        }
    }
}
