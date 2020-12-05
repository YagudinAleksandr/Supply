﻿using Supply_Admin.Domain;
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
    public partial class MainMenu : Form
    {
        SupplyDbContext _db;
        public MainMenu(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            var hostels = _db.Hostels.ToList();
            LinkLabel[] linkedLabels = new LinkLabel[hostels.Count()];

            for (int i = 0; i < hostels.Count(); i++)
            {
                linkedLabels[i] = new LinkLabel() { Location = new Point(7, 31 * (i + 1)), Text = "Общежитие № " + hostels[i].Name, Name = "HostelID" + hostels[i].Id.ToString() };
            }

            GB_Hostels.Controls.AddRange(linkedLabels);
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LL_Hostels_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HostelsManagment hostelsManagment = new HostelsManagment();
            hostelsManagment.Show();
        }

        private void LL_SupplyManagers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
