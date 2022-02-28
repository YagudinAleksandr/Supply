using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
        private Thread _serverThread;
        private User _user;
        private Role _role;
        private int _hostelID;
        public Form1(User user)
        {
            InitializeComponent();
            _user = user;
            _hostelID = 0;
            _serverThread = new Thread(AsyncProcessing);
            _serverThread.Name = "ServerThreadUpdateDatabase";
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
            if(_serverThread.IsAlive)
            {
                _serverThread.Abort();
            }
            
        }

        private void CloseApp_Click(object sender, EventArgs e)
        {
            if(_serverThread.IsAlive)
            {
                _serverThread.Abort();
            }
            Application.Exit();
        }
        private void ChangeUser_Click(object sender, EventArgs e)
        {
            _user = null;
            this.Close();
        }

        private void AppSettings_Click(object sender, EventArgs e)
        {
            AppSettingsForm appSettingsForm = new AppSettingsForm(_user);
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
        private void DeclarationContinueOrders_Click(object sender, EventArgs e)
        {
            DeclarationContinueOrders declarationContinueOrders = new DeclarationContinueOrders();
            declarationContinueOrders.Show();
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

        private void DeclarationTerminations_Click(object sender, EventArgs e)
        {
            DeclarationTerminations declarationTerminations = new DeclarationTerminations();
            declarationTerminations.Show();
        }
        private void CreateDeclarationLogs_Click(object sender, EventArgs e)
        {
            StreamWriter logStream = new StreamWriter(AppSettings.GetTemplateSetting("outfileDir") + @"\Отчет об ошибках " + DateTime.Now.ToShortDateString() + ".txt");

            logStream.WriteLine("----------------------------------------------------------------------------");
            logStream.WriteLine("Файл логирования приложения Supply");
            logStream.WriteLine($"Дата создания:{DateTime.Now.ToString()}");
            logStream.WriteLine("-----------------------------------------------------------------------------");

            logStream.WriteLine("=============================================================================");
            logStream.WriteLine("TYPE || DATE|| CAPTION  ");
            logStream.WriteLine("=============================================================================");

            using (SupplyDbContext db = new SupplyDbContext())
            {
                var logs = db.Logs.OrderBy(x => x.CreatedAt).ToList();
                foreach(Log log in logs)
                {
                    logStream.WriteLine($"{log.Type} || {log.CreatedAt} || {log.Caption}");
                }
                
            }

            logStream.Close();
            MessageBox.Show("Файл логов создан!");
        }

        private void CreateNew_Click(object sender, EventArgs e)
        {
            AdminNewsForm adminNewsForm = new AdminNewsForm();
            adminNewsForm.Show();
        }
        private void CreateHostelDeclaration_Click(object sender, EventArgs e)
        {
            if (_hostelID != 0) 
            {
                Thread thread = new Thread(CreateDeclarationForHostel);
                thread.Start();
                MessageBox.Show("Файл создается в фоновом режиме!");
            }
            else
            {
                MessageBox.Show("Выбирите общежитие в списке!");
            }
        }
        private void BenefitsPayments_Click(object sender, EventArgs e)
        {
            AdminBenefitPayments adminBenefitPayments = new AdminBenefitPayments();
            adminBenefitPayments.Show();
        }
        private void PaymentsDeclarationOrders_Click(object sender, EventArgs e)
        {
            AdminPaymentsDeclarations adminPaymentsDeclarations = new AdminPaymentsDeclarations();
            this.Hide();
            adminPaymentsDeclarations.ShowDialog();
            this.Show();
        }
        private void SpecialPaymentDeclaration_Click(object sender, EventArgs e)
        {
            DeclarationSpecialPayments declarationSpecialPayments = new DeclarationSpecialPayments();
            declarationSpecialPayments.Show();
        }
        private void MonthDeclarationPayment_Click(object sender, EventArgs e)
        {
            DeclarationMonthPayment declarationMonthPayment = new DeclarationMonthPayment();
            declarationMonthPayment.Show();
        }

        private void DeclarationTenantsDocuments_Click(object sender, EventArgs e)
        {
            DeclarationTenantsDocuments declarationTenantsDocuments = new DeclarationTenantsDocuments();
            declarationTenantsDocuments.Show();
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

                ToolStripMenuItem roomType = new ToolStripMenuItem("Типы комнат");
                roomType.Click += RoomType_Click;

                ToolStripMenuItem users = new ToolStripMenuItem("Пользователи");
                users.Click += Users_Click;

                ToolStripMenuItem news = new ToolStripMenuItem("Новости");
                news.Click += CreateNew_Click;

                settingItem.DropDownItems.Add(addresses);

                settingItem.DropDownItems.Add(hostels);
                settingItem.DropDownItems.Add(roomType);
                settingItem.DropDownItems.Add(users);
                settingItem.DropDownItems.Add(news);

                ToolStripMenuItem logDeclaration = new ToolStripMenuItem("Отчет ошибок");
                logDeclaration.Click += CreateDeclarationLogs_Click;
                declaration.DropDownItems.Add(logDeclaration);

                GC.Collect();
            }

            if (_role.Name == "ADMINISTRATOR" || _role.Name == "MANAGER")
            {
                

                ToolStripMenuItem managers = new ToolStripMenuItem("Менеджеры");
                managers.Click += managersToolStripMenuItem_Click;
                settingItem.DropDownItems.Add(managers);

                ToolStripMenuItem payments = new ToolStripMenuItem("Тарифные планы");
                payments.Click += Payments_Click;
                settingItem.DropDownItems.Add(payments);

                ToolStripMenuItem benefitPayments = new ToolStripMenuItem("Тарифные планы для льготников");
                benefitPayments.Click += BenefitsPayments_Click;
                settingItem.DropDownItems.Add(benefitPayments);

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

                ToolStripMenuItem paymentDeclarations = new ToolStripMenuItem("Отчеты по платежным поручениям");
                paymentDeclarations.Click += PaymentsDeclarationOrders_Click;
                declaration.DropDownItems.Add(paymentDeclarations);


                ToolStripMenuItem specialPaymentDeclaration = new ToolStripMenuItem("Отчеты по специализированным оплатам!");
                specialPaymentDeclaration.Click += SpecialPaymentDeclaration_Click;
                declaration.DropDownItems.Add(specialPaymentDeclaration);

                ToolStripMenuItem benefitsOrders = new ToolStripMenuItem("Отчеты по льготам");
                benefitsOrders.Click += BenefitsOrders_Click;
                declaration.DropDownItems.Add(benefitsOrders);

                ToolStripMenuItem changeroomOrders = new ToolStripMenuItem("Отчеты по переселению жильцов");
                changeroomOrders.Click += ChangeRoomOrder_Click;
                declaration.DropDownItems.Add(changeroomOrders);

                ToolStripMenuItem changePassportOrders = new ToolStripMenuItem("Отчеты по смене паспартов");
                changePassportOrders.Click += ChangePassportOrder_Click;
                declaration.DropDownItems.Add(changePassportOrders);

                ToolStripMenuItem declarationTerminations = new ToolStripMenuItem("Отчеты по расторжению договоров");
                declarationTerminations.Click += DeclarationTerminations_Click;
                declaration.DropDownItems.Add(declarationTerminations);

                ToolStripMenuItem declarationContinueOrders = new ToolStripMenuItem("Отчет по продлению договоров");
                declarationContinueOrders.Click += DeclarationContinueOrders_Click;
                declaration.DropDownItems.Add(declarationContinueOrders);

                ToolStripMenuItem declarationHostels = new ToolStripMenuItem("Отчет по общежитиям");
                declarationHostels.Click += DeclarationHostelsOrders;
                declaration.DropDownItems.Add(declarationHostels);

                ToolStripMenuItem declarationHostelsTenants = new ToolStripMenuItem("Отчет по проживающим");
                declarationHostelsTenants.Click += CreateTenantsInHostel_Click;
                declaration.DropDownItems.Add(declarationHostelsTenants);
                
                ToolStripMenuItem declarationElectricityPayment = new ToolStripMenuItem("Отчеты по договорам об оплате за эл.энергию");
                declarationElectricityPayment.Click += DeclarationElectricityOrders_Click;
                declaration.DropDownItems.Add(declarationElectricityPayment);
                
                ToolStripMenuItem monthDeclarationPayment = new ToolStripMenuItem("Отчет по начислениям");
                monthDeclarationPayment.Click += MonthDeclarationPayment_Click;
                declaration.DropDownItems.Add(monthDeclarationPayment);

                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Отчет по СПО");
                toolStripMenuItem.Click += (senderLoc, ev) =>
                  {
                      Thread thread = new Thread(CreateSPODeclaration);
                      thread.Start();
                      MessageBox.Show("Файл создается в фоновом режиме!");
                  };
                declaration.DropDownItems.Add(toolStripMenuItem);

                ToolStripMenuItem toolStripMenuItem1 = new ToolStripMenuItem("Отчет бакалавриат");
                toolStripMenuItem1.Click += (senderLoc, ev) =>
                  {
                      Thread thread = new Thread(CreateBachelorDeclaration);
                      thread.Start();
                      MessageBox.Show("Файл создается в фоновом режиме!");
                      
                  };
                declaration.DropDownItems.Add(toolStripMenuItem1);

                ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("Отчет магистратура");
                toolStripMenuItem2.Click += (senderLoc, ev) =>
                  {
                      Thread thread = new Thread(CreateBachelorMag);
                      thread.Start();
                      MessageBox.Show("Файл создается в фоновом режиме!");
                  };
                declaration.DropDownItems.Add(toolStripMenuItem2);

                ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem("Отчет по аспирантуре");
                toolStripMenuItem3.Click += (senderLoc, ev) =>
                  {
                      Thread thread = new Thread(CreateBachelorAsp);
                      thread.Start();
                      MessageBox.Show("Файл создается в фоновом режиме!");
                  };
                declaration.DropDownItems.Add(toolStripMenuItem3);
            }


            ToolStripMenuItem orderLiveInHostels = new ToolStripMenuItem("Проживающие в общежитии по комнатам");
            orderLiveInHostels.Click += CreateHostelDeclaration_Click;
            declaration.DropDownItems.Add(orderLiveInHostels);

            ToolStripMenuItem declarationTenantsDocuments = new ToolStripMenuItem("Отчет по документам жильцов");
            declarationTenantsDocuments.Click += DeclarationTenantsDocuments_Click;
            declaration.DropDownItems.Add(declarationTenantsDocuments);

            ToolStripMenuItem declarationForeignCitizenship = new ToolStripMenuItem("Отчет по иностранным студентам");
            declarationForeignCitizenship.Click += CreateDeclarationForeignCitizenship_Click;
            declaration.DropDownItems.Add(declarationForeignCitizenship);

            ToolStripMenuItem tenant = new ToolStripMenuItem("Жильцы");
            tenant.Click += Tenants_Click;

            ToolStripMenuItem settingsWindow = new ToolStripMenuItem("Настройки");
            settingsWindow.Click += AppSettings_Click;

            settingItem.DropDownItems.Add(tenant);
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

            
            

            if(Properties.Settings.Default.IsServer==true)
            {
                _serverThread.Start();
            }
            else
            {
                if(_serverThread.IsAlive)
                {
                    _serverThread.Abort();
                }
            }

            ShowNews();
        }

        private void AsyncProcessing()
        {
            while (true)
            {
                AsyncProcesses.UpdateChangeRoom();
                AsyncProcesses.UpdateBenefits();
                AsyncProcesses.UpdateOrders();
                AsyncProcesses.UpdateTerminations();
                Thread.Sleep(TimeSpan.FromMinutes(120));
            }
        }

        private void ShowNews()
        {
            List<Information> news = new List<Information>();
            using (SupplyDbContext db = new SupplyDbContext())
            {
                var infoNews = db.Informations.Where(s => s.Status == true).ToList();
                foreach(Information information in infoNews)
                {
                    news.Add(information);
                    
                }
            }

            if (news.Count > 0) 
            {
                UsersInformationForm usersInformationForm = new UsersInformationForm(news);
                usersInformationForm.Show();
            }
            
            
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
                try
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

                                        int tID = tenants[l].ID;
                                        ChangePassport changePassport = db.ChangePassports.Where(x => x.TenantID == tID).Where(s => s.Status == true).FirstOrDefault();

                                        if (changePassport != null)
                                        {
                                            tenantNodes[l].Text = changePassport.Surename + " " + changePassport.Name;
                                            if (changePassport.Patronymic != null)
                                            {
                                                tenantNodes[l].Text += " " + changePassport.Patronymic;
                                            }
                                        }
                                        else
                                        {
                                            tenantNodes[l].Text = tenants[l].Identification.Surename + " " + tenants[l].Identification.Name;
                                            if (tenants[l].Identification.Patronymic != null)
                                            {
                                                tenantNodes[l].Text += " " + tenants[l].Identification.Patronymic;
                                            }
                                        }

                                        if(OrdersCreation.AdditionalInf(10,tenants[l].ID)==string.Empty)
                                        {
                                            tenantNodes[l].Text += " (НИМИ)";
                                        }
                                        else
                                        {
                                            tenantNodes[l].Text += " (Сторонняя)";
                                        }

                                        tenantNodes[l].Tag = tID;
                                        CreateConetxtMenuForNode("tenant", out contextMenuForNode);
                                        tenantNodes[l].ContextMenu = contextMenuForNode;
                                        tenantNodes[l].Name = "Tenant";
                                        

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
                }
                catch(Exception ex)
                {
                    Log log = new Log();
                    log.ID = Guid.NewGuid();
                    log.Type = "ERROR";
                    log.CreatedAt = DateTime.Now.ToString();
                    log.Caption = $"Class: Form1. Method:CreateTreeOnTreeView. " + ex.Message + "." + ex.InnerException;
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        db.Logs.Add(log);
                        db.SaveChanges();
                    }
                    MessageBox.Show(ex.Message);
                }

                GC.Collect();
            };

            Invoke(action);
            
        }
        private void TV_HostelInformation_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name == "Tenant") 
            {
                int tenantID = 0;
                if(int.TryParse(e.Node.Tag.ToString(),out tenantID))
                {
                    TenantCard tenantCard = new TenantCard(tenantID);
                    tenantCard.Show();
                }
                else
                {
                    using (SupplyDbContext db = new SupplyDbContext())
                    {
                        Log logInfo = new Log();
                        logInfo.ID = Guid.NewGuid();
                        logInfo.Type = "WARNING";
                        logInfo.Caption = $"Class: Form1.cs. Method:TV_HostelInformation_NodeMouseDoubleClick. Selected node tag equil 0 when update tenant";
                        logInfo.CreatedAt = DateTime.Now.ToString();
                        db.Logs.Add(logInfo);
                        db.SaveChanges();
                    }
                    MessageBox.Show("ID жильца равен 0");
                }
            }
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
                    contextMenu.MenuItems.Add("Специализированная оплата", AddSpecialRulesForPayment);
                    contextMenu.MenuItems.Add("Внести оплату", AddAccounting);
