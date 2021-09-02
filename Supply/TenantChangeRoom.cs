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
    public partial class TenantChangeRoom : Form
    {
        private int _tenantID;
        private int _hostelID, _enteranceID, _flatID, _roomID;
        public TenantChangeRoom(int tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
            _hostelID = _enteranceID = _flatID = _roomID = 0;
        }

        private void TenantChangeRoom_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(LoadInformationAboutTenant);
            thread.Start();
        }

        private void CB_Hostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _hostelID = (int)CB_Hostel.SelectedValue;

                if (_hostelID != 0) 
                {
                    using(SupplyDbContext db = new SupplyDbContext())
                    {
                        CB_Enterance.DataSource = db.Enterances.Where(hid => hid.HostelId == _hostelID).ToList();
                        CB_Enterance.DisplayMember = "Name";
                        CB_Enterance.ValueMember = "ID";
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void CB_Enterance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _enteranceID = (int)CB_Enterance.SelectedValue;
                if (_enteranceID != 0)
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        CB_Flat.DataSource = db.Flats.Where(eid => eid.Enterance_ID == _enteranceID).ToList();
                        CB_Flat.DisplayMember = "Name";
                        CB_Flat.ValueMember = "ID";
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void CB_Flat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _flatID = (int)CB_Flat.SelectedValue;
                if (_flatID != 0)
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        CB_Room.DataSource = db.Rooms.Where(fid => fid.FlatID == _flatID).ToList();
                        CB_Room.DisplayMember = "Name";
                        CB_Room.ValueMember = "ID";
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void CB_Room_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _roomID = (int)CB_Room.SelectedValue;
                
            }
            catch
            {
                return;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if(_roomID!=0)
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {


                    Tenant tenant = db.Tenants.Where(id => id.ID == _tenantID).Include(or => or.Order).FirstOrDefault();

                    ChangeRoom changeRoom = new ChangeRoom();
                    changeRoom.OrderID = tenant.Order.ID;
                    changeRoom.CreatedAt = DateTime.Now.ToString();
                    changeRoom.StartDate = TB_Date.Text;
                    changeRoom.RoomID = _roomID;
                    changeRoom.UpdatedAt = DateTime.Now.ToString();
                    changeRoom.Status = true;
                    

                    try
                    {
                        

                        if (DateTime.Now.ToShortDateString() == changeRoom.StartDate)
                        {
                            tenant.RoomID = _roomID;
                            tenant.UpdatedAt = DateTime.Now.ToString();

                            try
                            {
                                changeRoom.Status = false;

                                db.Entry(tenant).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                                

                                
                            }
                            catch(Exception ex)
                            {
                                Log log = new Log();
                                log.ID = Guid.NewGuid();
                                log.Type = "ERROR";
                                log.CreatedAt = DateTime.Now.ToString();
                                log.Caption = $"Class: TenantChangeRoom. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException;

                                db.Logs.Add(log);
                                db.SaveChanges();
                                MessageBox.Show(ex.Message);
                            }
                        }
                        
                        db.ChangeRooms.Add(changeRoom);
                        db.SaveChanges();

                        string error = "";

                        if (!OrdersCreation.ChangeRoomCreate(changeRoom.ID, out error))
                        {
                            throw new Exception(error);
                        }
                        else
                        {
                            MessageBox.Show("Документ сформирован!");
                        }

                        MessageBox.Show("Переселение назначено!");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        Log log = new Log();
                        log.ID = Guid.NewGuid();
                        log.Type = "ERROR";
                        log.CreatedAt = DateTime.Now.ToString();
                        log.Caption = $"Class: TenantChangeRoom. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException;

                        db.Logs.Add(log);
                        db.SaveChanges();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Укажите комнату для переселения!");
            }
        }

        private void LoadInformationAboutTenant()
        {
            Action action = () =>
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Tenant tenant = db.Tenants.Where(id => id.ID == _tenantID).Include(ident => ident.Identification).Include(r => r.Room).FirstOrDefault();

                    LB_TenantName.Text = tenant.Identification.Surename + " " + tenant.Identification.Name;

                    if (tenant.Identification.Patronymic != null)
                        LB_TenantName.Text += " " + tenant.Identification.Patronymic;

                    LB_Room.Text = tenant.Room.Name;

                    Flat flat = db.Flats.Where(id => id.ID == tenant.Room.FlatID).Include(enter => enter.Enterance).FirstOrDefault();

                    LB_Flat.Text = flat.Name;
                    LB_Enterance.Text = flat.Enterance.Name;

                    Hostel hostel = db.Hostels.Where(id => id.ID == flat.Enterance.HostelId).FirstOrDefault();
                    LB_Hostel.Text = hostel.Name;


                    var hostels = db.Hostels.ToList();
                    CB_Hostel.DataSource = hostels;
                    CB_Hostel.ValueMember = "ID";
                    CB_Hostel.DisplayMember = "Name";
                }
            };
            Invoke(action);
        }
        
    }
}
