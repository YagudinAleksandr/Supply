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
                        Hostel hostel = db.Hostels.Where(x => x.ID == _hostelID).FirstOrDefault();
                        List<int> roomsID = new List<int>();
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
                                var tenants = db.Tenants
                                                .Where(x => x.RoomID == roomID)
                                                .Include(p => p.Identification)
                                                .Include(s => s.Order)
                                                .Include(r=>r.Room)
                                                .ToList();

                                foreach(Tenant tenant in tenants)
                                {
                                    if (tenant.Identification != null && tenant.Order != null) 
                                    {
                                        int rowNumber = DG_View_Tenants.Rows.Add();

                                        DG_View_Tenants.Rows[rowNumber].Cells[COL_ID.Name].Value = tenant.ID;
                                        DG_View_Tenants.Rows[rowNumber].Cells[COL_Surename.Name].Value = tenant.Identification.Surename;
                                        DG_View_Tenants.Rows[rowNumber].Cells[COL_Name.Name].Value = tenant.Identification.Name;
                                        DG_View_Tenants.Rows[rowNumber].Cells[COL_DateOfBirth.Name].Value = tenant.Identification.DateOfBirth;
                                        if (tenant.Identification.Patronymic != null) 
                                        {
                                            DG_View_Tenants.Rows[rowNumber].Cells[COL_Patronymic.Name].Value = tenant.Identification.Patronymic;
                                        }

                                        if (tenant.Order != null)
                                        {
                                            DG_View_Tenants.Rows[rowNumber].Cells[COL_Order.Name].Value = tenant.Order.OrderNumber;
                                            DG_View_Tenants.Rows[rowNumber].Cells[COL_StartDate.Name].Value = tenant.Order.StartDate;
                                            if (tenant.Order.EndDate != null) 
                                            {
                                                DG_View_Tenants.Rows[rowNumber].Cells[COL_EndDate.Name].Value = tenant.Order.EndDate;
                                            }
                                        }

                                        DG_View_Tenants.Rows[rowNumber].Cells[COL_Room.Name].Value = tenant.Room.Name;
                                    }
                                    

                                    
                                }

                                //var orders = db.Orders.Where(x => x.RoomID == roomID).ToList();
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
                //Создаем LOG запись об удалении!
                Log logInfo = new Log();
                logInfo.ID = Guid.NewGuid();
                logInfo.CreatedAt = DateTime.Now.ToString();
                logInfo.Type = "ERROR";
                logInfo.Caption = (error as string);
                db.Logs.Add(logInfo);
                db.SaveChanges();
            }
        }
    }
}
