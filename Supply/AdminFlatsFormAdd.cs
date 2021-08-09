using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminFlatsFormAdd : Form
    {
        private int _enteranceID, _flatID;

        public AdminFlatsFormAdd(int enteranceID)
        {
            InitializeComponent();
            _enteranceID = enteranceID;
            _flatID = 0;
        }
        public AdminFlatsFormAdd(int enteranceID, int flatID)
        {
            InitializeComponent();
            _enteranceID = enteranceID;
            _flatID = flatID;
        }

        private void LogCreation(object information)
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
        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (_enteranceID != 0 && _flatID != 0)
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Flat flat = db.Flats.Where(x => x.ID == _flatID).FirstOrDefault();
                    if (flat == null)
                    {
                        MessageBox.Show("Этаж не найден!");
                        this.Close();
                    }

                    flat.Name = TB_Name.Text;

                    try
                    {
                        db.Entry(flat).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Данные изменены успешно!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(LogCreation));
                        thread.Start($"Class: AdminFlatsFormAdd. Method: BTN_Save_Click. {ex.Message}. {ex.InnerException}");

                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                Flat flat = new Flat();
                flat.Name = TB_Name.Text;
                flat.Enterance_ID = _enteranceID;

                using (SupplyDbContext db = new SupplyDbContext())
                {
                    try
                    {
                        db.Flats.Add(flat);
                        db.SaveChanges();

                        MessageBox.Show("Этаж добавлен успешно!");

                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(LogCreation));
                        thread.Start($"Class: AdminFlatsFormAdd. Method: BTN_Save_Click. {ex.Message}. {ex.InnerException}");

                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void AdminFlatsFormAdd_Shown(object sender, EventArgs e)
        {
            if (_enteranceID != 0 && _flatID != 0)
            {
                using (SupplyDbContext db = new SupplyDbContext()) 
                {
                    Flat flat = db.Flats.Where(x => x.ID == _flatID).FirstOrDefault();
                    if (flat == null)
                    {
                        MessageBox.Show("Этаж не найден!");
                        this.Close();
                    }

                    TB_Name.Text = flat.Name;
                }
            }
        }
    }
}
