using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class TenantSpecialPayments : Form
    {
        private int _tenantID;
        private int _roomIDFirst, _roomIDSecond, _electricityPlan,_electricityPlanSecond;
        public TenantSpecialPayments(int tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
            _roomIDFirst = _roomIDSecond = 0;
        }

        private void CB_Room_First_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _roomIDFirst = (int)CB_Room_First.SelectedValue;
                TB_Room_First_Places.Text = LoadPlaces(_roomIDFirst).ToString();
                TB_ElCiti_Places_First.Text = LoadPlaces(_roomIDFirst).ToString();
            }
            catch
            {
                return;
            }
        }

        private void CB_Room_Second_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _roomIDSecond = (int)CB_Room_Second.SelectedValue;
                TB_Room_Second_Places.Text = LoadPlaces(_roomIDSecond).ToString();
                TB_ElCiti_Places_Second.Text = LoadPlaces(_roomIDSecond).ToString();
            }
            catch
            {
                return;
            }
        }

        

        private void TenantSpecialPayments_Load(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Tenant tenant = db.Tenants
                    .Where(id => id.ID == _tenantID)
                    .Include(ident => ident.Identification)
                    .Include(r => r.Room)
                    .Include(or => or.Order)
                    .FirstOrDefault();

                if (tenant == null)
                {
                    MessageBox.Show("Жилец не найден!");
                    this.Close();
                }
                else
                {
                    Flat flat = db.Flats.Where(x => x.ID == tenant.Room.FlatID).Include(enter => enter.Enterance).FirstOrDefault();
                    Hostel hostel = db.Hostels.Where(x => x.ID == flat.Enterance.HostelId).FirstOrDefault();

                    LoadRooms(hostel.ID);

                    ChangePassport changePassport = db.ChangePassports
                        .Where(x => x.TenantID == tenant.ID)
                        .Where(s => s.Status == true)
                        .FirstOrDefault();

                    LB_Order.Text = tenant.Order.OrderNumber;

                    if (changePassport != null)
                    {
                        LB_Tenant.Text = changePassport.Surename + " " + changePassport.Name[0] + ".";
                        if (changePassport.Patronymic != null)
                        {
                            LB_Tenant.Text += " " + changePassport.Patronymic[0] + ".";
                        }
                    }
                    else
                    {
                        LB_Tenant.Text = tenant.Identification.Surename + " " + tenant.Identification.Name[0] + ".";
                        if (tenant.Identification.Patronymic != null)
                        {
                            LB_Tenant.Text += " " + tenant.Identification.Patronymic[0] + ".";
                        }
                    }

                    CB_Room_First.SelectedValue = _roomIDFirst = tenant.Room.ID;

                    CB_ElectricityPlan_First.DataSource = db.ElectricityPayments.Where(hid => hid.HostelID == hostel.ID).ToList();
                    CB_ElectricityPlan_First.DisplayMember = "Name";
                    CB_ElectricityPlan_First.ValueMember = "ID";

                    CB_ElectricityPlan_Second.DataSource= db.ElectricityPayments.Where(hid => hid.HostelID == hostel.ID).ToList();
                    CB_ElectricityPlan_Second.DisplayMember = "Name";
                    CB_ElectricityPlan_Second.ValueMember = "ID";
                }

            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            SpecialPayment specialPayment;

            int places = 0;
            DateTime startDate, endDate;
            List<SpecialPayment> specialPayments = new List<SpecialPayment>();

            if (_roomIDFirst != 0 && TB_Room_First_Places.Text != "" && int.TryParse(TB_Room_First_Places.Text, out places))
            {
                
                if (places != 0 && DateTime.TryParse(TB_Room_First_StartDate.Text, out startDate) && DateTime.TryParse(TB_Room_First_EndDate.Text, out endDate)) 
                {
                    if (_electricityPlan == 0)
                    {
                        MessageBox.Show("Выбирите тарифный план эл.энергии!");
                        return;
                    }
                    int specElPlace = 0;
                    if(!int.TryParse(TB_ElCiti_Places_First.Text,out specElPlace))
                    {
                        MessageBox.Show("Укажите кол-во мест эл.энергии");
                        return;
                    }
                    specialPayment = new SpecialPayment();
                    specialPayment.CreatedAt = DateTime.Now.ToString();
                    specialPayment.RoomID = _roomIDFirst;
                    specialPayment.TenantID = _tenantID;
                    specialPayment.Status = true;
                    specialPayment.Places = places;
                    specialPayment.StartDate = startDate.ToShortDateString();
                    specialPayment.EndDate = endDate.ToShortDateString();
                    specialPayment.ElectricityPaymentID = _electricityPlan;
                    specialPayment.ElectricityPaymentPlaces = specElPlace;

                    specialPayments.Add(specialPayment);
                }
            }

            places = 0;
            specialPayment = null;

            if (_roomIDSecond != 0 && TB_Room_Second_Places.Text != "" && int.TryParse(TB_Room_Second_Places.Text, out places)) 
            {
                
                if (places != 0 && DateTime.TryParse(TB_Room_Second_StartDate.Text, out startDate) && DateTime.TryParse(TB_Room_Second_EndDate.Text, out endDate))
                {
                    if (_electricityPlanSecond == 0)
                    {
                        MessageBox.Show("Выбирите тарифный план эл.энергии!");
                        return;
                    }

                    int specElPlace = 0;
                    if (!int.TryParse(TB_ElCiti_Places_Second.Text, out specElPlace))
                    {
                        MessageBox.Show("Укажите кол-во мест эл.энергии");
                        return;
                    }
                    specialPayment = new SpecialPayment();
                    specialPayment.CreatedAt = DateTime.Now.ToString();
                    specialPayment.RoomID = _roomIDSecond;
                    specialPayment.Places = places;
                    specialPayment.TenantID = _tenantID;
                    specialPayment.StartDate = startDate.ToShortDateString();
                    specialPayment.EndDate = endDate.ToShortDateString();
                    specialPayment.Status = true;
                    specialPayment.ElectricityPaymentID = _electricityPlanSecond;
                    specialPayment.ElectricityPaymentPlaces = specElPlace;

                    specialPayments.Add(specialPayment);
                }
            }

            if (specialPayments.Count > 0) 
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    try
                    {
                        db.SpecialPayments.AddRange(specialPayments);
                        db.SaveChanges();
                        MessageBox.Show("Специализированная оплата добавлена успешно!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        Log logInfo = new Log();
                        logInfo.ID = Guid.NewGuid();
                        logInfo.Type = "ERROR";
                        logInfo.Caption = $"Class: TenantSpecialPayments.cs. Method:BTN_Save_Click. {ex.Message}. {ex.InnerException}";
                        logInfo.CreatedAt = DateTime.Now.ToString();
                        db.Logs.Add(logInfo);
                        db.SaveChanges();

                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        

        private void LoadRooms(int hostelID)
        {
            List<Room> roomsToComboBoxes = new List<Room>();

            using (SupplyDbContext db = new SupplyDbContext())
            {
                var enterances = db.Enterances
                    .Where(hid => hid.HostelId == hostelID)
                    .ToList();

                foreach(Enterance enterance in enterances)
                {
                    var flats = db.Flats
                        .Where(eid => eid.Enterance_ID == enterance.ID)
                        .ToList();

                    foreach(Flat flat in flats)
                    {
                        var rooms = db.Rooms.Where(fid => fid.FlatID == flat.ID).ToList();

                        for (int i = 0; i < rooms.Count; i++) 
                        {
                            rooms[i].Name = rooms[i].Name + $" (мест:{rooms[i].Places})";
                            roomsToComboBoxes.Add(rooms[i]);
                        }
                    }
                }
            }

            CB_Room_First.DataSource = roomsToComboBoxes;
            CB_Room_First.BindingContext = new BindingContext();
            CB_Room_First.DisplayMember = "Name";
            CB_Room_First.ValueMember = "ID";

            CB_Room_Second.DataSource = roomsToComboBoxes;
            CB_Room_Second.BindingContext = new BindingContext();
            CB_Room_Second.DisplayMember = "Name";
            CB_Room_Second.ValueMember = "ID";

        }

        private void CB_ElectricityPlan_First_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _electricityPlan= (int)CB_ElectricityPlan_First.SelectedValue;
            }
            catch
            {
                return;
            }
        }
        private void CB_ElectricityPlan_Second_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _electricityPlanSecond = (int)CB_ElectricityPlan_Second.SelectedValue;
            }
            catch
            {
                return;
            }
        }
        private int LoadPlaces(int roomID)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                Room room = db.Rooms.Where(x => x.ID == roomID).FirstOrDefault();
                return room.Places;
            }
        }
    }
}
