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
        

        public HostelInformation(SupplyDbContext db, int hostelId)
        {
            InitializeComponent();
            _hostelId = hostelId;
            _db = db;
        }
        private void CreateTree()
        {
            TV_Hostels.Nodes.Clear();
            var hostel = _db.Hostels.Where(x => x.Id == _hostelId).FirstOrDefault();
            TreeNode hostelNode = new TreeNode($"Общежитие № {hostel.Name}");

            var enterances = _db.Enterances.Where(x => x.HostelsId == hostel.Id).ToList();
            TreeNode[] enterancesNode = new TreeNode[enterances.Count()];

            for (int k = 0; k < enterances.Count(); k++)
            {
                enterancesNode[k] = new TreeNode();
                enterancesNode[k].Text = $"Подъезд № {enterances[k].Name}";
                int enteranceId = enterances[k].Id;

                var flats = _db.Flats.Where(x => x.EnteranceId == enteranceId).ToList();
                TreeNode[] flatsNode = new TreeNode[flats.Count()];

                for (int i = 0; i < flats.Count(); i++)
                {
                    flatsNode[i] = new TreeNode();
                    flatsNode[i].Text = $"Этаж № {flats[i].Name}";
                    flatsNode[i].Tag = flats[i].Id;
                    int f = flats[i].Id;

                    var rooms = _db.Rooms.Where(p => p.FlatId == f).ToList();
                    TreeNode[] roomsNode = new TreeNode[rooms.Count()];
                    for (int j = 0; j < rooms.Count(); j++)
                    {
                        roomsNode[j] = new TreeNode();
                        roomsNode[j].Text = rooms[j].Name.ToString();
                        roomsNode[j].Tag = rooms[j].Id;
                        menu = new ContextMenu() { MenuItems = { new MenuItem("Добавить жильца", AddHumanHandler) } };

                        roomsNode[j].ContextMenu = menu;

                        int roomId = rooms[j].Id;
                        var humens = _db.Humen.Where(x => x.RoomId == roomId).ToList();
                        TreeNode[] humensNode = new TreeNode[humens.Count()];

                        for (int m = 0; m < humens.Count(); m++)
                        {
                            humensNode[m] = new TreeNode();
                            humensNode[m].Text = humens[m].Surename + " " + humens[m].Name + " " + humens[m].Patronymic;
                            humensNode[m].Tag = humens[m].Id;
                            menu = new ContextMenu() { MenuItems = { new MenuItem("Хи-Хи") } };
                            humensNode[m].ContextMenu = menu;

                        }
                        roomsNode[j].Nodes.AddRange(humensNode);

                    }

                    flatsNode[i].Nodes.AddRange(roomsNode);

                }
                enterancesNode[k].Nodes.AddRange(flatsNode);

            }

            hostelNode.Nodes.AddRange(enterancesNode);


            TV_Hostels.Nodes.Add(hostelNode);
            TV_Hostels.ExpandAll();
        }
        private void HostelInformation_Shown(object sender, EventArgs e)
        {

            CreateTree();
        }
        private void TV_Hostels_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }
        private void AddHumanHandler(object sender, EventArgs e)
        {
            if (TV_Hostels.SelectedNode != null)
            {
                int room_id = Convert.ToInt32(TV_Hostels.SelectedNode.Tag.ToString());
                HumanCreate humanCreate = new HumanCreate(_db, room_id);
                humanCreate.ShowDialog();
                CreateTree();
            }
            
        }
    }
}
