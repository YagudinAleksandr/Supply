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
    public partial class HostelArchiveForm : Form
    {
        private int _hostelID;
        public HostelArchiveForm(int hostelID)
        {
            InitializeComponent();
            _hostelID = hostelID;
        }
    }
}
