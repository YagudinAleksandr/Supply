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
    public partial class HostelInformation : Form
    {
        private SupplyDbContext _db;
        private int _hostelId;
        public HostelInformation(SupplyDbContext db, int hostelId)
        {
            InitializeComponent();
            _hostelId = hostelId;
            _db = db;
        }

        private void HostelInformation_Shown(object sender, EventArgs e)
        {
            var hostel = _db.Hostels.Where(x => x.Id == _hostelId).FirstOrDefault();
            TreeNode hostelNode = new TreeNode($"Общежитие № {hostel.Name}");

            var flats = _db.Flats.Where(x => x.HostelsId == hostel.Id).ToList();
            TreeNode[] flatsNode = new TreeNode[flats.Count()];

            for (int i = 0; i < flats.Count(); i++) 
            {
                flatsNode[i] = new TreeNode();
                flatsNode[i].Text = $"Этаж № {flats[i].Name}";
                flatsNode[i].Tag = flats[i].Id;
            }

            hostelNode.Nodes.AddRange(flatsNode);


            TV_Hostels.Nodes.Add(hostelNode);
        }
    }
}
