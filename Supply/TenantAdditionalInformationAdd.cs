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
    public partial class TenantAdditionalInformationAdd : Form
    {
        private int _tenantId;
        private List<AdditionalInformationType> _additionalInformationType;
        public TenantAdditionalInformationAdd(int tenantId)
        {
            InitializeComponent();
            _tenantId = tenantId;
            using (SupplyDbContext db = new SupplyDbContext())
            {
                _additionalInformationType = db.AdditionalInformationTypes.ToList();
            }
        }

        private void TenantAdditionalInformationAdd_Load(object sender, EventArgs e)
        {
            this.COL_Type.DataSource = _additionalInformationType;
            this.COL_Type.DisplayMember = "Name";
            this.COL_Type.ValueMember = "ID";

            using(SupplyDbContext db = new SupplyDbContext())
            {
                DG_ViewAdditionalInformation.Rows.Clear();

                try
                {
                    foreach (AdditionalInformation additionalInformation in db.AdditionalInformation.Where(tid=>tid.TenantID==_tenantId).Include(t=>t.AdditionalInformationType))
                    {
                        int rowNumber = DG_ViewAdditionalInformation.Rows.Add();

                        DG_ViewAdditionalInformation.Rows[rowNumber].Cells[COL_ID.Name].Value = additionalInformation.ID;
                        DG_ViewAdditionalInformation.Rows[rowNumber].Cells[COL_Type.Name].Value = additionalInformation.AdditionalInformationType.ID;
                        DG_ViewAdditionalInformation.Rows[rowNumber].Cells[COL_Information.Name].Value = additionalInformation.Value;
                    }

                }
                catch (Exception ex)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                    thread.Start("Class:TenantAdditionalInformationAdd.cs. Method: TenantAdditionalInformationAdd_Load." + ex.Message + "." + ex.InnerException);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DG_ViewAdditionalInformation_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.COL_Type.DataSource = _additionalInformationType;
            this.COL_Type.DisplayMember = "Name";
            this.COL_Type.ValueMember = "ID";
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                foreach (DataGridViewRow dataGridViewRow in DG_ViewAdditionalInformation.Rows)
                {
                    if (dataGridViewRow.Cells[1].Value != null && dataGridViewRow.Cells[2].Value != null) 
                    {
                        if (dataGridViewRow.Cells[0].Value != null) 
                        {
                            int addInfId = int.Parse(dataGridViewRow.Cells[0].Value.ToString());
                            AdditionalInformation additionalInformation = db.AdditionalInformation.Where(id => id.ID == addInfId).FirstOrDefault();
                            if(additionalInformation!=null)
                            {
                                additionalInformation.AdditionalInformationTypeID = int.Parse(dataGridViewRow.Cells[1].Value.ToString());
                                additionalInformation.Value = dataGridViewRow.Cells[2].Value.ToString();
                            }
                            else
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                                thread.Start("Class: TenantAdditionalInformationAdd. Method: BTN_Save_Click. When update additional information, value in Db was null");
                            }

                            try
                            {
                                db.Entry(additionalInformation).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                            catch(Exception ex)
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                                thread.Start("Class:TenantAdditionalInformationAdd.cs. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException);
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            AdditionalInformation additionalInformation = new AdditionalInformation();
                            additionalInformation.TenantID = _tenantId;
                            additionalInformation.AdditionalInformationTypeID = int.Parse(dataGridViewRow.Cells[1].Value.ToString());
                            additionalInformation.Value = dataGridViewRow.Cells[2].Value.ToString();

                            try
                            {
                                db.AdditionalInformation.Add(additionalInformation);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                                thread.Start("Class:TenantAdditionalInformationAdd.cs. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException);
                                MessageBox.Show($"{ex.Message}");
                            }
                        }
                        
                    }
                }
                MessageBox.Show("Информация добавлена успешно!");
                this.Close();
            }
            
        }

        private void TenantAdditionalInformationAdd_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_ViewAdditionalInformation.Columns.Add(dataGridViewButtonColumn3);
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

        private void DG_ViewAdditionalInformation_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3) 
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить данные?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result==DialogResult.Yes)
                {
                    if (DG_ViewAdditionalInformation.Rows[e.RowIndex].Cells[0].Value != null) 
                    {
                        int id = 0;
                        if (int.TryParse(DG_ViewAdditionalInformation.Rows[e.RowIndex].Cells[0].Value.ToString(), out id))
                        {
                            if (id != 0)
                            {
                                using (SupplyDbContext db = new SupplyDbContext())
                                {
                                    AdditionalInformation additionalInformation = db.AdditionalInformation.Where(x => x.ID == id).FirstOrDefault();
                                    if(additionalInformation!=null)
                                    {
                                        db.AdditionalInformation.Remove(additionalInformation);
                                        db.SaveChanges();

                                        DG_ViewAdditionalInformation.Rows.RemoveAt(e.RowIndex);
                                        DG_ViewAdditionalInformation.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    
                }
                else
                {
                    DG_ViewAdditionalInformation.Rows.RemoveAt(e.RowIndex);
                    DG_ViewAdditionalInformation.Refresh();
                }
            }
        }
    }
}
