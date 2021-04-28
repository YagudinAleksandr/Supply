﻿using Supply.Domain;
using Supply.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminHostelsForm : Form
    {
        public AdminHostelsForm()
        {
            InitializeComponent();
        }

        private void AdminHostelsForm_Shown(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn1.HeaderText = "Комнаты";
            dataGridViewButtonColumn1.Name = "COL_Settings";
            dataGridViewButtonColumn1.Text = "Комнаты";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            DG_Hostels.Columns.Add(dataGridViewButtonColumn1);

            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.HeaderText = "Настройки";
            dataGridViewButtonColumn2.Name = "COL_Settings";
            dataGridViewButtonColumn2.Text = "Изменить";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            DG_Hostels.Columns.Add(dataGridViewButtonColumn2);

            DataGridViewButtonColumn dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn3.HeaderText = "Удалить";
            dataGridViewButtonColumn3.Name = "COL_Delete";
            dataGridViewButtonColumn3.Text = "Удалить";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            DG_Hostels.Columns.Add(dataGridViewButtonColumn3);
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                DG_Hostels.Rows.Clear();

                try
                {
                    foreach(Hostel hostel in db.Hostels.Include(a=>a.Address).Include(m=>m.Manager))
                    {
                        int rowNumber = DG_Hostels.Rows.Add();

                        DG_Hostels.Rows[rowNumber].Cells[COL_ID.Name].Value = hostel.ID;
                        DG_Hostels.Rows[rowNumber].Cells[COL_Name.Name].Value = hostel.Name;
                        DG_Hostels.Rows[rowNumber].Cells[COL_Manager.Name].Value = hostel.Manager.Surename + " " + hostel.Manager.Name + " " + hostel.Manager.Patronymic;
                        DG_Hostels.Rows[rowNumber].Cells[COL_Address.Name].Value = hostel.Address.ZipCode + ", " + hostel.Address.Country + "," + hostel.Address.Region + "," + hostel.Address.City + "," + hostel.Address.Street + "," + hostel.Address.House;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BTN_OpenHostelAddWindow_Click(object sender, EventArgs e)
        {
            AdminHostelsFormAdd adminHostelsFormAdd = new AdminHostelsFormAdd();
            adminHostelsFormAdd.ShowDialog();
            UpdateInfo();
        }

        private void DG_Hostels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==4)//Комнаты
            {
                int hostelid = 0;
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    int id = int.Parse(DG_Hostels.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Hostel hostel = db.Hostels.Where(x => x.ID == id).First();
                    if (hostel != null)
                    {
                        hostelid = hostel.ID;
                        
                    }
                    else
                    {
                        MessageBox.Show("Общежитие не найдено!");
                    }

                    AdminRoomsForm adminRoomsForm = new AdminRoomsForm(hostelid);
                    adminRoomsForm.ShowDialog();
                }
                
            }
        }
    }
}
