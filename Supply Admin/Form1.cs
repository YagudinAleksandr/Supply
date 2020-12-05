using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supply_Admin.Domain;
using Supply_Admin.Models;
namespace Supply_Admin
{
    public partial class MainWindow : Form
    {
        SupplyDbContext db;
        public MainWindow(SupplyDbContext _db)
        {
            
            InitializeComponent();
            db = _db;
        }

        private void HostelsSettings_Click(object sender, EventArgs e)
        {
            HostelsManagment hostelsManagmentWindow = new HostelsManagment();
            hostelsManagmentWindow.Show();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTN_Create_Human_Click(object sender, EventArgs e)
        {
            HumanCreate hc = new HumanCreate(db);
            hc.Show();
        }

        private void DataGridViewInformation()
        {
            DG_View_Peoples.Rows.Clear();
            
            try
            {
                var humens = db.Humen.OrderBy(p=>p.Surename).ToList();


                foreach (var human in humens)
                {
                    int rowNumber = DG_View_Peoples.Rows.Add();
                    DG_View_Peoples.Rows[rowNumber].Cells[COL_NumberOfOrder.Name].Value = human.Id;
                    DG_View_Peoples.Rows[rowNumber].Cells[COL_Surename.Name].Value = human.Surename;
                    DG_View_Peoples.Rows[rowNumber].Cells[COL_Name.Name].Value = human.Name;
                    DG_View_Peoples.Rows[rowNumber].Cells[COL_Patronymic.Name].Value = human.Patronymic;
                    DG_View_Peoples.Rows[rowNumber].Cells[COL_PhoneNumber.Name].Value = human.PhoneNumber;
                    
                    if(human.Status ==1)
                        DG_View_Peoples.Rows[rowNumber].Cells[COL_Status.Name].Value = "Активен";
                    else
                        DG_View_Peoples.Rows[rowNumber].Cells[COL_Status.Name].Value = "Не активен";

                    var room = db.Rooms.Where(x => x.Id == human.RoomId).FirstOrDefault();
                    DG_View_Peoples.Rows[rowNumber].Cells[COL_Room.Name].Value = room.Name;
                    var hostel = db.Hostels.Where(x => x.Id == room.HostelId).FirstOrDefault();
                    DG_View_Peoples.Rows[rowNumber].Cells[COL_Hostel.Name].Value = hostel.Name;
                    DG_View_Peoples.Rows[rowNumber].Cells[COL_StartOrder.Name].Value = human.OrderStart;
                    DG_View_Peoples.Rows[rowNumber].Cells[COL_EndOrder.Name].Value = human.OrderEnd;
                    DG_View_Peoples.Rows[rowNumber].Cells[COL_ToTime.Name].Value = human.ToTime;
                    if(human.Benifit == 1)
                        DG_View_Peoples.Rows[rowNumber].Cells[COL_Benefit.Name].Value = "Да";
                    else
                        DG_View_Peoples.Rows[rowNumber].Cells[COL_Benefit.Name].Value = "Нет";

                }
            }
            catch
            {
                MessageBox.Show("В базе данных нет сведений!");
            }
        }



        private void MainWindow_Load(object sender, EventArgs e)
        {
            DataGridViewInformation();
        }

        private void BTN_UpdateTable_Click(object sender, EventArgs e)
        {
            DataGridViewInformation();
        }

        private void BTN_CreateOrders_Click(object sender, EventArgs e)
        {
            CreateWordDocumentOrder cwd = new CreateWordDocumentOrder(db);
            cwd.Show();
        }


        private void DG_View_Peoples_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string value = DG_View_Peoples.Rows[e.RowIndex].Cells[0].Value.ToString();
            MessageBox.Show($"Двойной клик. Значение ячейки = {value}");
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu(db);
            mm.Show();
        }
    }
}
