﻿using Supply.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Libraries.WordSystem;
using System.Data.Entity;
using Supply.Models;
using Supply.Libs;

namespace Supply
{
    public partial class OrderCreateForm : Form
    {
        private int _hostelIndex;
        public OrderCreateForm()
        {
            InitializeComponent();
        }

        private void OrderCreateForm_Load(object sender, EventArgs e)
        {
            _hostelIndex = 0;
            using(SupplyDbContext db = new SupplyDbContext())
            {
                CB_Hostels.DataSource = db.Hostels.ToList();
                CB_Hostels.ValueMember = "ID";
                CB_Hostels.DisplayMember = "Name";

                
            }
            PB_Creation.Visible = false;
        }

        private void CB_Hostels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _hostelIndex = int.Parse(CB_Hostels.SelectedValue.ToString());
            }
            catch
            {
                return;
            }
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            if(_hostelIndex==0)
            {
                MessageBox.Show("Выбирете общежитие!");
                return;
            }


            int orderCounter = 0; //Счетчик созданых договоров
            using(SupplyDbContext db = new SupplyDbContext())
            {
                Hostel hostel = db.Hostels.Where(x => x.ID == _hostelIndex).Include(y => y.Manager).Include(p=>p.Address).First();
                License license = db.Licenses.Where(x => x.ManagerId == hostel.Manager.ID).First();
                var enterances = db.Enterances.Where(x => x.HostelId == _hostelIndex).ToList();

                PB_Creation.Minimum = 0;
                PB_Creation.Maximum = enterances.Count;
                PB_Creation.Visible = true;
                int counter = 0; // Счетчик

                foreach (var enterance in enterances)
                {
                    var flats = db.Flats.Where(x => x.Enterance_ID == enterance.ID).ToList();
                    foreach(var flat in flats)
                    {
                        var rooms = db.Rooms.Where(x => x.FlatID == flat.ID).Include(y=>y.RoomType).Include(p=>p.Properties).ToList();
                        foreach(var room in rooms)
                        {
                            var orders = db.Orders.Where(x => x.RoomID == room.ID).Where(y => y.StartDate == TB_StartOrder.Text).Include(lic=>lic.License).ToList();
                            foreach(var order in orders)
                            {
                                Tenant tenant = db.Tenants.Where(x => x.ID == order.ID).Where(y=>y.Status==true).Include(p=>p.Payment).First();

                                if(tenant==null)
                                {
                                    MessageBox.Show($"Жильца для договора №{order.OrderNumber} не найдено!");
                                    continue;
                                }

                                Identification identification = db.Identifications.Where(x => x.ID == tenant.ID).First();

                                var additionalInformation = db.AdditionalInformation.Where(x => x.TenantID == tenant.ID).ToList();

                                //Создание Word документа
                                string errorMessage = String.Empty;

                                string template = string.Empty;

                                switch(OrdersCreation.AdditionalInf(5,tenant.ID))
                                {
                                    case "Очная":
                                    case "очная":
                                    case "Очно-заочная":
                                    case "очно-заочная":
                                        template = "template1";
                                        break;
                                    case "Заочная":
                                    case "заочная":
                                        template = "template2";
                                        break;
                                    default:
                                        template = "";
                                        break;
                                }

                                if (tenant.TenantTypeID == 2)
                                {
                                    template = "template3";
                                }

                                if (tenant.TenantTypeID == 3)
                                {
                                    template = "template4";
                                }

                                if(template==string.Empty)
                                {
                                    Log logInfo = new Log();
                                    logInfo.ID = Guid.NewGuid();
                                    logInfo.Type = "WARNING";
                                    logInfo.Caption = $"Class: OrderCreateForm. Method: BTN_Create_Click. Несуществующий тип договора";
                                    logInfo.CreatedAt = DateTime.Now.ToString();
                                    db.Logs.Add(logInfo);
                                    db.SaveChanges();

                                    MessageBox.Show("Несуществующий тип договора!");
                                    continue;
                                }

                                WordDocument document = new WordDocument(AppSettings.GetTemplateSetting(template), AppSettings.GetTemplateSetting("outfileDir")+@"\", "Договор №" + order.OrderNumber.ToString());

                                if(document.OpenWordTemplate(out errorMessage))
                                {
                                    Dictionary<string, string> replacements = new Dictionary<string, string>();

                                    /*Жилец*/
                                    replacements.Add("ID", order.OrderNumber.ToString());
                                    DateTime orderStartDate = Convert.ToDateTime(order.StartDate);
                                    replacements.Add("startOrder", order.StartDate);
                                    DateTime orderEndDate = Convert.ToDateTime(order.EndDate);
                                    replacements.Add("EndOrder", order.EndDate);
                                    replacements.Add("yearEndDate", orderEndDate.Year.ToString());
                                    replacements.Add("surename", identification.Surename);
                                    replacements.Add("name", identification.Name);
                                    replacements.Add("ns", identification.Name[0].ToString());
                                    
                                    if (identification.Patronymic!=string.Empty)
                                    {
                                        replacements.Add("patronymic", identification.Patronymic);
                                        replacements.Add("ps", identification.Patronymic[0].ToString());
                                    }
                                    else
                                    {
                                        replacements.Add("patronymic", "");
                                        replacements.Add("ps", "");
                                    }



                                    replacements.Add("DocSeries", identification.DocumentSeries);
                                    replacements.Add("DocNumber", identification.DocumentNumber);
                                    replacements.Add("DocGiven", identification.Issued);
                                    replacements.Add("DocDate", identification.GivenDate);
                                    if(identification.Code!=null)
                                    {
                                        replacements.Add("DocCode", identification.Code);
                                    }
                                    else
                                    {
                                        replacements.Add("DocCode", "");
                                    }
                                    replacements.Add("HumanAddress", identification.Address);
                                    replacements.Add("humanCitizenship", identification.Cityzenship);

                                    replacements.Add("eduType", OrdersCreation.AdditionalInf(5, tenant.ID));
                                    replacements.Add("rent", OrdersCreation.AdditionalInf(8, tenant.ID));

                                    /*Льготы*/
                                    Benefit benefit;

                                    if (OrdersCreation.BenefitCheck(order, out benefit))
                                    {
                                        replacements.Add("benefit", "Да");
                                        replacements.Add("benefitCategory", benefit.BenefitType.Name);
                                        replacements.Add("benefitDecreeDate", benefit.DecreeDate);
                                        replacements.Add("benefitDecree", benefit.DecreeNumber);
                                        replacements.Add("benefitStartDate", benefit.StartDate);
                                        replacements.Add("benefitEndDate", benefit.EndDate);
                                    }
                                    else
                                    {
                                        replacements.Add("benefit", "Нет");
                                        replacements.Add("benefitCategory", "-");
                                        replacements.Add("benefitDecreeDate", "-");
                                        replacements.Add("benefitDecree", "-");
                                        replacements.Add("benefitStartDate", "-");
                                        replacements.Add("benefitEndDate", "-");
                                    }

                                    /*Данные по комнате*/
                                    replacements.Add("roomName", room.Name);
                                    replacements.Add("roomType", room.RoomType.Name);
                                    string elements = String.Empty;
                                    foreach(Property property in room.Properties)
                                    {
                                        elements += $"{property.Name}-{property.Count}шт., ";
                                    }
                                    replacements.Add("Elements", elements);

                                    //Общежитие

                                    replacements.Add("hostelName",hostel.Name);
                                    replacements.Add("hostelAddress", hostel.Address.ZipCode + ", " + hostel.Address.Country + ", " + hostel.Address.Region + ", "
                                        + hostel.Address.City + ", " + hostel.Address.Street + ", " + hostel.Address.House);
                                    replacements.Add("hostelFlat", flat.Name );
                                    replacements.Add("hostelFlats", flats.Count.ToString());
                                    replacements.Add("MainManager", order.License.Manager.Surename + " "+ order.License.Manager.Name[0]+"." + order.License.Manager.Patronymic[0] + ".");
                                    replacements.Add("Manager", order.License.Manager.Surename + " " + order.License.Manager.Name + " " + order.License.Manager.Patronymic);
                                    replacements.Add("LicenseType", order.License.Type);
                                    replacements.Add("LicenseNumber", order.License.Name);
                                    replacements.Add("LicenseStart", order.License.StartDate);
                                    replacements.Add("supplySurename", hostel.Manager.Surename + " " + hostel.Manager.Name[0] + "." + hostel.Manager.Patronymic[0] + ".");
                                    replacements.Add("supply", hostel.Manager.Surename + " " + hostel.Manager.Name + " " + hostel.Manager.Patronymic);
                                    replacements.Add("supplyProxy", license.Name);
                                    replacements.Add("supplyProxyDate", license.StartDate);

                                    int totalDate = 0;
                                    /*Тарифный план*/
                                    switch(template)
                                    {
                                        case "template1":

                                            replacements.Add("rate", (tenant.Payment.Rent + tenant.Payment.Service).ToString());
                                            replacements.Add("rateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service)));
                                            replacements.Add("yearRate", (tenant.Payment.Rent * 12).ToString());
                                            replacements.Add("rateWordYear", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service) * 12));
                                            totalDate = Math.Abs((orderEndDate.Month - orderStartDate.Month) + 12 * (orderEndDate.Year - orderStartDate.Year));
                                            replacements.Add("allTimeRate", ((int)(tenant.Payment.Rent + tenant.Payment.Service) * totalDate).ToString());
                                            replacements.Add("allTimeRateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service) * totalDate));

                                            break;


                                        case "template2":

                                            replacements.Add("rate", (tenant.Payment.Rent + tenant.Payment.Service).ToString());
                                            replacements.Add("rateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service)));
                                            totalDate = Math.Abs((orderEndDate - orderStartDate).Days);
                                            replacements.Add("allTimeRate", ((int)tenant.Payment.Rent * totalDate).ToString());
                                            replacements.Add("allTimeRateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service)));
                                            break;

                                        case "template3":

                                            var tenantFamily = additionalInformation.Where(x => x.AdditionalInformationTypeID == 8).ToList();
                                            if(tenantFamily.Count!=0)
                                            {
                                                string family = string.Empty;
                                                for (int y = 0; y < tenantFamily.Count; y++)
                                                {
                                                    family += $"{y + 1}) " + tenantFamily[y].Value + "\n";
                                                }
                                                replacements.Add("family", family);
                                            }
                                            else
                                            {
                                                replacements.Add("family", "");
                                            }

                                            replacements.Add("rate", (tenant.Payment.Rent + tenant.Payment.Service).ToString());
                                            replacements.Add("rateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service)));
                                            replacements.Add("yearRate", ((tenant.Payment.Rent + tenant.Payment.Service) * 12).ToString());
                                            replacements.Add("rateWordYear", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service) * 12));

                                            break;

                                        case "template4":
                                            var tenantFamily1 = additionalInformation.Where(x => x.AdditionalInformationTypeID == 9).ToList();
                                            if (tenantFamily1.Count != 0)
                                            {
                                                string family = string.Empty;
                                                for (int y = 0; y < tenantFamily1.Count; y++)
                                                {
                                                    family += $"{y + 1}) " + tenantFamily1[y].Value + "\n";
                                                }
                                                replacements.Add("family", family);
                                            }
                                            else
                                            {
                                                replacements.Add("family", "");
                                            }

                                            replacements.Add("rate", (tenant.Payment.Rent + tenant.Payment.Service).ToString());
                                            replacements.Add("rateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service)));
                                            totalDate = Math.Abs((orderEndDate.Day - orderStartDate.Day) + (orderEndDate.Day - orderStartDate.Day));
                                            replacements.Add("allTimeRate", ((int)tenant.Payment.Rent * totalDate).ToString());
                                            replacements.Add("allTimeRateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service) * totalDate));
                                            break;
                                    }
                                    

                                    //Начинаем замену в шаблоне и сохраняем документ
                                    document.MakeReplacementInWordTemplate(replacements);
                                    //Закрываем документ
                                    document.CloseWordTemplate(out errorMessage);
                                    orderCounter++;
                                }
                                else
                                {
                                    MessageBox.Show(errorMessage);

                                    Log logInfo = new Log();
                                    logInfo.ID = Guid.NewGuid();
                                    logInfo.Type = "WARNING";
                                    logInfo.Caption = $"Class: OrderCreateForm. Method: BTN_Create_Click.{errorMessage}";
                                    logInfo.CreatedAt = DateTime.Now.ToString();
                                    db.Logs.Add(logInfo);
                                    db.SaveChanges();

                                    continue;
                                }
                                //Окончание блока создания word документа
                            }
                        }
                    }

                    counter++;
                    PB_Creation.Value = counter;
                }
            }

            MessageBox.Show($"Выполнение завершено! Количество созданых договоро - {orderCounter} шт."); ;

            GC.Collect();

            this.Close();
        }

        

         
    }

}
