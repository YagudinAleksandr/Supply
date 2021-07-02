using Libraries.WordSystem;
using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Supply.Libs
{
    public static class OrdersCreation
    {
        public static bool CreateOrders(int tenantID, out string error)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Tenant tenant = db.Tenants.Where(x => x.ID == tenantID).Where(y => y.Status == true).Include(p => p.Payment).First();
                Order order = db.Orders.Where(x => x.ID == tenant.ID).Include(l=>l.License).FirstOrDefault();
                Room room = db.Rooms.Where(x => x.ID == order.RoomID).Include(t => t.RoomType).Include(p => p.Properties).FirstOrDefault();
                Flat flat = db.Flats.Where(x => x.ID == room.FlatID).FirstOrDefault();
                Enterance enterance = db.Enterances.Where(x => x.ID == flat.Enterance_ID).Include(f=>f.Flats).FirstOrDefault();
                Hostel hostel = db.Hostels.Where(x => x.ID == enterance.HostelId).Include(m => m.Manager).Include(h=>h.Address).FirstOrDefault();
                License license = db.Licenses.Where(x => x.ManagerId == hostel.Manager.ID).First();

                if (tenant == null)
                {
                    error = $"Жильца для договора №{order.OrderNumber} не найдено!";
                    return false;
                }

                Identification identification = db.Identifications.Where(x => x.ID == tenant.ID).First();

                var additionalInformation = db.AdditionalInformation.Where(x => x.TenantID == tenant.ID).ToList();

                //Создание Word документа
                string errorMessage = String.Empty;

                string template = string.Empty;

                if(tenant.TenantTypeID == 1)
                {
                    switch (AdditionalInf(5, tenant.ID))
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
                }
                
                if (tenant.TenantTypeID == 2)
                {
                    template = "template3";
                }

                if (tenant.TenantTypeID == 3)
                {
                    template = "template4";
                }

                if (template == string.Empty)
                {
                    error = "Несуществующий тип договора!";
                    return false;
                }

                WordDocument document = new WordDocument(AppSettings.GetTemplateSetting(template), AppSettings.GetTemplateSetting("outfileDir")+@"\", "Договор №" + order.OrderNumber.ToString());

                if (document.OpenWordTemplate(out errorMessage))
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

                    if (identification.Patronymic != string.Empty)
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
                    if (identification.Code != null)
                    {
                        replacements.Add("DocCode", identification.Code);
                    }
                    else
                    {
                        replacements.Add("DocCode", "");
                    }
                    replacements.Add("HumanAddress", identification.Address);
                    replacements.Add("humanCitizenship", identification.Cityzenship);

                    replacements.Add("eduType", AdditionalInf(5, tenant.ID));
                    replacements.Add("rent", AdditionalInf(8, tenant.ID));

                    /*Льготы*/
                    Benefit benefit;

                    if (BenefitCheck(order, out benefit))
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
                    foreach (Property property in room.Properties)
                    {
                        elements += $"{property.Name}-{property.Count}шт., ";
                    }
                    replacements.Add("Elements", elements);

                    //Общежитие
                    int flats = enterance.Flats.Count;
                    replacements.Add("hostelName", hostel.Name);
                    replacements.Add("hostelAddress", hostel.Address.ZipCode + ", " + hostel.Address.Country + ", " + hostel.Address.Region + ", "
                        + hostel.Address.City + ", " + hostel.Address.Street + ", " + hostel.Address.House);
                    replacements.Add("hostelFlat", flat.Name);
                    replacements.Add("hostelFlats", flats.ToString());
                    replacements.Add("MainManager", order.License.Manager.Surename + " " + order.License.Manager.Name[0] + "." + order.License.Manager.Patronymic[0] + ".");
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
                    switch (template)
                    {
                        case "template1":

                            replacements.Add("rate", (tenant.Payment.Rent + tenant.Payment.Service).ToString());
                            replacements.Add("rateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service)));
                            replacements.Add("yearRate", ((tenant.Payment.Rent + tenant.Payment.Service) * 12).ToString());
                            replacements.Add("rateWordYear", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service) * 12));
                            totalDate = Math.Abs((orderEndDate.Month - orderStartDate.Month) + 12 * (orderEndDate.Year - orderStartDate.Year));
                            replacements.Add("allTimeRate", ((int)(tenant.Payment.Rent + tenant.Payment.Service) * totalDate).ToString());
                            replacements.Add("allTimeRateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service) * totalDate));

                            break;


                        case "template2":

                            replacements.Add("rate", (tenant.Payment.Rent + tenant.Payment.Service).ToString());
                            replacements.Add("rateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service)));
                            totalDate = Math.Abs((orderEndDate - orderStartDate).Days);
                            replacements.Add("allTimeRate", ((int)(tenant.Payment.Rent + tenant.Payment.Service) * totalDate).ToString());
                            replacements.Add("allTimeRateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service) * totalDate));
                            break;

                        case "template3":

                            var tenantFamily = additionalInformation.Where(x => x.AdditionalInformationTypeID == 8).ToList();
                            if (tenantFamily.Count != 0)
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
                            replacements.Add("allTimeRate", ((int)(tenant.Payment.Rent + tenant.Payment.Service) * totalDate).ToString());
                            replacements.Add("allTimeRateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service) * totalDate));

                            break;

                        default:
                            break;
                    }


                    //Начинаем замену в шаблоне и сохраняем документ
                    document.MakeReplacementInWordTemplate(replacements);
                    //Закрываем документ
                    document.CloseWordTemplate(out errorMessage);
                    
                }
                else
                {
                    error = errorMessage;
                    return false;
                }
            }
            error = string.Empty;
            GC.Collect();
            return true;
        }
        public static bool BenefitCheck(Order order, out Benefit benefit)
        {
            benefit = new Benefit();

            using (SupplyDbContext db = new SupplyDbContext())
            {
                Benefit tempBenefit = db.Benefits.Where(x => x.OrderID == order.ID).Where(s => s.Status == true).Include(t => t.BenefitType).FirstOrDefault();
                if (tempBenefit != null)
                {
                    benefit = tempBenefit;
                    return true;
                }
            }
            return false;
        }
        public static string AdditionalInf(int type, int tenantId)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                var addinf = db.AdditionalInformation.Where(tenantid => tenantid.TenantID == tenantId)
                    .Where(x => x.AdditionalInformationTypeID == type)
                    .Include(t => t.AdditionalInformationType)
                    .FirstOrDefault();

                if (addinf != null)
                {
                    return addinf.Value;
                }

            }
            return string.Empty;
        }
        public static bool BenefitCreation(int orderId, out string error)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Order order = db.Orders.Where(x => x.ID == orderId).Include(l => l.License).FirstOrDefault();
                Benefit benefit;
                if (BenefitCheck(order, out benefit))
                {
                    Tenant tenant = db.Tenants.Where(x => x.ID == order.ID).Where(y => y.Status == true).Include(p => p.Payment).First();

                    Room room = db.Rooms.Where(x => x.ID == order.RoomID).Include(t => t.RoomType).Include(p => p.Properties).FirstOrDefault();
                    Flat flat = db.Flats.Where(x => x.ID == room.FlatID).FirstOrDefault();
                    Enterance enterance = db.Enterances.Where(x => x.ID == flat.Enterance_ID).Include(f => f.Flats).FirstOrDefault();
                    Hostel hostel = db.Hostels.Where(x => x.ID == enterance.HostelId).Include(m => m.Manager).Include(h => h.Address).FirstOrDefault();
                    License license = db.Licenses.Where(x => x.ManagerId == hostel.Manager.ID).First();

                    if (tenant == null)
                    {
                        error = $"Жильца для договора №{order.OrderNumber} не найдено!";
                        return false;
                    }

                    Identification identification = db.Identifications.Where(x => x.ID == tenant.ID).First();

                    var additionalInformation = db.AdditionalInformation.Where(x => x.TenantID == tenant.ID).ToList();

                    //Создание Word документа
                    string errorMessage = String.Empty;


                    WordDocument document = new WordDocument(AppSettings.GetTemplateSetting("template5"), AppSettings.GetTemplateSetting("outfileDir")+@"\", "Приложение(льгота) к договору №" + order.OrderNumber.ToString());

                    if (document.OpenWordTemplate(out errorMessage))
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

                        if (identification.Patronymic != string.Empty)
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
                        if (identification.Code != null)
                        {
                            replacements.Add("DocCode", identification.Code);
                        }
                        else
                        {
                            replacements.Add("DocCode", "");
                        }
                        replacements.Add("HumanAddress", identification.Address);
                        replacements.Add("humanCitizenship", identification.Cityzenship);

                        replacements.Add("eduType", AdditionalInf(5, tenant.ID));
                        replacements.Add("rent", AdditionalInf(7, tenant.ID));

                        /*Льготы*/

                        replacements.Add("benefit", "Да");
                        replacements.Add("benefitCategory", benefit.BenefitType.Name);
                        replacements.Add("benefitDecreeDate", benefit.DecreeDate);
                        replacements.Add("benefitDecree", benefit.DecreeNumber);
                        replacements.Add("benefitStartDate", benefit.StartDate);
                        replacements.Add("benefitEndDate", benefit.EndDate);
                        replacements.Add("OrderAdditionalDate", benefit.StartDate);




                        //Общежитие
                        int flats = enterance.Flats.Count;
                        replacements.Add("hostelName", hostel.Name);
                        replacements.Add("hostelAddress", hostel.Address.ZipCode + ", " + hostel.Address.Country + ", " + hostel.Address.Region + ", "
                            + hostel.Address.City + ", " + hostel.Address.Street + ", " + hostel.Address.House);
                        replacements.Add("hostelFlat", flat.Name);
                        replacements.Add("hostelFlats", flats.ToString());
                        replacements.Add("MainManager", order.License.Manager.Surename + " " + order.License.Manager.Name[0] + "." + order.License.Manager.Patronymic[0] + ".");
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
                        DateTime benefitStartDate = Convert.ToDateTime(order.StartDate);
                        DateTime benefitEndDate = Convert.ToDateTime(order.EndDate);
                        replacements.Add("rate", benefit.Payment.ToString());
                        replacements.Add("rateWord", NumbersToString.NumbersToString.Str((int)benefit.Payment));
                        replacements.Add("yearRate", (benefit.Payment * 12).ToString());
                        replacements.Add("rateWordYear", NumbersToString.NumbersToString.Str((int)benefit.Payment * 12));
                        totalDate = Math.Abs((benefitEndDate.Month - benefitStartDate.Month) + 12 * (benefitEndDate.Year - benefitStartDate.Year));
                        replacements.Add("allTimeRate", ((int)benefit.Payment * totalDate).ToString());
                        replacements.Add("allTimeRateWord", NumbersToString.NumbersToString.Str((int)benefit.Payment * totalDate));

                        //Начинаем замену в шаблоне и сохраняем документ
                        document.MakeReplacementInWordTemplate(replacements);
                        //Закрываем документ
                        document.CloseWordTemplate(out errorMessage);

                    }
                    else
                    {
                        error = errorMessage;
                        return false;
                    }
                }
                
            }
            error = string.Empty;
            GC.Collect();
            return true;
        }
        public static bool ChangeRoomCreate(int changeID, out string error)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                ChangeRoom changeRoom;
                Order order;
                Tenant tenant;
                Room room;
                Flat flat;
                Enterance enterance;
                Hostel hostel;
                License license;
                try
                {
                    changeRoom = db.ChangeRooms.Where(x => x.ID == changeID).Include(or => or.Order).Include(r => r.Room).FirstOrDefault();
                    order = db.Orders.Where(x => x.ID == changeRoom.Order.ID).Include(l => l.License).FirstOrDefault();
                    tenant = db.Tenants.Where(x => x.ID == order.ID).Where(y => y.Status == true).Include(p => p.Payment).First();

                    room = db.Rooms.Where(x => x.ID == changeRoom.Room.ID).Include(t => t.RoomType).Include(p => p.Properties).FirstOrDefault();
                    flat = db.Flats.Where(x => x.ID == room.FlatID).FirstOrDefault();
                    enterance = db.Enterances.Where(x => x.ID == flat.Enterance_ID).Include(f => f.Flats).FirstOrDefault();
                    hostel = db.Hostels.Where(x => x.ID == enterance.HostelId).Include(m => m.Manager).Include(h => h.Address).FirstOrDefault();
                    license = db.Licenses.Where(x => x.ManagerId == hostel.Manager.ID).First();
                }
                catch(Exception ex)
                {
                    error = ex.Message+"."+ex.InnerException;
                    return false;
                }

                if (tenant == null)
                {
                    error = $"Жильца для договора №{order.OrderNumber} не найдено!";
                    return false;
                }

                Identification identification = db.Identifications.Where(x => x.ID == tenant.ID).First();

                var additionalInformation = db.AdditionalInformation.Where(x => x.TenantID == tenant.ID).ToList();

                //Создание Word документа
                string errorMessage = String.Empty;


                WordDocument document = new WordDocument(AppSettings.GetTemplateSetting("template6"), AppSettings.GetTemplateSetting("outfileDir")+@"\", "Приложение(переселение) к договору №" + order.OrderNumber.ToString());

                if (document.OpenWordTemplate(out errorMessage))
                {
                    Dictionary<string, string> replacements = new Dictionary<string, string>();

                    /*Жилец*/
                    replacements.Add("ID", order.OrderNumber.ToString());
                    DateTime orderStartDate = Convert.ToDateTime(order.StartDate);
                    replacements.Add("startOrder", order.StartDate);
                    replacements.Add("OrderAdditionalDate", changeRoom.StartDate);

                    DateTime orderEndDate = Convert.ToDateTime(order.EndDate);
                    replacements.Add("EndOrder", order.EndDate);
                    replacements.Add("yearEndDate", orderEndDate.Year.ToString());
                    replacements.Add("surename", identification.Surename);
                    replacements.Add("name", identification.Name);
                    replacements.Add("ns", identification.Name[0].ToString());

                    if (identification.Patronymic != string.Empty)
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
                    if (identification.Code != null)
                    {
                        replacements.Add("DocCode", identification.Code);
                    }
                    else
                    {
                        replacements.Add("DocCode", "");
                    }
                    replacements.Add("HumanAddress", identification.Address);
                    replacements.Add("humanCitizenship", identification.Cityzenship);





                    //Общежитие
                    replacements.Add("roomName", room.Name);
                    replacements.Add("roomType", room.RoomType.Name);
                    int flats = enterance.Flats.Count;
                    replacements.Add("hostelName", hostel.Name);
                    replacements.Add("hostelAddress", hostel.Address.ZipCode + ", " + hostel.Address.Country + ", " + hostel.Address.Region + ", "
                        + hostel.Address.City + ", " + hostel.Address.Street + ", " + hostel.Address.House);
                    replacements.Add("MainManager", order.License.Manager.Surename + " " + order.License.Manager.Name[0] + "." + order.License.Manager.Patronymic[0] + ".");
                    replacements.Add("Manager", order.License.Manager.Surename + " " + order.License.Manager.Name + " " + order.License.Manager.Patronymic);
                    replacements.Add("LicenseType", order.License.Type);
                    replacements.Add("LicenseNumber", order.License.Name);
                    replacements.Add("LicenseStart", order.License.StartDate);


                    //Начинаем замену в шаблоне и сохраняем документ
                    document.MakeReplacementInWordTemplate(replacements);
                    //Закрываем документ
                    document.CloseWordTemplate(out errorMessage);

                }
                else
                {
                    error = errorMessage;
                    return false;
                }

            }
            error = string.Empty;
            GC.Collect();
            return true;
        }
        public static bool ChangePassportCreate(int changePassportID, out string error)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                ChangePassport changePassport;
                Order order;
                Tenant tenant;
                Room room;
                Flat flat;
                Enterance enterance;
                Hostel hostel;
                License license;
                Identification identification;

                try
                {
                    changePassport = db.ChangePassports.Where(id => id.ID == changePassportID).Include(t => t.Tenant).FirstOrDefault();
                    order = db.Orders.Where(x => x.ID == changePassport.Tenant.ID).Include(l => l.License).FirstOrDefault();
                    tenant = db.Tenants.Where(x => x.ID == order.ID).Where(y => y.Status == true).Include(r => r.Room).First();

                    room = db.Rooms.Where(x => x.ID == tenant.Room.ID).Include(t => t.RoomType).Include(p => p.Properties).FirstOrDefault();
                    flat = db.Flats.Where(x => x.ID == room.FlatID).FirstOrDefault();
                    enterance = db.Enterances.Where(x => x.ID == flat.Enterance_ID).Include(f => f.Flats).FirstOrDefault();
                    hostel = db.Hostels.Where(x => x.ID == enterance.HostelId).Include(m => m.Manager).Include(h => h.Address).FirstOrDefault();
                    license = db.Licenses.Where(x => x.ID == hostel.Manager.ID).First();
                    identification = db.Identifications.Where(x => x.ID == tenant.ID).First();
                }
                catch(Exception ex)
                {
                    error = ex.Message+"."+ex.InnerException;
                    return false;
                }

                if (tenant == null)
                {
                    error = $"Жильца для договора №{order.OrderNumber} не найдено!";
                    return false;
                }
                
                

                var additionalInformation = db.AdditionalInformation.Where(x => x.TenantID == tenant.ID).ToList();

                //Создание Word документа
                string errorMessage = String.Empty;


                WordDocument document = new WordDocument(AppSettings.GetTemplateSetting("template7"), AppSettings.GetTemplateSetting("outfileDir")+@"\", "Приложение(смена паспорта) к договору №" + order.OrderNumber.ToString());

                if (document.OpenWordTemplate(out errorMessage))
                {
                    Dictionary<string, string> replacements = new Dictionary<string, string>();

                    /*Жилец*/
                    replacements.Add("ID", order.OrderNumber.ToString());
                    DateTime orderStartDate = Convert.ToDateTime(order.StartDate);
                    replacements.Add("startOrder", order.StartDate);
                    replacements.Add("OrderAdditionalDate", changePassport.StartDate);

                    DateTime orderEndDate = Convert.ToDateTime(order.EndDate);
                    replacements.Add("EndOrder", order.EndDate);
                    replacements.Add("yearEndDate", orderEndDate.Year.ToString());
                    replacements.Add("surename", changePassport.Surename);
                    replacements.Add("name", changePassport.Name);
                    replacements.Add("ns", changePassport.Name[0].ToString());

                    if (identification.Patronymic != string.Empty)
                    {
                        replacements.Add("patronymic", changePassport.Patronymic);
                        replacements.Add("ps", changePassport.Patronymic[0].ToString());
                    }
                    else
                    {
                        replacements.Add("patronymic", "");
                        replacements.Add("ps", "");
                    }



                    replacements.Add("DocSeries", changePassport.Series);
                    replacements.Add("DocNumber", changePassport.Number);
                    replacements.Add("DocGiven", changePassport.Issued);
                    replacements.Add("DocDate", changePassport.GivenDate);
                    if (identification.Code != null)
                    {
                        replacements.Add("DocCode", changePassport.Code);
                    }
                    else
                    {
                        replacements.Add("DocCode", "");
                    }
                    replacements.Add("HumanAddress", changePassport.Address);
                    replacements.Add("humanCitizenship", changePassport.Citizenship);





                    //Общежитие
                    replacements.Add("roomName", room.Name);
                    replacements.Add("roomType", room.RoomType.Name);
                    int flats = enterance.Flats.Count;
                    replacements.Add("hostelName", hostel.Name);
                    replacements.Add("hostelAddress", hostel.Address.ZipCode + ", " + hostel.Address.Country + ", " + hostel.Address.Region + ", "
                        + hostel.Address.City + ", " + hostel.Address.Street + ", " + hostel.Address.House);
                    replacements.Add("MainManager", order.License.Manager.Surename + " " + order.License.Manager.Name[0] + "." + order.License.Manager.Patronymic[0] + ".");
                    replacements.Add("Manager", order.License.Manager.Surename + " " + order.License.Manager.Name + " " + order.License.Manager.Patronymic);
                    replacements.Add("LicenseType", order.License.Type);
                    replacements.Add("LicenseNumber", order.License.Name);
                    replacements.Add("LicenseStart", order.License.StartDate);


                    //Начинаем замену в шаблоне и сохраняем документ
                    document.MakeReplacementInWordTemplate(replacements);
                    //Закрываем документ
                    document.CloseWordTemplate(out errorMessage);

                }
                else
                {
                    error = errorMessage;
                    return false;
                }

            }
            error = string.Empty;
            GC.Collect();
            return true;
        }
        public static bool CreateServiceOrder(int tenantID, out string error)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Tenant tenant = db.Tenants.Where(x => x.ID == tenantID).Where(s => s.Status == true).Include(r => r.Room).FirstOrDefault();
                if(tenant!= null)
                {

                    ElectricityPayment electricityPayment = db.ElectricityPayments.Where(x => x.ID == tenant.Room.ElectricityPaymentID).FirstOrDefault();
                    if (electricityPayment == null)
                    {
                        error = "Тарифный план не назначен!";
                        return false;
                    }
                    ElecricityOrder elecricityOrder = db.ElecricityOrders.Where(x => x.TenantID == tenant.ID).Where(st => st.Status == true).FirstOrDefault();
                    
                    Order order = db.Orders.Where(x => x.ID == tenant.ID).Include(l => l.License).FirstOrDefault();
                    Room room = db.Rooms.Where(x => x.ID == order.RoomID).Include(t => t.RoomType).Include(p => p.Properties).FirstOrDefault();
                    Flat flat = db.Flats.Where(x => x.ID == room.FlatID).FirstOrDefault();
                    Enterance enterance = db.Enterances.Where(x => x.ID == flat.Enterance_ID).Include(f => f.Flats).FirstOrDefault();
                    Hostel hostel = db.Hostels.Where(x => x.ID == enterance.HostelId).Include(m => m.Manager).Include(h => h.Address).FirstOrDefault();
                    License license = db.Licenses.Where(x => x.ManagerId == hostel.Manager.ID).First();
                    Identification identification = db.Identifications.Where(x => x.ID == tenant.ID).Include(dt => dt.DocumentType).FirstOrDefault();
                    ChangePassport changePassport = db.ChangePassports.Where(x => x.TenantID == tenant.ID).Where(st => st.Status == true).FirstOrDefault();
                    if(identification==null)
                    {
                        error = $"Any identification data for tenant with ID {tenant.ID}";
                        return false;
                    }

                    WordDocument document;

                    if (changePassport!=null)
                    {
                        document = new WordDocument(AppSettings.GetTemplateSetting("template9"), AppSettings.GetTemplateSetting("outfileDir") + @"\", $"Договор эл.энергия {changePassport.Surename} {changePassport.Name} " + order.OrderNumber.ToString());
                    }
                    else
                    {
                        document = new WordDocument(AppSettings.GetTemplateSetting("template9"), AppSettings.GetTemplateSetting("outfileDir") + @"\", $"Договор эл.энергия {identification.Surename} {identification.Name} " + order.OrderNumber.ToString());
                    }

                    if (document.OpenWordTemplate(out error))
                    {
                        Dictionary<string, string> replacements = new Dictionary<string, string>();

                        /*Жилец*/
                        
                        DateTime orderStartDate = Convert.ToDateTime(elecricityOrder.StartDate);
                        replacements.Add("startOrder", elecricityOrder.StartDate);
                        DateTime orderEndDate = Convert.ToDateTime(elecricityOrder.EndDate);
                        replacements.Add("EndOrder", elecricityOrder.EndDate);
                        replacements.Add("yearEndDate", orderEndDate.Year.ToString());

                        if (changePassport != null)
                        {
                            replacements.Add("surename", changePassport.Surename);
                            replacements.Add("name", changePassport.Name);
                            replacements.Add("ns", changePassport.Name[0].ToString());

                            if (identification.Patronymic != string.Empty)
                            {
                                replacements.Add("patronymic", changePassport.Patronymic);
                                replacements.Add("ps", changePassport.Patronymic[0].ToString());
                            }
                            else
                            {
                                replacements.Add("patronymic", "");
                                replacements.Add("ps", "");
                            }



                            replacements.Add("DocSeries", changePassport.Series);
                            replacements.Add("DocNumber", changePassport.Number);
                            replacements.Add("DocGiven", changePassport.Issued);
                            replacements.Add("DocDate", changePassport.GivenDate);
                            if (identification.Code != null)
                            {
                                replacements.Add("DocCode", changePassport.Code);
                            }
                            else
                            {
                                replacements.Add("DocCode", "");
                            }
                            replacements.Add("HumanAddress", changePassport.Address);
                            replacements.Add("humanCitizenship", changePassport.Citizenship);

                        }
                        else
                        {
                            replacements.Add("surename", identification.Surename);
                            replacements.Add("name", identification.Name);
                            replacements.Add("ns", identification.Name[0].ToString());

                            if (identification.Patronymic != string.Empty)
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
                            if (identification.Code != null)
                            {
                                replacements.Add("DocCode", identification.Code);
                            }
                            else
                            {
                                replacements.Add("DocCode", "");
                            }
                            replacements.Add("HumanAddress", identification.Address);
                            replacements.Add("humanCitizenship", identification.Cityzenship);

                        }

                        replacements.Add("telephone", AdditionalInf(1, tenant.ID));

                        /*Данные по комнате*/
                        replacements.Add("roomName", room.Name);
                        

                        //Общежитие
                        int flats = enterance.Flats.Count;
                        replacements.Add("hostelName", hostel.Name);
                        replacements.Add("hostelAddress", hostel.Address.ZipCode + ", " + hostel.Address.Country + ", " + hostel.Address.Region + ", "
                            + hostel.Address.City + ", " + hostel.Address.Street + ", " + hostel.Address.House);
                        replacements.Add("MainManager", order.License.Manager.Surename + " " + order.License.Manager.Name[0] + "." + order.License.Manager.Patronymic[0] + ".");
                        replacements.Add("Manager", order.License.Manager.Surename + " " + order.License.Manager.Name + " " + order.License.Manager.Patronymic);
                        replacements.Add("LicenseType", order.License.Type);
                        replacements.Add("LicenseNumber", order.License.Name);
                        replacements.Add("LicenseStart", order.License.StartDate);
                        replacements.Add("supplySurename", hostel.Manager.Surename + " " + hostel.Manager.Name[0] + "." + hostel.Manager.Patronymic[0] + ".");
                        replacements.Add("supply", hostel.Manager.Surename + " " + hostel.Manager.Name + " " + hostel.Manager.Patronymic);
                        replacements.Add("supplyProxy", license.Name);
                        replacements.Add("supplyProxyDate", license.StartDate);

                        var electricitiesElements = db.ElectricityElements.Where(ep => ep.ElectricityPaymentID == electricityPayment.ID).ToList();

                        List<string> electricitiesElementsString = new List<string>();

                        //Первая заглавная строка таблицы
                        electricitiesElementsString.Add("Перечень электроприборов, разрешенных к использованию в общежитиях Исполнителя");
                        electricitiesElementsString.Add("Кол-во электроприборов");
                        electricitiesElementsString.Add("Период использовани, кол-во месяцев");
                        electricitiesElementsString.Add("Сумма платежа за месяц (с НДС, 18%) руб/чел");
                        electricitiesElementsString.Add("Итого сумма платежа за период использования, (с НДС, 18%), руб/чел");

                        //Платежи

                        decimal totalPayment = 0;
                        decimal totalPaymentInMonth = 0;

                        foreach(ElectricityElement electricityElement in electricitiesElements)
                        {
                            int totalDate = 0;
                            totalDate = Math.Abs((orderEndDate.Month - orderStartDate.Month) + 12 * (orderEndDate.Year - orderStartDate.Year));
                            electricitiesElementsString.Add(electricityElement.Name);
                            electricitiesElementsString.Add("1");
                            electricitiesElementsString.Add(totalDate.ToString());
                            totalPaymentInMonth += electricityElement.Payment;
                            electricitiesElementsString.Add(electricityElement.Payment.ToString());
                            totalPayment += (electricityElement.Payment * totalDate);
                            electricitiesElementsString.Add((electricityElement.Payment * totalDate).ToString());
                        }

                        electricitiesElementsString.Add("Итого сумма платежа с НДС (18%), руб/чел");
                        electricitiesElementsString.Add("");
                        electricitiesElementsString.Add("");
                        electricitiesElementsString.Add(totalPaymentInMonth.ToString());
                        electricitiesElementsString.Add(totalPayment.ToString());

                        if (!document.MakeTableInWordDocument("tablePayment", electricitiesElements.Count + 2, 5, electricitiesElementsString, out error)) 
                        {
                            return false;
                        }

                        //Начинаем замену в шаблоне и сохраняем документ
                        if(!document.MakeReplacementInWordTemplate(replacements))
                        {
                            return false;
                        }
                        //Закрываем документ

                        if(!document.CloseWordTemplate(out error))
                        {
                            return false;
                        }

                    }
                    else
                    {
                        
                        return false;
                    }
                }
                else
                {
                    error = "Не найден жилец в базе!";
                    return false;
                }
            }
            error = string.Empty;
            return true;
        }
        public static bool CreatePaymentOrder(int tenantID, string periodStart, string periodEnd, string action, out string error)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Tenant tenant = db.Tenants.Where(x => x.ID == tenantID).Where(s => s.Status == true).Include(r => r.Room).Include(p=>p.Payment).FirstOrDefault();
                if (tenant != null)
                {

                    ElectricityPayment electricityPayment = db.ElectricityPayments.Where(x => x.ID == tenant.Room.ElectricityPaymentID).FirstOrDefault();
                    if (electricityPayment == null)
                    {
                        error = "Тарифный план не назначен!";
                        return false;
                    }
                    ElecricityOrder elecricityOrder = db.ElecricityOrders.Where(x => x.TenantID == tenant.ID).Where(st => st.Status == true).FirstOrDefault();

                    Order order = db.Orders.Where(x => x.ID == tenant.ID).Include(l => l.License).FirstOrDefault();
                    Room room = db.Rooms.Where(x => x.ID == order.RoomID).Include(t => t.RoomType).Include(p => p.Properties).FirstOrDefault();
                    Flat flat = db.Flats.Where(x => x.ID == room.FlatID).FirstOrDefault();
                    Enterance enterance = db.Enterances.Where(x => x.ID == flat.Enterance_ID).Include(f => f.Flats).FirstOrDefault();
                    Hostel hostel = db.Hostels.Where(x => x.ID == enterance.HostelId).Include(m => m.Manager).Include(h => h.Address).FirstOrDefault();
                    Identification identification = db.Identifications.Where(x => x.ID == tenant.ID).Include(dt => dt.DocumentType).FirstOrDefault();
                    ChangePassport changePassport = db.ChangePassports.Where(x => x.TenantID == tenant.ID).Where(st => st.Status == true).FirstOrDefault();
                    if (identification == null)
                    {
                        error = $"Any identification data for tenant with ID {tenant.ID}";
                        return false;
                    }

                    WordDocument document;

                    if (changePassport != null)
                    {
                        document = new WordDocument(AppSettings.GetTemplateSetting("template11"), AppSettings.GetTemplateSetting("outfileDir") + @"\", $"Платежное поручение {changePassport.Surename} {changePassport.Name} " + order.OrderNumber.ToString());
                    }
                    else
                    {
                        document = new WordDocument(AppSettings.GetTemplateSetting("template11"), AppSettings.GetTemplateSetting("outfileDir") + @"\", $"Платежное поручение {identification.Surename} {identification.Name} " + order.OrderNumber.ToString());
                    }

                    if (document.OpenWordTemplate(out error))
                    {
                        Dictionary<string, string> replacements = new Dictionary<string, string>();

                        /*Жилец*/

                        

                        if (changePassport != null)
                        {
                            replacements.Add("surename", changePassport.Surename);
                            replacements.Add("name", changePassport.Name);
                            replacements.Add("ns", changePassport.Name[0].ToString());

                            if (identification.Patronymic != string.Empty)
                            {
                                replacements.Add("patronymic", changePassport.Patronymic);
                                replacements.Add("ps", changePassport.Patronymic[0].ToString());
                            }
                            else
                            {
                                replacements.Add("patronymic", "");
                                replacements.Add("ps", "");
                            }

                        }
                        else
                        {
                            replacements.Add("surename", identification.Surename);
                            replacements.Add("name", identification.Name);
                            replacements.Add("ns", identification.Name[0].ToString());

                            if (identification.Patronymic != string.Empty)
                            {
                                replacements.Add("patronymic", identification.Patronymic);
                                replacements.Add("ps", identification.Patronymic[0].ToString());
                            }
                            else
                            {
                                replacements.Add("patronymic", "");
                                replacements.Add("ps", "");
                            }

                        }

                        replacements.Add("faculty", AdditionalInf(3, tenant.ID));
                        replacements.Add("group", AdditionalInf(4, tenant.ID));

                        /*Данные по комнате*/
                        replacements.Add("roomName", room.Name);


                        //Общежитие
                        replacements.Add("hostelName", hostel.Name);

                        replacements.Add("periodStart", periodStart);
                        replacements.Add("periodEnd", periodEnd);
                        replacements.Add("paymentAct", action);

                        var electricitiesElements = db.ElectricityElements.Where(ep => ep.ElectricityPaymentID == electricityPayment.ID).ToList();

                        //Платежи
                        DateTime orderStartDate = Convert.ToDateTime(periodStart);
                        DateTime orderEndDate = Convert.ToDateTime(periodEnd);


                        decimal totalPayment = 0;
                        int totalDate = Math.Abs((orderEndDate.Month - orderStartDate.Month) + 12 * (orderEndDate.Year - orderStartDate.Year));

                        foreach (ElectricityElement electricityElement in electricitiesElements)
                        {
                            totalPayment += (electricityElement.Payment * totalDate);
                        }

                        if (AdditionalInf(5, tenant.ID) != "Заочная")
                        {
                            replacements.Add("supplyEl", totalPayment.ToString());
                            replacements.Add("bed", (tenant.Payment.Rent * totalDate).ToString());
                        }
                        else
                        {
                            replacements.Add("supplyEl", "0,00");
                            replacements.Add("bed", (tenant.Payment.Rent * (orderEndDate - orderStartDate).Days).ToString());
                        }
                        
                        replacements.Add("supply", (tenant.Payment.Service * totalDate).ToString());

                        //Начинаем замену в шаблоне и сохраняем документ
                        if (!document.MakeReplacementInWordTemplate(replacements))
                        {
                            return false;
                        }
                        //Закрываем документ

                        if (!document.CloseWordTemplate(out error))
                        {
                            return false;
                        }

                    }
                    else
                    {

                        return false;
                    }
                }
                else
                {
                    error = "Не найден жилец в базе!";
                    return false;
                }
            }
            error = string.Empty;
            return true;
        }
    }
    
}
