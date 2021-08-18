using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminBenefitPaymentAdd : Form
    {
        private int _benefitPaymentID;
        private int _benefitTypeID;
        private int _hostelID;
        public AdminBenefitPaymentAdd()
        {
            InitializeComponent();
            _benefitPaymentID = _benefitTypeID = _hostelID = 0;
        }
        public AdminBenefitPaymentAdd(int benefitPaymentID)
        {
            InitializeComponent();
            _benefitPaymentID = benefitPaymentID;
            _benefitTypeID = _hostelID = 0;
        }

        private void AdminBenefitPaymentAdd_Load(object sender, EventArgs e)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                CB_BenefitType.DataSource = db.BenefitTypes.ToList();
                CB_BenefitType.ValueMember = "ID";
                CB_BenefitType.DisplayMember = "Name";

                CB_Hostels.DataSource = db.Hostels.ToList();
                CB_Hostels.ValueMember = "ID";
                CB_Hostels.DisplayMember = "Name";

                if (_benefitPaymentID != 0)
                {
                    BenefitPayment benefitPayment = db.BenefitPayments.Where(x => x.ID == _benefitPaymentID).FirstOrDefault();

                    if (benefitPayment == null)
                    {
                        MessageBox.Show("Не найден тарифный план!");

                        this.Close();
                    }

                    TB_Price.Text = benefitPayment.Price.ToString();
                    CB_BenefitType.SelectedValue = _benefitTypeID = benefitPayment.BenefitTypeID;
                    CB_Hostels.SelectedValue = _hostelID = benefitPayment.HostelID;
                    ChB_Status.Checked = benefitPayment.Status;
                }
            }

            
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if(_hostelID==0)
            {
                MessageBox.Show("Выбирите общежитие!");
                return;
            }
            if(_benefitTypeID==0)
            {
                MessageBox.Show("Выбирите тип льготы!");
                return;
            }
            decimal price = 0;
            if(!decimal.TryParse(TB_Price.Text,out price))
            {
                MessageBox.Show("В поле цена должно быть число!");
                return;
            }

            if (_benefitPaymentID == 0)
            {
                BenefitPayment benefitPayment = new BenefitPayment();
                benefitPayment.BenefitTypeID = _benefitTypeID;
                benefitPayment.HostelID = _hostelID;
                benefitPayment.CreatedAt = DateTime.Now.ToString();
                benefitPayment.UpdatedAt = DateTime.Now.ToString();
                if (ChB_Status.Checked)
                {
                    benefitPayment.Status = true;
                }
                else
                {
                    benefitPayment.Status = false;
                }
                benefitPayment.Price = price;

                using (SupplyDbContext db = new SupplyDbContext())
                {
                    try
                    {
                        db.BenefitPayments.Add(benefitPayment);
                        db.SaveChanges();
                        MessageBox.Show("Тариф создан успешно!");
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                        Log logInfo = new Log();
                        logInfo.ID = Guid.NewGuid();
                        logInfo.Type = "ERROR";
                        logInfo.Caption = $"Class: AdminBenefitPaymentAdd. Method: BTN_Save_Click. {ex.Message}. {ex.InnerException}";
                        logInfo.CreatedAt = DateTime.Now.ToString();
                        db.Logs.Add(logInfo);
                        db.SaveChanges();
                    }
                }

                
            }
            else
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    BenefitPayment benefitPayment = db.BenefitPayments.Where(x => x.ID == _benefitPaymentID).FirstOrDefault();

                    if (benefitPayment == null)
                    {
                        MessageBox.Show("Не найдено тарифного плана!");
                        return;
                    }

                    benefitPayment.Price = price;
                    benefitPayment.UpdatedAt = DateTime.Now.ToString();
                    benefitPayment.HostelID = _hostelID;
                    if(ChB_Status.Checked)
                    {
                        benefitPayment.Status = true;
                    }
                    else
                    {
                        benefitPayment.Status = false;
                    }
                    benefitPayment.BenefitTypeID = _benefitTypeID;

                    try
                    {
                        db.Entry(benefitPayment).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Тариф изменен успешно!");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                        Log logInfo = new Log();
                        logInfo.ID = Guid.NewGuid();
                        logInfo.Type = "ERROR";
                        logInfo.Caption = $"Class: AdminBenefitPaymentAdd. Method: BTN_Save_Click. {ex.Message}. {ex.InnerException}";
                        logInfo.CreatedAt = DateTime.Now.ToString();
                        db.Logs.Add(logInfo);
                        db.SaveChanges();
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

        private void CB_BenefitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _benefitTypeID = (int)CB_BenefitType.SelectedValue;
            }
            catch
            {
                return;
            }
        }
    }
}
