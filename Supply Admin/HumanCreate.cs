using Supply_Admin.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supply_Admin.Models;

namespace Supply_Admin
{
    public partial class HumanCreate : Form
    {
        SupplyDbContext _db;
        private static int _roomId;
        private static int _hostelId;

        public HumanCreate(SupplyDbContext db, int roomId)
        {
            InitializeComponent();
            _db = db;
            _roomId = roomId;
           
        }

        private void BTN_SaveHuman_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Human human = new Human();

                    human.Name = TB_Name.Text;
                    human.Surename = TB_SecondName.Text;
                    human.Patronymic = TB_Patronymic.Text;
                    human.DocType = CB_DocType.SelectedItem.ToString();
                    human.Citizenship = TB_Citizenship.Text;
                    human.GivenCode = TB_DocOrgNumb.Text;
                    human.GivenDate = TB_GivenDate.Text;
                    human.Given = TB_Given.Text;
                    human.Registration = TB_Registration.Text;
                    human.PhoneNumber = TB_Phone.Text;
                    human.Series = TB_DocSeries.Text;
                    human.Number = TB_DocNumber.Text;
                    human.RoomId = _roomId;

                    _db.Humen.Add(human);
                    _db.SaveChanges();

                    bool benefit = CB_Benifit.Checked;

                    int orderId = CreateOrder(human.Id,benefit);

                    if (benefit == true)
                        CreateBenefit(orderId);

                    MessageBox.Show("Жилец добавлен успешно!");
                }
                catch 
                {
                    MessageBox.Show("Возникла ошибка! Повторите попытку позже или обратитесь к системному администратору");
                }
                
                Close();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка! Повторите попытку позже или обратитесь к системному администратору");
            }
        }

        private void HumanCreate_Shown(object sender, EventArgs e)
        {
            var room = _db.Rooms.Where(x => x.Id == _roomId).FirstOrDefault();
            var flat = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
            var enterance = _db.Enterances.Where(x => x.Id == flat.EnteranceId).FirstOrDefault();
            var hostel = _db.Hostels.Where(x => x.Id == enterance.HostelsId).FirstOrDefault();
            
            _hostelId = hostel.Id;

            var rates = _db.Rates.Where(x => x.HostelsId == _hostelId).ToList();

            LB_Room.Text = $"Комната № {room.Name}";
            LB_Hostel.Text = $"Общежитие № {hostel.Name}";

            var rents = _db.Rents.ToList();

            CB_Period.DataSource = rents;
            CB_Period.DisplayMember = "Name";
            CB_Period.ValueMember = "Id";


            CB_Rates.DataSource = rates;
            CB_Rates.DisplayMember = "Name";
            CB_Rates.ValueMember = "Id";
        }

        //Внутренние методы
        private int CreateOrder(int human,bool benefit)
        {
            try
            {
                Order order = new Order();

                order.HumanId = human;
                order.StartOrder = TB_OrderStart.Text;
                order.EndOrder = TB_OrderEnd.Text;
                order.RentId = (int)CB_Period.SelectedValue;
                order.RateId = (int)CB_Rates.SelectedValue;
                order.Status = 1;
                if (CB_EducationType.SelectedItem != null)
                {
                    order.EducationType = CB_EducationType.SelectedItem.ToString();
                }
                else
                    order.EducationType = "";


                if (benefit == true)
                    order.Benifit = 1;
                else
                    order.Benifit = 0;

                order.HostelsId = _hostelId;

                _db.Orders.Add(order);
                _db.SaveChanges();


                return order.Id;
            }
            catch
            {
                return 0;
            }
            
        }
        private void CreateBenefit(int orderId)
        {
            try
            {
                Benefit benefit = new Benefit();

                benefit.BenifitCat = CB_BenifitCat.SelectedItem.ToString();
                benefit.Proxy = TB_Proxy.Text;
                benefit.ProxyDate = TB_ProxyDate.Text;
                benefit.OrderId = orderId;
                benefit.StartDate = TB_BenifitStart.Text;
                benefit.EndDate = TB_BenifitEnd.Text;
                benefit.Decree = TB_Decree.Text;
                benefit.DecreeDate = TB_DecreeDate.Text;

                _db.Benefits.Add(benefit);
                _db.SaveChanges();


            }
            catch
            {
                MessageBox.Show("Возникли проблемы при добавлении льготы!");
            }
        }

        private void CB_Benifit_CheckedChanged(object sender, EventArgs e)
        {
            if(CB_Benifit.Checked)
            {
                TB_BenifitEnd.ReadOnly = false;
            }
            else
            {
                TB_BenifitEnd.ReadOnly = true;
            }
        }
    }
}
