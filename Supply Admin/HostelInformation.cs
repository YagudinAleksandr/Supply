﻿using Supply_Admin.Domain;
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
        private SupplyDbContext _db;//Контекст данных
        private int _hostelId;//Получение ID общежития
        ContextMenu menu;//Контекстное меню
        

        public HostelInformation(SupplyDbContext db, int hostelId)
        {
            InitializeComponent();
            _hostelId = hostelId;
            _db = db;
        }

        //Создание дерева общежития
        private void CreateTree()
        {
            //Очистка дерева (Для обновления дерева)
            TV_Hostels.Nodes.Clear();
            //Получение данных об общежитии
            var hostel = _db.Hostels.Where(x => x.Id == _hostelId).FirstOrDefault();
            //Создание основной ноды общежития
            TreeNode hostelNode = new TreeNode($"Общежитие № {hostel.Name}");

            //Ноды подъездов
            var enterances = _db.Enterances.Where(x => x.HostelsId == hostel.Id).ToList();
            TreeNode[] enterancesNode = new TreeNode[enterances.Count()];

            for (int k = 0; k < enterances.Count(); k++)
            {
                enterancesNode[k] = new TreeNode();
                enterancesNode[k].Text = $"Подъезд № {enterances[k].Name}";
                int enteranceId = enterances[k].Id;

                //Создание ноды по этажам
                var flats = _db.Flats.Where(x => x.EnteranceId == enteranceId).ToList();
                TreeNode[] flatsNode = new TreeNode[flats.Count()];

                for (int i = 0; i < flats.Count(); i++)
                {
                    flatsNode[i] = new TreeNode();
                    flatsNode[i].Text = $"Этаж № {flats[i].Name}";
                    flatsNode[i].Tag = flats[i].Id;
                    int f = flats[i].Id;

                    //Создание ноды комнат по этажам
                    var rooms = _db.Rooms.Where(p => p.FlatId == f).ToList();
                    TreeNode[] roomsNode = new TreeNode[rooms.Count()];
                    for (int j = 0; j < rooms.Count(); j++)
                    {
                        int roomId = rooms[j].Id;
                        //Сведения о жильцах комнаты (Вносим в ноду комнаты)
                        var humens = _db.Humen.Where(x => x.RoomId == roomId).ToList();

                        roomsNode[j] = new TreeNode();
                        roomsNode[j].Text = rooms[j].Name.ToString() + " (Количесвто мест -" + rooms[j].Places.ToString() +" / использовано мест - "+ humens.Count().ToString()+")";
                        roomsNode[j].Tag = rooms[j].Id;

                        //Проверка (Если количество мест в комнате больше проживающих, то позволяем добавлять жильца)
                        if(humens.Count() < rooms[j].Places)
                        {
                            //Создание контекстного меню для создания жильца и договора
                            menu = new ContextMenu() { MenuItems = { new MenuItem("Добавить жильца", AddHumanHandler) } };

                            roomsNode[j].ContextMenu = menu;
                        }

                        //Создание ноды жильцов комнаты
                        TreeNode[] humensNode = new TreeNode[humens.Count()];

                        for (int m = 0; m < humens.Count(); m++)
                        {
                            humensNode[m] = new TreeNode();
                            humensNode[m].Text = humens[m].Surename + " " + humens[m].Name + " " + humens[m].Patronymic;
                            humensNode[m].Tag = humens[m].Id;

                            int humanId = humens[m].Id;
                            //Получение сведений по договору
                            var order = _db.Orders.Where(x => x.HumanId == humanId).First();

                            
                            
                           
                            MenuItem menuItemCreateOrder = new MenuItem("Сформировать договор", CreateOrderForHuman);
                            MenuItem menuItemCreateOrderThreePersons = new MenuItem("Сформировать договор 3-х сторон", CreateOrderForThreePersons);
                            MenuItem menuItemAdditionalElectricity = new MenuItem("Сформировать договор на дополнительныеуслуги (Электроэнергия)", CreateAdditionaElectrocity);
                            MenuItem menuItemChangePassport = new MenuItem("Доп.соглашение (Замена паспорта)", CreatChangePassport);
                            MenuItem menuItemChangeHouse = new MenuItem("Доп.соглашение (Переселение)", CreatChangeHouse);
                            MenuItem menuItemKeepHouse = new MenuItem("Доп.соглашение (Продление проживания)", CreatKeepHouse);
                            MenuItem menuItemPay = new MenuItem("Доп.соглашение (Рассрочка оплаты)", CreatPay);

                            menu = new ContextMenu();
                            menu.MenuItems.Add(menuItemCreateOrder);
                            menu.MenuItems.Add(menuItemCreateOrderThreePersons);
                            menu.MenuItems.Add(menuItemAdditionalElectricity);
                            menu.MenuItems.Add(menuItemChangePassport);
                            menu.MenuItems.Add(menuItemKeepHouse);
                            menu.MenuItems.Add(menuItemPay);
                            menu.MenuItems.Add(menuItemChangeHouse);

                            if (order.Benifit == 1)
                            {
                                menu.MenuItems.Add(new MenuItem("Доп.соглашение (льготники)", CreatBenefitOrder));
                            }

                             
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
        

        //Menu Item Handler
        //Создание жильца 
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
        //Создание договора на жильца
        private void CreateOrderForHuman(object sender,EventArgs e)
        {
            if (TV_Hostels.SelectedNode != null) 
            {
                int humanId = Convert.ToInt32(TV_Hostels.SelectedNode.Tag.ToString());
                bool flag = WordExcelIO.CreateOrderForHuman(_db, humanId);

                if (flag == true)
                    MessageBox.Show("Договор создан!");
                else
                    MessageBox.Show("Ошибка при создании договора!");
            }
            
        }
        //Договор на дополнительные услуги (Электроэнергия) на жильца
        private void CreateAdditionaElectrocity(object sender,EventArgs e)
        {
            if(TV_Hostels.SelectedNode!=null)
            {
                int humanId = Convert.ToInt32(TV_Hostels.SelectedNode.Tag.ToString());
                bool flag = WordExcelIO.CreatAdditionalSettings(_db, 2, humanId);

                if (flag == true)
                    MessageBox.Show("Договор создан!");
                else
                    MessageBox.Show("Ошибка при создании договора!");
            }
        }
        private void CreatBenefitOrder(object sender,EventArgs e)
        {
            if (TV_Hostels.SelectedNode != null) 
            {
                int humanId = Convert.ToInt32(TV_Hostels.SelectedNode.Tag.ToString());
                bool flag = WordExcelIO.CreateBenefitOrder(_db, humanId);

                if (flag == true)
                    MessageBox.Show("Дополнение к договору сформировано успешно!");
                else
                    MessageBox.Show("Произошла ошибка при формировании дополнения к договору");
            }
        }
        private void CreatChangePassport(object sender, EventArgs e)
        {
            if (TV_Hostels.SelectedNode != null)
            {
                int humanId = Convert.ToInt32(TV_Hostels.SelectedNode.Tag.ToString());
                ChangePassport changePassport = new ChangePassport(_db, humanId);
                changePassport.ShowDialog();
                CreateTree();
            }
        }
        private void CreatChangeHouse(object sender, EventArgs e)
        {
            if (TV_Hostels.SelectedNode != null)
            {
                int humanId = Convert.ToInt32(TV_Hostels.SelectedNode.Tag.ToString());
                ChangeHouse changeHouse = new ChangeHouse(_db, humanId);
                changeHouse.ShowDialog();
                CreateTree();
            }
        }
        private void CreatKeepHouse(object sender, EventArgs e)
        {
            if (TV_Hostels.SelectedNode != null)
            {
                int humanId = Convert.ToInt32(TV_Hostels.SelectedNode.Tag.ToString());
                bool flag = WordExcelIO.CreateBenefitOrder(_db, humanId);

                if (flag == true)
                    MessageBox.Show("Дополнение к договору сформировано успешно!");
                else
                    MessageBox.Show("Произошла ошибка при формировании дополнения к договору");
            }
        }
        private void CreatPay(object sender, EventArgs e)
        {
            if (TV_Hostels.SelectedNode != null)
            {
                int humanId = Convert.ToInt32(TV_Hostels.SelectedNode.Tag.ToString());
                bool flag = WordExcelIO.CreateBenefitOrder(_db, humanId);

                if (flag == true)
                    MessageBox.Show("Дополнение к договору сформировано успешно!");
                else
                    MessageBox.Show("Произошла ошибка при формировании дополнения к договору");
            }
        }
        private void CreateOrderForThreePersons(object sender, EventArgs e)
        {
            if (TV_Hostels.SelectedNode != null)
            {
                int humanId = Convert.ToInt32(TV_Hostels.SelectedNode.Tag.ToString());
                OrderForThreePersons orderForThreePersons = new OrderForThreePersons(_db, humanId);
                orderForThreePersons.ShowDialog();
                
            }
        }
    }
}
