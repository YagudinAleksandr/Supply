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
    public partial class TenantUpdateInformation : Form
    {
        private int _tenantID;
        private int _paymentTypeID;
        private int _tenantTypeID;
        private int _docTypeID;
        private int _orderID;
        private int _roomID;
        private bool _edit;

        public TenantUpdateInformation(int tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
            _edit = true;
        }

        private void TenantUpdateInformation_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(LoadMainInformation);
            thread.Start();
        }

        private void CB_TenantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _tenantTypeID = (int)CB_TenantType.SelectedValue;
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Room room = db.Rooms.Where(x => x.ID == _roomID).Include(y => y.RoomType).First();
                    Flat flat = db.Flats.Where(x => x.ID == room.FlatID).Include(y => y.Enterance).First();
                    Hostel hostel = db.Hostels.Where(x => x.ID == flat.Enterance.HostelId).First();

                    var payments = db.Payments.Where(x => x.HostelID == hostel.ID).Where(y => y.RoomTypeID == room.RoomType.ID).Where(tt => tt.TenantTypeID == _tenantTypeID).ToList();

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
        private void CB_DocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _docTypeID = (int)CB_DocType.SelectedValue;
            }
            catch
            {

            }
        }
        private void BTN_AdditionalInformation_Click(object sender, EventArgs e)
        {
            TenantAdditionalInformationAdd tenantAdditionalInformationAdd = new TenantAdditionalInformationAdd(_tenantID);
            tenantAdditionalInformationAdd.ShowDialog();
        }

        private void BTN_OrderInformation_Click(object sender, EventArgs e)
        {
            OrderAddForm orderAddForm = new OrderAddForm(_orderID);
            orderAddForm.ShowDialog();
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            string validationError = string.Empty;
            if (ValidationCheck(out validationError) != true)
            {
                MessageBox.Show(validationError);
                return;
            }

            using (SupplyDbContext db = new SupplyDbContext()) 
            {
                Tenant tenant = db.Tenants.Where(id => id.ID == _tenantID).FirstOrDefault();
                if (tenant != null) 
                {
                    tenant.UpdatedAt = DateTime.Now.ToString();
                    tenant.PaymentID = _paymentTypeID;
                    tenant.TenantTypeID = _tenantTypeID;
                    if(ChB_Status.Checked)
                    {
                        tenant.Status = true;
                    }
                    else
                    {
                        tenant.Status = false;
                    }
                    
                    try
                    {
                        db.Entry(tenant).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                        thread.Start("Class:TenantUpdateInformation.cs. Method: BTN_Save_Click" + ex.Message + "." + ex.InnerException);
                        MessageBox.Show(ex.Message);
                        this.Close();
                    }

                    Identification identification = db.Identifications.Where(id => id.ID == _tenantID).FirstOrDefault();
                    if (identification != null) 
                    {
                        identification.Surename = TB_Surename.Text;
                        identification.Name = TB_Name.Text;
                        if (TB_Patronymic.Text != "")
                        {
                            identification.Patronymic = TB_Patronymic.Text;
                        }
                        identification.DocumentTypeID = _docTypeID;
                        identification.DocumentSeries = TB_DocSeries.Text;
                        identification.DocumentNumber = TB_DocNumber.Text;
                        identification.Issued = TB_Issued.Text;
                        identification.GivenDate = TB_GivenDate.Text;
                        identification.Address = TB_Address.Text;
                        identification.DateOfBirth = TB_DateOfBirth.Text;
                        identification.Cityzenship = TB_Cityzenship.Text;
                        if (TB_Code.Text != "")
                        {
                            identification.Code = TB_Code.Text;
                        }
                        identification.UpdatedAt = DateTime.Now.ToString();

                        try
                        {
                            if (_edit == true) 
                            {
                                db.Entry(identification).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                            
                            MessageBox.Show("Данные изменены успешно!");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                            thread.Start("Class:TenantUpdateInformation.cs. Method: BTN_Save_Click" + ex.Message + "." + ex.InnerException);
                            MessageBox.Show(ex.Message);
                            this.Close();
                        }
                    }
                    else
                    {
                        if (_edit == false)
                        {
                            identification = new Identification();
                            identification.ID = _tenantID;
                            identification.Surename = TB_Surename.Text;
                            identification.Name = TB_Name.Text;
                            if (TB_Patronymic.Text != "")
                            {
                                identification.Patronymic = TB_Patronymic.Text;
                            }
                            identification.DocumentTypeID = _docTypeID;
                            identification.DocumentSeries = TB_DocSeries.Text;
                            identification.DocumentNumber = TB_DocNumber.Text;
                            identification.Issued = TB_Issued.Text;
                            identification.GivenDate = TB_GivenDate.Text;
                            identification.Address = TB_Address.Text;
                            identification.DateOfBirth = TB_DateOfBirth.Text;
                            identification.Cityzenship = TB_Cityzenship.Text;
                            if (TB_Code.Text != "")
                            {
                                identification.Code = TB_Code.Text;
                            }
                            identification.UpdatedAt = DateTime.Now.ToString();
                            identification.CreatedAt = DateTime.Now.ToString();
                            try
                            {
                                db.Identifications.Add(identification);
                                db.SaveChanges();

                                MessageBox.Show("Данные изменены успешно!");
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                                thread.Start("Class:TenantUpdateInformation.cs. Method: BTN_Save_Click" + ex.Message + "." + ex.InnerException);
                                MessageBox.Show(ex.Message);
                                this.Close();
                            }
                        }
                        

                    }

                }
            }
        }

        #region Private methods for load

        private void LoadMainInformation()
        {
            Action action = () =>
              {
                  using (SupplyDbContext db = new SupplyDbContext()) 
                  {
                      try
                      {
                          CB_DocType.DataSource = db.DocumentTypes.ToList();
                          CB_DocType.DisplayMember = "Name";
                          CB_DocType.ValueMember = "ID";

                          CB_TenantType.DataSource = db.TenantTypes.ToList();
                          CB_TenantType.DisplayMember = "Name";
                          CB_TenantType.ValueMember = "ID";
                          Tenant tenant = db.Tenants.Where(id => id.ID == _tenantID).Include(tid => tid.Identification).FirstOrDefault();

                          Room room = db.Rooms.Where(x => x.ID == tenant.RoomID).Include(y => y.RoomType).First();
                          Flat flat = db.Flats.Where(x => x.ID == room.FlatID).Include(y => y.Enterance).First();
                          Hostel hostel = db.Hostels.Where(x => x.ID == flat.Enterance.HostelId).First();

                          var payments = db.Payments.Where(x => x.HostelID == hostel.ID).Where(y => y.RoomTypeID == room.RoomType.ID).Where(tt => tt.TenantTypeID == tenant.TenantTypeID).ToList();

                          CB_PaymentType.DataSource = payments;
                          CB_PaymentType.DisplayMember = "Name";
                          CB_PaymentType.ValueMember = "ID";

                          

                          if (tenant != null)
                          {
                              _orderID = tenant.ID;
                              _roomID = tenant.RoomID;
                              if (tenant.Identification != null) 
                              {
                                  TB_Surename.Text = tenant.Identification.Surename;
                                  TB_Name.Text = tenant.Identification.Name;
                                  TB_DateOfBirth.Text = tenant.Identification.DateOfBirth;
                                  if (tenant.Identification.Patronymic != null)
                                  {
                                      TB_Patronymic.Text = tenant.Identification.Patronymic;
                                  }
                                  TB_GivenDate.Text = tenant.Identification.GivenDate;
                                  TB_DocSeries.Text = tenant.Identification.DocumentSeries;
                                  TB_DocNumber.Text = tenant.Identification.DocumentNumber;
                                  TB_Issued.Text = tenant.Identification.Issued;
                                  TB_Cityzenship.Text = tenant.Identification.Cityzenship;
                                  TB_Address.Text = tenant.Identification.Address;
                                  if (tenant.Identification.Code != null)
                                  {
                                      TB_Code.Text = tenant.Identification.Code;
                                  }

                                  if (tenant.Status == true)
                                  {
                                      ChB_Status.Checked = true;
                                  }

                                  CB_DocType.SelectedValue = _docTypeID = tenant.Identification.DocumentTypeID;
                                  CB_PaymentType.SelectedValue = _paymentTypeID = (int)tenant.PaymentID;
                                  CB_TenantType.SelectedValue = _tenantTypeID = (int)tenant.TenantTypeID;
                              }
                              else
                              {
                                  _edit = false;
                              }
                              
                          }
                          else
                          {
                              string errorMessage = "Возникла проблема с ID жильца. Значение равно 0";
                              string cls = "Class:TenantUpdateInformation.cs. Method:LoadMainInformation.";
                              Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                              thread.Start(cls + errorMessage);
                              MessageBox.Show(errorMessage);
                              this.Close();
                          }
                      }
                      catch(Exception ex)
                      {
                          Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                          thread.Start("Class:TenantUpdateInformation.cs. Method:LoadMainInformation." + ex.Message + "." + ex.InnerException);
                          MessageBox.Show(ex.Message);
                          this.Close();
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
        private bool ValidationCheck(out string validerror)
        {
            validerror = string.Empty;
            if (TB_Surename.Text == "")
            {
                validerror = "Заполните поле Фамилия!";
                return false;
            }

            if (TB_Name.Text == "")
            {
                validerror = "Заполните поле Имя!";
                return false;
            }

            string dateCheck = TB_DateOfBirth.Text.Replace(".", "");

            if (dateCheck == "")
            {
                validerror = "Заполните поле Дата рождения!";
                return false;
            }

            if (_docTypeID == 0)
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

            if (TB_Issued.Text == "")
            {
                validerror = "Заполните поле кем выдан документ!";
                return false;
            }

            if (TB_Cityzenship.Text == "")
            {
                validerror = "Заполните поле гражданство!";
                return false;
            }
            if (TB_Address.Text == "")
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
        #endregion


    }
}
