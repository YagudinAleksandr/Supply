using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class HostelArchiveForm : Form
    {
        private int _hostelID;
        public HostelArchiveForm(int hostelID)
        {
            InitializeComponent();
            _hostelID = hostelID;
        }

        private void HostelArchiveForm_Shown(object sender, EventArgs e)
        {
            Thread thread = new Thread(LoadInform);
            thread.Start();
        }

        private void LoadInform()
        {
            Action action = () =>
            {
                DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
                dataGridViewButtonColumn2.HeaderText = "";
                dataGridViewButtonColumn2.Name = "COL_Information";
                dataGridViewButtonColumn2.Text = "Карточка";
                dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
                DG_View_Tenants.Columns.Add(dataGridViewButtonColumn2);

                DG_View_Tenants.Rows.Clear();

                using(SupplyDbContext db = new SupplyDbContext())
                {
                    try
                    {

                        List<int> roomsID = new List<int>();
                        List<int> ordersID = new List<int>();


                        Hostel hostel = db.Hostels.Where(x => x.ID == _hostelID).FirstOrDefault();
                        
                        if (hostel != null)
                        {
                            var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();

                            if (enterances.Count != 0)
                            {
                                

                                foreach (Enterance enterance in enterances)
                                {
                                    var flats = db.Flats.Where(x => x.Enterance_ID == enterance.ID).ToList();

                                    foreach(Flat flat in flats)
                                    {
                                        var rooms = db.Rooms.Where(x => x.FlatID == flat.ID).ToList();

                                        foreach(Room room in rooms)
                                        {
                                            roomsID.Add(room.ID);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Thread thread = new Thread(new ParameterizedThreadStart(LogInf));
                            thread.Start($"Class:HostelArchiveForm. Method: LoadInform. Any information in DB about Hostel");

                            MessageBox.Show("Общежитие не найдено!");

                            this.Close();
                        }

                        if (roomsID.Count() != 0) 
                        {
                            
                            foreach(int roomID in roomsID)
                            {
                                var orders = db.Orders
                                                .Where(r => r.RoomID == roomID)
                                                .Include(x => x.Room)
                                                .Include(t => t.Tenant)
                                                .ToList();


                                foreach(Order order in orders)
                                {
                                    int rowNumber = DG_View_Tenants.Rows.Add();

                                    ordersID.Add(order.ID);

                                    DG_View_Tenants.Rows[rowNumber].Cells[COL_ID.Name].Value = order.ID;
                                    DG_View_Tenants.Rows[rowNumber].Cells[COL_Order.Name].Value = order.OrderNumber;
                                    DG_View_Tenants.Rows[rowNumber].Cells[COL_StartDate.Name].Value = order.StartDate;
                                    if (order.EndDate != null)
                                    {
                                        DG_View_Tenants.Rows[rowNumber].Cells[COL_EndDate.Name].Value = order.EndDate;
                                    }

                                    Tenant tenant = db.Tenants
                                                    .Where(x => x.ID == order.ID)
                                                    .Include(p => p.Identification)
                                                    .Include(r => r.Room)
                                                    .FirstOrDefault();

                                    DG_View_Tenants.Rows[rowNumber].Cells[COL_Room.Name].Value = tenant.Room.Name;

                                    DG_View_Tenants.Rows[rowNumber].Cells[COL_Surename.Name].Value = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                    if (tenant.Identification.Patronymic != null)
                                    {
                                        DG_View_Tenants.Rows[rowNumber].Cells[COL_Surename.Name].Value += " " + tenant.Identification.Patronymic;
                                    }
                                    DG_View_Tenants.Rows[rowNumber].Cells[COL_DateOfBirth.Name].Value = tenant.Identification.DateOfBirth;
                                }


                                var tenants = db.Tenants
                                                .Where(r => r.RoomID == roomID)
                                                .Include(x => x.Room)
                                                .Include(i => i.Identification)
                                                .Include(o => o.Order)
                                                .ToList();

                                foreach(Tenant tenant in tenants)
                                {
                                    bool flag = false;
                                    foreach(int orID in ordersID)
                                    {
                                        if (tenant.ID == orID)
                                        {
                                            flag = true;
                                        }
                                    }

                                    if (flag == false)
                                    {
                                        int rowNumber = DG_View_Tenants.Rows.Add();

                                        DG_View_Tenants.Rows[rowNumber].Cells[COL_ID.Name].Value = tenant.ID;
                                        if (tenant.Identification != null) 
                                        {
                                            DG_View_Tenants.Rows[rowNumber].Cells[COL_Surename.Name].Value = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                            DG_View_Tenants.Rows[rowNumber].Cells[COL_DateOfBirth.Name].Value = tenant.Identification.DateOfBirth;
                                            if (tenant.Identification.Name != null)
                                            {
                                                DG_View_Tenants.Rows[rowNumber].Cells[COL_Surename.Name].Value += " " + tenant.Identification.Patronymic;
                                            }

                                            DG_View_Tenants.Rows[rowNumber].Cells[COL_Order.Name].Value = tenant.Order.OrderNumber;
                                            DG_View_Tenants.Rows[rowNumber].Cells[COL_StartDate.Name].Value = tenant.Order.StartDate;
                                            if (tenant.Order.EndDate != null)
                                            {
                                                DG_View_Tenants.Rows[rowNumber].Cells[COL_EndDate.Name].Value = tenant.Order.EndDate;
                                            }

                                            DG_View_Tenants.Rows[rowNumber].Cells[COL_Room.Name].Value = tenant.Room.Name;
                                        }
                                        
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Комнат не найдено для данного общежития!");

                            this.Close();
                        }
                    }
                    catch(Exception ex)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(LogInf));
                        thread.Start($"Class:HostelArchiveForm. Method: LoadInform. {ex.Message}.{ex.InnerException}");

                        MessageBox.Show(ex.Message);

                        this.Close();
                    }
                }
            };

            Invoke(action);
        }
        private void LogInf(object error)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                
                Log logInfo = new Log();
                logInfo.ID = Guid.NewGuid();
                logInfo.CreatedAt = DateTime.Now.ToString();
                logInfo.Type = "ERROR";
                logInfo.Caption = (error as string);
                db.Logs.Add(logInfo);
                db.SaveChanges();
            }
        }

        private void DG_View_Tenants_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                int tenantID = 0;

                if (int.TryParse(DG_View_Tenants.Rows[e.RowIndex].Cells[0].Value.ToString(), out tenantID)) 
                {
                    if (tenantID == 0)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(LogInf));
                        thread.Start($"Class:HostelArchiveForm. Method: DG_View_Tenants_CellMouseClick. Tenant ID equil 0");

                        MessageBox.Show("Не существует данного жильца!");

                        return;
                    }

                    TenantCard tenantCard = new TenantCard(tenantID);
                    tenantCard.Show();
                }
            }
        }

        private void TB_Search_TextChanged(object sender, EventArgs e)
        {
            if (TB_Search.Text != string.Empty)
            {
                for (int i = 0; i < DG_View_Tenants.RowCount; i++)
                {
                    DG_View_Tenants.Rows[i].Selected = false;
                    for (int j = 0; j < DG_View_Tenants.ColumnCount; j++)
                        if (DG_View_Tenants.Rows[i].Cells[j].Value != null)
                            if (DG_View_Tenants.Rows[i].Cells[j].Value.ToString().Contains(TB_Search.Text))
                            {
                                DG_View_Tenants.Rows[i].Selected = true;
                                break;
                            }
                }
            }
            else
            {
                for (int i = 0; i < DG_View_Tenants.RowCount; i++)
                {
                    DG_View_Tenants.Rows[i].Selected = false;
                    
                }
            }
            
        }
    }
}
