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
    public partial class DeclarationSpecialPayments : Form
    {
        private int _hostelID;
        public DeclarationSpecialPayments()
        {
            InitializeComponent();
        }

        private void CB_Hostels_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                _hostelID = (int)CB_Hostels.SelectedValue;

                Thread thread = new Thread(LoadInf);
                thread.Start();
            }
            catch
            {
                return;
            }
        }

        private void DeclarationSpecialPayments_Shown(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                CB_Hostels.DataSource = db.Hostels.ToList();
                CB_Hostels.DisplayMember = "Name";
                CB_Hostels.ValueMember = "ID";
            }
        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                foreach (DataGridViewRow row in DG_View_SpecialPayments.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        int specialPaymentID = 0;
                        if (int.TryParse(row.Cells[1].Value.ToString(), out specialPaymentID))
                        {
                            try
                            {
                                SpecialPayment specialPayment = db.SpecialPayments.Where(id => id.ID == specialPaymentID).FirstOrDefault();

                                db.SpecialPayments.Remove(specialPayment);
                                db.SaveChanges();

                                DG_View_SpecialPayments.Rows.Remove(row);
                            }
                            catch(Exception ex)
                            {
                                Log logInfo = new Log();
                                logInfo.ID = Guid.NewGuid();
                                logInfo.Type = "ERROR";
                                logInfo.Caption = $"LoginForm.cs. Class: DeclarationSpecialPayments. Method: BTN_Delete_Click." + ex.Message + "." + ex.InnerException;
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

        private void BTN_Deactivate_Click(object sender, EventArgs e)
        {

        }

        private void LoadInf()
        {
            Action action = () =>
              {
                  if(_hostelID==0)
                  {
                      MessageBox.Show("ID общежития равен 0");
                      return;
                  }

                  DG_View_SpecialPayments.Rows.Clear();

                  using(SupplyDbContext db = new SupplyDbContext())
                  {
                      var enterances = db.Enterances.Where(hid => hid.HostelId == _hostelID).ToList();

                      foreach(Enterance enterance in enterances)
                      {
                          var flats = db.Flats.Where(x => x.Enterance_ID == enterance.ID).ToList();

                          foreach(Flat flat in flats)
                          {
                              var rooms = db.Rooms.Where(fid => fid.FlatID == flat.ID).ToList();

                              foreach(Room room in rooms)
                              {
                                  var tenants = db.Tenants.Where(rid => rid.RoomID == room.ID).Where(s => s.Status == true).Include(ident => ident.Identification).ToList();

                                  foreach(Tenant tenant in tenants)
                                  {
                                      var specialPayments = db.SpecialPayments.Where(tid => tid.TenantID == tenant.ID).Include(r => r.Room).ToList();

                                      foreach(SpecialPayment specialPayment in specialPayments)
                                      {
                                          int rowNumber = DG_View_SpecialPayments.Rows.Add();

                                          DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_ID.Name].Value = specialPayment.ID;
                                          DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_Room.Name].Value = specialPayment.Room.Name;
                                          DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_EndDate.Name].Value = specialPayment.EndDate;
                                          DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_StartDate.Name].Value = specialPayment.StartDate;
                                          DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_Status.Name].Value = specialPayment.Status;
                                          DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_SpecialPaymentPlaces.Name].Value = specialPayment.Places;
                                          ChangePassport changePassport = db.ChangePassports.Where(tid => tid.TenantID == tenant.ID).Where(s => s.Status == true).FirstOrDefault();
                                          if(changePassport!=null)
                                          {
                                              DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_Tenant.Name].Value = changePassport.Surename + " " + changePassport.Name;
                                              if(changePassport.Patronymic!=null)
                                              {
                                                  DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_Tenant.Name].Value += " " + changePassport.Patronymic;

                                              }
                                          }
                                          else
                                          {
                                              DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_Tenant.Name].Value = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                              if (tenant.Identification.Patronymic != null)
                                              {
                                                  DG_View_SpecialPayments.Rows[rowNumber].Cells[COL_Tenant.Name].Value += " " + tenant.Identification.Patronymic;

                                              }
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
    }
}
