using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supply.Domain;

namespace Supply
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void CloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AppSettings_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void AddressesInformation_Click(object sender, EventArgs e)
        {
            AdminAddressesForm adminAddressesForm = new AdminAddressesForm();
            adminAddressesForm.ShowDialog();
        }

        private void менеджерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminManagersForm adminManagersForm = new AdminManagersForm();
            adminManagersForm.ShowDialog();
        }

        private void Hostels_Click(object sender, EventArgs e)
        {
            AdminHostelsForm adminHostelsForm = new AdminHostelsForm();
            adminHostelsForm.ShowDialog();
        }
    }
}
