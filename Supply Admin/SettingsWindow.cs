using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply_Admin
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void BTN_SaveChanges_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение будет перезапущено!");
            Properties.Settings.Default.ConnectionString = TB_ConnectionString.Text;
            Properties.Settings.Default.Save();
            Application.Restart();
        }
    }
}
