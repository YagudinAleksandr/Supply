namespace Supply.Domain
{
    public class AppSettings
    {
        
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
