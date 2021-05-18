using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace Libraries.WordSystem
{
    /// <summary>
    /// Класс работы с шаблоном Word и его заполнением
    /// </summary>
    public class WordDocument
    {
        #region public properties
        /// <summary>
        /// Директория шаблона
        /// </summary>
        public string TemplateDirectory { get; set; }
        /// <summary>
        /// Название шаблона
        /// </summary>
        public string TemplateName { get; set; }
        /// <summary>
        /// Директория выходного файла
        /// </summary>
        public string OutFileDirectory { get; set; }
        /// <summary>
        /// Название выходного файла
        /// </summary>
        public string OutFileName { get; set; }
        /// <summary>
        /// Свойства по которым идет поиск в документе
        /// </summary>
        public Dictionary<string, string> Properties { get; set; } //Свойства по которым идет поиск документа
        #endregion
        #region private fields
        private object missing = Type.Missing;
        private Word.Application app;
        private Word.Document doc;
        #endregion
        public WordDocument()
        {
            //Создание коллекции элементов для поиска
            Properties = new Dictionary<string, string>();
            //Создание объекта Word
            app = new Word.Application();
            //Загрузка WORD шаблона
            doc = null;
        }

        public bool OpenWordTemplate(out string ErrMessage)
        {
            ErrMessage = String.Empty;
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message;
                return false;
            }
        }
        public bool CloseWordTemplate()
        {
            return true;
            
        }
        public bool MakeReplacementInWordTemplate()
        {
            return true;
        }
    }
}
