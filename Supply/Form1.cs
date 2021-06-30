using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Libraries.ExcelSystem;
using Supply.Domain;
using Supply.Libs;
using Supply.Models;

namespace Supply
{
    public partial class Form1 : Form
    {
        private User _user;
        private Role _role;
        private int _hostelID;
        public Form1(User user)
        {
            InitializeComponent();
            _user = user;
            _hostelID = 0;
        }

        #region MainWindowMainFunctions
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
            AdminHostelsForm adminHostelsForm = new AdminHostelsForm(_user.ID);
            adminHostelsForm.ShowDialog();
            Thread thread = new Thread(UpdateComboboxItems);
            thread.Start();
        }
        private void Tenants_Click(object sender, EventArgs e)
        {
            AdminTenantsForm adminTenantsForm = new AdminTenantsForm();
            this.Hide();
            adminTenantsForm.ShowDialog();
            this.Show();
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
        private void Payments_Click(object sender, EventArgs e)
        {
            AdminPaymentsForm adminPaymentsForm = new AdminPaymentsForm(_user.ID);
            adminPaymentsForm.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
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
            AppSettingsForm appSettingsForm = new AppSettingsForm();
            appSettingsForm.ShowDialog();
        }
        private void MainOrders_Click(object sender,EventArgs e)
        {
            AdminOrders adminOrders = new AdminOrders();
            adminOrders.Show();
        }
        private void BenefitsOrders_Click(object sender, EventArgs e)
        {
            DeclarationsBenefits declarationsBenefits = new DeclarationsBenefits();
            declarationsBenefits.Show();
        }

        private void ChangeRoomOrder_Click(object sender,EventArgs e)
        {
            DeclarationChangeRoom declarationChangeRoom = new DeclarationChangeRoom();
            declarationChangeRoom.Show();
        }

        private void ChangePassportOrder_Click(object sender, EventArgs e)
        {
            DeclarationChangePassport declarationChangePassport = new DeclarationChangePassport();
            declarationChangePassport.Show();
        }
        

        private void DeclarationHostelsOrders(object sender, EventArgs e)
        {
            DeclarationHostels declarationHostels = new DeclarationHostels();
            declarationHostels.Show();
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            DeclarationAccount declarationAccount = new DeclarationAccount();
            declarationAccount.Show();
        }
        private void PaymentElectr_Click(object sender, EventArgs e)
        {
            AdminPaymentsElectricity adminPaymentsElectricity = new AdminPaymentsElectricity();
            adminPaymentsElectricity.Show();
        }
        private void DeclarationElectricityOrders_Click(object sender, EventArgs e)
        {
            DeclarationElectricityPaymentOrders declarationElectricityPaymentOrders = new DeclarationElectricityPaymentOrders();
            declarationElectricityPaymentOrders.Show();
        }
        private void CreateAccountElectr_Click(object sender, EventArgs e)
        {
            DeclarationAccountElectricity declarationAccountElectricity = new DeclarationAccountElectricity();
            declarationAccountElectricity.Show();
        }
        private void CreateTenantsInHostel_Click(object sender, EventArgs e)
        {
            DeclarationTenantsInHostels declarationTenantsInHostels = new DeclarationTenantsInHostels();
            declarationTenantsInHostels.Show();
        }

        private void CreateDeclarationForeignCitizenship_Click(object sender, EventArgs e)
        {
            DeclarationTenantsInHostels declarationTenantsInHostels = new DeclarationTenantsInHostels(true);
            declarationTenantsInHostels.Show();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            LB_UserName.Text = _user.Name;
            TV_HostelInformation.Nodes.Clear();

            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");
            ToolStripMenuItem settingItem = new ToolStripMenuItem("Настройки");
            ToolStripMenuItem declaration = new ToolStripMenuItem("Отчеты");


            using (SupplyDbContext db = new SupplyDbContext())
            {
                int roleId = _user.RoleID;
                _role = db.Roles.Where(x => x.ID == roleId).FirstOrDefault();
            }

            if (_role.Name == "ADMINISTRATOR")
            {
                ToolStripMenuItem addresses = new ToolStripMenuItem("Адреса");
                addresses.Click += AddressesInformation_Click;

                ToolStripMenuItem hostels = new ToolStripMenuItem("Общежития");
                hostels.Click += Hostels_Click;

                ToolStripMenuItem tenant = new ToolStripMenuItem("Жильцы");
                tenant.Click += Tenants_Click;

                ToolStripMenuItem roomType = new ToolStripMenuItem("Типы комнат");
                roomType.Click += RoomType_Click;

                ToolStripMenuItem users = new ToolStripMenuItem("Пользователи");
                users.Click += Users_Click;

                settingItem.DropDownItems.Add(addresses);

                settingItem.DropDownItems.Add(hostels);
                settingItem.DropDownItems.Add(roomType);
                settingItem.DropDownItems.Add(tenant);
                settingItem.DropDownItems.Add(users);
            }

            if (_role.Name == "ADMINISTRATOR" || _role.Name == "MANAGER")
            {
                

                ToolStripMenuItem managers = new ToolStripMenuItem("Менеджеры");
                managers.Click += managersToolStripMenuItem_Click;
                settingItem.DropDownItems.Add(managers);

                ToolStripMenuItem payments = new ToolStripMenuItem("Тарифные планы");
                payments.Click += Payments_Click;
                settingItem.DropDownItems.Add(payments);

                ToolStripMenuItem paymentsElectrycity = new ToolStripMenuItem("Тарифные планы эл.энергия");
                paymentsElectrycity.Click += PaymentElectr_Click;
                settingItem.DropDownItems.Add(paymentsElectrycity);

                ToolStripMenuItem payOrder = new ToolStripMenuItem("Оплаты");
                payOrder.Click += CreateAccount_Click;
                declaration.DropDownItems.Add(payOrder);

                ToolStripMenuItem payOrderElectricity = new ToolStripMenuItem("Оплаты за эл.энергию");
                payOrderElectricity.Click += CreateAccountElectr_Click;
                declaration.DropDownItems.Add(payOrderElectricity);

                ToolStripMenuItem mainOrder = new ToolStripMenuItem("Договора");
                mainOrder.Click += MainOrders_Click;
                declaration.DropDownItems.Add(mainOrder);

                ToolStripMenuItem benefitsOrders = new ToolStripMenuItem("Отчеты по льготам");
                benefitsOrders.Click += BenefitsOrders_Click;
                declaration.DropDownItems.Add(benefitsOrders);

                ToolStripMenuItem changeroomOrders = new ToolStripMenuItem("Отчеты по переселению жильцов");
                changeroomOrders.Click += ChangeRoomOrder_Click;
                declaration.DropDownItems.Add(changeroomOrders);

                ToolStripMenuItem changePassportOrders = new ToolStripMenuItem("Отчеты по смене паспартов");
                changePassportOrders.Click += ChangePassportOrder_Click;
                declaration.DropDownItems.Add(changePassportOrders);

                ToolStripMenuItem declarationHostels = new ToolStripMenuItem("Отчет по общежитиям");
                declarationHostels.Click += DeclarationHostelsOrders;
                declaration.DropDownItems.Add(declarationHostels);

                ToolStripMenuItem declarationHostelsTenants = new ToolStripMenuItem("Отчет по проживающим");
                declarationHostelsTenants.Click += CreateTenantsInHostel_Click;
                declaration.DropDownItems.Add(declarationHostelsTenants);

                ToolStripMenuItem declarationForeignCitizenship = new ToolStripMenuItem("Отчет по иностранным студентам");
                declarationForeignCitizenship.Click += CreateDeclarationForeignCitizenship_Click;
                declaration.DropDownItems.Add(declarationForeignCitizenship);

                ToolStripMenuItem declarationElectricityPayment = new ToolStripMenuItem("Отчеты по договорам об оплате за эл.энергию");
                declarationElectricityPayment.Click += DeclarationElectricityOrders_Click;
                declaration.DropDownItems.Add(declarationElectricityPayment);
            }

            ToolStripMenuItem settingsWindow = new ToolStripMenuItem("Настройки");
            settingsWindow.Click += AppSettings_Click;

            settingItem.DropDownItems.Add(settingsWindow);

            ToolStripMenuItem changeUser = new ToolStripMenuItem("Сменить пользователя");
            changeUser.Click += ChangeUser_Click;
            ToolStripMenuItem exitApp = new ToolStripMenuItem("Выход из приложения");
            exitApp.Click += CloseApp_Click;

            fileItem.DropDownItems.Add(changeUser);
            fileItem.DropDownItems.Add(exitApp);


            menuStrip1.Items.Add(fileItem);
            menuStrip1.Items.Add(settingItem);
            menuStrip1.Items.Add(declaration);

            Thread comboBoxthread = new Thread(UpdateComboboxItems);
            comboBoxthread.Start();

            LB_AsyncProcesses.Text = "Начаты фоновые процессы";
            Thread thread = new Thread(AsyncProcessing);
            thread.Start();
            
        }

        private void AsyncProcessing()
        {
            Action action = () =>
            {
                AsyncProcesses.UpdateChangeRoom();
                LB_AsyncProcesses.Text = "Все готово!";
            };
            Invoke(action);
        }
        #endregion
        #region FunctionsForNodeTree
        private void UpdateComboboxItems()
        {
            Action action = () => 
            {
                TV_HostelInformation.Nodes.Clear();
                LB_Hostels.DataSource = null;

                using (SupplyDbContext db = new SupplyDbContext())
                {
                    var hostels = db.Hostels.ToList();
                    for (int i = 0; i < hostels.Count; i++)
                    {
                        hostels[i].Name = $"Общежитие {hostels[i].Name}";
                    }
                    LB_Hostels.DataSource = hostels;
                    LB_Hostels.ValueMember = "ID";
                    LB_Hostels.DisplayMember = "Name";
                }
            };
            Invoke(action);
        }

        private void LB_Hostels_SelectedIndexChanged(object sender, EventArgs e)
        {
            TV_HostelInformation.Nodes.Clear();
            try
            {
                
                if (LB_Hostels.SelectedValue != null)
                {
                    int.TryParse(LB_Hostels.SelectedValue.ToString(), out _hostelID);
                    if (_hostelID != 0)
                    {
                        Thread createNodesThread = new Thread(new ParameterizedThreadStart(CreateTreeOnTreeView));
                        createNodesThread.Start(_hostelID);
                        
                    }
                }
                
                
            }
            catch
            {
                return;
            }
        }

        private void CreateTreeOnTreeView(object hostelIndex)
        {
            Action action = () =>
            {
                TV_HostelInformation.Nodes.Clear();

                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Hostel hostel = db.Hostels.Where(id => id.ID == (int)hostelIndex).First();

                    ContextMenu contextMenuForNode;//Variable for context menu

                    if (hostel == null)
                    {
                        MessageBox.Show("Не существует общежития!");
                        Log log = new Log() { ID = Guid.NewGuid(), Caption = $"Ошибка выборки из общежитий, объект с индексом {hostelIndex} не существует", Type = "Ошибка выборки", CreatedAt = DateTime.Now.ToString(), UserID = _user.ID };
                        db.Logs.Add(log);
                        db.SaveChanges();
                        return;
                    }

                    TreeNode hostelNode = new TreeNode($"Общежитие {hostel.Name}");

                    var enterances = db.Enterances.Where(id => id.HostelId == hostel.ID).ToList();
                    TreeNode[] enteranceNodes = new TreeNode[enterances.Count];

                    for (int i = 0; i < enterances.Count; i++)
                    {
                        enteranceNodes[i] = new TreeNode();
                        enteranceNodes[i].Text = $"Подъезд №{enterances[i].Name}";
                        int enteranceIndex = enterances[i].ID;

                        var flats = db.Flats.Where(id => id.Enterance_ID == enteranceIndex).ToList();
                        TreeNode[] flatNodes = new TreeNode[flats.Count];

                        for (int j = 0; j < flats.Count; j++)
                        {
                            flatNodes[j] = new TreeNode();
                            flatNodes[j].Text = $"Этаж №{flats[j].Name}";

                            int flatIndex = flats[j].ID;

                            var rooms = db.Rooms.Where(id => id.FlatID == flatIndex).OrderBy(x => x.Name).ToList();
                            TreeNode[] roomNodes = new TreeNode[rooms.Count];



                            for (int k = 0; k < rooms.Count; k++)
                            {
                                int roomId = rooms[k].ID;
                                var tenants = db.Tenants.Where(x => x.RoomID == roomId)
                                    .Where(y => y.Status == true)
                                    .Include(p => p.Identification)
                                    .Include(ai => ai.AdditionalInformation)
                                    .ToList();

                                roomNodes[k] = new TreeNode();
                                roomNodes[k].Text = $"Комната № {rooms[k].Name} (Количество мест-{rooms[k].Places} / Использовано-{tenants.Count})";
                                roomNodes[k].Tag = roomId;

                                TreeNode[] tenantNodes = new TreeNode[tenants.Count];

                                for (int l = 0; l < tenants.Count; l++)
                                {
                                    tenantNodes[l] = new TreeNode();
                                    tenantNodes[l].Text = tenants[l].Identification.Surename + " " + tenants[l].Identification.Name;
                                    tenantNodes[l].Tag = tenants[l].ID;
                                    CreateConetxtMenuForNode("tenant", out contextMenuForNode);
                                    tenantNodes[l].ContextMenu = contextMenuForNode;

                                    var adinften = tenants[l].AdditionalInformation.Where(x => x.AdditionalInformationTypeID == 9).ToList();
                                    TreeNode[] additionalInfNode = new TreeNode[adinften.Count()];
                                    for (int a = 0; a < adinften.Count; a++)
                                    {
                                        additionalInfNode[a] = new TreeNode();
                                        additionalInfNode[a].Text = $"{adinften[a].Value}";
                                    }

                                    tenantNodes[l].Nodes.AddRange(additionalInfNode);

                                }

                                roomNodes[k].Nodes.AddRange(tenantNodes);

                                if (tenants.Count != rooms[k].Places || tenants.Count < rooms[k].Places)
                                {
                                    CreateConetxtMenuForNode("room", out contextMenuForNode);
                                    roomNodes[k].ContextMenu = contextMenuForNode;
                                }

                            }
                            flatNodes[j].Nodes.AddRange(roomNodes);
                        }
                        enteranceNodes[i].Nodes.AddRange(flatNodes);
                    }

                    hostelNode.Nodes.AddRange(enteranceNodes);

                    TV_HostelInformation.Nodes.Add(hostelNode);
                    TV_HostelInformation.ExpandAll();
                }
            };

            Invoke(action);
            
        }

