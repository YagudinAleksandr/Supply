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
            /*
            //Обращение к БД
            IQueryable<Human> humens = _db.Humen;

            //Начало фильтра
            if(TB_Name.Text != "")
            {
                humens = humens.Where(x => x.Name == TB_Name.Text);
            }
            if(TB_Surename.Text != "")
                humens = humens.Where(x => x.Surename == TB_Surename.Text);
            if(TB_Patronymic.Text != "")
                humens = humens.Where(x => x.Patronymic == TB_Patronymic.Text);
            if(TB_StartOrder.Text != "  .  .")
            {
                humens = humens.Where(x => x.OrderStart == TB_StartOrder.Text);
            }

            //Объект "Missing"
            object missing = Type.Missing;

            if (humens.Count() != 0)
            {
                //Открытие Progress Bar и инициализация начальных значений
                PB_Creation.Visible = true;
                PB_Creation.Minimum = 0;
                PB_Creation.Maximum = humens.Count();
                PB_Creation.Step = 1;

                //Счетчик для ProgressBar
                int counter = 0;

                //Создание объекта Word
                Word.Application app = new Word.Application();

                //Загрузка WORD шаблона
                Word.Document doc = null;

                object fileName = "C:\\Users\\Aleksandr\\Desktop\\Template.docx";

                //Создание документов по шаблону
                foreach (var human in humens)
                {

                    doc = app.Documents.Open(fileName, missing, missing);
                    app.Selection.Find.ClearFormatting();
                    app.Selection.Find.Replacement.ClearFormatting();
                    
                    /*
                    //Поиск и замена полей в шаблоне на данные
                    try
                    {
                        app.Selection.Find.Execute("<ID>", missing, missing, missing, missing, missing, missing, missing, missing, human.Id, 2);
                        app.Selection.Find.Execute("<surename>", missing, missing, missing, missing, missing, missing, missing, missing, human.Surename, 2);
                        app.Selection.Find.Execute("<name>", missing, missing, missing, missing, missing, missing, missing, missing, human.Name, 2);
                        app.Selection.Find.Execute("<patronymic>", missing, missing, missing, missing, missing, missing, missing, missing, human.Patronymic, 2);
                        app.Selection.Find.Execute("<startorder>", missing, missing, missing, missing, missing, missing, missing, missing, human.OrderStart, 2);
                        app.Selection.Find.Execute("<endorder>", missing, missing, missing, missing, missing, missing, missing, missing, human.OrderEnd, 2);
                        app.Selection.Find.Execute("<room>", missing, missing, missing, missing, missing, missing, missing, missing, human.Room.Name, 2);
                        app.Selection.Find.Execute("<classroom>", missing, missing, missing, missing, missing, missing, missing, missing, human.Room.Type, 2);
                        app.Selection.Find.Execute("<hostelName>", missing, missing, missing, missing, missing, missing, missing, missing, human.Room.Hostel.Name, 2);

                    }
                    catch
                    {
                        MessageBox.Show("Нет полей для замены в шаблоне!");
                        return;
                    }
                    

                    //Сохранение договоров
                    object saveAsFile = (object)"C:\\Users\\Aleksandr\\Desktop\\Report\\Договор№" + human.Id.ToString() + ".doc";
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
            {
                MessageBox.Show("Не найдено совпадений в базе данных!");
            }*/
        }
    }
}
