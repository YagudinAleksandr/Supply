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
                linkedLabels[i] = new LinkLabel() { Location = new Point(7, 31 * (i + 1)), Text = "Общежитие № " + hostels[i].Name, Name = "HostelID" + hostels[i].Id.ToString(), Tag = hostels[i].Id};
                linkedLabels[i].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
            }

            GB_Hostels.Controls.AddRange(linkedLabels);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel linkLabel = (LinkLabel)sender;
            int id = Convert.ToInt32(linkLabel.Tag);
            
            
            HostelInformation hostelInformation = new HostelInformation(_db,id);
            hostelInformation.Show();
            
            
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
            SupplyManagers supplyManagers = new SupplyManagers(_db);
            supplyManagers.Show();
        }

        private void LL_Categories_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RentMenegers rentMenegers = new RentMenegers(_db);
            rentMenegers.Show();
        }

        private void LL_Rates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RatesManager ratesManager = new RatesManager(_db);
            ratesManager.Show();
        }

        private void LL_Rooms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RoomsManager roomsManager = new RoomsManager(_db);
            roomsManager.Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LL_Objects_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GarageManager garageManager = new GarageManager(_db);
            garageManager.ShowDialog();
        }

        private void BTN_Orders_Click(object sender, EventArgs e)
        {
            OrdersManager ordersManager = new OrdersManager(_db);
            ordersManager.ShowDialog();
        }

        private void BTN_OrderEl_Click(object sender, EventArgs e)
        {
            AddtionalServices addtionalServices = new AddtionalServices(_db);
            addtionalServices.ShowDialog();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }
    }
}
