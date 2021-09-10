using Supply.Domain;
using Supply.Libs;
using Supply.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminTenantsForm : Form
    {
        public AdminTenantsForm()
        {
            InitializeComponent();
        }

        private void AdminTenantsForm_Load(object sender, EventArgs e)
        {

            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Настройки";
            dataGridViewButtonColumn2.Name = "COL_Settings";
            dataGridViewButtonColumn2.Text = "Изменить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_TenantsView.Columns.Add(dataGridViewButtonColumn2);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_TenantsView.Columns.Add(dataGridViewButtonColumn3);

            Thread thread = new Thread(UpdateInfo);
            thread.Start();
        }

        private void UpdateInfo()
        {
            Action action = () =>
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    DG_TenantsView.Rows.Clear();

                    try
                    {
                        var tenants = db.Tenants.ToList();

                        foreach (var tenant in tenants)
                        {
                            int rowNumber = DG_TenantsView.Rows.Add();

                            DG_TenantsView.Rows[rowNumber].Cells[COL_ID.Name].Value = tenant.ID;
                            DG_TenantsView.Rows[rowNumber].Cells[COL_Status.Name].Value = tenant.Status;
                            DG_TenantsView.Rows[rowNumber].Cells[COL_CreatedAt.Name].Value = tenant.CreatedAt;
                            DG_TenantsView.Rows[rowNumber].Cells[COL_UpdatedAt.Name].Value = tenant.UpdatedAt;
                            Order order = db.Orders.Where(x => x.ID == tenant.ID).FirstOrDefault();
                            if (order != null)
                            {
                                DG_TenantsView.Rows[rowNumber].Cells[COL_Order.Name].Value = order.OrderNumber;
                            }
                            else
                            {
                                DG_TenantsView.Rows[rowNumber].Cells[COL_Order.Name].Value = "-";
                            }
                            Identification identification = db.Identifications.Include(p => p.DocumentType).Where(x => x.ID == tenant.ID).FirstOrDefault();
                            if (identification != null)
                            {
                                DG_TenantsView.Rows[rowNumber].Cells[COL_Name.Name].Value = identification.Name;
                                DG_TenantsView.Rows[rowNumber].Cells[COL_Surename.Name].Value = identification.Surename;
                                DG_TenantsView.Rows[rowNumber].Cells[COL_Patronymic.Name].Value = identification.Patronymic;
                                DG_TenantsView.Rows[rowNumber].Cells[COL_DocType.Name].Value = identification.DocumentType.Name;
                                DG_TenantsView.Rows[rowNumber].Cells[COL_Series.Name].Value = identification.DocumentSeries;
                                DG_TenantsView.Rows[rowNumber].Cells[COL_DocNumb.Name].Value = identification.DocumentNumber;
                            }
                            else
                            {
                                DG_TenantsView.Rows[rowNumber].Cells[COL_Name.Name].Value = "-";
                                DG_TenantsView.Rows[rowNumber].Cells[COL_Surename.Name].Value = "-";
                                DG_TenantsView.Rows[rowNumber].Cells[COL_Patronymic.Name].Value = "-";
                                DG_TenantsView.Rows[rowNumber].Cells[COL_DocType.Name].Value = "-";
                                DG_TenantsView.Rows[rowNumber].Cells[COL_Series.Name].Value = "-";
                                DG_TenantsView.Rows[rowNumber].Cells[COL_DocNumb.Name].Value = "-";
                            }
                            DG_TenantsView.Rows[rowNumber].Cells[COL_Faculty.Name].Value = OrdersCreation.AdditionalInf(3, tenant.ID);
                            if(OrdersCreation.AdditionalInf(10, tenant.ID)==string.Empty)
                            {
                                DG_TenantsView.Rows[rowNumber].Cells[COL_Institute.Name].Value = "НИМИ";
                            }
                            else
                            {
                                DG_TenantsView.Rows[rowNumber].Cells[COL_Institute.Name].Value = "Стороннее";
                            }
                            
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

        private void DG_TenantsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                int tenantIndex = int.Parse(DG_TenantsView.Rows[e.RowIndex].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Удалить жильца?", "Удалить жильца", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(DialogResult.Yes==result)
                {
                    using(SupplyDbContext db = new SupplyDbContext())
                    {
                        Tenant tenant = db.Tenants.Include(x=>x.Identification).Include(p=>p.Order).Where(x => x.ID == tenantIndex).First();
                        if (tenant != null)
                        {

                            db.Tenants.Remove(tenant);
                            db.SaveChanges();
                            MessageBox.Show("Жилец удален!");
                            DG_TenantsView.Rows.Remove(DG_TenantsView.Rows[e.RowIndex]);
                        }
                    }
                }
            }

            if (e.ColumnIndex == 13)
            {
                int tenantIndex = int.Parse(DG_TenantsView.Rows[e.RowIndex].Cells[0].Value.ToString());

                TenantUpdateInformation tenantUpdateInformation = new TenantUpdateInformation(tenantIndex);
                tenantUpdateInformation.ShowDialog();

                MessageBox.Show("Жилец изменен!");
            }
        }
    }
}
