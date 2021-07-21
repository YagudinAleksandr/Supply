using Supply.Domain;
using Supply.Models;
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
        private User _user;
        public AppSettingsForm()
        {
            InitializeComponent();
            _user = null;
        }

        public AppSettingsForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void AppSettingsForm_Load(object sender, EventArgs e)
        {
            
            if(Properties.Settings.Default.connect!="")
            {
                TB_DatabaseConnectionString.Text = Properties.Settings.Default.connect;
            }
            else
            {
                TB_DatabaseConnectionString.Text = "";
            }
            TB_StudentOrder.Text = Properties.Settings.Default.template1;
            TB_StidentsOrder2.Text = Properties.Settings.Default.template2;
            TB_WorkerOrder.Text = Properties.Settings.Default.template3;
            TB_RentOrder.Text = Properties.Settings.Default.template4;
            TB_OutFileDir.Text = Properties.Settings.Default.outFileDir;
            TB_ChangeRoom.Text = Properties.Settings.Default.template6;
            TB_Benefit.Text = Properties.Settings.Default.template5;
            TB_ChangePassport.Text = Properties.Settings.Default.template7;
            TB_Services.Text = Properties.Settings.Default.template9;
            TB_PaymentOrder.Text = Properties.Settings.Default.template11;


            //User settings

            if (_user != null)
            {
                LB_User.Text = _user.Name;
                TB_LoginOld.Text = _user.Login;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("После сохранения приложение будет перезапущено!", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            Properties.Settings.Default.connect = TB_DatabaseConnectionString.Text;

            Properties.Settings.Default.template1 = TB_StudentOrder.Text;
            Properties.Settings.Default.template2 = TB_StidentsOrder2.Text;
            Properties.Settings.Default.template3 = TB_WorkerOrder.Text;
            Properties.Settings.Default.template4 = TB_RentOrder.Text;
            Properties.Settings.Default.template5 = TB_Benefit.Text;
            Properties.Settings.Default.template6 = TB_ChangeRoom.Text;
            Properties.Settings.Default.template7 = TB_ChangePassport.Text;

            Properties.Settings.Default.template9 = TB_Services.Text;

            Properties.Settings.Default.template11 = TB_PaymentOrder.Text;

            Properties.Settings.Default.outFileDir = TB_OutFileDir.Text;


            if (result==DialogResult.Yes)
            {
                Properties.Settings.Default.Save();

                try
                {
                    if (TB_LoginNew.Text != "")
                    {
                        _user.Login = TB_LoginNew.Text;
                    }
                    
                }
                catch (Exception ex)
                {

                }

                Application.Restart();
            }

            
            
        }

        private void BTN_Browse_Click(object sender, EventArgs e)
        {
            string buttonTag = (sender as Button).Tag.ToString();

            if (buttonTag != "outDir")
            {
                using (OpenFileDialog openFileDirectory = new OpenFileDialog())
                {
                    openFileDirectory.Filter = "Microsoft Word (*.docx)|*.docx";

                    if (openFileDirectory.ShowDialog() == DialogResult.OK)
                    {
                        switch(buttonTag)
                        {
                            case "t1":
                                TB_StudentOrder.Text = openFileDirectory.FileName;
                                break;
                            case "t2":
                                TB_StidentsOrder2.Text = openFileDirectory.FileName;
                                break;
                            case "t3":
                                TB_WorkerOrder.Text = openFileDirectory.FileName;
                                break;
                            case "t4":
                                TB_RentOrder.Text = openFileDirectory.FileName;
                                break;
                            case "t5":
                                TB_Benefit.Text = openFileDirectory.FileName;
                                break;
                            case "t6":
                                TB_ChangeRoom.Text = openFileDirectory.FileName;
                                break;
                            case "t7":
                                TB_ChangePassport.Text = openFileDirectory.FileName;
                                break;
                            case "t9":
                                TB_Services.Text = openFileDirectory.FileName;
                                break;
                            case "t11":
                                TB_PaymentOrder.Text = openFileDirectory.FileName;
                                break;
                        }

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
