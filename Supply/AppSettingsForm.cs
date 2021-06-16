using Supply.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class AppSettingsForm : Form
    {
        public AppSettingsForm()
        {
            InitializeComponent();
        }

        private void AppSettingsForm_Load(object sender, EventArgs e)
        {

            TB_StudentOrder.Text = AppSettings.GetTemplateSetting("template1");
            TB_WorkerOrder.Text = AppSettings.GetTemplateSetting("template2");
            if(Properties.Settings.Default.connect!="")
            {
                TB_DatabaseConnectionString.Text = Properties.Settings.Default.connect;
            }
            else
            {
                TB_DatabaseConnectionString.Text = "";
            }
            TB_OutFileDir.Text = Properties.Settings.Default.outFileDir;
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("После сохранения приложение будет перезапущено!", "Предкпреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            Properties.Settings.Default.connect = TB_DatabaseConnectionString.Text;
            Properties.Settings.Default.outFileDir = TB_OutFileDir.Text;
            if (result==DialogResult.Yes)
            {
                Properties.Settings.Default.Save();
                Application.Restart();
            }
            
        }

        private void BTN_Browse_Click(object sender, EventArgs e)
        {
            string buttonTag = (sender as Button).Tag.ToString();

            if (buttonTag != "outDir")
            {
                using (OpenFileDialog openDatabaseDirectory = new OpenFileDialog())
                {
                    openDatabaseDirectory.Filter = "Microsoft Word (*.docx)|*.docx";

                    if (openDatabaseDirectory.ShowDialog() == DialogResult.OK)
                    {
                        TB_StudentOrder.Text = openDatabaseDirectory.FileName;
                    }
                }
            }
            else
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        

                        TB_OutFileDir.Text = fbd.SelectedPath;
                    }
                }
            }
        }
    }
}
