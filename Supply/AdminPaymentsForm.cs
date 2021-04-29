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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminPaymentsForm : Form
    {
        private int _userID;
        public AdminPaymentsForm(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void AdminPaymentsForm_Load(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            AdminPaymentsFormAdd adminPaymentsFormAdd = new AdminPaymentsFormAdd(_userID);
            adminPaymentsFormAdd.ShowDialog();
            UpdateInfo();
        }
        private void UpdateInfo()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                DG_Payments.Rows.Clear();

                try
                {

                    foreach (Payment payment in db.Payments.Include(user => user.User).Include(hostels => hostels.Hostel).Include(roomTypes => roomTypes.RoomType).Include(tenantType=>tenantType.TenantType))
                    {
                        int rowNumber = DG_Payments.Rows.Add();

                        DG_Payments.Rows[rowNumber].Cells[COL_ID.Name].Value = payment.ID;
                        DG_Payments.Rows[rowNumber].Cells[COL_Name.Name].Value = payment.Name;
                        DG_Payments.Rows[rowNumber].Cells[COL_Hostel.Name].Value = payment.Hostel.Name;
                        DG_Payments.Rows[rowNumber].Cells[COL_Manager.Name].Value = payment.User.Name;
                        DG_Payments.Rows[rowNumber].Cells[COL_RoomType.Name].Value = payment.RoomType.Name;
                        DG_Payments.Rows[rowNumber].Cells[COL_TenantType.Name].Value = payment.TenantType.Name;
                        DG_Payments.Rows[rowNumber].Cells[COL_UpdatedAt.Name].Value = payment.UpdatedAt;
                        DG_Payments.Rows[rowNumber].Cells[COL_Status.Name].Value = payment.Status;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
