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

            TB_Directory.Text = AppSettings.GetTemplateSetting("template1");

            
        }
    }
}