        private void CreateConetxtMenuForNode(string menuType, out ContextMenu contextMenu)
        {
            contextMenu = new ContextMenu();

            switch(menuType)
            {
                case "room":
                    contextMenu.MenuItems.Add("Добавить жильца",AddHumanHandler);
                    break;
                case "tenant":
                    contextMenu.MenuItems.Add("Изменить", UpdateTenantInformation);
                    contextMenu.MenuItems.Add("Внести оплату", AddAccounting);
                    contextMenu.MenuItems.Add("Внести оплату за эл.энергию", AddAccountingForElectricity);
                    contextMenu.MenuItems.Add("Сформировать договор", AddHumanMainOrder);
                    contextMenu.MenuItems.Add("Сформировать платежное поручение", AddTenantAccountingForElectricity);
                    contextMenu.MenuItems.Add("Переселить жильца", ChangeRoomOrder);
                    contextMenu.MenuItems.Add("Смена паспорта", AddChangePassportHandler);
                    contextMenu.MenuItems.Add("Создать льготу", AddBenefitHandler);
                    contextMenu.MenuItems.Add("Расторжение договора", DestroyOrder);
                    contextMenu.MenuItems.Add("Удалить", DisabledTenant);
                    break;
            }
        }

        private void UpdateTenantInformation(object sender, EventArgs e)
        {
            try
            {
                if (TV_HostelInformation.SelectedNode.Tag != null)
                {
                    int tenantID = 0;
                    if (int.TryParse(TV_HostelInformation.SelectedNode.Tag.ToString(), out tenantID)) 
                    {
                        if (tenantID == 0)
                        {
                            using (SupplyDbContext db = new SupplyDbContext()) 
                            {
                                Log logInfo = new Log();
                                logInfo.ID = Guid.NewGuid();
                                logInfo.Type = "WARNING";
                                logInfo.Caption = $"Class: Form1.cs. Method:UpdateTenantInformation. Selected node tag equil 0 when update tenant";
                                logInfo.CreatedAt = DateTime.Now.ToString();
                                db.Logs.Add(logInfo);
                                db.SaveChanges();
                            }
                            MessageBox.Show("ID жильца равен 0");
                        }
                        else
                        {
                            TenantUpdateInformation tenantUpdateInformation = new TenantUpdateInformation(tenantID);
                            tenantUpdateInformation.ShowDialog();

                            CreateTreeOnTreeView(_hostelID);
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }
        private void DestroyOrder(object sender, EventArgs e)
        {

        }
        private void AddChangePassportHandler(object sender, EventArgs e)
        {
            try
            {
                if (TV_HostelInformation.SelectedNode.Tag != null) 
                {
                    int tenantID = 0;
                    if (int.TryParse(TV_HostelInformation.SelectedNode.Tag.ToString(), out tenantID))
                    {
                        if (tenantID != 0)
                        {
                            using(SupplyDbContext db = new SupplyDbContext())
                            {
                                Tenant tenant = db.Tenants.Where(id => id.ID == tenantID).FirstOrDefault();
                                TenantChangePassport tenantChangePassport = new TenantChangePassport(tenant);
                                tenantChangePassport.ShowDialog();
                                CreateTreeOnTreeView(_hostelID);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Log log = new Log();
                    log.ID = Guid.NewGuid();
                    log.Type = "ERROR";
                    log.CreatedAt = DateTime.Now.ToString();
                    log.Caption = $"Class: Form1. Method:AddChangePassportHandler. "+ex.Message+"."+ex.InnerException;

                    db.Logs.Add(log);
                    db.SaveChanges();
                }
                
            }
        }
        private void AddBenefitHandler(object sender, EventArgs e)
        {
            try
            {
                if (TV_HostelInformation.SelectedNode.Tag != null)
                {
                    int tenantID = int.Parse(TV_HostelInformation.SelectedNode.Tag.ToString());
                    TenantBenefitAdd tenantBenefitAdd = new TenantBenefitAdd(tenantID);
                    tenantBenefitAdd.Show();
                }
            }
            catch
            {
                return;
            }
        }
        private void AddHumanHandler(object sender, EventArgs e)
        {
            if (TV_HostelInformation.SelectedNode.Tag != null)
            {
                int room_id = Convert.ToInt32(TV_HostelInformation.SelectedNode.Tag.ToString());
                TenantAdd tenantAdd = new TenantAdd(room_id);
                tenantAdd.ShowDialog();
                CreateTreeOnTreeView(_hostelID);
            }
        }

        private void DisabledTenant(object sender, EventArgs e)
        {
            try
            {
                if (TV_HostelInformation.SelectedNode.Tag != null)
                {
                    DialogResult result = MessageBox.Show("Вы дейтвительно хотите удалить жильца", "Удалить жильца?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int tenantId = Convert.ToInt32(TV_HostelInformation.SelectedNode.Tag.ToString());
                        using (SupplyDbContext db = new SupplyDbContext())
                        {
                            Tenant tenant = db.Tenants.Where(x => x.ID == tenantId).First();
                            tenant.Status = false;
                            tenant.UpdatedAt = DateTime.Now.ToString();
                            try
                            {
                                db.Entry(tenant).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                                MessageBox.Show("Жилец удален!");
                                CreateTreeOnTreeView(_hostelID);
                            }
                            catch (Exception ex)
                            {
                                Log log = new Log();
                                log.ID = Guid.NewGuid();
                                log.Type = "ERROR";
                                log.CreatedAt = DateTime.Now.ToString();
                                log.UserID = _user.ID;
                                log.Caption = ex.Message;

                                db.Logs.Add(log);
                                db.SaveChanges();
                                MessageBox.Show(ex.Message);
                                return;

                            }
                        }
                    }


                }
            }
            catch
            {
                return;
            }
           
        }
        private void AddHumanMainOrder(object sender, EventArgs e)
        {
            try
            {
                if (TV_HostelInformation.SelectedNode.Tag != null)
                {
                    string error = string.Empty;
                    int tenantID = int.Parse(TV_HostelInformation.SelectedNode.Tag.ToString());
                    if (OrdersCreation.CreateOrders(tenantID, out error) == false)
                    {
                        MessageBox.Show(error);
                    }
                    else
                    {
                        MessageBox.Show("Договор сформирован");
                    }
                }
            }
            catch
            {
                return;
            }
        }
        private void ChangeRoomOrder(object sender,EventArgs e)
        {
            
            try
            {
                if(TV_HostelInformation.SelectedNode.Tag!=null)
                {
                    int tenantID = Convert.ToInt32(TV_HostelInformation.SelectedNode.Tag);
                    TenantChangeRoom tenantChangeRoom = new TenantChangeRoom(tenantID);
                    tenantChangeRoom.ShowDialog();

                    CreateTreeOnTreeView(_hostelID);
                }
            }
            catch
            {
                return;
            }
        }
        private void AddAccounting(object sender, EventArgs e)
        {
            try
            {
                if (TV_HostelInformation.SelectedNode.Tag != null)
                {
                    int tenantID = Convert.ToInt32(TV_HostelInformation.SelectedNode.Tag);
                    TenantAccounting tenantAccounting = new TenantAccounting(tenantID);
                    tenantAccounting.Show();
                }
            }
            catch
            {
                return;
            }
        }
        private void AddAccountingForElectricity(object sender, EventArgs e)
        {
            try
            {
                if (TV_HostelInformation.SelectedNode.Tag != null)
                {
                    int tenantID = Convert.ToInt32(TV_HostelInformation.SelectedNode.Tag);

                    TenantElectricityAccount tenantElectricityAccount = new TenantElectricityAccount(tenantID);
                    tenantElectricityAccount.Show();
                }
            }
            catch
            {
                return;
            }
        }
        private void AddTenantAccountingForElectricity(object sender, EventArgs e)
        {
            try
            {
                if (TV_HostelInformation.SelectedNode.Tag != null)
                {
                    int tenantID = Convert.ToInt32(TV_HostelInformation.SelectedNode.Tag);

                    DeclarationPaymentOrder declarationPaymentOrder = new DeclarationPaymentOrder(tenantID);
                    declarationPaymentOrder.Show();
                }
            }
            catch
            {
                return;
            }
        }
        #endregion
        #region Buttons functions
        private void BTN_CreateOrders_Click(object sender, EventArgs e)
        {
            OrderCreateForm orderCreateForm = new OrderCreateForm();
            orderCreateForm.ShowDialog();
        }

        private void BTN_CreatePaymentOrder_Click(object sender, EventArgs e)
        {
            DeclarationPaymentOrder declarationPaymentOrder = new DeclarationPaymentOrder();
            declarationPaymentOrder.Show();
        }

        private void BTN_OrderToElectricity_Click(object sender, EventArgs e)
        {
            OrderElectricityCreate orderElectricityCreate = new OrderElectricityCreate();
            orderElectricityCreate.Show();
        }
        
        #endregion


    }
}
