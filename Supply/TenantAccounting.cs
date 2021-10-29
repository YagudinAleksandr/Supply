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
    public partial class TenantAccounting : Form
    {
        private int _tenantID;
        public TenantAccounting(int tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
        }

        private void TenantAccounting_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn1.HeaderText = "Удалить платеж";
            dataGridViewButtonColumn1.Name = "COL_CreateOrder";
            dataGridViewButtonColumn1.Text = "Удалить";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            DG_View_Accounting.Columns.Add(dataGridViewButtonColumn1);
            Thread thread = new Thread(LoadInformation);
            thread.Start();
        }

        private void LoadInformation()
        {
            Action action = () =>
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {

                    Tenant tenant = db.Tenants
                    .Where(id=>id.ID==_tenantID)
                    .Include(ident => ident.Identification)
                    .FirstOrDefault();

                    if (tenant != null)
                    {
                        ChangePassport changePassport = db.ChangePassports.
                        Where(tid => tid.TenantID == tenant.ID).
                        Where(s => s.Status == true).
                        FirstOrDefault();

                        var accountings = db.Accountings
                        .Where(tid => tid.TenantID == tenant.ID)
                        //.Where(d => d.Debt != "0,00")
                        .ToList();

                        if (changePassport != null)
                        {
                            LB_TenantName.Text = changePassport.Surename + " " + changePassport.Name;
                            if (changePassport.Patronymic != null)
                            {
                                LB_TenantName.Text += " " + changePassport.Patronymic;
                            }
                        }
                        else
                        {
                            LB_TenantName.Text = tenant.Identification.Surename + " " + tenant.Identification.Name;
                            if (tenant.Identification.Patronymic != null)
                            {
                                LB_TenantName.Text += " " + tenant.Identification.Patronymic;
                            }
                        }

                        DG_View_Accounting.Rows.Clear();

                        foreach(Accounting accounting in accountings)
                        {
                            int rowNumber = DG_View_Accounting.Rows.Add();

                            DG_View_Accounting.Rows[rowNumber].Cells[COL_ID.Name].Value = accounting.ID;
                            DG_View_Accounting.Rows[rowNumber].Cells[COL_CreatedAt.Name].Value = accounting.CreatedAt;
                            DG_View_Accounting.Rows[rowNumber].Cells[COL_StartDate.Name].Value = accounting.PeriodStart;
                            DG_View_Accounting.Rows[rowNumber].Cells[COL_EndDate.Name].Value = accounting.PeriodEnd;
                            DG_View_Accounting.Rows[rowNumber].Cells[COL_Debt.Name].Value = accounting.Debt;
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("Жилец не найден!");
                        return;
                    }
                }

            };

            Invoke(action);
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                foreach (DataGridViewRow row in DG_View_Accounting.Rows)
                {
                    decimal coast = 0;

                    if (row.Cells[0].Value != null && row.Cells[5].Value!=null && decimal.TryParse(row.Cells[5].Value.ToString(), out coast))
                    {
                        int accountingId = int.Parse(row.Cells[0].Value.ToString());

                        Accounting accounting = db.Accountings
                            .Where(id => id.ID == accountingId)
                            .FirstOrDefault();

                        decimal debt = decimal.Parse(accounting.Debt);

                        debt -= coast;

                        accounting.Debt = debt.ToString();
                        accounting.Coast = coast.ToString();
                        accounting.LastPayEnterCoast = coast;
                        accounting.LasPayDay = DateTime.Now.ToString();

                        try
                        {
                            db.Entry(accounting).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch(Exception ex)
                        {
                            Log logInfo = new Log();
                            logInfo.ID = Guid.NewGuid();
                            logInfo.Type = "ERROR";
                            logInfo.Caption = "Class: TenantAccounting. Method: BTN_Add_Click. " + ex.Message + ". " + ex.InnerException;
                            logInfo.CreatedAt = DateTime.Now.ToString();
                            db.Logs.Add(logInfo);
                            db.SaveChanges();
                        }
                    }
                }
                MessageBox.Show("Данные внесены!");

                Thread thread = new Thread(LoadInformation);
                thread.Start();
            }
            
        }

        private void DG_View_Accounting_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                int accountID = 0;
                if (int.TryParse(DG_View_Accounting.Rows[e.RowIndex].Cells[0].Value.ToString(), out accountID)) 
                {
                    if(accountID==0)
                    {
                        MessageBox.Show("ID равен 0");
                        return;
                    }
                    DialogResult result = MessageBox.Show("Вы действительно хотите удалить общий счет платежного поручения", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        using(SupplyDbContext db = new SupplyDbContext())
                        {
                            try
                            {
                                Accounting accounting = db.Accountings.Where(x => x.ID == accountID).FirstOrDefault();
                                db.Accountings.Remove(accounting);
                                db.SaveChanges();
                                MessageBox.Show("Платежное поручение удалено успешно!");
                                DG_View_Accounting.Rows.Remove(DG_View_Accounting.Rows[e.RowIndex]);
                            }
                            catch(Exception ex)
                            {
                                Log logInfo = new Log();
                                logInfo.ID = Guid.NewGuid();
                                logInfo.Type = "ERROR";
                                logInfo.Caption = $"Class: TenantAccounting. Method: DG_View_Accounting_CellMouseClick. {ex.Message}. {ex.InnerException}";
                                logInfo.CreatedAt = DateTime.Now.ToString();
                                db.Logs.Add(logInfo);
                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
        }
    }
}
