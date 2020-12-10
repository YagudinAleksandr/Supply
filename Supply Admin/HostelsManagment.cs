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
using Supply_Admin.Domain;
using Supply_Admin.Models;
using System.Data.Entity;

namespace Supply_Admin
{
    public partial class HostelsManagment : Form
    {
        SupplyDbContext db;
        
        public HostelsManagment()
        {
            InitializeComponent();
            
            try
            {
                db = new SupplyDbContext();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных");
                Close();
            }
        }

        private void BTN_Add_Hostels_Click(object sender, EventArgs e)
        {
            CreateHostel ch = new CreateHostel(db);
            ch.Show();

            
            /*
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";
            

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            string res = dialog.FileName;

            TL_Waiting.Visible = true;
            Excel.Application xlApp;
            Excel.Workbook xlWorkbook;
            Excel.Worksheet xlWorkSheet;

            xlApp = new Excel.Application();
            xlWorkbook = xlApp.Workbooks.Open(res, 0, true, 5, "", "", true);
            xlWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1); //The first item is 1


            Hostels hostel = new Hostels();

            string[] data = new string[3];

            

            for (int i = 2; i < 100; i++)
            {
                data[0] = xlWorkSheet.get_Range("A" + i.ToString()).Text;
                data[1] = xlWorkSheet.get_Range("B" + i.ToString()).Text;
                data[2] = xlWorkSheet.get_Range("C" + i.ToString()).Text;
                if (data[0] != "")
                {
                    try
                    {
                        hostel.Name = Convert.ToInt32(data[0]);
                        int flats = Convert.ToInt32(data[1]);
                        
                        hostel.SupplyManager = data[2].ToString();
                        db.Hostels.Add(hostel);
                        int idHostel = db.SaveChanges();


                        CreateFlats(flats, idHostel);
                    }
                    catch
                    {
                        MessageBox.Show("Возникла ошибка");
                        break;
                    }
                }
                else break;
            
            }

            xlWorkbook.Close(false);
            xlApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            this.DataGridViewInformation();
            TL_Waiting.Visible = false;
            MessageBox.Show("Данные были внесены успешно!");*/

        }

        

        private void HostelsManagment_Shown(object sender, EventArgs e)
        {
            this.DataGridViewInformation();
        }

        private void DataGridViewInformation()
        {
            DG_View_HostelsManage.Rows.Clear();
            
            try
            {
                var hostels = db.Hostels.ToList();


                foreach (var hostel in hostels)
                {
                    int rowNumber = DG_View_HostelsManage.Rows.Add();
                    DG_View_HostelsManage.Rows[rowNumber].Cells[DGView_IDHostels.Name].Value = hostel.Id;
                    DG_View_HostelsManage.Rows[rowNumber].Cells[DGView_NameHostel.Name].Value = hostel.Name;
                    int enterances = db.Enterances.Where(x => x.HostelsId == hostel.Id).Count();
                    DG_View_HostelsManage.Rows[rowNumber].Cells[DGV_CountEnterance.Name].Value = enterances;
                    
                    string name="";
                    foreach(var supplies in db.Supplies.Where(x=>x.HostelsId == hostel.Id).ToList())
                    {
                        name += supplies.Name + ", ";
                    }
                    DG_View_HostelsManage.Rows[rowNumber].Cells[DGView_SupplyHostel.Name].Value = name;
                    DG_View_HostelsManage.Rows[rowNumber].Cells[COL_Address.Name].Value = hostel.Address;
                }
            }
            catch
            {
                MessageBox.Show("В базе данных нет сведений!");
            }
            
        }

        private void BTN_Update_Click(object sender, EventArgs e)
        {
            DataGridViewInformation();
        }
    }
}
