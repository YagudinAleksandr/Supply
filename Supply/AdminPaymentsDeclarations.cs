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
    public partial class AdminPaymentsDeclarations : Form
    {
        private int _hostelID;
        public AdminPaymentsDeclarations()
        {
            InitializeComponent();
            _hostelID = 0;
            BTN_CreateDeclaration.Enabled = false;
        }


        private void AdminPaymentsDeclarations_Load(object sender, EventArgs e)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                CB_Hostels.DataSource = db.Hostels.ToList();
                CB_Hostels.ValueMember = "ID";
                CB_Hostels.DisplayMember = "Name";
            }
        }

        private void CB_Hostels_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int hostelID = 0;
                if (int.TryParse(CB_Hostels.SelectedValue.ToString(), out hostelID))
                {
                    _hostelID = hostelID;
                    if (_hostelID != 0)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(LoadInf));
                        thread.Start(_hostelID);
                    }
                }
                else
                {
                    MessageBox.Show("Неправильно указан ID общежития!");
                }
            }
            catch
            {
                return;
            }
        }
        private void LoadInf(object hostelID)
        {
            Action action = () =>
              {
                  using (SupplyDbContext db = new SupplyDbContext())
                  {
                      DG_View_PaymentDeclarations.Rows.Clear();

                      var enterances = db.Enterances.Where(hid => hid.HostelId == (int)hostelID).ToList();

                      foreach (Enterance enterance in enterances)
                      {
                          var flats = db.Flats.Where(eid => eid.Enterance_ID == enterance.ID).ToList();

                          foreach (Flat flat in flats)
                          {
                              var rooms = db.Rooms.Where(fid => fid.FlatID == flat.ID).ToList();

                              foreach (Room room in rooms)
                              {
                                  var tenants = db.Tenants.Where(r => r.RoomID == room.ID).Where(s => s.Status == true).Include(ident => ident.Identification).ToList();

                                  foreach (Tenant tenant in tenants)
                                  {
                                      var accountings = db.Accountings
                                      .Where(tid => tid.TenantID == tenant.ID)
                                      .Where(d => d.Debt != "0,00")
                                      .ToList();
                                      foreach (Accounting accounting in accountings)
                                      {
                                          int rowNumber = DG_View_PaymentDeclarations.Rows.Add();

                                          DG_View_PaymentDeclarations.Rows[rowNumber].Cells[COL_ID.Name].Value = accounting.ID;
                                          DG_View_PaymentDeclarations.Rows[rowNumber].Cells[COL_CreatedAt.Name].Value = accounting.CreatedAt;
                                          DG_View_PaymentDeclarations.Rows[rowNumber].Cells[COL_EndDate.Name].Value = accounting.PeriodEnd;
                                          DG_View_PaymentDeclarations.Rows[rowNumber].Cells[COL_StartDate.Name].Value = accounting.PeriodStart;
                                          DG_View_PaymentDeclarations.Rows[rowNumber].Cells[COL_Debt.Name].Value = accounting.Debt;

                                          ChangePassport changePassport = db.ChangePassports.Where(tid => tid.TenantID == tenant.ID).Where(s => s.Status == true).FirstOrDefault();

                                          if(changePassport!=null)
                                          {
                                              DG_View_PaymentDeclarations.Rows[rowNumber].Cells[COL_Tenant.Name].Value = changePassport.Surename + " " + changePassport.Name;
                                              if(changePassport.Patronymic!=null)
                                              {
                                                  DG_View_PaymentDeclarations.Rows[rowNumber].Cells[COL_Tenant.Name].Value += " " + changePassport.Patronymic;
                                              }
                                          }
                                          else
                                          {
                                              DG_View_PaymentDeclarations.Rows[rowNumber].Cells[COL_Tenant.Name].Value = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                              if(tenant.Identification.Patronymic!=null)
                                              {
                                                  DG_View_PaymentDeclarations.Rows[rowNumber].Cells[COL_Tenant.Name].Value += " " + tenant.Identification.Patronymic;
                                              }
                                          }

                                          DG_View_PaymentDeclarations.Rows[rowNumber].Cells[COL_Faculty.Name].Value = OrdersCreation.AdditionalInf(3, tenant.ID);

                                          if(OrdersCreation.AdditionalInf(10,tenant.ID)!=string.Empty)
                                          {
                                              DG_View_PaymentDeclarations.Rows[rowNumber].Cells[COL_Organization.Name].Value = "Сторонняя";

                                          }
                                          else
                                          {
                                              DG_View_PaymentDeclarations.Rows[rowNumber].Cells[COL_Organization.Name].Value = "НИМИ";
                                          }
                                      }
                                  }
                              }
                          }
                      }


                  }
              };
            Invoke(action);
        }

        private void BTN_SelectAll_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in DG_View_PaymentDeclarations.Rows)
            {
                
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];

                chk.Value = true;
            }
        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            List<Accounting> accountings = new List<Accounting>();
            using(SupplyDbContext db = new SupplyDbContext())
            {
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить выбранные платежные счета?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No) 
                {
                    return;
                }
                foreach (DataGridViewRow row in DG_View_PaymentDeclarations.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];

                    if (chk.Value != null)
                    {
                        int accountingID = 0;
                        if (int.TryParse(row.Cells[1].Value.ToString(), out accountingID))
                        {
                            Accounting accounting = db.Accountings.Where(id => id.ID == accountingID).FirstOrDefault();
                            try
                            {
                                db.Accountings.Remove(accounting);
                                db.SaveChanges();
                                DG_View_PaymentDeclarations.Rows.Remove(row);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                Log logInfo = new Log();
                                logInfo.ID = Guid.NewGuid();
                                logInfo.Type = "ERROR";
                                logInfo.Caption = "Class: AdminPaymentsDeclarations. Method: BTN_Delete_Click. " + ex.Message + ". " + ex.InnerException;
                                logInfo.CreatedAt = DateTime.Now.ToString();
                                db.Logs.Add(logInfo);
                                db.SaveChanges();
                            }

                        }
                    }
                }
            }
            
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext()) 
            {
                foreach (DataGridViewRow row in DG_View_PaymentDeclarations.Rows)
                {
                    decimal payment = 0;
                    int accountingID = 0;
                    if (row.Cells[8].Value.ToString() != "" && decimal.TryParse(row.Cells[8].Value.ToString(), out payment))
                    {
                        if (int.TryParse(row.Cells[1].Value.ToString(), out accountingID))
                        {
                            Accounting accounting = db.Accountings.Where(id => id.ID == accountingID).FirstOrDefault();
                            if (accounting != null)
                            {
                                decimal debt = decimal.Parse(accounting.Debt);
                                debt -= payment;

                                accounting.Debt = debt.ToString();
                                accounting.Coast = payment.ToString();

                                try
                                {
                                    db.Entry(accounting).State = System.Data.Entity.EntityState.Modified;
                                    db.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    Log logInfo = new Log();
                                    logInfo.ID = Guid.NewGuid();
                                    logInfo.Type = "ERROR";
                                    logInfo.Caption = "Class: AdminPaymentsDeclarations. Method: BTN_Save_Click. " + ex.Message + ". " + ex.InnerException;
                                    logInfo.CreatedAt = DateTime.Now.ToString();
                                    db.Logs.Add(logInfo);
                                    db.SaveChanges();
                                }

                                if(debt==0)
                                {
                                    DG_View_PaymentDeclarations.Rows.Remove(row);
                                }
                                else
                                {
                                    row.Cells[7].Value = debt;
                                    row.Cells[8].Value = "";
                                }
                            }
                        }
                    }
                }
            }
            
        }
    }
}
