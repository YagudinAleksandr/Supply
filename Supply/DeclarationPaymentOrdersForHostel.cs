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
    public partial class DeclarationPaymentOrdersForHostel : Form
    {
        private int _hostelID;
        public DeclarationPaymentOrdersForHostel(int hostelID)
        {
            InitializeComponent();
            _hostelID = hostelID;
        }

        private void DeclarationPaymentOrdersForHostel_Shown(object sender, EventArgs e)
        {
            new Thread(LoadInf).Start();
        }

        private void LoadInf()
        {
            Action action = () =>
            {
                DG_View_PaymentActiveOrders.Rows.Clear();

                using (SupplyDbContext db = new SupplyDbContext())
                {
                    var enterances = db.Enterances.Where(hid => hid.HostelId == _hostelID).ToList();
                    foreach (Enterance enterance in enterances)
                    {
                        var flats = db.Flats.Where(eid => eid.Enterance_ID == enterance.ID).ToList();
                        foreach (Flat flat in flats)
                        {
                            var rooms = db.Rooms.Where(fid => fid.FlatID == flat.ID).ToList();
                            foreach (Room room in rooms)
                            {
                                var tenants = db.Tenants
                                    .Where(rid => rid.RoomID == room.ID)
                                    .Where(s => s.Status == true)
                                    .Include(ident => ident.Identification)
                                    .Include(o => o.Order)
                                    .ToList();

                                foreach (Tenant tenant in tenants)
                                {
                                    int rowNumber = DG_View_PaymentActiveOrders.Rows.Add();

                                    DG_View_PaymentActiveOrders.Rows[rowNumber].Cells[COL_ID.Name].Value = tenant.ID;
                                    DG_View_PaymentActiveOrders.Rows[rowNumber].Cells[COL_Order.Name].Value = tenant.Order.OrderNumber;
                                    DG_View_PaymentActiveOrders.Rows[rowNumber].Cells[COL_EndOrder.Name].Value = tenant.Order.EndDate;
                                    DG_View_PaymentActiveOrders.Rows[rowNumber].Cells[COL_StartDate.Name].Value = tenant.Order.StartDate;
                                    DG_View_PaymentActiveOrders.Rows[rowNumber].Cells[COL_Room.Name].Value = tenant.Room.Name;

                                    ChangePassport changePassport = db.ChangePassports.Where(tid => tid.TenantID == tenant.ID).Where(s => s.Status == true).FirstOrDefault();
                                    if(changePassport!=null)
                                    {
                                        DG_View_PaymentActiveOrders.Rows[rowNumber].Cells[COL_Tenant.Name].Value = changePassport.Surename + " " + changePassport.Name;
                                        if(changePassport.Patronymic!=null)
                                        {
                                            DG_View_PaymentActiveOrders.Rows[rowNumber].Cells[COL_Tenant.Name].Value += " " + changePassport.Patronymic;
                                        }
                                    }
                                    else
                                    {
                                        DG_View_PaymentActiveOrders.Rows[rowNumber].Cells[COL_Tenant.Name].Value = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                        if (tenant.Identification.Patronymic != null)
                                        {
                                            DG_View_PaymentActiveOrders.Rows[rowNumber].Cells[COL_Tenant.Name].Value += " " + tenant.Identification.Patronymic;
                                        }
                                    }

                                    if(OrdersCreation.AdditionalInf(10,tenant.ID)!=string.Empty)
                                    {
                                        DG_View_PaymentActiveOrders.Rows[rowNumber].Cells[COL_Organization.Name].Value = "Сторонняя";

                                    }
                                    else
                                    {
                                        DG_View_PaymentActiveOrders.Rows[rowNumber].Cells[COL_Organization.Name].Value = "НИМИ";
                                    }
                                    DG_View_PaymentActiveOrders.Rows[rowNumber].Cells[COL_Faculty.Name].Value = OrdersCreation.AdditionalInf(3, tenant.ID);
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
