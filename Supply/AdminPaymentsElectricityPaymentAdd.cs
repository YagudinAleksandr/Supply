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
    public partial class AdminPaymentsElectricityPaymentAdd : Form
    {
        private bool _edit;
        private int _paymentID;
        private int _hostelID;
        public AdminPaymentsElectricityPaymentAdd()
        {
            InitializeComponent();
            _edit = false;
            _hostelID = 0;
            _paymentID = 0;
        }
        public AdminPaymentsElectricityPaymentAdd(int id)
        {
            InitializeComponent();
            _edit = true;
            _paymentID = id;
        }

        private void AdminPaymentsElectricityPaymentAdd_Shown(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                CB_Hostels.DataSource = db.Hostels.ToList();
                CB_Hostels.DisplayMember = "Name";
                CB_Hostels.ValueMember = "ID";
            }

            if (_edit == true)
            {
                Thread thread = new Thread(UpdateInformation);
                thread.Start();
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

        

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            string validationError = string.Empty;
            if (CheckValidation(out validationError) != true)
            {
                MessageBox.Show(validationError);
                return;
            }

            using (SupplyDbContext db = new SupplyDbContext())
            {
                if (_edit == true)
                {
                    ElectricityPayment electricityPayment = db.ElectricityPayments.Where(x => x.ID == _paymentID).FirstOrDefault();
                    electricityPayment.Name = TB_Name.Text;
                    electricityPayment.UpdatedAt = DateTime.Now.ToString();
                    if(ChB_Status.Checked)
                    {
                        electricityPayment.Status = true;
                    }
                    else
                    {
                        electricityPayment.Status = false;
                    }
                    electricityPayment.HostelID = _hostelID;

                    try
                    {
                        db.Entry(electricityPayment).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Тарифный план обновлен!");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                        thread.Start("Class:AdminPaymentsElectricityPaymentAdd. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException);
                        MessageBox.Show(ex.Message);
                        this.Close();
                    }
                }
                else
                {
                    ElectricityPayment electricityPayment = new ElectricityPayment();
                    electricityPayment.HostelID = _hostelID;
                    electricityPayment.Name = TB_Name.Text;
                    electricityPayment.CreatedAt = DateTime.Now.ToString();
                    electricityPayment.UpdatedAt = DateTime.Now.ToString();
                    if(ChB_Status.Checked)
                    {
                        electricityPayment.Status = true;
                    }
                    else
                    {
                        electricityPayment.Status = false;
                    }

                    try
                    {
                        db.ElectricityPayments.Add(electricityPayment);
                        db.SaveChanges();
                        MessageBox.Show("Тарифный план добавлен успешно!");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                        thread.Start("Class:AdminPaymentsElectricityPaymentAdd. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException);
                        MessageBox.Show(ex.Message);
                        this.Close();
                    }
                }
            }
        }

        #region Private methods
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
        private void UpdateInformation()
        {
            Action action = () =>
            {

                using (SupplyDbContext db = new SupplyDbContext())
                {
                    ElectricityPayment electricityPayment = db.ElectricityPayments.Where(x => x.ID == _paymentID).Include(hid => hid.Hostel).FirstOrDefault();
                    CB_Hostels.SelectedValue = electricityPayment.Hostel.ID;
                    TB_Name.Text = electricityPayment.Name;
                    if (electricityPayment.Status == true)
                    {
                        ChB_Status.Checked = true;
                    }
                    else
                    {
                        ChB_Status.Checked = false;
                    }
                    _hostelID = electricityPayment.HostelID;
                }
            };
            Invoke(action);
        }

        private bool CheckValidation(out string validError)
        {
            validError = string.Empty;
            if (_hostelID == 0)
            {
                validError = "Выбирите общежитие!";
                return false;
            }
            if(TB_Name.Text=="")
            {
                validError = "Введите название!";
                return false;
            }
            return true;
        }
        #endregion
    }
}
