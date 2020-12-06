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
        ContextMenu menu;
        TreeNode[] roomsNode;
        //TreeNode[] peopleNode;

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
                int f = flats[i].Id;
               
                var rooms = _db.Rooms.Where(p => p.FlatId == f).ToList();
                roomsNode = new TreeNode[rooms.Count()];
                for (int j = 0; j < rooms.Count(); j++)
                {
                    roomsNode[j] = new TreeNode();
                    roomsNode[j].Text = rooms[j].Name.ToString();
                    roomsNode[j].Tag = rooms[j].Id;
                    menu = new ContextMenu(){MenuItems = {new MenuItem("Добавить жильца", AddHumanHandler)}};

                    roomsNode[j].ContextMenu = menu;
                }

                flatsNode[i].Nodes.AddRange(roomsNode);
            }

            hostelNode.Nodes.AddRange(flatsNode);
            

            TV_Hostels.Nodes.Add(hostelNode);
        }
        private void TV_Hostels_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }
        private void AddHumanHandler(object sender, EventArgs e)
        {
            
            
            if (TV_Hostels.SelectedNode != null)
            {
                MessageBox.Show(TV_Hostels.SelectedNode.Tag.ToString());
            }
            
        }
    }
}
