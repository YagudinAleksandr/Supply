using Libraries.WordSystem;
using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                License license = db.Licenses.Where(x => x.ID == hostel.Manager.ID).First();

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

                WordDocument document = new WordDocument(AppSettings.GetTemplateSetting(template), AppSettings.GetTemplateSetting("outfileDir"), "Договор №" + order.OrderNumber.ToString());

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
                            replacements.Add("yearRate", (tenant.Payment.Rent * 12).ToString());
                            replacements.Add("rateWordYear", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service) * 12));
                            totalDate = Math.Abs((orderEndDate.Month - orderStartDate.Month) + 12 * (orderEndDate.Year - orderStartDate.Year));
                            replacements.Add("allTimeRate", ((int)tenant.Payment.Rent * totalDate).ToString());
                            replacements.Add("allTimeRateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service) * totalDate));

                            break;


                        case "template2":

                            replacements.Add("rate", (tenant.Payment.Rent + tenant.Payment.Service).ToString());
                            replacements.Add("rateWord", NumbersToString.NumbersToString.Str((int)(tenant.Payment.Rent + tenant.Payment.Service)));
                            totalDate = Math.Abs((orderEndDate.Day - orderStartDate.Day) + (orderEndDate.Day - orderStartDate.Day));
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

                            var tenantFamily1 = additionalInformation.Where(x => x.AdditionalInformationTypeID == 8).ToList();
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
                    License license = db.Licenses.Where(x => x.ID == hostel.Manager.ID).First();

                    if (tenant == null)
                    {
                        error = $"Жильца для договора №{order.OrderNumber} не найдено!";
                        return false;
                    }

                    Identification identification = db.Identifications.Where(x => x.ID == tenant.ID).First();

                    var additionalInformation = db.AdditionalInformation.Where(x => x.TenantID == tenant.ID).ToList();

                    //Создание Word документа
                    string errorMessage = String.Empty;


                    WordDocument document = new WordDocument(AppSettings.GetTemplateSetting("template5"), AppSettings.GetTemplateSetting("outfileDir"), "Приложение(льгота) к договору №" + order.OrderNumber.ToString());

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
                ChangeRoom changeRoom = db.ChangeRooms.Where(x => x.ID == changeID).Include(or => or.Order).Include(r => r.Room).FirstOrDefault();
                Order order = db.Orders.Where(x => x.ID == changeRoom.Order.ID).Include(l => l.License).FirstOrDefault();
                Tenant tenant = db.Tenants.Where(x => x.ID == order.ID).Where(y => y.Status == true).Include(p => p.Payment).First();

                Room room = db.Rooms.Where(x => x.ID == changeRoom.Room.ID).Include(t => t.RoomType).Include(p => p.Properties).FirstOrDefault();
                Flat flat = db.Flats.Where(x => x.ID == room.FlatID).FirstOrDefault();
                Enterance enterance = db.Enterances.Where(x => x.ID == flat.Enterance_ID).Include(f => f.Flats).FirstOrDefault();
                Hostel hostel = db.Hostels.Where(x => x.ID == enterance.HostelId).Include(m => m.Manager).Include(h => h.Address).FirstOrDefault();
                License license = db.Licenses.Where(x => x.ID == hostel.Manager.ID).First();

                if (tenant == null)
                {
                    error = $"Жильца для договора №{order.OrderNumber} не найдено!";
                    return false;
                }

                Identification identification = db.Identifications.Where(x => x.ID == tenant.ID).First();

                var additionalInformation = db.AdditionalInformation.Where(x => x.TenantID == tenant.ID).ToList();

                //Создание Word документа
                string errorMessage = String.Empty;


                WordDocument document = new WordDocument(AppSettings.GetTemplateSetting("template6"), AppSettings.GetTemplateSetting("outfileDir"), "Приложение(переселение) к договору №" + order.OrderNumber.ToString());

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
                ChangePassport changePassport = db.ChangePassports.Where(id => id.ID == changePassportID).Include(t=>t.Tenant).FirstOrDefault();
                Order order = db.Orders.Where(x => x.ID == changePassport.Tenant.ID).Include(l => l.License).FirstOrDefault();
                Tenant tenant = db.Tenants.Where(x => x.ID == order.ID).Where(y => y.Status == true).Include(r => r.Room).First();

                Room room = db.Rooms.Where(x => x.ID == tenant.Room.ID).Include(t => t.RoomType).Include(p => p.Properties).FirstOrDefault();
                Flat flat = db.Flats.Where(x => x.ID == room.FlatID).FirstOrDefault();
                Enterance enterance = db.Enterances.Where(x => x.ID == flat.Enterance_ID).Include(f => f.Flats).FirstOrDefault();
                Hostel hostel = db.Hostels.Where(x => x.ID == enterance.HostelId).Include(m => m.Manager).Include(h => h.Address).FirstOrDefault();
                License license = db.Licenses.Where(x => x.ID == hostel.Manager.ID).First();

                if (tenant == null)
                {
                    error = $"Жильца для договора №{order.OrderNumber} не найдено!";
                    return false;
                }

                Identification identification = db.Identifications.Where(x => x.ID == tenant.ID).First();

                var additionalInformation = db.AdditionalInformation.Where(x => x.TenantID == tenant.ID).ToList();

                //Создание Word документа
                string errorMessage = String.Empty;


                WordDocument document = new WordDocument(AppSettings.GetTemplateSetting("template7"), AppSettings.GetTemplateSetting("outfileDir"), "Приложение(смена паспорта) к договору №" + order.OrderNumber.ToString());

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
    }
    
}
