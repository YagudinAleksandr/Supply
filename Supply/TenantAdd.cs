using Supply.Domain;
using Supply.Models;
using System;
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
        public TenantAdd(int roomID)
        {
            InitializeComponent();
            _roomID = roomID;
            _tenantID = _documentTypeID = _tenantTypeID = 0;
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
                    MessageBox.Show(ex.Message);
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
            }
            catch
            {
                return;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
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
    }
}
