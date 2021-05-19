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
        private string TemplateName { get; set; }
        /// <summary>
        /// Директория выходного файла
        /// </summary>
        private string OutFileDirectory { get; set; }
        /// <summary>
        /// Название выходного файла
        /// </summary>
        private string OutFileName { get; set; }
        #endregion
        #region private fields
        private object _missing = Type.Missing;
        private Word.Application _app;
        private Word.Document _doc;
        #endregion
        public WordDocument(string templateName, string outFileDirectory, string outFileName)
        {
            //Создание объекта Word
            _app = new Word.Application();
            //Загрузка WORD шаблона
            _doc = null;
            TemplateName = templateName;
            OutFileDirectory = outFileDirectory;
            OutFileName = outFileName;
        }

        public bool OpenWordTemplate(out string ErrMessage)
        {
            ErrMessage = String.Empty;
            try
            {
                _doc = _app.Documents.Open((object)TemplateName, _missing, _missing);
                _app.Selection.Find.ClearFormatting();
                _app.Selection.Find.Replacement.ClearFormatting();
                return true;
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message;
                
                return false;
            }
        }
        public bool CloseWordTemplate(out string ErrMessage)
        {
            ErrMessage = String.Empty;
            try
            {
                _doc.Close(false, _missing, _missing);
                _app.Quit(false, false, false);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(_app);
                return true;
            }
            catch(Exception ex)
            {
                ErrMessage = ex.Message;
                return false;
            }
        }
        public bool MakeReplacementInWordTemplate(Dictionary<string,string> replaceKeyEndValue)
        {
            foreach(KeyValuePair<string,string> replace in replaceKeyEndValue)
            {
                try
                {
                    _app.Selection.Find.Execute($"<{replace.Key}>", _missing, _missing, _missing, _missing, _missing, _missing, _missing, _missing, replace.Value, 2);
                }
                catch
                {
                    return false;
                }
            }

            string saveDirectory = OutFileDirectory + OutFileName  + ".doc";
            //Сохранение договоров
            object saveAsFile = (object)saveDirectory;
            try
            {
                _doc.SaveAs2(saveAsFile, _missing, _missing, _missing);
            }
            catch
            {
                _doc.Close(false, _missing, _missing);
                _app.Quit(false, false, false);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(_app);
                return false;
            }

            return true;
        }
    }
}
