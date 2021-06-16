using Supply.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            TB_DatabaseConnectionString.Text = Properties.Settings.Default.connect;
            
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("После сохранения приложение будет перезапущено!", "Предкпреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result==DialogResult.Yes)
            {
                Application.Restart();
            }
            
        }

        private void BTN_Browse_Click(object sender, EventArgs e)
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
    }
}
