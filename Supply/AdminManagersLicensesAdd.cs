using Supply.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supply.Models;

namespace Supply
{
    public partial class AdminManagersLicensesAdd : Form
    {
        private int _managerId;
        private int _licenseID;
        private bool _edit;
        public AdminManagersLicensesAdd(int managerId)
        {
            InitializeComponent();
            _managerId = managerId;
            _edit = false;
        }
        public AdminManagersLicensesAdd(int licenseID, bool edit)
        {
            InitializeComponent();
            _licenseID = licenseID;
            _edit = edit;
        }
        private void BTN_Add_Click(object sender, EventArgs e)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                if(_edit==false)
                {
                    Models.License license = new Models.License()
                    {
                        Name = TB_Name.Text,
                        Type = CB_Types.SelectedItem.ToString(),
                        StartDate = TB_StartDate.Text,
                        EndDate = TB_EndDate.Text,
                        ManagerId = _managerId,
                        Status = CB_Status.Checked
                    };
                    try
                    {
                        db.Licenses.Add(license);
                        db.SaveChanges();
                        MessageBox.Show("Лицензия добавлена успешно!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                else
                {
                    Models.License license = db.Licenses.Where(id => id.ID == _licenseID).FirstOrDefault();

                    license.StartDate = TB_StartDate.Text;
                    license.EndDate = TB_EndDate.Text;
                    license.Status = CB_Status.Checked;
                    license.Name = TB_Name.Text;

                    try
                    {
                        db.Entry(license).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Лицензтя изменена успешно!");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
        }

        private void AdminManagersLicensesAdd_Load(object sender, EventArgs e)
        {
            if (_edit == true)
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    Models.License license = db.Licenses.Where(id => id.ID == _licenseID).FirstOrDefault();

                    TB_Name.Text = license.Name;
                    CB_Types.SelectedItem = license.Type;
                    TB_StartDate.Text = license.StartDate;
                    TB_EndDate.Text = license.EndDate;
                    CB_Status.Checked = license.Status;
                }
            }
        }
    }
}
