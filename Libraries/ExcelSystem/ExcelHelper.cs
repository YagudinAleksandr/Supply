﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Libraries.ExcelSystem
{
    public class ExcelHelper : IDisposable
    {
        private Application _excel;
        private Workbook _workbook;
        private string _filePath;

        public ExcelHelper()
        {
            _excel = new Excel.Application();
        }
        public void Dispose()
        {
            try
            {
                _workbook.Close();
                _excel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_excel);
            }
            catch
            {
                return;
            }
        }
        public void Close()
        {
            try
            {
                _workbook.Close();
                _excel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_excel);
            }
            catch
            {
                return;
            }
        }
        public bool Open(string filePath, string name, out string error)
        {
            try
            {

                if (File.Exists(filePath + name))
                {
                    _workbook = _excel.Workbooks.Open(filePath + name);
                }
                else
                {
                    _workbook = _excel.Workbooks.Add();
                    _filePath = filePath + name;
                }

                error = string.Empty;
                return true;
            }
            catch(Exception ex)
            {
                error = ex.Message + "." + ex.InnerException;
                return false;
            }
        }

        public bool Set(string columnName, int rowNumber, string value, out string error)
        {
            try
            {

                ((Excel.Worksheet)_excel.ActiveSheet).Cells[rowNumber, columnName] = value;

                error = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message + "." + ex.InnerException;
                return false;
            }
        }

        public bool Merge(object nameOfCelsFirst, object nameOfCelsLast,int rowStart, int celCount, string data, out string error)
        {
            error = string.Empty;

            try
            {
                Excel.Worksheet _worksheet = (Excel.Worksheet)_excel.ActiveSheet;

                Excel.Range _excelCel = (Excel.Range)_worksheet.get_Range(nameOfCelsFirst, nameOfCelsLast).Cells;

                _excelCel.Merge(Type.Missing);

                _worksheet.Cells[rowStart, celCount] = data;
                
                return true;
            }
            catch(Exception ex)
            {
                error = ex.Message + ". " + ex.InnerException;
                return false;
            }
            
        }
        public void Save()
        {
            if(!string.IsNullOrEmpty(_filePath))
            {
                _workbook.SaveAs(_filePath);
                _filePath = null;
            }
            else
            {
                _workbook.Save();
            }
        }
    }
}
