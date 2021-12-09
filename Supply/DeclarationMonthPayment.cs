using Libraries.ExcelSystem;
using Supply.Domain;
using Supply.Libs;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
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
                            List<TenantView> tenantViews = new List<TenantView>();

                            foreach (Enterance enterance in enterances)
                            {
                                foreach (Flat flat in db.Flats.Where(eid => eid.Enterance_ID == enterance.ID).ToList())
                                {
                                    foreach (Room room in db.Rooms.Where(fid => fid.FlatID == flat.ID).Include(el => el.ElectricityPayment).ToList()) 
                                    {
                                        foreach (Tenant tenant in db.Tenants.Where(r => r.RoomID == room.ID).Include(ident => ident.Identification).Include(t => t.TenantType).Include(p=>p.Payment).Include(o => o.Order).ToList())
                                        {

                                            if (tenant.Identification == null) 
                                            {
                                                continue;
                                            }

                                            if (tenant.Order == null)
                                            {
                                                continue;
                                            }

                                            //Region of check tenant for create declaration
                                            DateTime endOrder=DateTime.Now;
                                            DateTime terminationStart=DateTime.Now;

                                            DateTime checkStartOrder = DateTime.Now;

                                            if(!DateTime.TryParse(tenant.Order.StartDate, out checkStartOrder))
                                            {
                                                Log logInfo = new Log();
                                                logInfo.ID = Guid.NewGuid();
                                                logInfo.Type = "ERROR";
                                                logInfo.Caption = $"Class: DeclarationMonthPayment. Method: BTN_Create_Click. Not correct order start date {tenant.Identification.Surename} {tenant.Identification.Name}";
                                                logInfo.CreatedAt = DateTime.Now.ToString();
                                                db.Logs.Add(logInfo);
                                                db.SaveChanges();

                                                continue;
                                            }

                                            if (checkStartOrder > endDate)
                                                continue;

                                            if(!DateTime.TryParse(tenant.Order.EndDate, out endOrder))
                                            {
                                                Log logInfo = new Log();
                                                logInfo.ID = Guid.NewGuid();
                                                logInfo.Type = "ERROR";
                                                logInfo.Caption = $"Class: DeclarationMonthPayment. Method: BTN_Create_Click. Not correct order end date {tenant.Identification.Surename} {tenant.Identification.Name}";
                                                logInfo.CreatedAt = DateTime.Now.ToString();
                                                db.Logs.Add(logInfo);
                                                db.SaveChanges();

                                                continue;
                                            }

                                            Termination termination = db.Terminations.Where(oid => oid.OrderID == tenant.Order.ID).FirstOrDefault();

                                            if (termination != null)
                                            {
                                                if (!DateTime.TryParse(termination.Date, out terminationStart))
                                                {
                                                    Log logInfo = new Log();
                                                    logInfo.ID = Guid.NewGuid();
                                                    logInfo.Type = "ERROR";
                                                    logInfo.Caption = $"Class: DeclarationMonthPayment. Method: BTN_Create_Click. Not correct termination date {tenant.Identification.Surename} {tenant.Identification.Name}";
                                                    logInfo.CreatedAt = DateTime.Now.ToString();
                                                    db.Logs.Add(logInfo);
                                                    db.SaveChanges();

                                                    continue;
                                                }
                                                else
                                                {
                                                    if (terminationStart <= startDate)
                                                    {
                                                        continue;
                                                    }
                                                }
                                            }


                                            if (endOrder < startDate)
                                            {
                                                continue;
                                            }

                                            
                                            //Region of create order payment

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

                                            tenantViews.Add(new TenantView
                                            {
                                                ID = tenant.ID,
                                                Name = name,
                                                Order = tenant.Order,
                                                Room = tenant.Room,
                                                Type = tenant.TenantType,
                                                Payment = tenant.Payment,
                                                startOrder = startDate,
                                                endOrder = endDate,
                                                Termination = termination
                                            });

                                        }
                                    }
                                }
                            }

                            var tvs = from tenanView in tenantViews
                                      orderby tenanView.Name
                                      select tenanView;

                            foreach(var tv in tvs)
                            {
                                excel.Set("A", rowNumber, counter.ToString(), out error);
                                excel.Set("B", rowNumber, tv.Name, out error);
                                excel.Set("C", rowNumber, tv.Type.Name, out error);
                                excel.Set("D", rowNumber, tv.Order.OrderNumber, out error);
                                excel.Set("E", rowNumber, tv.Order.StartDate, out error);
                                excel.Set("F", rowNumber, tv.Order.EndDate, out error);

                                DateTime startBenefit = DateTime.Now;
                                DateTime endBenefit = DateTime.Now;

                                decimal rent = 0;
                                decimal house = 0;
                                decimal service = 0;
                                decimal electricity = 0;

                                int days = 0;
                                int monthes = 0;
                                int daysInMonth = 0;

                                DateTime startTenantOrderInner = DateTime.Parse(tv.Order.StartDate);
                                DateTime endTenantOrderInner = DateTime.Parse(tv.Order.EndDate);

                                if (startTenantOrderInner.Month == tv.startOrder.Month && startTenantOrderInner.Year == tv.startOrder.Year)
                                {
                                    tv.startOrder = DateTime.Parse(tv.Order.StartDate).AddDays(-1);
                                }

                                if (endTenantOrderInner.Month == tv.endOrder.Month && endTenantOrderInner.Year == tv.endOrder.Year)
                                {
                                    tv.endOrder = DateTime.Parse(tv.Order.EndDate);
                                }

                                if (tv.Termination != null)
                                {
                                    DateTime dateOfTermination = DateTime.Now;

                                    if (DateTime.TryParse(tv.Termination.Date, out dateOfTermination))
                                    {
                                        if (tv.endOrder > dateOfTermination && tv.endOrder.Month == dateOfTermination.Month)
                                        {
                                            tv.endOrder = dateOfTermination;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Дата расторжения договра не может быть преобразована в тип даты у жильца {tv.Name}! Данный жилец не будет внесен в отчет!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                if (tv.Type.ID != 2 && tv.Type.ID != 3)
                                {
                                    if (OrdersCreation.AdditionalInf(5, tv.ID) != "Заочная")
                                    {
                                        OrdersCreation.BenefitCheck(tv.Order.ID, tv.startOrder, tv.endOrder, ref rent, out house, out service, out electricity);


                                        if (OrdersCreation.AdditionalInf(10, tv.ID) != string.Empty)
                                        {
                                            electricity = 0;
                                        }
                                        
                                    }
                                    else
                                    {
                                        rent = Convert.ToDecimal(tv.Payment.Rent);
                                        service = Convert.ToDecimal(tv.Payment.Service);
                                        house = Convert.ToDecimal(tv.Payment.House);

                                        rent *= (tv.endOrder - tv.startOrder).Days + 1;
                                        service *= (tv.endOrder - tv.startOrder).Days + 1;
                                        house *= (tv.endOrder - tv.startOrder).Days + 1;
                                    }

                                }
                                else
                                {

                                    OrdersCreation.SpecialDateCheck(tv.startOrder, tv.endOrder, out days, out monthes, out daysInMonth);

                                    OrdersCreation.SpecialPayments(tv.ID, out rent, out house, out service);


                                    OrdersCreation.CalculationServiceCoast(days, monthes, daysInMonth, ref rent, ref house, ref service, ref electricity);

                                }

                                excel.Set("G", rowNumber, Math.Round(rent, 2).ToString(), out error);
                                excel.Set("H", rowNumber, Math.Round(service, 2).ToString(), out error);
                                excel.Set("I", rowNumber, Math.Round(house, 2).ToString(), out error);
                                excel.Set("J", rowNumber, Math.Round(electricity, 2).ToString(), out error);

                                counter++;
                                rowNumber++;
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
                            MessageBox.Show(ex.Message);

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

    public class TenantView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Termination Termination { get; set; }
        public TenantType Type { get; set; }
        public Room Room { get; set; }
        public Order Order { get; set; }
        public Payment Payment { get; set; }
        public DateTime startOrder { get; set; }
        public DateTime endOrder { get; set; }
    }
}
