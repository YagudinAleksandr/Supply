using Supply_Admin.Domain;
using Supply_Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Supply_Admin
{
    public partial class RoomsManagment : Form
    {
        SupplyDbContext db;
        private static int index = 0;
        public RoomsManagment()
        {
            InitializeComponent();
            TL_WaitingLoad.Visible = false;
            try
            {
                db = new SupplyDbContext();
                var hostels = db.Hostels.ToList();
                if(hostels.Count == 0)
                {
                    BTN_AddRooms.Visible = false;
                }
                else
                {
                    CB_HostelNumber.DataSource = hostels;
                    CB_HostelNumber.DisplayMember = "Name";
                    CB_HostelNumber.ValueMember = "Id";
                }
                
                
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных");
                Close();
            }
        }

        private void BTN_AddRooms_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";


            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            string res = dialog.FileName;
            TL_WaitingLoad.Visible = true;

            //string res = "C:\\Users\\Aleksandr\\Desktop\\Form.xlsx";
            Excel.Application xlApp;
            Excel.Workbook xlWorkbook;
            Excel.Worksheet xlWorkSheet;

            xlApp = new Excel.Application();
            xlWorkbook = xlApp.Workbooks.Open(res, 0, true, 5, "", "", true);
            xlWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1); //The first item is 1



            Rooms rooms = new Rooms();

            string[] data = new string[3];
            int i = 2;
            while (data[0] != "")
            {
                data[0] = xlWorkSheet.get_Range("A" + i.ToString()).Text;
                data[1] = xlWorkSheet.get_Range("B" + i.ToString()).Text;
                data[2] = xlWorkSheet.get_Range("C" + i.ToString()).Text;

                if (data[0] != "")
                {
                    try
                    {
                        rooms.Name = Convert.ToInt32(data[0]);
                        rooms.Places = Convert.ToInt32(data[1]);
                        rooms.Type = data[2];
                        rooms.HostelId = index;
                        db.Rooms.Add(rooms);
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Возникла ошибка");
                        break;
                    }

                    i++;
                }
                else break;
                
            }




            xlWorkbook.Close(false);
            xlApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            TL_WaitingLoad.Visible = false;
            this.DataGridViewInformation();
            MessageBox.Show("Данные добавлены");
        }

        private void CB_HostelNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = (int)CB_HostelNumber.SelectedValue;
            
        }
        private void DataGridViewInformation()
        {
            DG_View_Rooms.Rows.Clear();

            try
            {
                var rooms = db.Rooms.ToList();


                foreach (var room in rooms)
                {
                    int rowNumber = DG_View_Rooms.Rows.Add();
                    DG_View_Rooms.Rows[rowNumber].Cells[DGV_RoomNum.Name].Value = room.Name;
                    DG_View_Rooms.Rows[rowNumber].Cells[DGV_RoomType.Name].Value = room.Type;
                    DG_View_Rooms.Rows[rowNumber].Cells[DGV_Places.Name].Value = room.Places;
                    DG_View_Rooms.Rows[rowNumber].Cells[DGV_HostelName.Name].Value = room.Hostel.Name;
                }
            }
            catch
            {
                MessageBox.Show("В базе данных нет сведений!");
            }
        }

        private void RoomsManagment_Shown(object sender, EventArgs e)
        {
            this.DataGridViewInformation();
        }
    }
}
