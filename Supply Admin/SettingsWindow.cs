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
        private FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

        public SettingsWindow()
        {
            InitializeComponent();
            TB_SaveFolderDir.Text = Properties.Settings.Default.Directory;
            TB_TempDir.Text = Properties.Settings.Default.TemplateDir;
        }

        private void BTN_SaveChanges_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение будет перезапущено!");

            if(TB_ConnectionString.Text != "")
                Properties.Settings.Default.ConnectionString = TB_ConnectionString.Text;

            if (TB_SaveFolderDir.Text != "")
                Properties.Settings.Default.Directory = TB_SaveFolderDir.Text;

            if (TB_SaveFolderDir.Text != "")
                Properties.Settings.Default.TemplateDir = TB_TempDir.Text;

            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void BTN_OpenFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TB_SaveFolderDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void BTN_TemplateDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TB_TempDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
