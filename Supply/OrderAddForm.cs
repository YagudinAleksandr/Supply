using Supply.Domain;
using Supply.Models;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class OrderAddForm : Form
    {
        private Tenant _tenantID;
        private int _selectedIndexOfManagers;
        private bool _edit;
        private int _orderID;
        public OrderAddForm(Tenant tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
            _selectedIndexOfManagers = 0;
            _edit = false;
        }
        public OrderAddForm(int orderID)
        {
            InitializeComponent();
            _edit = true;
            _orderID = orderID;
        }

        private void OrderAddForm_Load(object sender, EventArgs e)
        {
            if (_edit == false)
            {
                TB_OrderNumber.Text = _tenantID.ID.ToString();

                using (SupplyDbContext db = new SupplyDbContext())
                {
                    var licenses = db.Licenses.ToList();

                    for (int i = 0; i < licenses.Count; i++)
                    {
                        licenses[i].Name = licenses[i].Manager.Surename + " " + licenses[i].Manager.Name + " " + licenses[i].Manager.Patronymic + " " + licenses[i].Name + $"({licenses[i].StartDate})";
                    }

                    CB_Managers.DataSource = licenses;
                    CB_Managers.DisplayMember = "Name";
                    CB_Managers.ValueMember = "ID";
                }
            }
            else
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Order order = db.Orders.Where(id => id.ID == _orderID).FirstOrDefault();
                    Tenant tenant = db.Tenants.Where(id => id.ID == _orderID).FirstOrDefault();
                    if (order != null) 
                    {
                        TB_OrderNumber.Text = order.OrderNumber;
                        
                        var licenses = db.Licenses.ToList();

                        for (int i = 0; i < licenses.Count; i++)
                        {
                            licenses[i].Name = licenses[i].Manager.Surename + " " + licenses[i].Manager.Name + " " + licenses[i].Manager.Patronymic + " " + licenses[i].Name + $"({licenses[i].StartDate})";
                        }
                        TB_StartDate.Text = order.StartDate;
                        TB_EndDate.Text = order.EndDate;

                        CB_Managers.DataSource = licenses;
                        CB_Managers.DisplayMember = "Name";
                        CB_Managers.ValueMember = "ID";

                        CB_Managers.SelectedValue = order.LicenseID;
                    }
                    else
                    {

                        _tenantID = tenant;
                        TB_OrderNumber.Text = _orderID.ToString();
                        var licenses = db.Licenses.ToList();

                        for (int i = 0; i < licenses.Count; i++)
                        {
                            licenses[i].Name = licenses[i].Manager.Surename + " " + licenses[i].Manager.Name + " " + licenses[i].Manager.Patronymic + " " + licenses[i].Name + $"({licenses[i].StartDate})";
                        }

                        CB_Managers.DataSource = licenses;
                        CB_Managers.DisplayMember = "Name";
                        CB_Managers.ValueMember = "ID";
                        _edit = false;
                    }
                    
                }
            }
            
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (_edit == false)
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Order order = new Order();
                    order.OrderNumber = TB_OrderNumber.Text;
                    order.ID = _tenantID.ID;
                    order.StartDate = TB_StartDate.Text;
                    order.EndDate = TB_EndDate.Text;
                    order.RoomID = _tenantID.RoomID;
                    order.LicenseID = _selectedIndexOfManagers;
                    order.CreatedAt = DateTime.Now.ToString();
                    order.UpdatedAt = DateTime.Now.ToString();

                    try
                    {
                        db.Orders.Add(order);
                        db.SaveChanges();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                        thread.Start("Class: OrderAddForm.cs. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException);
                        MessageBox.Show("Не удалось создать договор!" + $" {ex.Message}");
                        return;
                    }
                }
            }
            else
            {
                using (SupplyDbContext db = new SupplyDbContext()) 
                {
                    Order order = db.Orders.Where(id => id.ID == _orderID).FirstOrDefault();
                    order.OrderNumber = TB_OrderNumber.Text;
                    order.StartDate = TB_StartDate.Text;
                    order.EndDate = TB_EndDate.Text;
                    order.LicenseID = _selectedIndexOfManagers;
                    order.UpdatedAt = DateTime.Now.ToString();

                    try
                    {
                        db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Данные изменены успешно!");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(AddLog));
                        thread.Start("Class: OrderAddForm.cs. Method: BTN_Save_Click." + ex.Message + "." + ex.InnerException);
                        MessageBox.Show("Не удалось изменить договор!" + $" {ex.Message}");
                    }
                }
            }
            
        }

        private void CB_Managers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _selectedIndexOfManagers = (int)CB_Managers.SelectedValue;

            }
            catch
            {
                return;
            }
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
