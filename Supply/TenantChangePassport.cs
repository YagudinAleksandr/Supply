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
    public partial class TenantChangePassport : Form
    {
        private Tenant _tenant;
        private int _documentTypeID;
        private int _licenseID;
        public TenantChangePassport(Tenant tenant)
        {
            InitializeComponent();
            _tenant = tenant;
            _documentTypeID = _licenseID = 0;
        }

        private void TenantChangePassport_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(LoadInformation);
            thread.Start();
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            ChangePassport changePassport = new ChangePassport();

            if (_licenseID == 0)
            {
                MessageBox.Show("Выбирите ответственного за договор!");
                return;
            }

            changePassport.CreatedAt = DateTime.Now.ToString();
            changePassport.UpdatedAt = DateTime.Now.ToString();
            changePassport.StartDate = DateTime.Now.ToShortDateString();
            changePassport.Surename = TB_Surename.Text;
            changePassport.Name = TB_Name.Text;
            changePassport.Patronymic = TB_Patronimic.Text;
            changePassport.DateOfBirth = TB_DateOfBirth.Text;
            changePassport.Address = TB_Address.Text;
            changePassport.Issued = TB_Issued.Text;
            changePassport.GivenDate = TB_GivenDate.Text;
            changePassport.Citizenship = TB_Citizenship.Text;
            changePassport.Series = TB_DocSeries.Text;
            changePassport.Number = TB_DocNumber.Text;
            changePassport.Status = true;
            changePassport.TenantID = _tenant.ID;
            changePassport.Code = TB_DocCode.Text;
            changePassport.DocumentTypeID = _documentTypeID;
            changePassport.LicenseID = _licenseID;
            using(SupplyDbContext db = new SupplyDbContext())
            {
                
                try
                {
                    var changepassports = db.ChangePassports.Where(tid => tid.TenantID == _tenant.ID).Where(s => s.Status == true).ToList();
                    if(changepassports!=null)
                    {
                        foreach(ChangePassport cp in changepassports)
                        {
                            cp.Status = false;
                            cp.UpdatedAt = DateTime.Now.ToString();
                            db.Entry(cp).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                    db.ChangePassports.Add(changePassport);
                    db.SaveChanges();

                    string error = string.Empty;

                    if (!OrdersCreation.ChangePassportCreate(changePassport.ID, out error))
                    {
                        MessageBox.Show(error);
                    }

                    MessageBox.Show("Паспортные данные изменены!");
                    this.Close();
                }
                catch(Exception ex)
                {
                    Log log = new Log();
                    log.ID = Guid.NewGuid();
                    log.Type = "ERROR";
                    log.CreatedAt = DateTime.Now.ToString();
                    log.Caption = $"Class: TenantChangePassport. Method:BTN_Save_Click. {ex.Message}.{ex.InnerException}";

                    db.Logs.Add(log);
                    db.SaveChanges();

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadInformation()
        {
            Action action = () =>
              {
                  using(SupplyDbContext db = new SupplyDbContext())
                  {
                      CB_DocType.DataSource = db.DocumentTypes.ToList();
                      CB_DocType.ValueMember = "ID";
                      CB_DocType.DisplayMember = "Name";

                      Tenant tenant = db.Tenants.Where(id => id.ID == _tenant.ID).Include(ident => ident.Identification).FirstOrDefault();
                      if(tenant!=null)
                      {
                          ChangePassport changePassport = db.ChangePassports.Where(tid => tid.TenantID == _tenant.ID).Where(st => st.Status == true).FirstOrDefault();

                          if (changePassport != null)
                          {
                              LB_TenantName.Text = tenant.Identification.Surename + " " + tenant.Identification.Name;
                              if (tenant.Identification.Patronymic != null)
                              {
                                  LB_TenantName.Text += tenant.Identification.Patronymic;
                              }

                              TB_Address.Text = changePassport.Address;
                              TB_Citizenship.Text = changePassport.Citizenship;
                              TB_DocCode.Text = changePassport.Code;
                              TB_DocNumber.Text = changePassport.Number;
                              TB_Issued.Text = changePassport.Issued;
                              TB_DocSeries.Text = changePassport.Series;
                              TB_GivenDate.Text = changePassport.GivenDate;
                              TB_DateOfBirth.Text = changePassport.DateOfBirth;
                              TB_Surename.Text = changePassport.Surename;
                              TB_Name.Text = changePassport.Name;
                              TB_Patronimic.Text = changePassport.Patronymic;
                              CB_DocType.SelectedValue = changePassport.DocumentTypeID;
                              _documentTypeID = changePassport.DocumentTypeID;

                              var licenses = db.Licenses.Where(s => s.Status == true).Include(m => m.Manager).ToList();

                              for (int i = 0; i < licenses.Count; i++)
                              {
                                  licenses[i].Name = licenses[i].Manager.Surename + " " + licenses[i].Manager.Name + " " + licenses[i].Manager.Patronymic + "(" + licenses[i].Name + ")";
                              }

                              CB_Licenses.DataSource = licenses;
                              CB_Licenses.DisplayMember = "Name";
                              CB_Licenses.ValueMember = "ID";

                              CB_Licenses.SelectedValue = _licenseID = (int)changePassport.LicenseID;
                          }
                          else
                          {
                              LB_TenantName.Text = tenant.Identification.Surename + " " + tenant.Identification.Name;
                              if (tenant.Identification.Patronymic != null)
                              {
                                  LB_TenantName.Text += tenant.Identification.Patronymic;
                              }
                              TB_Address.Text = tenant.Identification.Address;
                              TB_Citizenship.Text = tenant.Identification.Cityzenship;
                              TB_DocCode.Text = tenant.Identification.Code;
                              TB_DocNumber.Text = tenant.Identification.DocumentNumber;
                              TB_Issued.Text = tenant.Identification.Issued;
                              TB_DocSeries.Text = tenant.Identification.DocumentSeries;
                              TB_GivenDate.Text = tenant.Identification.GivenDate;
                              TB_DateOfBirth.Text = tenant.Identification.DateOfBirth;
                              TB_Surename.Text = tenant.Identification.Surename;
                              TB_Name.Text = tenant.Identification.Name;
                              TB_Patronimic.Text = tenant.Identification.Patronymic;
                              CB_DocType.SelectedValue = tenant.Identification.DocumentTypeID;
                              _documentTypeID = tenant.Identification.DocumentTypeID;

                              var licenses = db.Licenses.Where(s => s.Status == true).Include(m => m.Manager).ToList();

                              for (int i = 0; i < licenses.Count; i++) 
                              {
                                  licenses[i].Name = licenses[i].Manager.Surename + " " + licenses[i].Manager.Name + " " + licenses[i].Manager.Patronymic + "(" + licenses[i].Name + ")";
                              }

                              CB_Licenses.DataSource = licenses;
                              CB_Licenses.DisplayMember = "Name";
                              CB_Licenses.ValueMember = "ID";
                          }
                      }
                      else
                      {
                          Log log = new Log();
                          log.ID = Guid.NewGuid();
                          log.Type = "ERROR";
                          log.CreatedAt = DateTime.Now.ToString();
                          log.Caption = $"Class: TenantChangePassport. Method:LoadInformation. tenant variable equil NULL";

                          db.Logs.Add(log);
                          db.SaveChanges();

                          MessageBox.Show("Значение ID равно NULL");
                          this.Close();
                      }
                  }
              };

            Invoke(action);
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

        private void CB_Licenses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                _licenseID = (int)CB_Licenses.SelectedValue;
            }
            catch
            {
                return;
            }
        }
    }
}
