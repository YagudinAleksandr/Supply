using Supply_Admin.Domain;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Supply_Admin
{
    public partial class OrdersManager : Form
    {
        private SupplyDbContext _db;
        public OrdersManager(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void DataGridViewInformation_Update()
        {
            DG_View_Orders.Rows.Clear();

            try
            {
                var orders = _db.Orders.ToList();

                foreach(var order in orders)
                {
                    int rowNumber = DG_View_Orders.Rows.Add();

                    DG_View_Orders.Rows[rowNumber].Cells[COL_Id.Name].Value = order.Id;
                    DG_View_Orders.Rows[rowNumber].Cells[COL_StartDate.Name].Value = order.StartOrder;
                    DG_View_Orders.Rows[rowNumber].Cells[COL_EndDate.Name].Value = order.EndOrder;
                    
                    var human = _db.Humen.Where(x => x.Id == order.HumanId).FirstOrDefault();
                    DG_View_Orders.Rows[rowNumber].Cells[COL_Human.Name].Value = human.Surename + " " + human.Name + " " + human.Patronymic;

                    var room = _db.Rooms.Where(x => x.Id == human.RoomId).FirstOrDefault();
                    DG_View_Orders.Rows[rowNumber].Cells[COL_Room.Name].Value = room.Name;

                    var flat = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
                    var enterance = _db.Enterances.Where(x => x.Id == flat.EnteranceId).FirstOrDefault();

                    var hostel = _db.Hostels.Where(x => x.Id == enterance.HostelsId).FirstOrDefault();
                    DG_View_Orders.Rows[rowNumber].Cells[COL_Hostel.Name].Value = hostel.Name;

                    var rent = _db.Rents.Where(x => x.Id == order.RentId).FirstOrDefault();
                    DG_View_Orders.Rows[rowNumber].Cells[COL_Rent.Name].Value = rent.Name;

                    if (order.Benifit == 1)
                        DG_View_Orders.Rows[rowNumber].Cells[COL_Benifit.Name].Value = "Да";
                    else
                        DG_View_Orders.Rows[rowNumber].Cells[COL_Benifit.Name].Value = "Нет";
                }

            }
            catch
            {
                MessageBox.Show("В базе данных нет сведений!");
            }
        }

        private void OrdersManager_Shown(object sender, EventArgs e)
        {
            DataGridViewInformation_Update();
        }

        private void TB_OrderNumber_TextChanged(object sender, EventArgs e)
        {
            if(TB_OrderNumber.Text != "")
            {
                DG_View_Orders.Rows.Clear();

                try
                {
                    int orderId = Convert.ToInt32(TB_OrderNumber.Text);
                    var orders = _db.Orders.Where(x => x.Id == orderId).ToList();

                    foreach (var order in orders)
                    {
                        int rowNumber = DG_View_Orders.Rows.Add();

                        DG_View_Orders.Rows[rowNumber].Cells[COL_Id.Name].Value = order.Id;
                        DG_View_Orders.Rows[rowNumber].Cells[COL_StartDate.Name].Value = order.StartOrder;
                        DG_View_Orders.Rows[rowNumber].Cells[COL_EndDate.Name].Value = order.EndOrder;

                        var human = _db.Humen.Where(x => x.Id == order.HumanId).FirstOrDefault();
                        DG_View_Orders.Rows[rowNumber].Cells[COL_Human.Name].Value = human.Surename + " " + human.Name + " " + human.Patronymic;

                        var room = _db.Rooms.Where(x => x.Id == human.RoomId).FirstOrDefault();
                        DG_View_Orders.Rows[rowNumber].Cells[COL_Room.Name].Value = room.Name;

                        var flat = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
                        var enterance = _db.Enterances.Where(x => x.Id == flat.EnteranceId).FirstOrDefault();

                        var hostel = _db.Hostels.Where(x => x.Id == enterance.HostelsId).FirstOrDefault();
                        DG_View_Orders.Rows[rowNumber].Cells[COL_Hostel.Name].Value = hostel.Name;

                        var rent = _db.Rents.Where(x => x.Id == order.RentId).FirstOrDefault();
                        DG_View_Orders.Rows[rowNumber].Cells[COL_Rent.Name].Value = rent.Name;

                        if (order.Benifit == 1)
                            DG_View_Orders.Rows[rowNumber].Cells[COL_Benifit.Name].Value = "Да";
                        else
                            DG_View_Orders.Rows[rowNumber].Cells[COL_Benifit.Name].Value = "Нет";
                    }

                }
                catch
                {
                    MessageBox.Show("В базе данных нет сведений!");
                }
            }
            else
            {
                DataGridViewInformation_Update();
            }
        }

        private void TB_OrderStart_TextChanged(object sender, EventArgs e)
        {
            if (TB_OrderStart.Text != "")
            {
                DG_View_Orders.Rows.Clear();

                try
                {
                    string orderStartDate = TB_OrderStart.Text;
                    var orders = _db.Orders.Where(x => x.StartOrder == orderStartDate).ToList();

                    foreach (var order in orders)
                    {
                        int rowNumber = DG_View_Orders.Rows.Add();

                        DG_View_Orders.Rows[rowNumber].Cells[COL_Id.Name].Value = order.Id;
                        DG_View_Orders.Rows[rowNumber].Cells[COL_StartDate.Name].Value = order.StartOrder;
                        DG_View_Orders.Rows[rowNumber].Cells[COL_EndDate.Name].Value = order.EndOrder;

                        var human = _db.Humen.Where(x => x.Id == order.HumanId).FirstOrDefault();
                        DG_View_Orders.Rows[rowNumber].Cells[COL_Human.Name].Value = human.Surename + " " + human.Name + " " + human.Patronymic;

                        var room = _db.Rooms.Where(x => x.Id == human.RoomId).FirstOrDefault();
                        DG_View_Orders.Rows[rowNumber].Cells[COL_Room.Name].Value = room.Name;

                        var flat = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
                        var enterance = _db.Enterances.Where(x => x.Id == flat.EnteranceId).FirstOrDefault();

                        var hostel = _db.Hostels.Where(x => x.Id == enterance.HostelsId).FirstOrDefault();
                        DG_View_Orders.Rows[rowNumber].Cells[COL_Hostel.Name].Value = hostel.Name;

                        var rent = _db.Rents.Where(x => x.Id == order.RentId).FirstOrDefault();
                        DG_View_Orders.Rows[rowNumber].Cells[COL_Rent.Name].Value = rent.Name;

                        if (order.Benifit == 1)
                            DG_View_Orders.Rows[rowNumber].Cells[COL_Benifit.Name].Value = "Да";
                        else
                            DG_View_Orders.Rows[rowNumber].Cells[COL_Benifit.Name].Value = "Нет";
                    }

                }
                catch
                {
                    MessageBox.Show("В базе данных нет сведений!");
                }
            }
            else
            {
                DataGridViewInformation_Update();
            }
        }
    }
}
