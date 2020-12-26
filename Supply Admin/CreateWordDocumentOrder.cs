using Supply_Admin.Domain;
using Supply_Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            
            var orders = _db.Orders.Where(x => x.StartOrder == TB_OrderStart.Text).ToList();

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
                    doc = app.Documents.Open(fileName, missing, missing);
                    app.Selection.Find.ClearFormatting();
                    app.Selection.Find.Replacement.ClearFormatting();



                    var human = _db.Humen.Where(x => x.Id == order.HumanId).FirstOrDefault();
                    var room = _db.Rooms.Where(x => x.Id == human.RoomId).FirstOrDefault();
                    var flat = _db.Flats.Where(x => x.Id == room.FlatId).FirstOrDefault();
                    var enterance = _db.Enterances.Where(x => x.Id == flat.EnteranceId).FirstOrDefault();
                    var hostel = _db.Hostels.Where(x => x.Id == enterance.HostelsId).FirstOrDefault();

                    try
                    {
                        app.Selection.Find.Execute("<ID>", missing, missing, missing, missing, missing, missing, missing, missing, order.Id, 2);
                        app.Selection.Find.Execute("<startOrder>", missing, missing, missing, missing, missing, missing, missing, missing, order.StartOrder, 2);

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

                        app.Selection.Find.Execute("<roomName>", missing, missing, missing, missing, missing, missing, missing, missing, room.Name, 2);
                        app.Selection.Find.Execute("<roomType>", missing, missing, missing, missing, missing, missing, missing, missing, room.Type, 2);
                        app.Selection.Find.Execute("<hostelName>", missing, missing, missing, missing, missing, missing, missing, missing, hostel.Name, 2);
                        app.Selection.Find.Execute("<hostelAddress>", missing, missing, missing, missing, missing, missing, missing, missing, hostel.Address, 2);
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
        }
    }
}
