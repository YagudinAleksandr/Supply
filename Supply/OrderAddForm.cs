using Supply.Domain;
using Supply.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class OrderAddForm : Form
    {
        private Tenant _tenantID;
        private int _selectedIndexOfManagers;
        public OrderAddForm(Tenant tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
            _selectedIndexOfManagers = 0;
        }

        private void OrderAddForm_Load(object sender, EventArgs e)
        {
            TB_OrderNumber.Text = _tenantID.ID.ToString();

            using(SupplyDbContext db = new SupplyDbContext())
            {
                var managers = db.Managers.ToList();

                for (int i = 0; i < managers.Count; i++)
                {
                    managers[i].Surename += " " + managers[i].Name + " " + managers[i].Patronymic;
                }

                CB_Managers.DataSource = managers;
                CB_Managers.DisplayMember = "Surename";
                CB_Managers.ValueMember = "ID";
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                Order order = new Order();
                order.OrderNumber = TB_OrderNumber.Text;
                order.ID = _tenantID.ID;
                order.StartDate = TB_StartDate.Text;
                order.EndDate = TB_EndDate.Text;
                order.RoomID = _tenantID.RoomID;
                order.ManagerID = _selectedIndexOfManagers;
                order.CreatedAt = DateTime.Now.ToString();
                order.UpdatedAt = DateTime.Now.ToString();

                try
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Не удалось создать договор!"+$" {ex.Message}");
                    return;
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
    }
}
