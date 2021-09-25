using Libraries.ExcelSystem;
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
                    if (excel.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: $"Отчеты по начислениям общежития {hostel.Name} с {startDate.ToShortDateString()} по {endDate.ToShortDateString()}.xlsx", out error))
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

                        int rowNumber = 5;
                        int counter = 1;

                        try
                        {
                            foreach (Enterance enterance in enterances)
                            {
                                foreach (Flat flat in db.Flats.Where(eid => eid.Enterance_ID == enterance.ID).ToList())
                                {
                                    foreach (Room room in db.Rooms.Where(fid => fid.FlatID == flat.ID).ToList())
                                    {
                                        foreach (Tenant tenant in db.Tenants.Where(r => r.RoomID == room.ID).Include(ident => ident.Identification).Include(t => t.TenantType).Include(o => o.Order).ToList())
                                        {
                                            excel.Set("A", rowNumber, counter.ToString(), out error);

                                            string name = string.Empty;

                                            ChangePassport changePassport = db.ChangePassports.Where(tid => tid.TenantID == tenant.ID).Where(s => s.Status).FirstOrDefault();

                                            if (changePassport != null)
                                            {
                                                name = changePassport.Surename + " " + changePassport.Name;
                                                if (changePassport.Patronymic != null)
                                                {
                                                    name += " " + changePassport.Patronymic;
                                                }
                                            }
                                            else
                                            {
                                                name = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                                if (tenant.Identification.Patronymic != null)
                                                {
                                                    name += " " + tenant.Identification.Patronymic;
                                                }
                                            }

                                            excel.Set("B", rowNumber, name, out error);
                                            excel.Set("C", rowNumber, tenant.TenantType.Name, out error);
                                            excel.Set("D", rowNumber, tenant.Order.OrderNumber, out error);
                                            excel.Set("E", rowNumber, tenant.Order.StartDate, out error);
                                            excel.Set("F", rowNumber, tenant.Order.EndDate, out error);

                                            counter++;
                                            rowNumber++;
                                        }
                                    }
                                }
                            }

                            rowNumber += 2;

                            excel.Set("B", rowNumber, "СОГЛАСОВАНО:", out error);
                            rowNumber += 2;

                            excel.Set("B", rowNumber, "Зам.директора по УиИИ", out error);
                            excel.Set("E", rowNumber, "Р.А.Олейник", out error);
                            rowNumber++;

                            excel.Set("B", rowNumber, "ВРИО Гл.бухгалетра", out error);
                            excel.Set("E", rowNumber, "З.Н.Архипова", out error);
                            rowNumber++;

                            excel.Set("B", rowNumber, "Руководитель ХТО", out error);
                            excel.Set("E", rowNumber, "О.А.Болычева", out error);
                            rowNumber++;

                            excel.Set("B", rowNumber, "Ведущий бухгалтер", out error);
                            excel.Set("E", rowNumber, "Т.Г.Лукина", out error);


                            excel.Save();

                            

                            MessageBox.Show("Файл создан!");
                        }
                        catch(Exception ex)
                        {
                            Log logInfo = new Log();
                            logInfo.ID = Guid.NewGuid();
                            logInfo.Type = "ERROR";
                            logInfo.Caption = $"Class: DeclarationMonthPayment. Method: BTN_Create_Click. {ex.Message}. {ex.InnerException}";
                            logInfo.CreatedAt = DateTime.Now.ToString();
                            db.Logs.Add(logInfo);
                            db.SaveChanges();
                        }
                        finally
                        {
                            excel.Close();
                        }
                        
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
