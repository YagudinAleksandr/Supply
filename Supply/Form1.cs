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
using Supply.Models;

namespace Supply
{
    public partial class Form1 : Form
    {
        private User _user;
        private Role _role;
        public Form1(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void CloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ChangeUser_Click(object sender, EventArgs e)
        {
            _user = null;
            this.Close();
        }

        private void AppSettings_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            LB_UserName.Text = _user.Name;

            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");
            ToolStripMenuItem settingItem = new ToolStripMenuItem("Настройки");



            using (SupplyDbContext db = new SupplyDbContext())
            {
                int roleId = _user.RoleID;
                _role = db.Roles.Where(x => x.ID == roleId).FirstOrDefault();
            }

            if (_role.Name == "ADMINISTRATOR")
            {
                ToolStripMenuItem addresses = new ToolStripMenuItem("Адреса");
                addresses.Click += AddressesInformation_Click;

                ToolStripMenuItem managers = new ToolStripMenuItem("Менеджеры");
                managers.Click += managersToolStripMenuItem_Click;

                ToolStripMenuItem hostels = new ToolStripMenuItem("Общежития");
                hostels.Click += Hostels_Click;

                ToolStripMenuItem roomType = new ToolStripMenuItem("Типы комнат");
                roomType.Click += RoomType_Click;

                ToolStripMenuItem users = new ToolStripMenuItem("Пользователи");
                users.Click += Users_Click;

                settingItem.DropDownItems.Add(addresses);
                settingItem.DropDownItems.Add(managers);
                settingItem.DropDownItems.Add(hostels);
                settingItem.DropDownItems.Add(roomType);
                settingItem.DropDownItems.Add(users);
            }

            ToolStripMenuItem settingsWindow = new ToolStripMenuItem("Настройки");
            settingItem.Click += AppSettings_Click;

            settingItem.DropDownItems.Add(settingsWindow);

            ToolStripMenuItem changeUser = new ToolStripMenuItem("Сменить пользователя");
            changeUser.Click += ChangeUser_Click;
            ToolStripMenuItem exitApp = new ToolStripMenuItem("Выход из приложения");
            exitApp.Click += CloseApp_Click;

            fileItem.DropDownItems.Add(changeUser);
            fileItem.DropDownItems.Add(exitApp);


            menuStrip1.Items.Add(fileItem);
            menuStrip1.Items.Add(settingItem);
        }

        private void AddressesInformation_Click(object sender, EventArgs e)
        {
            AdminAddressesForm adminAddressesForm = new AdminAddressesForm();
            adminAddressesForm.ShowDialog();
        }

        private void managersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminManagersForm adminManagersForm = new AdminManagersForm();
            adminManagersForm.ShowDialog();
        }

        private void Hostels_Click(object sender, EventArgs e)
        {
            AdminHostelsForm adminHostelsForm = new AdminHostelsForm();
            adminHostelsForm.ShowDialog();
        }

        private void Users_Click(object sender, EventArgs e)
        {
            AdminUsersForm adminUsersForm = new AdminUsersForm(_user.ID);
            adminUsersForm.Show();
        }

        private void RoomType_Click(object sender, EventArgs e)
        {
            AdminRoomTypes adminRoomTypes = new AdminRoomTypes();
            adminRoomTypes.Show();
        }
    }
}
