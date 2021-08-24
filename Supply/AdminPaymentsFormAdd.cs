using Supply.Domain;
using Supply.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminPaymentsFormAdd : Form
    {
        private int _userID;
        private int _hostelID;
        private int _roomTypeID;
        private int _tenantTypeID;
        private int _paymentID;
        public AdminPaymentsFormAdd(int userID, int paymentID = 0)
        {
            InitializeComponent();
            _userID = userID;
            _paymentID = paymentID;
        }

        private void AdminPaymentsFormAdd_Load(object sender, EventArgs e)
        {
            _hostelID = _roomTypeID = _tenantTypeID = 0;

            using(SupplyDbContext db = new SupplyDbContext())
            {
                CB_Hostels.DataSource = db.Hostels.ToList();
                CB_Hostels.DisplayMember = "Name";
                CB_Hostels.ValueMember = "ID";

                CB_RoomTypes.DataSource = db.RoomTypes.ToList();
                CB_RoomTypes.DisplayMember = "Name";
                CB_RoomTypes.ValueMember = "ID";

                CB_TenantTypes.DataSource = db.TenantTypes.ToList();
                CB_TenantTypes.DisplayMember = "Name";
                CB_TenantTypes.ValueMember = "ID";
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (_roomTypeID == 0) 
            {
                MessageBox.Show("Выбирите тип комнаты!");
                return;
            }
            if (_hostelID == 0) 
            {
                MessageBox.Show("Выбирите общежитие!");
                return;
            }

            decimal rent = 0;
            decimal house = 0;
            decimal service = 0;

            if (TB_Coast.Text != string.Empty)
            {
                if (!decimal.TryParse(TB_Coast.Text, out rent))
                {
                    MessageBox.Show("Значение поля суммы за койко место должно быть числом!");
                    return;
                }
            }
            else
            {
                rent = 0;
            }

            if (TB_Service.Text != string.Empty) 
            {
                if (!decimal.TryParse(TB_Service.Text, out service))
                {
                    MessageBox.Show("Значение поля суммы за коммунальные услуги должно быть числом!");
                    return;
                }
            }
            else
            {
                service = 0;
            }

            if (TB_House.Text != string.Empty)
            {
                if (!decimal.TryParse(TB_House.Text, out house))
                {
                    MessageBox.Show("Значение поля Сумма за содержание жилого помещения должно быть числом!");
                    return;
                }
            }
            else
            {
                house = 0;
            }

            using(SupplyDbContext db = new SupplyDbContext())
            {
                Payment payment;
                if (_paymentID != 0)
                {
                    payment = db.Payments.Where(x => x.ID == _paymentID).FirstOrDefault();
                    payment.Name = TB_Name.Text;
                    payment.Description = TB_Description.Text;
                    payment.UserID = _userID;
                    payment.HostelID = _hostelID;
                    payment.RoomTypeID = _roomTypeID;
                    payment.UpdatedAt = DateTime.Now.ToString();
                    if(ChB_Status.Checked)
                    {
                        payment.Status = true;
                    }
                    else
                    {
                        payment.Status = false;
                    }

                    payment.Rent = rent;
                    payment.Service = service;
                    payment.House = house;
                    payment.TenantTypeID = _tenantTypeID;
                    payment.PaymentType = CB_PeriodOfPayment.SelectedItem.ToString();
                    try
                    {
                        db.Entry(payment).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Тарифный план изменен успешно!");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    this.Close();
                }
                else
                {
                    payment = new Payment();
                    payment.Name = TB_Name.Text;
                    payment.UserID = _userID;
                    payment.Description = TB_Description.Text;
                    payment.HostelID = _hostelID;
                    payment.RoomTypeID = _roomTypeID;
                    payment.CreatedAt = DateTime.Now.ToString();
                    payment.UpdatedAt = DateTime.Now.ToString();
                    if (ChB_Status.Checked)
                    {
                        payment.Status = true;
                    }
                    else
                    {
                        payment.Status = false;
                    }
                    payment.Rent = rent;
                    payment.Service = service;
                    payment.House = house;
                    payment.TenantTypeID = _tenantTypeID;
                    payment.PaymentType = CB_PeriodOfPayment.SelectedItem.ToString();

                    try
                    {
                        db.Payments.Add(payment);
                        db.SaveChanges();
                        MessageBox.Show("Тарифный план добавлен успешно!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                
            }
            
        }

        private void CB_Hostels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _hostelID = (int)CB_Hostels.SelectedValue;
            }
            catch
            {
                return;
            }
        }

        private void CB_RoomTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _roomTypeID = (int)CB_RoomTypes.SelectedValue;
            }
            catch
            {
                return;
            }
        }

        private void CB_TenantTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _tenantTypeID = (int)CB_TenantTypes.SelectedValue;
            }
            catch
            {
                return;
            }
        }

        private void AdminPaymentsFormAdd_Shown(object sender, EventArgs e)
        {
            if (_paymentID != 0)
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Payment payment = db.Payments.Where(x => x.ID == _paymentID).FirstOrDefault();

                    if (payment != null)
                    {
                        CB_Hostels.SelectedValue = _hostelID = (int)payment.HostelID;
                        CB_PeriodOfPayment.SelectedItem = payment.PaymentType;
                        CB_RoomTypes.SelectedValue = _roomTypeID = (int)payment.RoomTypeID;
                        CB_TenantTypes.SelectedValue = _tenantTypeID= (int)payment.TenantTypeID;
                        TB_Name.Text = payment.Name;
                        TB_Description.Text = payment.Description;
                        TB_Coast.Text = payment.Rent.ToString();
                        TB_Service.Text = payment.Service.ToString();
                        TB_House.Text = payment.House.ToString();
                        ChB_Status.Checked = payment.Status;
                    }
                }
            }
            else
            {
                TB_Coast.Text = TB_Service.Text = TB_House.Text = "0";
            }
        }
    }
}
