using Libraries.ExcelSystem;
using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class DeclarationMonthPayment : Form
    {
        private int _hostelID;
        public DeclarationMonthPayment()
        {
            InitializeComponent();
        }

        private void DeclarationMonthPayment_Shown(object sender, EventArgs e)
        {
            using(SupplyDbContext db = new SupplyDbContext())
            {
                CB_Hostels.DataSource = db.Hostels.ToList();
                CB_Hostels.ValueMember = "ID";
                CB_Hostels.DisplayMember = "Name";
            }
        }

        private void CB_Hostels_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                _hostelID = (int)CB_Hostels.SelectedValue;
            }
            catch
            {
                return;
            }
            
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            DateTime startDate;
            DateTime endDate;
            if (!DateTime.TryParse(TB_StartDate.Text, out startDate))
            {
                MessageBox.Show("Неверно введена дата начала");
                return;
            }
            if (!DateTime.TryParse(TB_EndDate.Text, out endDate))
            {
                MessageBox.Show("Неверно указана дата окончания");
                return;
            }
            if (_hostelID == 0)
            {
                MessageBox.Show("Выбирите общежитие");
                return;
            }


            using(SupplyDbContext db = new SupplyDbContext())
            {
                Hostel hostel = db.Hostels.Where(id => id.ID == _hostelID).FirstOrDefault();

                var enterances = db.Enterances.Where(hid => hid.HostelId == hostel.ID).ToList();

                string error = string.Empty;
                using(ExcelHelper excel = new ExcelHelper())
                {
                    if (excel.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: $"Отчеты по начислениям с {startDate.ToShortDateString()} по {endDate.ToShortDateString()}.xlsx", out error))
                    {
                        if (!excel.Merge("A1", "J1", 1, 1, $"Список проживающих в общежитии № {hostel.Name}", out error))
                        {
                            MessageBox.Show("Не удалось объединить ячейки!");
                            excel.Close();
                            return;
                        }

                        if (!excel.Merge("A3", "A4", 3, 1, "№ п/п", out error))
                        {
                            MessageBox.Show("Не удалось объединить ячейки!");
                            excel.Close();
                            return;
                        }

                        if (!excel.Merge("B3", "B4", 3, 2, "ФИО проживающих", out error))
                        {
                            MessageBox.Show("Не удалось объединить ячейки!");
                            excel.Close();
                            return;
                        }

                        if (!excel.Merge("C3", "C4", 3, 3, "Категория", out error))
                        {
                            MessageBox.Show("Не удалось объединить ячейки!");
                            excel.Close();
                            return;
                        }

                        if (!excel.Merge("D3", "D4", 3, 4, "Номер договора", out error))
                        {
                            MessageBox.Show("Не удалось объединить ячейки!");
                            excel.Close();
                            return;
                        }

                        if (!excel.Merge("E3", "E4", 3, 5, "Дата начала договора", out error))
                        {
                            MessageBox.Show("Не удалось объединить ячейки!");
                            excel.Close();
                            return;
                        }

                        if (!excel.Merge("F3", "F4", 3, 6, "Дата окончания договора", out error))
                        {
                            MessageBox.Show("Не удалось объединить ячейки!");
                            excel.Close();
                            return;
                        }

                        if (!excel.Merge("G3", "J3", 3, 7, "Сумма к начислению и оплате", out error))
                        {
                            MessageBox.Show("Не удалось объединить ячейки!");
                            excel.Close();
                            return;
                        }

                        if (!excel.Set("G", 4, "Найм", out error) ||
                            !excel.Set("H", 4, "Коммунальные услуги", out error) ||
                            !excel.Set("I", 4, "Содержание жилого помещения", out error) ||
                            !excel.Set("J", 4, "Электроэнергия", out error))  
                        {
                            MessageBox.Show("Не удалось внести значение в ячейку!");
                            excel.Close();
                            return;
                        }

                        //TODO

                        excel.Save();

                        excel.Close();

                        MessageBox.Show("Файл создан!");
                    }
                    else
                    {
                        Log logInfo = new Log();
                        logInfo.ID = Guid.NewGuid();
                        logInfo.Type = "ERROR";
                        logInfo.Caption = $"Class: DeclarationMonthPayment. Method: BTN_Create_Click. {error}";
                        logInfo.CreatedAt = DateTime.Now.ToString();
                        db.Logs.Add(logInfo);
                        db.SaveChanges();

                        excel.Close();
                    }
                }

            }
            GC.Collect();
        }
    }
}
