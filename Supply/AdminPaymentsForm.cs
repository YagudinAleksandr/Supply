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
            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Изменить";
            dataGridViewButtonColumn2.Name = "COL_Settings";
            dataGridViewButtonColumn2.Text = "Изменить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_Payments.Columns.Add(dataGridViewButtonColumn2);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_Payments.Columns.Add(dataGridViewButtonColumn3);
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

        private void DG_Payments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8) 
            {
                int paymentID = 0;
                if (int.TryParse(DG_Payments.Rows[e.RowIndex].Cells[0].Value.ToString(), out paymentID)) 
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        AdminPaymentsFormAdd adminPaymentsFormAdd = new AdminPaymentsFormAdd(_userID, paymentID);
                        adminPaymentsFormAdd.ShowDialog();
                        UpdateInfo();
                    }
                }
            }

            if (e.ColumnIndex == 9)
            {
                int paymentID = 0;
                if (int.TryParse(DG_Payments.Rows[e.RowIndex].Cells[0].Value.ToString(), out paymentID))
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите удалить тарифный план?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        if (paymentID != 0 && result == DialogResult.Yes) 
                        {
                            Payment payment = db.Payments.Where(x => x.ID == paymentID).FirstOrDefault();
                            if (payment != null)
                            {
                                try
                                {
                                    db.Payments.Remove(payment);
                                    db.SaveChanges();
                                    MessageBox.Show("Тарифный план удален успешно!");
                                    UpdateInfo();
                                }
                                catch (Exception ex)
                                {
                                    //Создаем LOG запись об удалении!
                                    Log logInfo = new Log();
                                    logInfo.ID = Guid.NewGuid();
                                    logInfo.UserID = _userID;
                                    logInfo.CreatedAt = DateTime.Now.ToString();
                                    logInfo.Type = "ERROR";
                                    logInfo.Caption = $"Class:AdminPaymentsForm. Method: DG_Payments_CellClick. {ex.Message}. {ex.InnerException}";
                                    db.Logs.Add(logInfo);
                                    db.SaveChanges();

                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        UpdateInfo();
                    }
                }
            }
        }
    }
}
