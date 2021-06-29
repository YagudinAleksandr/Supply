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
    public partial class DeclarationElectricityPaymentOrders : Form
    {
        public DeclarationElectricityPaymentOrders()
        {
            InitializeComponent();
        }

        private void DeclarationElectricityPaymentOrders_Shown(object sender, EventArgs e)
        {
            Thread thread = new Thread(UpdateInf);
            thread.Start();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateInf()
        {
            Action action = () =>
              {
                  using (SupplyDbContext db = new SupplyDbContext())
                  {
                      DG_View_ElectricityOrders.Rows.Clear();

                      try
                      {
                          foreach (ElecricityOrder order in db.ElecricityOrders.Include(t=>t.Tenant).ToList())
                          {
                              int rowNumber = DG_View_ElectricityOrders.Rows.Add();

                              Identification identification = db.Identifications.Where(x => x.ID == order.Tenant.ID).FirstOrDefault();
                              ChangePassport changePassport = db.ChangePassports.Where(x => x.Status == true).Where(t => t.TenantID == order.Tenant.ID).FirstOrDefault();

                              DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_ID.Name].Value = order.ID;
                              if (changePassport != null)
                              {
                                  DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_Tenant.Name].Value = changePassport.Surename + " " + changePassport.Name;
                              }
                              else
                              {
                                  DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_Tenant.Name].Value = identification.Surename + " " + identification.Name;
                              }
                              
                              DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_EndDate.Name].Value = order.EndDate;
                              DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_StartDate.Name].Value = order.StartDate;
                              DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_Status.Name].Value = order.Status;

                              Room room = db.Rooms.Where(x => x.ID == order.Tenant.RoomID).Include(f=>f.Flat).FirstOrDefault();

                              DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_Room.Name].Value = room.Name;

                              Enterance enterance = db.Enterances.Where(x => x.ID == room.Flat.Enterance_ID).Include(h => h.Hostel).FirstOrDefault();

                              DG_View_ElectricityOrders.Rows[rowNumber].Cells[COL_Hostel.Name].Value = enterance.Hostel.Name;

                          }
                      }
                      catch (Exception ex)
                      {
                          Log logInfo = new Log();
                          logInfo.ID = Guid.NewGuid();
                          logInfo.CreatedAt = DateTime.Now.ToString();
                          logInfo.Type = "ERROR";
                          logInfo.Caption = $"Class:DeclarationElectricityPaymentOrders. Method: UpdateInf. {ex.Message}. {ex.InnerException}";
                          db.Logs.Add(logInfo);
                          db.SaveChanges();

                          MessageBox.Show(ex.Message);
                      }
                  }
              };
            Invoke(action);
        }
    }
}
