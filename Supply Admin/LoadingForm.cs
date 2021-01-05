using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supply_Admin.Domain;

namespace Supply_Admin
{
    public partial class LoadingForm : Form
    {
        private static SupplyDbContext _db;
        public LoadingForm()
        {
            InitializeComponent();
        }

        Timer tmr;
        private void LoadingForm_Shown(object sender, EventArgs e)
        {
            
            LB_Inform.Text = "Загрузка базы данных...";
            tmr = new Timer();
            tmr.Interval = 3000;
            tmr.Start();
            tmr.Tick += tmr_Tick;
            
        }

        void tmr_Tick(object sender, EventArgs e)

        {

            //after 3 sec stop the timer

            tmr.Stop();

            //display mainform

            try
            {

                
                _db = new SupplyDbContext();
                
                if (_db == null)
                {
                    this.Hide();
                    SettingsWindow settingsWindow = new SettingsWindow();
                    settingsWindow.ShowDialog();
                }
                
            }
            catch
            {
                this.Hide();
                SettingsWindow settingsWindow = new SettingsWindow();
                settingsWindow.ShowDialog();
            }
            LB_Inform.Text = "Создание среды работы";
            
            //hide this form

            
            MainMenu mm = new MainMenu(_db);
            mm.Show();
            this.Hide();
        }
    }
}
