using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminOrders : Form
    {
        public AdminOrders()
        {
            InitializeComponent();
        }

        private void AdminOrders_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(UpdateInfo);
            thread.Start();
        }

        private void UpdateInfo()
        {

        }
    }
}
