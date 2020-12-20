using Supply_Admin.Domain;
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
    public partial class GarageManager : Form
    {
        private SupplyDbContext _db;
        public GarageManager(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;
        }
    }
}
