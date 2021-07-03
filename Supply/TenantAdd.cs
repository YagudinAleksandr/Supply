using Supply.Domain;
using Supply.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class TenantAdd : Form
    {
        private int _roomID;
        private int _tenantID;
        private int _documentTypeID;
        private int _tenantTypeID;
        private int _paymentTypeID;
        public TenantAdd(int roomID)
        {
            InitializeComponent();
            _roomID = roomID;
            _tenantID = _documentTypeID = _tenantTypeID = 0;
            _paymentTypeID = 0;
        }

        private void TenantAdd_Load(object sender, EventArgs e)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                Tenant tenant = new Tenant();
                tenant.RoomID = _roomID;
                tenant.CreatedAt = DateTime.Now.ToString();
                tenant.UpdatedAt = DateTime.Now.ToString();
                tenant.Status = false;
                try
                {
                    db.Tenants.Add(tenant);
                    db.SaveChanges();
                    _tenantID = tenant.ID;

                    comboBox1.DataSource = db.TenantTypes.ToList();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "ID";

                    CB_DocType.DataSource = db.DocumentTypes.ToList();
                    CB_DocType.DisplayMember = "Name";
                    CB_DocType.ValueMember = "ID";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message+"."+ex.InnerException);
                    this.Close();
                }
            }

            
        }

        private void CB_DocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _documentTypeID = (int)CB_DocType.SelectedValue;
            }
            catch
            {
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _tenantTypeID = (int)comboBox1.SelectedValue;

                using(SupplyDbContext db = new SupplyDbContext())
                {
                    Room room = db.Rooms.Where(x => x.ID == _roomID).Include(y => y.RoomType).First();
                    Flat flat = db.Flats.Where(x => x.ID == room.FlatID).Include(y => y.Enterance).First();
                    Hostel hostel = db.Hostels.Where(x => x.ID == flat.Enterance.HostelId).First();

                    var payments = db.Payments.Where(x => x.HostelID == hostel.ID).Where(y => y.RoomTypeID == room.RoomType.ID).Where(tt=>tt.TenantTypeID==_tenantTypeID).Where(s=>s.Status==true).ToList();

                    CB_PaymentType.DataSource = payments;
                    CB_PaymentType.DisplayMember = "Name";
                    CB_PaymentType.ValueMember = "ID";
                }
            }
            catch
            {
                return;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            string validError = string.Empty;
            if (ValidationCheck(out validError) != true) 
            {
                MessageBox.Show(validError);
                return;
            }

            Identification identification = new Identification();
            identification.Surename = TB_Surename.Text;
            identification.Name = TB_Name.Text;
            identification.Patronymic = TB_Patronymic.Text;
            identification.DateOfBirth = TB_DateOfBirth.Text;
            identification.DocumentTypeID = _documentTypeID;
            identification.DocumentSeries = TB_DocSeries.Text;
            identification.DocumentNumber = TB_DocNumber.Text;
            identification.Cityzenship = TB_Cityzenship.Text;
            identification.Issued = TB_Issued.Text;
            identification.Address = TB_Address.Text;
            identification.CreatedAt = DateTime.Now.ToString();
            identification.UpdatedAt = DateTime.Now.ToString();
            identification.GivenDate = TB_GivenDate.Text;
            identification.Code = TB_Code.Text;
            identification.ID = _tenantID;
            try
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    db.Identifications.Add(identification);
                    db.SaveChanges();

                    Tenant tenant = db.Tenants.Where(x => x.ID == _tenantID).First();
                    tenant.Status = true;
                    tenant.UpdatedAt = DateTime.Now.ToString();
                    tenant.TenantTypeID = _tenantTypeID;
                    tenant.PaymentID = _paymentTypeID;
                    db.Entry(tenant).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    OrderAddForm orderAddForm = new OrderAddForm(tenant);
                    this.Hide();
                    orderAddForm.ShowDialog();
                    this.Show();
                    MessageBox.Show("Жилец добавлен успешно!");
                    GC.Collect();
                    this.Close();
                }
                
            }
            catch(DbEntityValidationException ex)
            {
                string err = "";
                foreach(DbEntityValidationResult validErr in ex.EntityValidationErrors)
                {
                    err += validErr.Entry.Entity.ToString()+":";
                    int i = 0;
                    foreach(DbValidationError error in validErr.ValidationErrors)
                    {
                        i++;
                        err += $"{i}.{error.ErrorMessage};";
                    }
                }
                MessageBox.Show(err);
            }
        }

        private void BTN_AdditionalInformation_Click(object sender, EventArgs e)
        {
            TenantAdditionalInformationAdd tenantAdditionalInformationAdd = new TenantAdditionalInformationAdd(_tenantID);
            tenantAdditionalInformationAdd.ShowDialog();
        }

        private void CB_PaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _paymentTypeID = (int)CB_PaymentType.SelectedValue;
            }
            catch
            {
                return;
            }
        }

        private bool ValidationCheck(out string validerror)
        {
            validerror = string.Empty;
            if(TB_Surename.Text=="")
            {
                validerror = "Заполните поле Фамилия!";
                return false;
            }

            if(TB_Name.Text=="")
            {
                validerror = "Заполните поле Имя!";
                return false;
            }

            string dateCheck = TB_DateOfBirth.Text.Replace(".","");

            if(dateCheck=="")
            {
                validerror = "Заполните поле Дата рождения!";
                return false;
            }

            if(_documentTypeID==0)
            {
                validerror = "Выбирите тип документа!";
                return false;
            }
            if (TB_DocSeries.Text == "")
            {
                validerror = "Заполните поле Серия";
                return false;
            }
            if (TB_DocNumber.Text == "")
            {
                validerror = "Заполните поле Номер!";
                return false;
            }

            dateCheck = TB_GivenDate.Text.Replace(".", "");
            if (dateCheck == "")
            {
                validerror = "Заполните дату выдачи документа!";
                return false;
            }

            if(TB_Issued.Text=="")
            {
                validerror = "Заполните поле кем выдан документ!";
                return false;
            }

            if(TB_Cityzenship.Text=="")
            {
                validerror = "Заполните поле гражданство!";
                return false;
            }
            if(TB_Address.Text=="")
            {
                validerror = "Заполните поле Адрес!";
                return false;
            }
            if (_paymentTypeID == 0)
            {
                validerror = "Выбирите тип тарифного плана!";
                return false;
            }
            if (_tenantTypeID == 0)
            {
                validerror = "Выбирите тип жильца!";
                return false;
            }

            return true;
        }
    }
}
