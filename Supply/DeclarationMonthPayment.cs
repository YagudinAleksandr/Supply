using Libraries.ExcelSystem;
using Supply.Domain;
using Supply.Libs;
using Supply.Models;
using System;
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
                                                    if (terminationStart < startDate)
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

                                            excel.Set("B", rowNumber, name, out error);
                                            excel.Set("C", rowNumber, tenant.TenantType.Name, out error);
                                            excel.Set("D", rowNumber, tenant.Order.OrderNumber, out error);
                                            excel.Set("E", rowNumber, tenant.Order.StartDate, out error);
                                            excel.Set("F", rowNumber, tenant.Order.EndDate, out error);

                                            int days = 0;
                                            int month = 0;
                                            int daysInMonth = 0;

                                            decimal electricity = 0;
                                            decimal house = 0;
                                            decimal rent = 0;
                                            decimal service = 0;

                                            if (termination != null && terminationStart < endDate) 
                                            {
                                                OrdersCreation.SpecialDateCheck(startDate, terminationStart, out days, out month, out daysInMonth);

                                                if (DateTime.Parse(tenant.Order.StartDate) > startDate)
                                                {
                                                    OrdersCreation.SpecialDateCheck(DateTime.Parse(tenant.Order.StartDate), endDate, out days, out month, out daysInMonth);
                                                }

                                                if (tenant.TenantTypeID != 2 && tenant.TenantTypeID != 3)
                                                {
                                                    if (days != 0)
                                                    {
                                                        SpecialPayment specialPayment = db.SpecialPayments.Where(t => t.TenantID == tenant.ID).FirstOrDefault();
                                                        service = (tenant.Payment.Service / daysInMonth) * days + (tenant.Payment.Service * month);
                                                        rent = (tenant.Payment.Rent / daysInMonth) * days + (tenant.Payment.Rent * month);
                                                        house = (tenant.Payment.House / daysInMonth) * days + (tenant.Payment.House * month);
                                                        foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(p => p.ElectricityPaymentID == room.ElectricityPaymentID).ToList())
                                                        {
                                                            electricity += electricityElement.Payment;
                                                        }

                                                        electricity = (electricity / daysInMonth) * days + (electricity * month);

                                                        
                                                    }
                                                    else
                                                    {
                                                        service = tenant.Payment.Service * month;
                                                        rent = tenant.Payment.Rent * month;
                                                        house = tenant.Payment.House * month;
                                                        foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(p => p.ElectricityPaymentID == room.ElectricityPaymentID).ToList())
                                                        {
                                                            electricity += electricityElement.Payment;
                                                        }

                                                        electricity = electricity * month;
                                                    }
                                                }
                                                else
                                                {
                                                    if (DateTime.Parse(tenant.Order.StartDate) > startDate)
                                                    {
                                                        OrdersCreation.SpecialDateCheck(DateTime.Parse(tenant.Order.StartDate), endDate, out days, out month, out daysInMonth);
                                                    }

                                                    if (days != 0)
                                                    {
                                                        service = (tenant.Payment.Service / daysInMonth) * days + (tenant.Payment.Service * month);
                                                        rent = (tenant.Payment.Rent / daysInMonth) * days + (tenant.Payment.Rent * month);
                                                        house = (tenant.Payment.House / daysInMonth) * days + (tenant.Payment.House * month);
                                                    }
                                                    else
                                                    {
                                                        service = tenant.Payment.Service * month;
                                                        rent = tenant.Payment.Rent * month;
                                                        house = tenant.Payment.House * month;
                                                    }
                                                }

                                                if (DateTime.Parse(tenant.Order.EndDate) < endDate)
                                                {
                                                    OrdersCreation.SpecialDateCheck(endDate, DateTime.Parse(tenant.Order.EndDate), out days, out month, out daysInMonth);

                                                    
                                                }
                                            }
                                            else
                                            {
                                                OrdersCreation.SpecialDateCheck(startDate, endDate, out days, out month, out daysInMonth);

                                                if (tenant.TenantTypeID != 2 && tenant.TenantTypeID != 3)
                                                {
                                                    if(DateTime.Parse(tenant.Order.StartDate)>startDate)
                                                    {
                                                        OrdersCreation.SpecialDateCheck(DateTime.Parse(tenant.Order.StartDate), endDate, out days, out month, out daysInMonth);
                                                    }

                                                    if (days != 0)
                                                    {
                                                        service = (tenant.Payment.Service / daysInMonth) * days + (tenant.Payment.Service * month);
                                                        rent = (tenant.Payment.Rent / daysInMonth) * days + (tenant.Payment.Rent * month);
                                                        house = (tenant.Payment.House / daysInMonth) * days + (tenant.Payment.House * month);
                                                        foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(p => p.ElectricityPaymentID == room.ElectricityPaymentID).ToList())
                                                        {
                                                            electricity += electricityElement.Payment;
                                                        }

                                                        electricity = (electricity / daysInMonth) * days + (electricity * month);
                                                    }
                                                    else
                                                    {
                                                        service = tenant.Payment.Service * month;
                                                        rent = tenant.Payment.Rent * month;
                                                        house = tenant.Payment.House * month;
                                                        foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(p => p.ElectricityPaymentID == room.ElectricityPaymentID).ToList())
                                                        {
                                                            electricity += electricityElement.Payment;
                                                        }

                                                        electricity = electricity * month;
                                                    }
                                                }
                                                else
                                                {
                                                    if (DateTime.Parse(tenant.Order.StartDate) > startDate)
                                                    {
                                                        OrdersCreation.SpecialDateCheck(DateTime.Parse(tenant.Order.StartDate), endDate, out days, out month, out daysInMonth);
                                                    }

                                                    if (days != 0)
                                                    {
                                                        service = (tenant.Payment.Service / daysInMonth) * days + (tenant.Payment.Service * month);
                                                        rent = (tenant.Payment.Rent / daysInMonth) * days + (tenant.Payment.Rent * month);
                                                        house = (tenant.Payment.House / daysInMonth) * days + (tenant.Payment.House * month);
                                                    }
                                                    else
                                                    {
                                                        service = tenant.Payment.Service * month;
                                                        rent = tenant.Payment.Rent * month;
                                                        house = tenant.Payment.House * month;
                                                    }
                                                }
                                            }

                                            decimal tempRent = rent;
                                            decimal tempHouse = house;
                                            decimal tempSevice = service;
                                            decimal tempElectricity = electricity;

                                            if (!SpecialPayment(tenant.ID, startDate, endDate, out rent, out house, out service, out electricity)) 
                                            {
                                                rent = tempRent;
                                                house = tempHouse;
                                                service = tempSevice;
                                                electricity = tempElectricity;
                                            }

                                            if (OrdersCreation.AdditionalInf(10, tenant.ID) != string.Empty)
                                            {
                                                electricity = 0;
                                            }

                                            excel.Set("G", rowNumber, Math.Round(rent, 2).ToString(), out error);
                                            excel.Set("H", rowNumber, Math.Round(service, 2).ToString(), out error);
                                            excel.Set("I", rowNumber, Math.Round(house, 2).ToString(), out error);
                                            excel.Set("J", rowNumber, Math.Round(electricity, 2).ToString(), out error);

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
        private bool SpecialPayment(int tenantID, DateTime startDate, DateTime endDate,out decimal rent,out decimal house, out decimal service, out decimal electricity)
        {
            rent = 0;
            house = 0;
            electricity = 0;
            service = 0;

            using(SupplyDbContext db = new SupplyDbContext())
            {
                var specialPayments = db.SpecialPayments.Where(x => x.TenantID == tenantID).ToList();
                var benefits = db.Benefits.Where(tid => tid.OrderID == tenantID).ToList();

                SpecialPayment specialPayment = null;
                Benefit benefit = null;

                if (specialPayments.Count() != 0)
                {
                    foreach(SpecialPayment tSpecialPayment in specialPayments)
                    {
                        specialPayment = tSpecialPayment;
                    }
                }

                if (benefits.Count() != 0)
                {
                    foreach(Benefit tBenefit in benefits)
                    {
                        benefit = tBenefit;
                    }
                }

                int days = 0;
                int monthes = 0;
                int daysInMonth = 0;

                if (benefit != null)
                {

                    Tenant tenant = db.Tenants.Where(x => x.ID == tenantID).Include(p => p.Payment).Include(r=>r.Room).FirstOrDefault();

                    decimal paymentHouse, paymentRent;

                    decimal payment = 0;
                    decimal _tempPaymentHouse = 0;
                    decimal _tempPaymentService = 0;
                    decimal _tempPaymentElectricity = 0;



                    paymentHouse = tenant.Payment.House;
                    paymentRent = tenant.Payment.Rent;

                    DateTime startBenefit, endBenefit;

                    DateTime.TryParse(benefit.StartDate, out startBenefit);
                    DateTime.TryParse(benefit.EndDate, out endBenefit);

                    if (endBenefit < endDate && startBenefit < startDate)
                    {
                        OrdersCreation.SpecialDateCheck(startDate, endBenefit, out days, out monthes, out daysInMonth);

                        if (days != 0)
                        {
                            payment += (Convert.ToDecimal(benefit.Payment) / daysInMonth) * days + (Convert.ToDecimal(benefit.Payment) * monthes);
                            _tempPaymentHouse += (Convert.ToDecimal(benefit.House) / daysInMonth) * days + (Convert.ToDecimal(benefit.House) * monthes);
                            _tempPaymentService += (Convert.ToDecimal(benefit.Service) / daysInMonth) * days + (Convert.ToDecimal(benefit.Service) * monthes);
                            _tempPaymentElectricity += (Convert.ToDecimal(benefit.Electricity) / daysInMonth) * days + (Convert.ToDecimal(benefit.Electricity) * monthes);
                        }
                        else
                        {
                            payment += Convert.ToDecimal(benefit.Payment) * monthes;
                            _tempPaymentHouse += Convert.ToDecimal(benefit.House) * monthes;
                            _tempPaymentService += Convert.ToDecimal(benefit.Service) * monthes;
                            _tempPaymentElectricity += Convert.ToDecimal(benefit.Electricity) * monthes;
                        }
                        int tempDays = days;
                        int tempDaysInMonth = daysInMonth;

                        OrdersCreation.SpecialDateCheck(endBenefit, endDate, out days, out monthes, out daysInMonth);

                        if (tempDays != 0)
                        {
                            payment = (tenant.Payment.Rent / tempDaysInMonth) * (days) + (tenant.Payment.Rent * monthes) + payment;
                            _tempPaymentHouse = (tenant.Payment.House / daysInMonth) * days + (tenant.Payment.House * monthes) + _tempPaymentHouse;
                            _tempPaymentService = (tenant.Payment.Service / daysInMonth) * days + (tenant.Payment.Service * monthes) + _tempPaymentService;

                            decimal _tempElectricity = 0;

                            foreach(ElectricityElement electricityElement in db.ElectricityElements.Where(eid=>eid.ElectricityPaymentID==tenant.Room.ElectricityPaymentID).ToList())
                            {
                                _tempElectricity += electricityElement.Payment;
                            }
                            _tempPaymentElectricity = (_tempElectricity / daysInMonth) * days + (_tempElectricity * monthes) + _tempPaymentElectricity;

                        }
                        else
                        {
                            payment = (tenant.Payment.Rent) * monthes + payment;
                            _tempPaymentHouse = tenant.Payment.House * monthes + _tempPaymentHouse;
                            _tempPaymentService = tenant.Payment.Service * monthes + _tempPaymentService;

                            decimal _tempElectricity = 0;

                            foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(eid => eid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                            {
                                _tempElectricity += electricityElement.Payment;
                            }
                            _tempPaymentElectricity = _tempElectricity * monthes + _tempPaymentElectricity;
                        }

                    }

                    if (startBenefit > startDate && endBenefit > endDate)
                    {
                        OrdersCreation.SpecialDateCheck(startDate, startBenefit, out days, out monthes, out daysInMonth);

                        if (days != 0)
                        {
                            payment += (tenant.Payment.Rent / daysInMonth) * days + tenant.Payment.Rent * monthes;
                            _tempPaymentHouse += (tenant.Payment.House / daysInMonth) * days + tenant.Payment.House * monthes;
                            _tempPaymentService += (tenant.Payment.Service / daysInMonth) * days + tenant.Payment.Service * monthes;

                            decimal _tempElectricity = 0;

                            foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(eid => eid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                            {
                                _tempElectricity += electricityElement.Payment;
                            }

                            _tempPaymentElectricity += (_tempElectricity / daysInMonth) * days + _tempElectricity * monthes;
                        }
                        else
                        {
                            payment += tenant.Payment.Rent * monthes;
                            _tempPaymentHouse += tenant.Payment.House * monthes;
                            _tempPaymentService += tenant.Payment.Service * monthes;

                            decimal _tempElectricity = 0;

                            foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(eid => eid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                            {
                                _tempElectricity += electricityElement.Payment;
                            }

                            _tempPaymentElectricity += _tempElectricity * monthes;
                        }

                        OrdersCreation.SpecialDateCheck(startBenefit, endDate, out days, out monthes, out daysInMonth);

                        if (days != 0)
                        {
                            payment += Convert.ToDecimal(benefit.Payment) / daysInMonth * days + Convert.ToDecimal(benefit.Payment) * monthes;
                            _tempPaymentHouse += Convert.ToDecimal(benefit.House) / daysInMonth * days + Convert.ToDecimal(benefit.House) * monthes;
                            _tempPaymentService += Convert.ToDecimal(benefit.Service) / daysInMonth * days + Convert.ToDecimal(benefit.Service) * monthes;
                            _tempPaymentElectricity += Convert.ToDecimal(benefit.Electricity / daysInMonth) * days + Convert.ToDecimal(benefit.Electricity) * monthes;
                        }
                        else
                        {
                            payment += Convert.ToDecimal(benefit.Payment) + monthes;
                            _tempPaymentHouse += Convert.ToDecimal(benefit.House) * monthes;
                            _tempPaymentService += Convert.ToDecimal(benefit.Service) * monthes;
                            _tempPaymentElectricity += Convert.ToDecimal(benefit.Electricity) * monthes;
                        }
                    }

                    if ((endBenefit == endDate && startDate == startBenefit) || (startBenefit > startDate && endBenefit < endDate))
                    {
                        OrdersCreation.SpecialDateCheck(startDate, endDate, out days, out monthes, out daysInMonth);
                        if (days != 0)
                        {
                            payment += ((tenant.Payment.Rent / daysInMonth) * days + tenant.Payment.Rent * monthes);
                            _tempPaymentHouse += (tenant.Payment.House / daysInMonth) * days + tenant.Payment.House * monthes;
                            _tempPaymentService += (tenant.Payment.Service / daysInMonth) * days + tenant.Payment.Service * monthes;

                            decimal _tempElectricity = 0;

                            foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(eid => eid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                            {
                                _tempElectricity += electricityElement.Payment;
                            }

                            _tempPaymentElectricity += (_tempElectricity / daysInMonth) * days + _tempElectricity * monthes;
                        }
                        else
                        {
                            payment += tenant.Payment.Rent * monthes;
                            _tempPaymentHouse += tenant.Payment.House * monthes;
                            _tempPaymentService += tenant.Payment.Service * monthes;

                            decimal _tempElectricity = 0;

                            foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(eid => eid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                            {
                                _tempElectricity += electricityElement.Payment;
                            }

                            _tempPaymentElectricity += _tempElectricity * monthes;
                        }


                        OrdersCreation.SpecialDateCheck(startBenefit, endBenefit, out days, out monthes, out daysInMonth);
                        if (days != 0)
                        {
                            payment = payment - ((tenant.Payment.Rent / daysInMonth) * days);
                            _tempPaymentHouse = _tempPaymentHouse - (tenant.Payment.House / daysInMonth) * days;
                            _tempPaymentService = _tempPaymentService - (tenant.Payment.Service / daysInMonth) * days;
                            decimal _tempElectricity = 0;

                            foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(eid => eid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                            {
                                _tempElectricity += electricityElement.Payment;
                            }

                            _tempPaymentElectricity += (_tempElectricity / daysInMonth) * days;

                            payment += (Convert.ToDecimal(benefit.Payment) / daysInMonth) * days + Convert.ToDecimal(benefit.Payment) * monthes;
                            _tempPaymentHouse += (Convert.ToDecimal(benefit.House / daysInMonth) * days) + Convert.ToDecimal(benefit.House) * monthes;
                            _tempPaymentService += (Convert.ToDecimal(benefit.Service / daysInMonth) * days) + Convert.ToDecimal(benefit.Service) * monthes;
                            _tempPaymentElectricity += (Convert.ToDecimal(benefit.Electricity / daysInMonth) * days) + Convert.ToDecimal(benefit.Electricity) * monthes;
                        }
                        else
                        {
                            payment = payment - (tenant.Payment.Rent * monthes);
                            _tempPaymentHouse = _tempPaymentHouse - tenant.Payment.House * monthes;
                            _tempPaymentService = _tempPaymentService - tenant.Payment.Service * monthes;
                            decimal _tempElectricity = 0;

                            foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(eid => eid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                            {
                                _tempElectricity += electricityElement.Payment;
                            }

                            _tempPaymentElectricity += _tempElectricity * monthes;

                            _tempPaymentHouse += Convert.ToDecimal(benefit.House) * monthes;
                            _tempPaymentService += Convert.ToDecimal(benefit.Service) * monthes;
                            _tempPaymentElectricity += Convert.ToDecimal(benefit.Electricity) * monthes;
                            payment += Convert.ToDecimal(benefit.Payment) * monthes;
                        }

                    }

                    if (startDate > startBenefit && endBenefit > endDate)
                    {
                        OrdersCreation.SpecialDateCheck(startDate, endDate, out days, out monthes, out daysInMonth);
                        if (days != 0)
                        {
                            payment += Convert.ToDecimal(benefit.Payment) / daysInMonth * days;
                            payment += Convert.ToDecimal(benefit.Payment) * monthes;

                            _tempPaymentElectricity += Convert.ToDecimal(benefit.Electricity) / daysInMonth * days;
                            _tempPaymentElectricity += Convert.ToDecimal(benefit.Electricity) * monthes;

                            _tempPaymentHouse += Convert.ToDecimal(benefit.House) / daysInMonth * days;
                            _tempPaymentHouse += Convert.ToDecimal(benefit.House) * monthes;

                            _tempPaymentService += Convert.ToDecimal(benefit.Service) / daysInMonth * days;
                            _tempPaymentService += Convert.ToDecimal(benefit.Service) * monthes;
                        }
                        else
                        {
                            payment += Convert.ToDecimal(benefit.Payment) * monthes;
                            _tempPaymentElectricity += Convert.ToDecimal(benefit.Electricity) * monthes;
                            _tempPaymentHouse += Convert.ToDecimal(benefit.House) * monthes;
                            _tempPaymentService += Convert.ToDecimal(benefit.Service) * monthes;
                        }
                    }

                    if (startBenefit == startDate && endBenefit < endDate)
                    {
                        OrdersCreation.SpecialDateCheck(startDate, endBenefit, out days, out monthes, out daysInMonth);

                        if (days != 0)
                        {
                            payment += Convert.ToDecimal(benefit.Payment) / daysInMonth * days;
                            payment += Convert.ToDecimal(benefit.Payment) * monthes;

                            _tempPaymentElectricity += Convert.ToDecimal(benefit.Electricity) / daysInMonth * days;
                            _tempPaymentElectricity += Convert.ToDecimal(benefit.Electricity) * monthes;

                            _tempPaymentHouse += Convert.ToDecimal(benefit.House) / daysInMonth * days;
                            _tempPaymentHouse += Convert.ToDecimal(benefit.House) * monthes;

                            _tempPaymentService += Convert.ToDecimal(benefit.Service) / daysInMonth * days;
                            _tempPaymentService += Convert.ToDecimal(benefit.Service) * monthes;
                        }
                        else
                        {
                            payment += Convert.ToDecimal(benefit.Payment) * monthes;
                            _tempPaymentElectricity += Convert.ToDecimal(benefit.Electricity) * monthes;
                            _tempPaymentHouse += Convert.ToDecimal(benefit.House) * monthes;
                            _tempPaymentService += Convert.ToDecimal(benefit.Service) * monthes;
                        }

                        OrdersCreation.SpecialDateCheck(endBenefit, endDate, out days, out monthes, out daysInMonth);

                        if (days != 0)
                        {
                            payment += Convert.ToDecimal(tenant.Payment.Rent) / daysInMonth * days;
                            payment += Convert.ToDecimal(tenant.Payment.Rent) * monthes;

                            _tempPaymentHouse += Convert.ToDecimal(tenant.Payment.House) / daysInMonth * days;
                            _tempPaymentHouse += Convert.ToDecimal(tenant.Payment.House) * monthes;

                            _tempPaymentService += Convert.ToDecimal(tenant.Payment.Service) / daysInMonth * days;
                            _tempPaymentService += Convert.ToDecimal(tenant.Payment.Service) * monthes;

                            decimal _tempElectricity = 0;

                            foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(eid => eid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                            {
                                _tempElectricity += electricityElement.Payment;
                            }

                            _tempPaymentElectricity += (_tempElectricity / daysInMonth) * days + _tempElectricity * monthes;
                        }
                        else
                        {
                            payment += Convert.ToDecimal(tenant.Payment.Rent) * monthes;
                            _tempPaymentHouse += Convert.ToDecimal(tenant.Payment.House) * monthes;
                            _tempPaymentService += Convert.ToDecimal(tenant.Payment.Service) * monthes;

                            decimal _tempElectricity = 0;

                            foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(eid => eid.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                            {
                                _tempElectricity += electricityElement.Payment;
                            }

                            _tempPaymentElectricity +=  _tempElectricity * monthes;
                        }
                    }

                    rent = payment;
                    house = _tempPaymentHouse;
                    service = _tempPaymentService;
                    electricity = +_tempPaymentElectricity;

                    days = 0;
                    daysInMonth = 0;
                    monthes = 0;

                    

                    return true;
                }

                if(specialPayment !=null)
                {

                    Tenant tenant = db.Tenants.Where(x => x.ID == tenantID).Include(p=>p.Payment).Include(r => r.Room).FirstOrDefault();

                    DateTime startSpecialPaymentDate = DateTime.Parse(specialPayment.StartDate);
                    DateTime endSpecialPayment = DateTime.Parse(specialPayment.EndDate);

                    if (startSpecialPaymentDate <= startDate && endDate <= endSpecialPayment)
                    {
                        rent += tenant.Payment.Rent * specialPayment.Places;
                        house += tenant.Payment.House * specialPayment.Places;
                        service += tenant.Payment.Service * specialPayment.Places;

                        if(tenant.TenantTypeID != 3 && tenant.TenantTypeID != 2)
                        {
                            foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(pid => pid.ElectricityPaymentID == specialPayment.ElectricityPaymentID).ToList())
                            {
                                electricity += electricityElement.Payment * (decimal)specialPayment.ElectricityPaymentPlaces;
                            }
                        }

                    }
                    else
                    {

                        OrdersCreation.SpecialDateCheck(startDate, endDate, out days, out monthes, out daysInMonth);

                        if (days != 0)
                        {
                            service = (tenant.Payment.Service / daysInMonth) * days + (tenant.Payment.Service * monthes);
                            house = (tenant.Payment.House / daysInMonth) * days + (tenant.Payment.House * monthes);
                            if(tenant.TenantTypeID != 3 && tenant.TenantTypeID != 2)
                            {
                                foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(p => p.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                                {
                                    electricity += electricityElement.Payment;
                                }

                                electricity = (electricity / daysInMonth) * days + (electricity * monthes);
                            }
                            
                        }
                        else
                        {
                            service = tenant.Payment.Service * monthes;
                            house = tenant.Payment.House * monthes;
                            if(tenant.TenantTypeID != 3 && tenant.TenantTypeID != 2)
                            {
                                foreach (ElectricityElement electricityElement in db.ElectricityElements.Where(p => p.ElectricityPaymentID == tenant.Room.ElectricityPaymentID).ToList())
                                {
                                    electricity += electricityElement.Payment;
                                }

                                electricity = electricity * monthes;
                            }
                            
                        }
                    }

                    return true;
                }
                
            }

            return false;
        }
    }
}