#if DEBUG
                    contextMenu.MenuItems.Add("Внести оплату за эл.энергию", AddAccountingForElectricity);
#endif
                    contextMenu.MenuItems.Add("Сформировать договор", AddHumanMainOrder);
                    contextMenu.MenuItems.Add("Сформировать договор на эл.энергию", CreateOrderForElectricity);
                    contextMenu.MenuItems.Add("Сформировать платежное поручение", AddTenantAccountingForElectricity);
                    contextMenu.MenuItems.Add("Переселить жильца", ChangeRoomOrder);
                    contextMenu.MenuItems.Add("Смена паспорта", AddChangePassportHandler);
                    contextMenu.MenuItems.Add("Создать льготу", AddBenefitHandler);
                    contextMenu.MenuItems.Add("Продление договора", ContinueOrder);
                    contextMenu.MenuItems.Add("Расторжение договора", DestroyOrder);
                    contextMenu.MenuItems.Add("Дополнительные документы", TenantAdditionalDocument);
                    contextMenu.MenuItems.Add("Удалить", DisabledTenant);
                    break;
            }
        }

        private void ContinueOrder(object sender, EventArgs e)
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
                                logInfo.Caption = $"Class: Form1.cs. Method:ContinueOrder. Selected node tag equil 0 when update tenant";
                                logInfo.CreatedAt = DateTime.Now.ToString();
                                db.Logs.Add(logInfo);
                                db.SaveChanges();
                            }
                            MessageBox.Show("ID жильца равен 0");
                        }
                        else
                        {
                            TenantContinueOrder tenantContinueOrder = new TenantContinueOrder(tenantID);
                            tenantContinueOrder.Show();
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }
        private void TenantAdditionalDocument(object sender, EventArgs e)
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
                                logInfo.Caption = $"Class: Form1.cs. Method:TenantDocument. Selected node tag equil 0 when update tenant";
                                logInfo.CreatedAt = DateTime.Now.ToString();
                                db.Logs.Add(logInfo);
                                db.SaveChanges();
                            }
                            MessageBox.Show("ID жильца равен 0");
                        }
                        else
                        {
                            TenantDocument tenantDocument = new TenantDocument(tenantID);
                            tenantDocument.Show();
                        }
                    }
                }
            }
            catch
            {
                return;
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
            try
            {
                if (TV_HostelInformation.SelectedNode.Tag != null)
                {
                    int tenantID = 0;
                    if (int.TryParse(TV_HostelInformation.SelectedNode.Tag.ToString(), out tenantID))
                    {
                        if (tenantID != 0)
                        {
                            TenantTerminationForm terminationForm = new TenantTerminationForm(tenantID);
                            terminationForm.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Log log = new Log();
                    log.ID = Guid.NewGuid();
                    log.Type = "ERROR";
                    log.CreatedAt = DateTime.Now.ToString();
                    log.Caption = $"Class: Form1. Method:DestroyOrder. " + ex.Message + "." + ex.InnerException;

                    db.Logs.Add(log);
                    db.SaveChanges();
                }

            }
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
            try
            {
                if (TV_HostelInformation.SelectedNode.Tag != null)
                {
                    int room_id = Convert.ToInt32(TV_HostelInformation.SelectedNode.Tag.ToString());
                    TenantAdd tenantAdd = new TenantAdd(room_id);
                    tenantAdd.ShowDialog();

                    TV_HostelInformation.SelectedNode.Nodes.Clear();

                    if(AddHumanToTree(room_id)!=null)
                    {
                        TV_HostelInformation.SelectedNode.Nodes.AddRange(AddHumanToTree(room_id));
                    }

                    TV_HostelInformation.SelectedNode.ExpandAll();
                    
                }
            }
            catch
            {
                return;
            }
        }

        private TreeNode[] AddHumanToTree(int tag)
        {
            TreeNode[] tenantNodes;
            using (SupplyDbContext db = new SupplyDbContext())
            {
                var tenants = db.Tenants.Where(x => x.RoomID == tag)
                                        .Where(y => y.Status == true)
                                        .Include(p => p.Identification)
                                        .Include(ai => ai.AdditionalInformation)
                                        .ToList();

                if (tenants == null) 
                {
                    return null;
                }

                tenantNodes = new TreeNode[tenants.Count];
                ContextMenu contextMenuForNode;
                for (int l = 0; l < tenants.Count; l++)
                {
                    tenantNodes[l] = new TreeNode();

                    int tID = tenants[l].ID;
                    ChangePassport changePassport = db.ChangePassports.Where(x => x.TenantID == tID).Where(s => s.Status == true).FirstOrDefault();

                    if (changePassport != null)
                    {
                        tenantNodes[l].Text = changePassport.Surename + " " + changePassport.Name;
                        if (changePassport.Patronymic != null)
                        {
                            tenantNodes[l].Text += " " + changePassport.Patronymic;
                        }
                    }
                    else
                    {
                        tenantNodes[l].Text = tenants[l].Identification.Surename + " " + tenants[l].Identification.Name;
                        if (tenants[l].Identification.Patronymic != null)
                        {
                            tenantNodes[l].Text += " " + tenants[l].Identification.Patronymic;
                        }
                    }

                    tenantNodes[l].Tag = tID;
                    CreateConetxtMenuForNode("tenant", out contextMenuForNode);
                    tenantNodes[l].ContextMenu = contextMenuForNode;
                    tenantNodes[l].Name = "Tenant";

                    var adinften = tenants[l].AdditionalInformation.Where(x => x.AdditionalInformationTypeID == 9).ToList();
                    TreeNode[] additionalInfNode = new TreeNode[adinften.Count()];
                    for (int a = 0; a < adinften.Count; a++)
                    {
                        additionalInfNode[a] = new TreeNode();
                        additionalInfNode[a].Text = $"{adinften[a].Value}";
                    }

                    tenantNodes[l].Nodes.AddRange(additionalInfNode);

                }
            }
            return tenantNodes;
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

                                TV_HostelInformation.SelectedNode.Remove();
                                
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
        private void AddSpecialRulesForPayment(object sender, EventArgs e)
        {
            try
            {
                int tenantID = 0;
                if (TV_HostelInformation.SelectedNode.Tag != null && int.TryParse(TV_HostelInformation.SelectedNode.Tag.ToString(), out tenantID))
                {
                    TenantSpecialPayments tenantSpecialPayments = new TenantSpecialPayments(tenantID);
                    tenantSpecialPayments.Show();
                }
            }
            catch
            {
                return;
            }
        }
        private void CreateOrderForElectricity(object sender, EventArgs e)
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
                            OrderElectricityCreate orderElectricityCreate = new OrderElectricityCreate(tenantID);
                            orderElectricityCreate.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Log log = new Log();
                    log.ID = Guid.NewGuid();
                    log.Type = "ERROR";
                    log.CreatedAt = DateTime.Now.ToString();
                    log.Caption = $"Class: Form1. Method:CreateOrderForElectricity. " + ex.Message + "." + ex.InnerException;

                    db.Logs.Add(log);
                    db.SaveChanges();
                }

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

        private void BTN_Archive_Click(object sender, EventArgs e)
        {
            if(_hostelID==0)
            {
                MessageBox.Show("Выбирите общежитие!");
                return;
            }
            else
            {
                HostelArchiveForm hostelArchiveForm = new HostelArchiveForm(_hostelID);
                Hide();
                hostelArchiveForm.ShowDialog();
                Show();
            }
            
        }
        private void BTN_PaymentOrders_Click(object sender, EventArgs e)
        {
            DeclarationPaymentOrdersForHostel declarationPaymentOrdersForHostel = new DeclarationPaymentOrdersForHostel(_hostelID);
            this.Hide();
            declarationPaymentOrdersForHostel.ShowDialog();
            this.Show();
        }
        #endregion
        #region Search

        private List<TreeNode> _currentNodeMatches = new List<TreeNode>();

        private int _lastNodeIndex = 0;

        private string _lastSearchText;
        private void BTN_Search_Click(object sender, EventArgs e)
        {
            string searchText = TB_Search.Text;

            if(string.IsNullOrEmpty(searchText))
            {
                return;
            }

            if (_lastSearchText != searchText)
            {
                _currentNodeMatches.Clear();
                _lastSearchText = searchText;
                _lastNodeIndex = 0;
                SearchNodes(searchText, TV_HostelInformation.Nodes[0]);
            }

            if (_lastNodeIndex >= 0 && _currentNodeMatches.Count > 0 && _lastNodeIndex < _currentNodeMatches.Count)
            {
                TreeNode selectedNode = _currentNodeMatches[_lastNodeIndex];
                _lastNodeIndex++;

                TV_HostelInformation.SelectedNode = selectedNode;
                TV_HostelInformation.SelectedNode.Expand();
                TV_HostelInformation.Select();
            }
        }

        private void SearchNodes(string searchText, TreeNode startNode)
        {
            while (startNode != null)
            {
                if (startNode.Text.ToLower().Contains(searchText.ToLower()))
                {
                    _currentNodeMatches.Add(startNode);
                };
                if (startNode.Nodes.Count != 0)
                {
                    SearchNodes(searchText, startNode.Nodes[0]); 
                };
                startNode = startNode.NextNode;
            };
        }
#endregion
#region Private methods
        private void CreateDeclarationForHostel()
        {
            string error = string.Empty;

            using (ExcelHelper excel = new ExcelHelper())
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    Hostel hostel = db.Hostels.Where(x => x.ID == _hostelID).FirstOrDefault();

                    if (excel.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: $"Список общежития {hostel.Name}({DateTime.Now.ToShortDateString()}).xlsx", out error))
                    {
                        try
                        {

                            if (hostel == null)
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class:Form1. Method: CreateHostelDeclaration_Click. Not found the hostel with ID:{_hostelID}");

                                MessageBox.Show("Не найдено общежития!");
                                return;
                            }

                            if (!excel.Set("A", 1, "Комната", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("B", 1, "Кол-во мест", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("C", 1, "ФИО", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("D", 1, "Договор", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("E", 1, "Дата начала", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("F", 1, "Дата рождения", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("G", 1, "Факультет/Группа", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("H", 1, "Адрес", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("I", 1, "Телефон", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }

                            var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();

                            if (enterances.Count == 0)
                            {
                                MessageBox.Show("Не найдено подъездов!");
                                return;
                            }

                            List<Flat> flats = new List<Flat>();

                            foreach (Enterance enterance in enterances)
                            {
                                flats.AddRange(db.Flats.Where(x => x.Enterance_ID == enterance.ID).OrderBy(n => n.Name).ToList());
                            }

                            List<Room> rooms = new List<Room>();
                            foreach (Flat flat in flats)
                            {
                                rooms.AddRange(db.Rooms.Where(x => x.FlatID == flat.ID).OrderBy(p => p.Name).ToList());
                            }


                            flats.Clear();


                            int rowCounter = 2;
                            object startCell, endCell;
                            List<RoomModel> roomModels = new List<RoomModel>();

                            foreach (Room room in rooms)
                            {
                                roomModels.Add(new RoomModel { ID = room.ID, Name = int.Parse(room.Name), Places = room.Places });
                                /*
                                //Column Room name
                                startCell = $"A{rowCounter}";
                                endCell = $"A{rowCounter + room.Places - 1}";
                                if (!excel.Merge(startCell, endCell, rowCounter, 1, room.Name, out error))
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                    thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                                }

                                //Column room places
                                startCell = $"B{rowCounter}";
                                endCell = $"B{rowCounter + room.Places - 1}";
                                if (!excel.Merge(startCell, endCell, rowCounter, 2, room.Places.ToString(), out error))
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                    thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                                }

                                var tenants = db.Tenants
                                                .Where(x => x.RoomID == room.ID)
                                                .Where(s => s.Status == true)
                                                .Include(i => i.Identification)
                                                .Include(o => o.Order)
                                                .ToList();

                                int tenantPlaces = rowCounter;

                                foreach (Tenant tenant in tenants)
                                {
                                    string tenantName = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                    if (tenant.Identification.Patronymic != null)
                                    {
                                        tenantName += " " + tenant.Identification.Patronymic;
                                    }
                                    excel.Set("C", tenantPlaces, tenantName, out error);
                                    excel.Set("D", tenantPlaces, tenant.Order.OrderNumber, out error);
                                    excel.Set("E", tenantPlaces, tenant.Order.StartDate, out error);
                                    excel.Set("F", tenantPlaces, tenant.Identification.DateOfBirth, out error);
                                    excel.Set("G", tenantPlaces, OrdersCreation.AdditionalInf(3, tenant.ID)+"/"+ OrdersCreation.AdditionalInf(4, tenant.ID), out error);
                                    excel.Set("H", tenantPlaces, tenant.Identification.Address, out error);
                                    excel.Set("I", tenantPlaces, OrdersCreation.AdditionalInf(1, tenant.ID), out error);

                                    tenantPlaces++;
                                }


                                rowCounter += room.Places;

                                startCell = endCell = string.Empty;
                                */
                            }

                            var rm = from roomModel in roomModels
                                     orderby roomModel.Name
                                     select roomModel;

                            foreach(var r in rm)
                            {
                                startCell = $"A{rowCounter}";
                                endCell = $"A{rowCounter + r.Places - 1}";
                                if (!excel.Merge(startCell, endCell, rowCounter, 1, r.Name.ToString(), out error))
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                    thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                                }

                                //Column room places
                                startCell = $"B{rowCounter}";
                                endCell = $"B{rowCounter + r.Places - 1}";
                                if (!excel.Merge(startCell, endCell, rowCounter, 2, r.Places.ToString(), out error))
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                    thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                                }

                                var tenants = db.Tenants
                                                .Where(x => x.RoomID == r.ID)
                                                .Where(s => s.Status == true)
                                                .Include(i => i.Identification)
                                                .Include(o => o.Order)
                                                .ToList();

                                int tenantPlaces = rowCounter;

                                foreach (Tenant tenant in tenants)
                                {
                                    string tenantName = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                    if (tenant.Identification.Patronymic != null)
                                    {
                                        tenantName += " " + tenant.Identification.Patronymic;
                                    }
                                    excel.Set("C", tenantPlaces, tenantName, out error);
                                    excel.Set("D", tenantPlaces, tenant.Order.OrderNumber, out error);
                                    excel.Set("E", tenantPlaces, tenant.Order.StartDate, out error);
                                    excel.Set("F", tenantPlaces, tenant.Identification.DateOfBirth, out error);
                                    excel.Set("G", tenantPlaces, OrdersCreation.AdditionalInf(3, tenant.ID) + "/" + OrdersCreation.AdditionalInf(4, tenant.ID), out error);
                                    excel.Set("H", tenantPlaces, tenant.Identification.Address, out error);
                                    excel.Set("I", tenantPlaces, OrdersCreation.AdditionalInf(1, tenant.ID), out error);

                                    tenantPlaces++;
                                }


                                rowCounter += r.Places;

                                startCell = endCell = string.Empty;
                            }

                            rooms.Clear();

                            excel.Save();

                            MessageBox.Show("Файл сформирован успешно!");

                        }
                        catch (Exception ex)
                        {
                            Thread thread = new Thread(new ParameterizedThreadStart(Log));
                            thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {ex.Message}. {ex.InnerException}");

                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(Log));
                        thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");

                        MessageBox.Show(error);
                        excel.Close();
                        return;
                    }
                }
                

            }

            GC.Collect();
        }

        private void CreateSPODeclaration()
        {
            string error = string.Empty;

            using (ExcelHelper excel = new ExcelHelper())
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Hostel hostel = db.Hostels.Where(x => x.ID == _hostelID).FirstOrDefault();

                    if (excel.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: $"Список общежития {hostel.Name} СПО({DateTime.Now.ToShortDateString()}).xlsx", out error))
                    {
                        try
                        {
                            int counter = 0;
                            if (hostel == null)
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class:Form1. Method: CreateHostelDeclaration_Click. Not found the hostel with ID:{_hostelID}");

                                MessageBox.Show("Не найдено общежития!");
                                return;
                            }

                            if (!excel.Set("A", 1, "Комната", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("B", 1, "Кол-во мест", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("C", 1, "ФИО", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("D", 1, "Договор", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("E", 1, "Дата начала", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("F", 1, "Дата рождения", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("G", 1, "Факультет/Группа", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("H", 1, "Адрес", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("I", 1, "Телефон", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }

                            var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();

                            if (enterances.Count == 0)
                            {
                                MessageBox.Show("Не найдено подъездов!");
                                return;
                            }

                            List<Flat> flats = new List<Flat>();

                            foreach (Enterance enterance in enterances)
                            {
                                flats.AddRange(db.Flats.Where(x => x.Enterance_ID == enterance.ID).OrderBy(n => n.Name).ToList());
                            }

                            List<Room> rooms = new List<Room>();
                            foreach (Flat flat in flats)
                            {
                                rooms.AddRange(db.Rooms.Where(x => x.FlatID == flat.ID).OrderBy(p => p.Name).ToList());
                            }


                            flats.Clear();


                            int rowCounter = 2;
                            object startCell, endCell;
                            List<RoomModel> roomModels = new List<RoomModel>();

                            foreach (Room room in rooms)
                            {
                                roomModels.Add(new RoomModel { ID = room.ID, Name = int.Parse(room.Name), Places = room.Places });
                                
                            }

                            var rm = from roomModel in roomModels
                                     orderby roomModel.Name
                                     select roomModel;

                            foreach (var r in rm)
                            {
                                startCell = $"A{rowCounter}";
                                endCell = $"A{rowCounter + r.Places - 1}";
                                if (!excel.Merge(startCell, endCell, rowCounter, 1, r.Name.ToString(), out error))
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                    thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                                }

                                //Column room places
                                startCell = $"B{rowCounter}";
                                endCell = $"B{rowCounter + r.Places - 1}";
                                if (!excel.Merge(startCell, endCell, rowCounter, 2, r.Places.ToString(), out error))
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                    thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                                }

                                var tenants = db.Tenants
                                                .Where(x => x.RoomID == r.ID)
                                                .Where(s => s.Status == true)
                                                .Include(i => i.Identification)
                                                .Include(o => o.Order)
                                                .ToList();

                                int tenantPlaces = rowCounter;

                                

                                foreach (Tenant tenant in tenants)
                                {
                                    if (OrdersCreation.AdditionalInf(10, tenant.ID) == string.Empty && OrdersCreation.AdditionalInf(6, tenant.ID) == "СПО")
                                    {
                                        string tenantName = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                        if (tenant.Identification.Patronymic != null)
                                        {
                                            tenantName += " " + tenant.Identification.Patronymic;
                                        }
                                        excel.Set("C", tenantPlaces, tenantName, out error);
                                        excel.Set("D", tenantPlaces, tenant.Order.OrderNumber, out error);
                                        excel.Set("E", tenantPlaces, tenant.Order.StartDate, out error);
                                        excel.Set("F", tenantPlaces, tenant.Identification.DateOfBirth, out error);
                                        excel.Set("G", tenantPlaces, OrdersCreation.AdditionalInf(3, tenant.ID) + "/" + OrdersCreation.AdditionalInf(4, tenant.ID), out error);
                                        excel.Set("H", tenantPlaces, tenant.Identification.Address, out error);
                                        excel.Set("I", tenantPlaces, OrdersCreation.AdditionalInf(1, tenant.ID), out error);

                                        counter++;
                                    }
                                    

                                    tenantPlaces++;
                                }


                                rowCounter += r.Places;

                                startCell = endCell = string.Empty;
                            }

                            excel.Set("A", rowCounter, "Всего студентов СПО НИМИ", out error);
                            excel.Set("B", rowCounter, counter.ToString(), out error);

                            rooms.Clear();

                            excel.Save();

                            MessageBox.Show("Файл сформирован успешно!");

                        }
                        catch (Exception ex)
                        {
                            Thread thread = new Thread(new ParameterizedThreadStart(Log));
                            thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {ex.Message}. {ex.InnerException}");

                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(Log));
                        thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");

                        MessageBox.Show(error);
                        excel.Close();
                        return;
                    }
                }


            }

            GC.Collect();
        }

        private void CreateBachelorDeclaration()
        {
            string error = string.Empty;

            using (ExcelHelper excel = new ExcelHelper())
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Hostel hostel = db.Hostels.Where(x => x.ID == _hostelID).FirstOrDefault();

                    if (excel.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: $"Список общежития {hostel.Name} бакалавриат({DateTime.Now.ToShortDateString()}).xlsx", out error))
                    {
                        try
                        {
                            int counter = 0;
                            if (hostel == null)
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class:Form1. Method: CreateHostelDeclaration_Click. Not found the hostel with ID:{_hostelID}");

                                MessageBox.Show("Не найдено общежития!");
                                return;
                            }

                            if (!excel.Set("A", 1, "Комната", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("B", 1, "Кол-во мест", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("C", 1, "ФИО", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("D", 1, "Договор", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("E", 1, "Дата начала", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("F", 1, "Дата рождения", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("G", 1, "Факультет/Группа", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("H", 1, "Адрес", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("I", 1, "Телефон", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }

                            var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();

                            if (enterances.Count == 0)
                            {
                                MessageBox.Show("Не найдено подъездов!");
                                return;
                            }

                            List<Flat> flats = new List<Flat>();

                            foreach (Enterance enterance in enterances)
                            {
                                flats.AddRange(db.Flats.Where(x => x.Enterance_ID == enterance.ID).OrderBy(n => n.Name).ToList());
                            }

                            List<Room> rooms = new List<Room>();
                            foreach (Flat flat in flats)
                            {
                                rooms.AddRange(db.Rooms.Where(x => x.FlatID == flat.ID).OrderBy(p => p.Name).ToList());
                            }


                            flats.Clear();


                            int rowCounter = 2;
                            object startCell, endCell;
                            List<RoomModel> roomModels = new List<RoomModel>();

                            foreach (Room room in rooms)
                            {
                                roomModels.Add(new RoomModel { ID = room.ID, Name = int.Parse(room.Name), Places = room.Places });

                            }

                            var rm = from roomModel in roomModels
                                     orderby roomModel.Name
                                     select roomModel;

                            foreach (var r in rm)
                            {
                                startCell = $"A{rowCounter}";
                                endCell = $"A{rowCounter + r.Places - 1}";
                                if (!excel.Merge(startCell, endCell, rowCounter, 1, r.Name.ToString(), out error))
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                    thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                                }

                                //Column room places
                                startCell = $"B{rowCounter}";
                                endCell = $"B{rowCounter + r.Places - 1}";
                                if (!excel.Merge(startCell, endCell, rowCounter, 2, r.Places.ToString(), out error))
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                    thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                                }

                                var tenants = db.Tenants
                                                .Where(x => x.RoomID == r.ID)
                                                .Where(s => s.Status == true)
                                                .Include(i => i.Identification)
                                                .Include(o => o.Order)
                                                .ToList();

                                int tenantPlaces = rowCounter;



                                foreach (Tenant tenant in tenants)
                                {
                                    if (OrdersCreation.AdditionalInf(10, tenant.ID) == string.Empty)
                                    {
                                        if(OrdersCreation.AdditionalInf(6, tenant.ID) == "бакалавр" || OrdersCreation.AdditionalInf(6, tenant.ID) == "бакалавриат"|| OrdersCreation.AdditionalInf(6, tenant.ID) == "Бакалавр"|| OrdersCreation.AdditionalInf(6, tenant.ID) == "Бакалавриат")
                                        {
                                            {
                                                string tenantName = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                                if (tenant.Identification.Patronymic != null)
                                                {
                                                    tenantName += " " + tenant.Identification.Patronymic;
                                                }
                                                excel.Set("C", tenantPlaces, tenantName, out error);
                                                excel.Set("D", tenantPlaces, tenant.Order.OrderNumber, out error);
                                                excel.Set("E", tenantPlaces, tenant.Order.StartDate, out error);
                                                excel.Set("F", tenantPlaces, tenant.Identification.DateOfBirth, out error);
                                                excel.Set("G", tenantPlaces, OrdersCreation.AdditionalInf(3, tenant.ID) + "/" + OrdersCreation.AdditionalInf(4, tenant.ID), out error);
                                                excel.Set("H", tenantPlaces, tenant.Identification.Address, out error);
                                                excel.Set("I", tenantPlaces, OrdersCreation.AdditionalInf(1, tenant.ID), out error);

                                                counter++;
                                            }
                                        }
                                    }


                                    tenantPlaces++;
                                }


                                rowCounter += r.Places;

                                startCell = endCell = string.Empty;
                            }

                            excel.Set("A", rowCounter, "Всего студентов бакалавриата НИМИ", out error);
                            excel.Set("B", rowCounter, counter.ToString(), out error);

                            rooms.Clear();

                            excel.Save();

                            MessageBox.Show("Файл сформирован успешно!");

                        }
                        catch (Exception ex)
                        {
                            Thread thread = new Thread(new ParameterizedThreadStart(Log));
                            thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {ex.Message}. {ex.InnerException}");

                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(Log));
                        thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");

                        MessageBox.Show(error);
                        excel.Close();
                        return;
                    }
                }


            }

            GC.Collect();
        }
        private void CreateBachelorMag()
        {
            string error = string.Empty;

            using (ExcelHelper excel = new ExcelHelper())
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Hostel hostel = db.Hostels.Where(x => x.ID == _hostelID).FirstOrDefault();

                    if (excel.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: $"Список общежития {hostel.Name} магистратура({DateTime.Now.ToShortDateString()}).xlsx", out error))
                    {
                        try
                        {
                            int counter = 0;
                            if (hostel == null)
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class:Form1. Method: CreateHostelDeclaration_Click. Not found the hostel with ID:{_hostelID}");

                                MessageBox.Show("Не найдено общежития!");
                                return;
                            }

                            if (!excel.Set("A", 1, "Комната", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("B", 1, "Кол-во мест", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("C", 1, "ФИО", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("D", 1, "Договор", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("E", 1, "Дата начала", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("F", 1, "Дата рождения", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("G", 1, "Факультет/Группа", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("H", 1, "Адрес", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("I", 1, "Телефон", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }

                            var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();

                            if (enterances.Count == 0)
                            {
                                MessageBox.Show("Не найдено подъездов!");
                                return;
                            }

                            List<Flat> flats = new List<Flat>();

                            foreach (Enterance enterance in enterances)
                            {
                                flats.AddRange(db.Flats.Where(x => x.Enterance_ID == enterance.ID).OrderBy(n => n.Name).ToList());
                            }

                            List<Room> rooms = new List<Room>();
                            foreach (Flat flat in flats)
                            {
                                rooms.AddRange(db.Rooms.Where(x => x.FlatID == flat.ID).OrderBy(p => p.Name).ToList());
                            }


                            flats.Clear();


                            int rowCounter = 2;
                            object startCell, endCell;
                            List<RoomModel> roomModels = new List<RoomModel>();

                            foreach (Room room in rooms)
                            {
                                roomModels.Add(new RoomModel { ID = room.ID, Name = int.Parse(room.Name), Places = room.Places });

                            }

                            var rm = from roomModel in roomModels
                                     orderby roomModel.Name
                                     select roomModel;

                            foreach (var r in rm)
                            {
                                startCell = $"A{rowCounter}";
                                endCell = $"A{rowCounter + r.Places - 1}";
                                if (!excel.Merge(startCell, endCell, rowCounter, 1, r.Name.ToString(), out error))
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                    thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                                }

                                //Column room places
                                startCell = $"B{rowCounter}";
                                endCell = $"B{rowCounter + r.Places - 1}";
                                if (!excel.Merge(startCell, endCell, rowCounter, 2, r.Places.ToString(), out error))
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                    thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                                }

                                var tenants = db.Tenants
                                                .Where(x => x.RoomID == r.ID)
                                                .Where(s => s.Status == true)
                                                .Include(i => i.Identification)
                                                .Include(o => o.Order)
                                                .ToList();

                                int tenantPlaces = rowCounter;



                                foreach (Tenant tenant in tenants)
                                {
                                    if (OrdersCreation.AdditionalInf(10, tenant.ID) == string.Empty)
                                    {
                                        if (OrdersCreation.AdditionalInf(6, tenant.ID) == "магистратура" || OrdersCreation.AdditionalInf(6, tenant.ID) == "Магистратура" 
                                            || OrdersCreation.AdditionalInf(6, tenant.ID) == "Магистрант" || OrdersCreation.AdditionalInf(6, tenant.ID) == "магистрант" 
                                            || OrdersCreation.AdditionalInf(6, tenant.ID) == "Магистр" || OrdersCreation.AdditionalInf(6, tenant.ID) == "магистр")
                                        {
                                            {
                                                string tenantName = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                                if (tenant.Identification.Patronymic != null)
                                                {
                                                    tenantName += " " + tenant.Identification.Patronymic;
                                                }
                                                excel.Set("C", tenantPlaces, tenantName, out error);
                                                excel.Set("D", tenantPlaces, tenant.Order.OrderNumber, out error);
                                                excel.Set("E", tenantPlaces, tenant.Order.StartDate, out error);
                                                excel.Set("F", tenantPlaces, tenant.Identification.DateOfBirth, out error);
                                                excel.Set("G", tenantPlaces, OrdersCreation.AdditionalInf(3, tenant.ID) + "/" + OrdersCreation.AdditionalInf(4, tenant.ID), out error);
                                                excel.Set("H", tenantPlaces, tenant.Identification.Address, out error);
                                                excel.Set("I", tenantPlaces, OrdersCreation.AdditionalInf(1, tenant.ID), out error);

                                                counter++;
                                            }
                                        }
                                    }


                                    tenantPlaces++;
                                }


                                rowCounter += r.Places;

                                startCell = endCell = string.Empty;
                            }

                            excel.Set("A", rowCounter, "Всего студентов магистратуры НИМИ", out error);
                            excel.Set("B", rowCounter, counter.ToString(), out error);

                            rooms.Clear();

                            excel.Save();

                            MessageBox.Show("Файл сформирован успешно!");

                        }
                        catch (Exception ex)
                        {
                            Thread thread = new Thread(new ParameterizedThreadStart(Log));
                            thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {ex.Message}. {ex.InnerException}");

                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(Log));
                        thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");

                        MessageBox.Show(error);
                        excel.Close();
                        return;
                    }
                }


            }

            GC.Collect();
        }
        private void CreateBachelorAsp()
        {
            string error = string.Empty;

            using (ExcelHelper excel = new ExcelHelper())
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Hostel hostel = db.Hostels.Where(x => x.ID == _hostelID).FirstOrDefault();

                    if (excel.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: $"Список общежития {hostel.Name} аспирантура({DateTime.Now.ToShortDateString()}).xlsx", out error))
                    {
                        try
                        {
                            int counter = 0;
                            if (hostel == null)
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class:Form1. Method: CreateHostelDeclaration_Click. Not found the hostel with ID:{_hostelID}");

                                MessageBox.Show("Не найдено общежития!");
                                return;
                            }

                            if (!excel.Set("A", 1, "Комната", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("B", 1, "Кол-во мест", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("C", 1, "ФИО", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("D", 1, "Договор", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("E", 1, "Дата начала", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("F", 1, "Дата рождения", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("G", 1, "Факультет/Группа", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("H", 1, "Адрес", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }
                            if (!excel.Set("I", 1, "Телефон", out error))
                            {
                                Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                            }

                            var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();

                            if (enterances.Count == 0)
                            {
                                MessageBox.Show("Не найдено подъездов!");
                                return;
                            }

                            List<Flat> flats = new List<Flat>();

                            foreach (Enterance enterance in enterances)
                            {
                                flats.AddRange(db.Flats.Where(x => x.Enterance_ID == enterance.ID).OrderBy(n => n.Name).ToList());
                            }

                            List<Room> rooms = new List<Room>();
                            foreach (Flat flat in flats)
                            {
                                rooms.AddRange(db.Rooms.Where(x => x.FlatID == flat.ID).OrderBy(p => p.Name).ToList());
                            }


                            flats.Clear();


                            int rowCounter = 2;
                            object startCell, endCell;
                            List<RoomModel> roomModels = new List<RoomModel>();

                            foreach (Room room in rooms)
                            {
                                roomModels.Add(new RoomModel { ID = room.ID, Name = int.Parse(room.Name), Places = room.Places });

                            }

                            var rm = from roomModel in roomModels
                                     orderby roomModel.Name
                                     select roomModel;

                            foreach (var r in rm)
                            {
                                startCell = $"A{rowCounter}";
                                endCell = $"A{rowCounter + r.Places - 1}";
                                if (!excel.Merge(startCell, endCell, rowCounter, 1, r.Name.ToString(), out error))
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                    thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                                }

                                //Column room places
                                startCell = $"B{rowCounter}";
                                endCell = $"B{rowCounter + r.Places - 1}";
                                if (!excel.Merge(startCell, endCell, rowCounter, 2, r.Places.ToString(), out error))
                                {
                                    Thread thread = new Thread(new ParameterizedThreadStart(Log));
                                    thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");
                                }

                                var tenants = db.Tenants
                                                .Where(x => x.RoomID == r.ID)
                                                .Where(s => s.Status == true)
                                                .Include(i => i.Identification)
                                                .Include(o => o.Order)
                                                .ToList();

                                int tenantPlaces = rowCounter;



                                foreach (Tenant tenant in tenants)
                                {
                                    if (OrdersCreation.AdditionalInf(10, tenant.ID) == string.Empty)
                                    {
                                        if (OrdersCreation.AdditionalInf(6, tenant.ID) == "аспирантура" || OrdersCreation.AdditionalInf(6, tenant.ID) == "Аспирантура"
                                            || OrdersCreation.AdditionalInf(6, tenant.ID) == "Аспирант" || OrdersCreation.AdditionalInf(6, tenant.ID) == "аспирант")
                                        {
                                            {
                                                string tenantName = tenant.Identification.Surename + " " + tenant.Identification.Name;
                                                if (tenant.Identification.Patronymic != null)
                                                {
                                                    tenantName += " " + tenant.Identification.Patronymic;
                                                }
                                                excel.Set("C", tenantPlaces, tenantName, out error);
                                                excel.Set("D", tenantPlaces, tenant.Order.OrderNumber, out error);
                                                excel.Set("E", tenantPlaces, tenant.Order.StartDate, out error);
                                                excel.Set("F", tenantPlaces, tenant.Identification.DateOfBirth, out error);
                                                excel.Set("G", tenantPlaces, OrdersCreation.AdditionalInf(3, tenant.ID) + "/" + OrdersCreation.AdditionalInf(4, tenant.ID), out error);
                                                excel.Set("H", tenantPlaces, tenant.Identification.Address, out error);
                                                excel.Set("I", tenantPlaces, OrdersCreation.AdditionalInf(1, tenant.ID), out error);

                                                counter++;
                                            }
                                        }
                                    }


                                    tenantPlaces++;
                                }


                                rowCounter += r.Places;

                                startCell = endCell = string.Empty;
                            }

                            excel.Set("A", rowCounter, "Всего студентов магистратуры НИМИ", out error);
                            excel.Set("B", rowCounter, counter.ToString(), out error);

                            rooms.Clear();

                            excel.Save();

                            MessageBox.Show("Файл сформирован успешно!");

                        }
                        catch (Exception ex)
                        {
                            Thread thread = new Thread(new ParameterizedThreadStart(Log));
                            thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {ex.Message}. {ex.InnerException}");

                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(Log));
                        thread.Start($"Class: Form1. Method: CreateDeclarationForHostel. {error}");

                        MessageBox.Show(error);
                        excel.Close();
                        return;
                    }
                }


            }

            GC.Collect();
        }
        private void Log(object information)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Log logInfo = new Log();
                logInfo.ID = Guid.NewGuid();
                logInfo.Type = "ERROR";
                logInfo.Caption = (string)information;
                logInfo.CreatedAt = DateTime.Now.ToString();
                db.Logs.Add(logInfo);
                db.SaveChanges();
            }
        }

        #endregion

        
    }

    public class RoomModel
    {
        public int ID { get; set; }
        public int Name { get; set; }
        public int Places { get; set; }
    }
}
