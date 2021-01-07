﻿using Supply_Admin.Domain;
using Supply_Admin.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Supply_Admin
{
    public class WordExcelIO
    {

        public static bool CreatAdditionalSettings(SupplyDbContext _db, int flag, int Infid)
        {
            if(flag == 1)
            {
                var orders = _db.Orders.Where(x => x.HostelsId == Infid).Where(x => x.Status == 1).ToList();

                object missing = Type.Missing;

                if (orders.Count() != 0)
                {


                    //Создание объекта Word
                    Word.Application app = new Word.Application();

                    //Загрузка WORD шаблона
                    Word.Document doc = null;

                    object fileName = "Y:\\U2035\\Supply\\Supply Admin\\Files\\Electosupplies.docx";


                    foreach (var order in orders)
                    {
                        doc = app.Documents.Open(fileName, missing, missing);
                        app.Selection.Find.ClearFormatting();
                        app.Selection.Find.Replacement.ClearFormatting();



                        var human = _db.Humen.Where(x => x.Id == order.HumanId).FirstOrDefault();
                        var room = _db.Rooms.Where(x => x.Id == human.RoomId).FirstOrDefault();
                        var flat = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
                        var enterance = _db.Enterances.Where(x => x.Id == flat.EnteranceId).FirstOrDefault();
                        var hostel = _db.Hostels.Where(x => x.Id == enterance.HostelsId).FirstOrDefault();
                        var supply = _db.Supplies.Where(x => x.HostelsId == hostel.Id).FirstOrDefault();


                        try
                        {


                            app.Selection.Find.Execute("<surename>", missing, missing, missing, missing, missing, missing, missing, missing, human.Surename, 2);
                            app.Selection.Find.Execute("<name>", missing, missing, missing, missing, missing, missing, missing, missing, human.Name, 2);
                            app.Selection.Find.Execute("<patronymic>", missing, missing, missing, missing, missing, missing, missing, missing, human.Patronymic, 2);
                            app.Selection.Find.Execute("<DocSeries>", missing, missing, missing, missing, missing, missing, missing, missing, human.Series, 2);
                            app.Selection.Find.Execute("<DocNumber>", missing, missing, missing, missing, missing, missing, missing, missing, human.Number, 2);
                            app.Selection.Find.Execute("<DocGiven>", missing, missing, missing, missing, missing, missing, missing, missing, human.Given, 2);
                            app.Selection.Find.Execute("<DocDate>", missing, missing, missing, missing, missing, missing, missing, missing, human.GivenDate, 2);
                            app.Selection.Find.Execute("<PhoneNumber>", missing, missing, missing, missing, missing, missing, missing, missing, human.PhoneNumber, 2);
                            app.Selection.Find.Execute("<HumanAddress>", missing, missing, missing, missing, missing, missing, missing, missing, human.Registration, 2);
                            app.Selection.Find.Execute("<humanCitizenship>", missing, missing, missing, missing, missing, missing, missing, missing, human.Citizenship, 2);



                            app.Selection.Find.Execute("<ns>", missing, missing, missing, missing, missing, missing, missing, missing, human.Name[0].ToString(), 2);
                            app.Selection.Find.Execute("<ps>", missing, missing, missing, missing, missing, missing, missing, missing, human.Patronymic[0].ToString(), 2);

                            app.Selection.Find.Execute("<roomName>", missing, missing, missing, missing, missing, missing, missing, missing, room.Name, 2);
                            app.Selection.Find.Execute("<hostelName>", missing, missing, missing, missing, missing, missing, missing, missing, hostel.Name, 2);
                            app.Selection.Find.Execute("<hostelAddress>", missing, missing, missing, missing, missing, missing, missing, missing, hostel.Address, 2);


                            app.Selection.Find.Execute("<sSurename>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Surename, 2);
                            app.Selection.Find.Execute("<supplyName>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name, 2);
                            app.Selection.Find.Execute("<supplyPatronymic>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic, 2);
                            app.Selection.Find.Execute("<sN>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name[0].ToString(), 2);
                            app.Selection.Find.Execute("<sP>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic[0].ToString(), 2);
                            app.Selection.Find.Execute("<supplyProxy>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Proxy, 2);
                            app.Selection.Find.Execute("<supplyProxyDate>", missing, missing, missing, missing, missing, missing, missing, missing, supply.ProxyDate, 2);
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка работы с шаблоном");

                            //Закрытие ProgressBar


                            //Закрытие документа
                            doc.Close(false, missing, missing);
                            app.Quit(false, false, false);

                            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                            return false;
                        }


                        //Сохранение договоров
                        object saveAsFile = (object)"C:\\Users\\Aleksandr\\Desktop\\Report\\Договор(Эл.энергия)" + order.Id.ToString() + ".doc";
                        doc.SaveAs2(saveAsFile, missing, missing, missing);

                        return true;

                    }


                    //Закрытие документа
                    doc.Close(false, missing, missing);
                    app.Quit(false, false, false);

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);


                }
            }
            else if(flag == 2)
            {
                var human = _db.Humen.Where(x => x.Id == Infid).FirstOrDefault();
                var order = _db.Orders.Where(x => x.HumanId == Infid).Where(x => x.Status == 1).First();

                object missing = Type.Missing;

                if (order != null)
                {


                    //Создание объекта Word
                    Word.Application app = new Word.Application();

                    //Загрузка WORD шаблона
                    Word.Document doc = null;

                    object fileName = "Y:\\U2035\\Supply\\Supply Admin\\Files\\Electosupplies.docx";


                    doc = app.Documents.Open(fileName, missing, missing);
                    app.Selection.Find.ClearFormatting();
                    app.Selection.Find.Replacement.ClearFormatting();




                    var room = _db.Rooms.Where(x => x.Id == human.RoomId).FirstOrDefault();
                    var flat = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
                    var enterance = _db.Enterances.Where(x => x.Id == flat.EnteranceId).FirstOrDefault();
                    var hostel = _db.Hostels.Where(x => x.Id == enterance.HostelsId).FirstOrDefault();
                    var supply = _db.Supplies.Where(x => x.HostelsId == hostel.Id).FirstOrDefault();


                    try
                    {


                        app.Selection.Find.Execute("<surename>", missing, missing, missing, missing, missing, missing, missing, missing, human.Surename, 2);
                        app.Selection.Find.Execute("<name>", missing, missing, missing, missing, missing, missing, missing, missing, human.Name, 2);
                        app.Selection.Find.Execute("<patronymic>", missing, missing, missing, missing, missing, missing, missing, missing, human.Patronymic, 2);
                        app.Selection.Find.Execute("<DocSeries>", missing, missing, missing, missing, missing, missing, missing, missing, human.Series, 2);
                        app.Selection.Find.Execute("<DocNumber>", missing, missing, missing, missing, missing, missing, missing, missing, human.Number, 2);
                        app.Selection.Find.Execute("<DocGiven>", missing, missing, missing, missing, missing, missing, missing, missing, human.Given, 2);
                        app.Selection.Find.Execute("<DocDate>", missing, missing, missing, missing, missing, missing, missing, missing, human.GivenDate, 2);
                        app.Selection.Find.Execute("<PhoneNumber>", missing, missing, missing, missing, missing, missing, missing, missing, human.PhoneNumber, 2);
                        app.Selection.Find.Execute("<HumanAddress>", missing, missing, missing, missing, missing, missing, missing, missing, human.Registration, 2);
                        app.Selection.Find.Execute("<humanCitizenship>", missing, missing, missing, missing, missing, missing, missing, missing, human.Citizenship, 2);



                        app.Selection.Find.Execute("<ns>", missing, missing, missing, missing, missing, missing, missing, missing, human.Name[0].ToString(), 2);
                        app.Selection.Find.Execute("<ps>", missing, missing, missing, missing, missing, missing, missing, missing, human.Patronymic[0].ToString(), 2);

                        app.Selection.Find.Execute("<roomName>", missing, missing, missing, missing, missing, missing, missing, missing, room.Name, 2);
                        app.Selection.Find.Execute("<hostelName>", missing, missing, missing, missing, missing, missing, missing, missing, hostel.Name, 2);
                        app.Selection.Find.Execute("<hostelAddress>", missing, missing, missing, missing, missing, missing, missing, missing, hostel.Address, 2);


                        app.Selection.Find.Execute("<sSurename>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Surename, 2);
                        app.Selection.Find.Execute("<supplyName>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name, 2);
                        app.Selection.Find.Execute("<supplyPatronymic>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic, 2);
                        app.Selection.Find.Execute("<sN>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name[0].ToString(), 2);
                        app.Selection.Find.Execute("<sP>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic[0].ToString(), 2);
                        app.Selection.Find.Execute("<supplyProxy>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Proxy, 2);
                        app.Selection.Find.Execute("<supplyProxyDate>", missing, missing, missing, missing, missing, missing, missing, missing, supply.ProxyDate, 2);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка работы с шаблоном");

                        //Закрытие ProgressBar


                        //Закрытие документа
                        doc.Close(false, missing, missing);
                        app.Quit(false, false, false);

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                        return false;
                    }


                    //Сохранение договоров
                    object saveAsFile = (object)"C:\\Users\\Aleksandr\\Desktop\\Report\\Договор(Эл.энергия)" + order.Id.ToString() + ".doc";
                    doc.SaveAs2(saveAsFile, missing, missing, missing);


                    //Закрытие документа
                    doc.Close(false, missing, missing);
                    app.Quit(false, false, false);

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                    return true;
                }
            }
            
            return false;
        }
        public static bool CreatAdditionalSettings(SupplyDbContext _db, List<int> listOfId)
        {
            object missing = Type.Missing;


            //Создание объекта Word
            Word.Application app = new Word.Application();

            //Загрузка WORD шаблона
            Word.Document doc = null;

            object fileName = "Y:\\U2035\\Supply\\Supply Admin\\Files\\Electosupplies.docx";

            for (int i = 0; i < listOfId.Count; i++)
            {
                int orderId = listOfId[i];
                var order = _db.Orders.Where(x => x.Id == orderId).Where(x => x.Status == 1).First();


                doc = app.Documents.Open(fileName, missing, missing);
                app.Selection.Find.ClearFormatting();
                app.Selection.Find.Replacement.ClearFormatting();

                var human = _db.Humen.Where(x => x.Id == order.HumanId).FirstOrDefault();
                var room = _db.Rooms.Where(x => x.Id == human.RoomId).FirstOrDefault();
                var flat = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
                var enterance = _db.Enterances.Where(x => x.Id == flat.EnteranceId).FirstOrDefault();
                var hostel = _db.Hostels.Where(x => x.Id == enterance.HostelsId).FirstOrDefault();
                var supply = _db.Supplies.Where(x => x.HostelsId == hostel.Id).FirstOrDefault();

                try
                {


                    app.Selection.Find.Execute("<surename>", missing, missing, missing, missing, missing, missing, missing, missing, human.Surename, 2);
                    app.Selection.Find.Execute("<name>", missing, missing, missing, missing, missing, missing, missing, missing, human.Name, 2);
                    app.Selection.Find.Execute("<patronymic>", missing, missing, missing, missing, missing, missing, missing, missing, human.Patronymic, 2);
                    app.Selection.Find.Execute("<DocSeries>", missing, missing, missing, missing, missing, missing, missing, missing, human.Series, 2);
                    app.Selection.Find.Execute("<DocNumber>", missing, missing, missing, missing, missing, missing, missing, missing, human.Number, 2);
                    app.Selection.Find.Execute("<DocGiven>", missing, missing, missing, missing, missing, missing, missing, missing, human.Given, 2);
                    app.Selection.Find.Execute("<DocDate>", missing, missing, missing, missing, missing, missing, missing, missing, human.GivenDate, 2);
                    app.Selection.Find.Execute("<PhoneNumber>", missing, missing, missing, missing, missing, missing, missing, missing, human.PhoneNumber, 2);
                    app.Selection.Find.Execute("<HumanAddress>", missing, missing, missing, missing, missing, missing, missing, missing, human.Registration, 2);
                    app.Selection.Find.Execute("<humanCitizenship>", missing, missing, missing, missing, missing, missing, missing, missing, human.Citizenship, 2);



                    app.Selection.Find.Execute("<ns>", missing, missing, missing, missing, missing, missing, missing, missing, human.Name[0].ToString(), 2);
                    app.Selection.Find.Execute("<ps>", missing, missing, missing, missing, missing, missing, missing, missing, human.Patronymic[0].ToString(), 2);

                    app.Selection.Find.Execute("<roomName>", missing, missing, missing, missing, missing, missing, missing, missing, room.Name, 2);
                    app.Selection.Find.Execute("<hostelName>", missing, missing, missing, missing, missing, missing, missing, missing, hostel.Name, 2);
                    app.Selection.Find.Execute("<hostelAddress>", missing, missing, missing, missing, missing, missing, missing, missing, hostel.Address, 2);


                    app.Selection.Find.Execute("<sSurename>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Surename, 2);
                    app.Selection.Find.Execute("<supplyName>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name, 2);
                    app.Selection.Find.Execute("<supplyPatronymic>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic, 2);
                    app.Selection.Find.Execute("<sN>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name[0].ToString(), 2);
                    app.Selection.Find.Execute("<sP>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic[0].ToString(), 2);
                    app.Selection.Find.Execute("<supplyProxy>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Proxy, 2);
                    app.Selection.Find.Execute("<supplyProxyDate>", missing, missing, missing, missing, missing, missing, missing, missing, supply.ProxyDate, 2);
                }
                catch
                {
                    MessageBox.Show("Ошибка работы с шаблоном");

                    //Закрытие ProgressBar


                    //Закрытие документа
                    doc.Close(false, missing, missing);
                    app.Quit(false, false, false);

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                    return false;
                }


                //Сохранение договоров
                object saveAsFile = (object)"C:\\Users\\Aleksandr\\Desktop\\Report\\Договор(Эл.энергия)" + order.Id.ToString() + ".doc";
                doc.SaveAs2(saveAsFile, missing, missing, missing);
            }

            //Закрытие документа
            doc.Close(false, missing, missing);
            app.Quit(false, false, false);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

            return true;
        }
        
        public static bool CreateOrderForHuman(SupplyDbContext _db,int humanId)
        {
            var human = _db.Humen.Where(x => x.Id == humanId).FirstOrDefault();
            var order = _db.Orders.Where(x => x.HumanId==human.Id).Where(x => x.Status == 1).First();

            object missing = Type.Missing;

            if (order != null)
            {
                
                //Создание объекта Word
                Word.Application app = new Word.Application();

                //Загрузка WORD шаблона
                Word.Document doc = null;

                object fileName = "Y:\\U2035\\Supply\\Supply Admin\\Files\\OrderStudent.docx";


                try
                {
                    doc = app.Documents.Open(fileName, missing, missing);
                    app.Selection.Find.ClearFormatting();
                    app.Selection.Find.Replacement.ClearFormatting();
                }
                catch
                {
                    MessageBox.Show("Проблемы работы с Word документом");
                }


                var room = _db.Rooms.Where(x => x.Id == human.RoomId).FirstOrDefault();
                var flat = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
                var enterance = _db.Enterances.Where(x => x.Id == flat.EnteranceId).FirstOrDefault();
                var hostel = _db.Hostels.Where(x => x.Id == enterance.HostelsId).FirstOrDefault();
                var supply = _db.Supplies.Where(x => x.HostelsId == hostel.Id).FirstOrDefault();
                var rent = _db.Rents.Where(x => x.Id == order.RentId).FirstOrDefault();
                var garages = _db.Garages.Where(x => x.RoomsId == room.Id).ToList();
                var rate = _db.Rates.Where(x => x.Id == order.Id).FirstOrDefault();

                try
                {
                    app.Selection.Find.Execute("<ID>", missing, missing, missing, missing, missing, missing, missing, missing, order.Id, 2);
                    app.Selection.Find.Execute("<startOrder>", missing, missing, missing, missing, missing, missing, missing, missing, order.StartOrder, 2);
                    app.Selection.Find.Execute("<EndOrder>", missing, missing, missing, missing, missing, missing, missing, missing, order.EndOrder, 2);

                    DateTime orderEndDate = Convert.ToDateTime(order.EndOrder);
                    DateTime orderStartDate = Convert.ToDateTime(order.StartOrder);

                    app.Selection.Find.Execute("<yearEndDate>", missing, missing, missing, missing, missing, missing, missing, missing, orderEndDate.Year.ToString(), 2);

                    app.Selection.Find.Execute("<rent>", missing, missing, missing, missing, missing, missing, missing, missing, rent.Name, 2);

                    app.Selection.Find.Execute("<surename>", missing, missing, missing, missing, missing, missing, missing, missing, human.Surename, 2);
                    app.Selection.Find.Execute("<name>", missing, missing, missing, missing, missing, missing, missing, missing, human.Name, 2);
                    app.Selection.Find.Execute("<patronymic>", missing, missing, missing, missing, missing, missing, missing, missing, human.Patronymic, 2);
                    app.Selection.Find.Execute("<DocSeries>", missing, missing, missing, missing, missing, missing, missing, missing, human.Series, 2);
                    app.Selection.Find.Execute("<DocNumber>", missing, missing, missing, missing, missing, missing, missing, missing, human.Number, 2);
                    app.Selection.Find.Execute("<DocGiven>", missing, missing, missing, missing, missing, missing, missing, missing, human.Given, 2);
                    app.Selection.Find.Execute("<DocDate>", missing, missing, missing, missing, missing, missing, missing, missing, human.GivenDate, 2);
                    app.Selection.Find.Execute("<DocCode>", missing, missing, missing, missing, missing, missing, missing, missing, human.GivenCode, 2);
                    app.Selection.Find.Execute("<HumanAddress>", missing, missing, missing, missing, missing, missing, missing, missing, human.Registration, 2);
                    app.Selection.Find.Execute("<humanCitizenship>", missing, missing, missing, missing, missing, missing, missing, missing, human.Citizenship, 2);

                    if (order.Benifit == 1)
                    {
                        var benefit = _db.Benefits.Where(x => x.OrderId == order.Id).FirstOrDefault();

                        app.Selection.Find.Execute("<benefit>", missing, missing, missing, missing, missing, missing, missing, missing, "да", 2);
                        app.Selection.Find.Execute("<benefitCategory>", missing, missing, missing, missing, missing, missing, missing, missing, benefit.BenifitCat, 2);
                        app.Selection.Find.Execute("<benefitDecreeDate>", missing, missing, missing, missing, missing, missing, missing, missing, benefit.DecreeDate, 2);
                        app.Selection.Find.Execute("<benefitDecree>", missing, missing, missing, missing, missing, missing, missing, missing, benefit.Decree, 2);
                        app.Selection.Find.Execute("<benefitStartDate>", missing, missing, missing, missing, missing, missing, missing, missing, benefit.StartDate, 2);
                        app.Selection.Find.Execute("<benefitEndDate>", missing, missing, missing, missing, missing, missing, missing, missing, benefit.EndDate, 2);
                    }
                    else
                    {
                        app.Selection.Find.Execute("<benefit>", missing, missing, missing, missing, missing, missing, missing, missing, "нет", 2);
                        app.Selection.Find.Execute("<benefitCategory>", missing, missing, missing, missing, missing, missing, missing, missing, "-", 2);
                        app.Selection.Find.Execute("<benefitDecreeDate>", missing, missing, missing, missing, missing, missing, missing, missing, "-", 2);
                        app.Selection.Find.Execute("<benefitDecree>", missing, missing, missing, missing, missing, missing, missing, missing, "-", 2);
                        app.Selection.Find.Execute("<benefitStartDate>", missing, missing, missing, missing, missing, missing, missing, missing, "-", 2);
                        app.Selection.Find.Execute("<benefitEndDate>", missing, missing, missing, missing, missing, missing, missing, missing, "-", 2);
                    }

                    app.Selection.Find.Execute("<ns>", missing, missing, missing, missing, missing, missing, missing, missing, human.Name[0].ToString(), 2);
                    app.Selection.Find.Execute("<ps>", missing, missing, missing, missing, missing, missing, missing, missing, human.Patronymic[0].ToString(), 2);

                    app.Selection.Find.Execute("<roomName>", missing, missing, missing, missing, missing, missing, missing, missing, room.Name, 2);
                    app.Selection.Find.Execute("<roomType>", missing, missing, missing, missing, missing, missing, missing, missing, room.Type, 2);
                    app.Selection.Find.Execute("<hostelName>", missing, missing, missing, missing, missing, missing, missing, missing, hostel.Name, 2);
                    app.Selection.Find.Execute("<hostelAddress>", missing, missing, missing, missing, missing, missing, missing, missing, hostel.Address, 2);
                    app.Selection.Find.Execute("<hostelFlat>", missing, missing, missing, missing, missing, missing, missing, missing, flat.Name, 2);
                    app.Selection.Find.Execute("<hostelFlats>", missing, missing, missing, missing, missing, missing, missing, missing, hostel.FlatCount, 2);

                    string elements = "";

                    for (int i = 0; i < garages.Count(); i++)
                    {
                        if (i == garages.Count() - 1)
                        {
                            elements = garages[i].Name + "(№" + garages[i].Numeric + "), ";
                            app.Selection.Find.Execute("<Elements>", missing, missing, missing, missing, missing, missing, missing, missing, elements, 2);
                        }
                        else
                        {
                            elements = garages[i].Name + "(№" + garages[i].Numeric + "), <Elements>";
                            app.Selection.Find.Execute("<Elements>", missing, missing, missing, missing, missing, missing, missing, missing, elements, 2);
                        }
                    }

                    app.Selection.Find.Execute("<rate>", missing, missing, missing, missing, missing, missing, missing, missing, rate.Price, 2);
                    app.Selection.Find.Execute("<rateWord>", missing, missing, missing, missing, missing, missing, missing, missing, NumbersToString.Str((int)rate.Price), 2);
                    app.Selection.Find.Execute("<yearRate>", missing, missing, missing, missing, missing, missing, missing, missing, rate.Price * 12, 2);
                    app.Selection.Find.Execute("<rateWordYear>", missing, missing, missing, missing, missing, missing, missing, missing, NumbersToString.Str((int)rate.Price * 12), 2);

                    int iOrderStartDate = Convert.ToInt32(orderStartDate.Year);
                    int iOrderEndDate = Convert.ToInt32(orderEndDate.Year);

                    int allMonthOrder = (iOrderEndDate - iOrderStartDate) * 12;

                    app.Selection.Find.Execute("<allTimeRate>", missing, missing, missing, missing, missing, missing, missing, missing, (int)rate.Price * allMonthOrder, 2);
                    app.Selection.Find.Execute("<allTimeRateWord>", missing, missing, missing, missing, missing, missing, missing, missing, NumbersToString.Str((int)rate.Price * allMonthOrder), 2);

                    app.Selection.Find.Execute("<supplySurename>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Surename, 2);
                    app.Selection.Find.Execute("<supplyName>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name, 2);
                    app.Selection.Find.Execute("<supplyPatronymic>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic, 2);
                    app.Selection.Find.Execute("<supplyN>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name[0].ToString(), 2);
                    app.Selection.Find.Execute("<supplyP>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic[0].ToString(), 2);
                    app.Selection.Find.Execute("<supplyProxy>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Proxy, 2);
                    app.Selection.Find.Execute("<supplyProxyDate>", missing, missing, missing, missing, missing, missing, missing, missing, supply.ProxyDate, 2);
                }
                catch
                {
                    MessageBox.Show("Ошибка работы с шаблоном");



                    //Закрытие документа
                    doc.Close(false, missing, missing);
                    app.Quit(false, false, false);

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                    return false;
                }


                //Сохранение договоров
                object saveAsFile = (object)"C:\\Users\\Aleksandr\\Desktop\\Report\\Договор№" + order.Id.ToString() + ".doc";
                doc.SaveAs2(saveAsFile, missing, missing, missing);

                
                //Закрытие документа
                doc.Close(false, missing, missing);
                app.Quit(false, false, false);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                return true;

            }
            else
                return false;
        }
    }
}
