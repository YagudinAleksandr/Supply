﻿using Supply.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Supply
{
    public partial class UsersInformationForm : Form
    {
        private List<Information> _news;
        public UsersInformationForm(List<Information> news)
        {
            InitializeComponent();
            _news = news;
        }

        private void UsersInformationForm_Shown(object sender, EventArgs e)
        {
            foreach(Information inf in _news)
            {
                RTB_News.Text += inf.Title + " ("+inf.StartInformation+")"+"-("+inf.EndInformation+")\n";
                RTB_News.Text += inf.Topic + "\n";
                RTB_News.Text += "\n";
            }
        }
    }
}
