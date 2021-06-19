using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Supply.Domain
{
    public class AppSettings
    {
        //Data Source = EASYNOTE\SQLEXPRESS;Initial Catalog = SupplyMain; Persist Security Info=True;User ID =; Password=c9vjCdm7
        private static XmlDocument userSettingsXmlFile;
        
        private static void CreateXmlSettingsFile()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            string directory = domain.BaseDirectory;

            try
            {
                XDocument xmlDoc = new XDocument();

                
                XElement template1 = new XElement("template1", "");
                XElement template2 = new XElement("template2", "");
                XElement template3 = new XElement("template3", "");
                XElement template4 = new XElement("template4", "");
                XElement template5 = new XElement("template5", "");

                XElement templates = new XElement("templates");
                templates.Add(template1);
                templates.Add(template2);
                templates.Add(template3);
                templates.Add(template4);
                templates.Add(template5);

                XElement connectionStringToDB = new XElement("connectionString", "");

                XElement settings = new XElement("settings");

                settings.Add(connectionStringToDB);
                settings.Add(templates);

                xmlDoc.Add(settings);
                xmlDoc.Save(directory + "UserSettingsFile.xml");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось создать файл настройк!" + ex.Message);
                Application.Exit();
            }
        }
        private static XmlElement GetXmlElement()
        {
            userSettingsXmlFile = new XmlDocument();
            try
            {
                AppDomain domain = AppDomain.CurrentDomain;
                string directory = domain.BaseDirectory;

                userSettingsXmlFile.Load(directory+ "UserSettingsFile.xml");

                XmlElement root = userSettingsXmlFile.DocumentElement;

                return root;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не удалось загрузить файл настроек!"+ex.Message);
                Application.Exit();
                return null;
            }
        }
        
        public static string GetTemplateSetting(string field)
        {
            if (field != string.Empty) 
            {
                string filedir = "";
                switch(field)
                {
                    case "template1":
                        filedir = Properties.Settings.Default.template1;
                        break;
                    case "template2":
                        filedir = Properties.Settings.Default.template2;
                        break;
                    case "template3":
                        filedir = Properties.Settings.Default.template3;
                        break;
                    case "template4":
                        filedir = Properties.Settings.Default.template4;
                        break;
                    case "template5":
                        filedir = Properties.Settings.Default.template5;
                        break;
                    case "template6":
                        filedir = Properties.Settings.Default.template6;
                        break;
                    case "template7":
                        filedir = Properties.Settings.Default.template7;
                        break;
                    case "template8":
                        filedir = Properties.Settings.Default.template8;
                        break;
                    case "template9":
                        filedir = Properties.Settings.Default.template9;
                        break;
                    case "template10":
                        filedir = Properties.Settings.Default.template10;
                        break;
                    case "template11":
                        filedir = Properties.Settings.Default.template11;
                        break;
                    case "outfileDir":
                        filedir = Properties.Settings.Default.outFileDir;
                        break;
                    default:
                        return string.Empty;

                }
                return filedir;
            }
            else
            {
                return string.Empty;
            }
            
        }
        
    }

}
