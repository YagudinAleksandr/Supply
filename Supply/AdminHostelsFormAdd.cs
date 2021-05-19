using Supply.Domain;
using Supply.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminHostelsFormAdd : Form
    {
        private int _selectedIndexOfManagers;
        private int _selectedIndexOfAddresses;
        public AdminHostelsFormAdd()
        {
            InitializeComponent();
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (TB_EnterancesCount.Text == "")
            {
                MessageBox.Show("Заполните количество подъездов!");
                return;
            }
            if (TB_HostelName.Text == "")
            {
                MessageBox.Show("Заполните название!");
                return;
            }
            if (TB_FlatsCount.Text == "")
            {
                MessageBox.Show("Заполните колличество этажей!");
                return;
            }
            if (_selectedIndexOfAddresses == 0) 
            {
                MessageBox.Show("Выбирите адрес!");
                return;
            }
            if (_selectedIndexOfManagers == 0) 
            {
                MessageBox.Show("Выбирите заведующего!");
                return;
            }

            Hostel hostel = new Hostel()
            {
                Name = TB_HostelName.Text,
                AddressID = _selectedIndexOfAddresses,
                ManagerId = _selectedIndexOfManagers
            };
            
            

            using(SupplyDbContext db = new SupplyDbContext())
            {
                try
                {
                    db.Hostels.Add(hostel);
                    db.SaveChanges();

                    for (int i = 0; i < int.Parse(TB_EnterancesCount.Text); i++)
                    {
                        Enterance enterance = new Enterance();
                        enterance.Name = (i + 1).ToString();
                        enterance.HostelId = hostel.ID;
                        db.Enterances.Add(enterance);
                        db.SaveChanges();

                        for (int j = 0; j < int.Parse(TB_FlatsCount.Text); j++)
                        {
                            Flat flat = new Flat();
                            flat.Name = (j + 1).ToString();
                            flat.Enterance_ID = enterance.ID;
                            db.Flats.Add(flat);
                            db.SaveChanges();
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
            }

            MessageBox.Show($"Общежитие {TB_HostelName.Text} добавлено успешно!");
            this.Close();
        }

        private void AdminHostelsFormAdd_Shown(object sender, EventArgs e)
        {
            _selectedIndexOfAddresses = _selectedIndexOfManagers = 0;

            using(SupplyDbContext db = new SupplyDbContext())
            {
                var addresses = db.Adresses.ToList();

                for (int i = 0; i < addresses.Count; i++)
                {
                    addresses[i].Country += "," + addresses[i].Region + "," + addresses[i].City + "," + addresses[i].Street + "," + addresses[i].House + "," + addresses[i].Housing;
                }

                CB_Addresses.DataSource = addresses;
                CB_Addresses.DisplayMember = "Country";
                CB_Addresses.ValueMember = "ID";


                var managers = db.Managers.ToList();

                for(int i =0;i<managers.Count;i++)
                {
                    managers[i].Surename += " " + managers[i].Name + " " + managers[i].Patronymic;
                }

                CB_Managers.DataSource = managers;
                CB_Managers.DisplayMember = "Surename";
                CB_Managers.ValueMember = "ID";
            }
        }

        private void CB_Addresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _selectedIndexOfAddresses = (int)CB_Addresses.SelectedValue;
                
            }
            catch
            {
                return;
            }
        }

        private void CB_Managers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _selectedIndexOfManagers = (int)CB_Managers.SelectedValue;
                
            }
            catch
            {
                return;
            }
        }
    }
}
