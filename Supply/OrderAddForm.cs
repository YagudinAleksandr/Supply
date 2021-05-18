using Supply.Domain;
using Supply.Models;
using System;
using System.Windows.Forms;

namespace Supply
{
    public partial class OrderAddForm : Form
    {
        private Tenant _tenantID;
        public OrderAddForm(Tenant tenantID)
        {
            InitializeComponent();
            _tenantID = tenantID;
        }

        private void OrderAddForm_Load(object sender, EventArgs e)
        {
            TB_OrderNumber.Text = _tenantID.ID.ToString();
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
    }
}
