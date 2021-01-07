using Supply_Admin.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply_Admin
{
    public partial class AddtionalServices : Form
    {
        private static SupplyDbContext _db;
        private static int hostelId;
        public AddtionalServices(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;

            var hostels = _db.Hostels.ToList();
            CB_Hostels.DataSource = hostels;
            CB_Hostels.DisplayMember = "Name";
            CB_Hostels.ValueMember = "Id";
        }

        private void CB_Hostels_SelectedIndexChanged(object sender, EventArgs e)
        {
            hostelId = (int)CB_Hostels.SelectedValue;
            UpdateInformationInDataGridView(hostelId);
        }

        private void UpdateInformationInDataGridView(int hostelId)
        {
            DG_View_Orders.Rows.Clear();

            try
            {
                var orders = _db.Orders.Where(x => x.HostelsId == hostelId).Where(x => x.Status == 1).ToList();

                foreach (var order in orders)
                {
                    int rowNumber = DG_View_Orders.Rows.Add();

                    DG_View_Orders.Rows[rowNumber].Cells[COL_OrderNumber.Name].Value = order.Id;

                    var human = _db.Humen.Where(x => x.Id == order.HumanId).FirstOrDefault();
                    DG_View_Orders.Rows[rowNumber].Cells[COL_Person.Name].Value = human.Surename + " " + human.Name + " " + human.Patronymic;

                    var room = _db.Rooms.Where(x => x.Id == human.RoomId).FirstOrDefault();
                    DG_View_Orders.Rows[rowNumber].Cells[COL_Room.Name].Value = room.Name;
                }

            }
            catch
            {
                MessageBox.Show("В базе данных нет сведений!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ожидайте ответа программы!");
            
            List<int> listOfId = new List<int>(); //Лист с ID договоров

            for (int i = 0; i < DG_View_Orders.RowCount; i++)
            {
                if (Convert.ToBoolean(DG_View_Orders.Rows[i].Cells[COL_OrderId.Name].Value) == true)
                    listOfId.Add(Convert.ToInt32(DG_View_Orders.Rows[i].Cells[COL_OrderNumber.Name].Value));
            }

            bool errorReport;

            if (listOfId.Count != 0)
            {
                errorReport = WordExcelIO.CreatAdditionalSettings(_db, listOfId);
            }
            else
                errorReport = WordExcelIO.CreatAdditionalSettings(_db, 1, hostelId);

            if (errorReport == false)
                MessageBox.Show("Возникли проблемы при создании файлов");
            else
                MessageBox.Show("Файлы созданы успешно");

        }
    }
}
