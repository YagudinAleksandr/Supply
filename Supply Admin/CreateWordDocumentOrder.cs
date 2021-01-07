using Supply_Admin.Domain;
using System;
using System.Data;
using System.Linq;
using Supply_Admin.Libraries;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

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

                object fileName = "Y:\\U2035\\Supply\\Supply Admin\\Files\\OrderStudent.docx";


                foreach (var order in orders)
                {
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



                    var human = _db.Humen.Where(x => x.Id == order.HumanId).FirstOrDefault();
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

                        //Закрытие ProgressBar
                        PB_Creation.Visible = false;

                        //Закрытие документа
                        doc.Close(false, missing, missing);
                        app.Quit(false, false, false);

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                        return;
                    }


                    //Сохранение договоров
                    object saveAsFile = (object)"C:\\Users\\Aleksandr\\Desktop\\Report\\Договор№" + order.Id.ToString() + ".doc";
                    doc.SaveAs2(saveAsFile, missing, missing, missing);

                    //Изменение знаечения ProgressBar
                    counter++;
                    PB_Creation.Value = counter;

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
