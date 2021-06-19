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
    public partial class AdminRoomsFormAdd : Form
    {
        private int _hostelID;
        private int _flatIndex;
        private int _roomType;
        private int _electricityPaymentID;
        private int _roomID;
        private bool _flag;
        public AdminRoomsFormAdd(int hostelID)
        {
            InitializeComponent();
            _hostelID = hostelID;
            _flag = false;
        }

        public AdminRoomsFormAdd(int roomID, bool flag, int hostelID)
        {
            InitializeComponent();
            _roomID = roomID;
            _flag = flag;
            _hostelID = hostelID;
        }

        private void AdminRoomsFormAdd_Shown(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                CB_RoomType.DataSource = db.RoomTypes.ToList();
                CB_RoomType.DisplayMember = "Name";
                CB_RoomType.ValueMember = "ID";

                CB_Enterances.DataSource = db.Enterances.Where(x => x.HostelId == _hostelID).ToList();
                CB_Enterances.DisplayMember = "Name";
                CB_Enterances.ValueMember = "ID";

                CB_Electricity.DataSource = db.ElectricityPayments.Where(hid => hid.HostelID == _hostelID).Where(st => st.Status == true).ToList();
                CB_Electricity.ValueMember = "ID";
                CB_Electricity.DisplayMember = "Name";

                
            }

            if (_flag == false)
            {
                _flatIndex = 0;
                _roomType = 0;
                _electricityPaymentID = 0;
            }

            if (_flag == true)
            {
                Thread thread = new Thread(LoadInform);
                thread.Start();
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if(TB_Name.Text=="")
            {
                MessageBox.Show("Введите название комнаты!");
                return;
            }
            if (TB_Places.Text == "")
            {
                MessageBox.Show("Введите кол-во мест!");
                return;
            }
            if(_flatIndex==0)
            {
                MessageBox.Show("Выбирите этаж!");
                return;
            }
            if (_roomType == 0)
            {
                MessageBox.Show("Выбирите тип комнаты!");
                return;
            }

            using(SupplyDbContext db = new SupplyDbContext())
            {
                if(_flag == false)
                {
                    Room room = new Room();
                    room.Name = TB_Name.Text;
                    room.Places = int.Parse(TB_Places.Text);
                    room.RoomTypeID = _roomType;
                    room.FlatID = _flatIndex;
                    room.ElectricityPaymentID = _electricityPaymentID;

                    try
                    {
                        db.Rooms.Add(room);
                        db.SaveChanges();
                        MessageBox.Show("Комната добавлена успешно!");
                        
                    }
                    catch(Exception ex)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                        thread.Start("Class: AdminRoomsFormAdd.cs. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException);
                        MessageBox.Show(ex.Message);
                    }
                }

                if (_flag == true)
                {
                    Room room = db.Rooms.Where(x => x.ID == _roomID).FirstOrDefault();
                    if (room != null)
                    {
                        room.Name = TB_Name.Text;
                        room.Places = int.Parse(TB_Places.Text);
                        room.RoomTypeID = _roomType;
                        room.FlatID = _flatIndex;
                        room.ElectricityPaymentID = _electricityPaymentID;

                        try
                        {
                            db.Entry(room).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            MessageBox.Show("Комната изменена успешно!");
                        }
                        catch(Exception ex)
                        {
                            Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                            thread.Start("Class: AdminRoomsFormAdd.cs. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException);
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                        thread.Start($"Class: AdminRoomsFormAdd.cs. Method: BTN_Save_Click. Any room with ID {_roomID} in table");
                        MessageBox.Show("Не найдено совпадений по ID в базе данных комнат!");
                    }
                }

            }
            this.Close();
        }

        private void CB_RoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _roomType = (int)CB_RoomType.SelectedValue;

            }
            catch
            {
                return;
            }
        }

        private void CB_Enterances_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    int i = 0;
                    int.TryParse(CB_Enterances.SelectedValue.ToString(), out i);
                    if(i!=0)
                    {
                        CB_Flat.DataSource = db.Flats.Where(x => x.Enterance_ID == i).ToList();
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
                _flatIndex = (int)CB_Flat.SelectedValue;

            }
            catch
            {
                return;
            }
        }

        private void CB_Electricity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _electricityPaymentID = (int)CB_Electricity.SelectedValue;
            }
            catch
            {
                return;
            }
        }

        private void LoadInform()
        {
            Action action = () =>
              {
                  if (_flag == true)
                  {
                      using (SupplyDbContext db = new SupplyDbContext())
                      {
                          Room room = db.Rooms.Where(id => id.ID == _roomID).Include(fid => fid.Flat).FirstOrDefault();
                          if (room != null)
                          {
                              TB_Name.Text = room.Name;
                              TB_Places.Text = room.Places.ToString();
                              CB_Electricity.SelectedValue = room.ElectricityPaymentID;
                              CB_RoomType.SelectedValue = room.RoomTypeID;

                              Enterance enterance = db.Enterances.Where(x => x.ID == room.Flat.Enterance_ID).Include(hid => hid.Hostel).FirstOrDefault();

                              CB_Enterances.SelectedValue = enterance.ID;

                              CB_Flat.DataSource = db.Flats.Where(eid => eid.Enterance_ID == enterance.ID).ToList();
                              CB_Flat.DisplayMember = "Name";
                              CB_Flat.ValueMember = "ID";

                              CB_Flat.SelectedValue = room.Flat.ID;

                              _electricityPaymentID = (int)room.ElectricityPaymentID;
                              _flatIndex = room.FlatID;
                              _roomType = (int)room.RoomTypeID;
                          }
                          else
                          {
                              Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                              thread.Start("Class: AdminRoomsFormAdd.cs. Method: LoadInform. ID of room equil 0");
                              MessageBox.Show("Значение ID не может быть равным 0!");
                          }

                      }
                  }
              };

            Invoke(action);
        }
        private void AddLog(object error)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Log logInfo = new Log();
                logInfo.ID = Guid.NewGuid();
                logInfo.Type = "ERROR";
                logInfo.Caption = (string)error;
                logInfo.CreatedAt = DateTime.Now.ToString();
                db.Logs.Add(logInfo);
                db.SaveChanges();
            }
        }
    }
}
