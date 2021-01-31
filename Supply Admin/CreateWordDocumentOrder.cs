using Supply_Admin.Domain;
using System;
using System.Data;
using System.Linq;
using Supply_Admin.Libraries;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using QRCoder;
using System.Drawing;

namespace Supply_Admin
{
    public partial class CreateWordDocumentOrder : Form
    {
        
        private static SupplyDbContext _db;
        public CreateWordDocumentOrder(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
            PB_Creation.Visible = false;


            var hostels = _db.Hostels.ToList();
            CB_Hostels.DataSource = hostels;
            CB_Hostels.DisplayMember = "Name";
            CB_Hostels.ValueMember = "Id";
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            int hostelId = (int)CB_Hostels.SelectedValue;
            var orders = _db.Orders.Where(x => x.StartOrder == TB_OrderStart.Text).Where(x => x.HostelsId == hostelId).Where(x => x.Status == 1).ToList();
            
            object missing = Type.Missing;

            if (orders.Count() != 0)
            {
                //Открытие Progress Bar и инициализация начальных значений
                PB_Creation.Visible = true;
                PB_Creation.Minimum = 0;
                PB_Creation.Maximum = orders.Count();
                PB_Creation.Step = 1;

                //Счетчик для ProgressBar
                int counter = 0;

                //Создание объекта Word
                Word.Application app = new Word.Application();

                //Загрузка WORD шаблона
                Word.Document doc = null;


                QRCodeGenerator Qr = new QRCodeGenerator();
                var QrCodeData = Qr.CreateQrCode("http://ngma.su", QRCodeGenerator.ECCLevel.M, true, true);
                var QRData = new QRCode(QrCodeData);
                Image image = QRData.GetGraphic(150);
                Clipboard.SetImage(image);



                foreach (var order in orders)
                {
                    var rent = _db.Rents.Where(x => x.Id == order.RentId).FirstOrDefault();

                    //Директория хранения шаблона
                    string templateDirectory = "";
                    if (rent.Name == "обучения (очное)")
                        templateDirectory = Properties.Settings.Default.TemplateDir + "\\OrderStudent.docx";
                    else if(rent.Name == "обучение")
                        templateDirectory = Properties.Settings.Default.TemplateDir + "\\OrderStudent2.docx";
                    else if(rent.Name == "промежуточной аттестации")
                        templateDirectory = Properties.Settings.Default.TemplateDir + "\\OrderStudent2.docx";
                    else if (rent.Name == "итоговой аттестации")
                        templateDirectory = Properties.Settings.Default.TemplateDir + "\\OrderStudent2.docx";
                    else if(rent.Name == "иной")
                        templateDirectory = Properties.Settings.Default.TemplateDir + "\\OrderRent.docx";
                    else if(rent.Name == "работы")
                        templateDirectory = Properties.Settings.Default.TemplateDir + "\\OrderWorker.docx";
                    try
                    {
                        doc = app.Documents.Open((object)templateDirectory, missing, missing);
                        app.Selection.Find.ClearFormatting();
                        app.Selection.Find.Replacement.ClearFormatting();
                    }
                    catch
                    {
                        MessageBox.Show("Проблемы работы с Word документом");
                    }

                    
                    try
                    {
                        var human = _db.Humen.Where(x => x.Id == order.HumanId).FirstOrDefault();
                        var room = _db.Rooms.Where(x => x.Id == human.RoomId).FirstOrDefault();
                        var flat = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
                        var enterance = _db.Enterances.Where(x => x.Id == flat.EnteranceId).FirstOrDefault();
                        var hostel = _db.Hostels.Where(x => x.Id == enterance.HostelsId).FirstOrDefault();
                        var supply = _db.Supplies.Where(x => x.HostelsId == hostel.Id).FirstOrDefault();
                        var garages = _db.Garages.Where(x => x.RoomsId == room.Id).ToList();
                        var rate = _db.Rates.Where(x => x.Id == order.RateId).FirstOrDefault();


                        if(rent.Name == "обучения (очное)")
                        {
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

                                int totalMonth = Math.Abs((orderEndDate.Month - orderStartDate.Month) + 12 * (orderEndDate.Year - orderStartDate.Year));
                                

                                app.Selection.Find.Execute("<allTimeRate>", missing, missing, missing, missing, missing, missing, missing, missing, (int)rate.Price * totalMonth, 2);
                                app.Selection.Find.Execute("<allTimeRateWord>", missing, missing, missing, missing, missing, missing, missing, missing, NumbersToString.Str((int)rate.Price * totalMonth), 2);

                                app.Selection.Find.Execute("<supplySurename>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Surename, 2);
                                app.Selection.Find.Execute("<supplyName>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name, 2);
                                app.Selection.Find.Execute("<supplyPatronymic>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic, 2);
                                app.Selection.Find.Execute("<supplyN>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name[0].ToString(), 2);
                                app.Selection.Find.Execute("<supplyP>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic[0].ToString(), 2);
                                app.Selection.Find.Execute("<supplyProxy>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Proxy, 2);
                                app.Selection.Find.Execute("<supplyProxyDate>", missing, missing, missing, missing, missing, missing, missing, missing, supply.ProxyDate, 2);


                                
                                app.ActiveDocument.Bookmarks["QRCodeMark"].Range.Paste();
                            }
                            catch
                            {
                                MessageBox.Show("Ошибка работы с шаблоном");

                                //Закрытие ProgressBar
                                PB_Creation.Visible = false;

                                //Закрытие документа
                                doc.Close(false, missing, missing);
                                app.Quit(false, false, false);

                                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                                return;
                            }
                        }
                        if (rent.Name == "обучение" | rent.Name == "промежуточной аттестации" | rent.Name == "итоговой аттестации")
                        {
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

                                app.Selection.Find.Execute("<eduType>", missing, missing, missing, missing, missing, missing, missing, missing, order.EducationType, 2);

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



                                int days = (int)(orderEndDate - orderStartDate).TotalDays;

                                double rents = days * rate.Price;

                                app.Selection.Find.Execute("<allTimeRate>", missing, missing, missing, missing, missing, missing, missing, missing, rents, 2);
                                app.Selection.Find.Execute("<allTimeRateWord>", missing, missing, missing, missing, missing, missing, missing, missing, NumbersToString.Str((int)rents), 2);
                                app.Selection.Find.Execute("<rate>", missing, missing, missing, missing, missing, missing, missing, missing, rate.Price, 2);
                                app.Selection.Find.Execute("<rateWord>", missing, missing, missing, missing, missing, missing, missing, missing, NumbersToString.Str((int)rate.Price), 2);


                                app.Selection.Find.Execute("<supplySurename>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Surename, 2);
                                app.Selection.Find.Execute("<supplyName>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name, 2);
                                app.Selection.Find.Execute("<supplyPatronymic>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic, 2);
                                app.Selection.Find.Execute("<supplyN>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name[0].ToString(), 2);
                                app.Selection.Find.Execute("<supplyP>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic[0].ToString(), 2);
                                app.Selection.Find.Execute("<supplyProxy>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Proxy, 2);
                                app.Selection.Find.Execute("<supplyProxyDate>", missing, missing, missing, missing, missing, missing, missing, missing, supply.ProxyDate, 2);


                                
                                app.ActiveDocument.Bookmarks["QRCodeMark"].Range.Paste();
                            }
                            catch
                            {
                                MessageBox.Show("Ошибка работы с шаблоном");

                                //Закрытие ProgressBar
                                PB_Creation.Visible = false;

                                //Закрытие документа
                                doc.Close(false, missing, missing);
                                app.Quit(false, false, false);

                                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                                return;
                            }
                        }
                        if(rent.Name == "иной")
                        {
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
                                

                                int totalMonth = Math.Abs((orderEndDate.Month - orderStartDate.Month) + 12 * (orderEndDate.Year - orderStartDate.Year));


                                app.Selection.Find.Execute("<allTimeRate>", missing, missing, missing, missing, missing, missing, missing, missing, (int)rate.Price * totalMonth, 2);
                                app.Selection.Find.Execute("<allTimeRateWord>", missing, missing, missing, missing, missing, missing, missing, missing, NumbersToString.Str((int)rate.Price * totalMonth), 2);

                                app.Selection.Find.Execute("<supplySurename>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Surename, 2);
                                app.Selection.Find.Execute("<supplyName>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name, 2);
                                app.Selection.Find.Execute("<supplyPatronymic>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic, 2);
                                app.Selection.Find.Execute("<supplyN>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name[0].ToString(), 2);
                                app.Selection.Find.Execute("<supplyP>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic[0].ToString(), 2);
                                app.Selection.Find.Execute("<supplyProxy>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Proxy, 2);
                                app.Selection.Find.Execute("<supplyProxyDate>", missing, missing, missing, missing, missing, missing, missing, missing, supply.ProxyDate, 2);


                                
                                app.ActiveDocument.Bookmarks["QRCodeMark"].Range.Paste();
                            }
                            catch
                            {
                                MessageBox.Show("Ошибка работы с шаблоном");

                                //Закрытие ProgressBar
                                PB_Creation.Visible = false;

                                //Закрытие документа
                                doc.Close(false, missing, missing);
                                app.Quit(false, false, false);

                                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                                return;
                            }
                        }    
                        if(rent.Name == "работы")
                        {
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


                                


                                app.Selection.Find.Execute("<allTimeRate>", missing, missing, missing, missing, missing, missing, missing, missing, (int)rate.Price * 12, 2);
                                app.Selection.Find.Execute("<allTimeRateWord>", missing, missing, missing, missing, missing, missing, missing, missing, NumbersToString.Str((int)rate.Price * 12), 2);

                                app.Selection.Find.Execute("<supplySurename>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Surename, 2);
                                app.Selection.Find.Execute("<supplyName>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name, 2);
                                app.Selection.Find.Execute("<supplyPatronymic>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic, 2);
                                app.Selection.Find.Execute("<supplyN>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Name[0].ToString(), 2);
                                app.Selection.Find.Execute("<supplyP>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Patronimic[0].ToString(), 2);
                                app.Selection.Find.Execute("<supplyProxy>", missing, missing, missing, missing, missing, missing, missing, missing, supply.Proxy, 2);
                                app.Selection.Find.Execute("<supplyProxyDate>", missing, missing, missing, missing, missing, missing, missing, missing, supply.ProxyDate, 2);


                                
                                app.ActiveDocument.Bookmarks["QRCodeMark"].Range.Paste();
                            }
                            catch
                            {
                                MessageBox.Show("Ошибка работы с шаблоном");

                                //Закрытие ProgressBar
                                PB_Creation.Visible = false;

                                //Закрытие документа
                                doc.Close(false, missing, missing);
                                app.Quit(false, false, false);

                                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                                return;
                            }
                        }

                        string saveDirectory = Properties.Settings.Default.Directory + "\\Договор№" + order.Id.ToString() + ".doc";
                        //Сохранение договоров
                        object saveAsFile = (object)saveDirectory;
                        doc.SaveAs2(saveAsFile, missing, missing, missing);

                        //Изменение знаечения ProgressBar
                        counter++;
                        PB_Creation.Value = counter;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Исключение:{ex.Message}");
                    }
                    
                }

                //Вывод данных о работе
                MessageBox.Show("Файлы созданы");

                //Закрытие ProgressBar
                PB_Creation.Visible = false;

                //Закрытие документа
                doc.Close(false, missing, missing);
                app.Quit(false, false, false);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);


            }
            else
                MessageBox.Show("В базе данных не найдено совпадений по введенным данным!");
        }

    }
}
