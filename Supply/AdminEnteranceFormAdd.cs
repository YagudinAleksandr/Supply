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
    public partial class AdminEnteranceFormAdd : Form
    {
        private int _enteranceID = 0;
        private int _hostelID = 0;
        public AdminEnteranceFormAdd(int hostelID)
        {
            InitializeComponent();
            _hostelID = hostelID;
        }

        public AdminEnteranceFormAdd(int enteranceID, int hostelID)
        {
            InitializeComponent();
            _enteranceID = enteranceID;
            _hostelID = hostelID;
        }

        private void AdminEnteranceFormAdd_Shown(object sender, EventArgs e)
        {
            if (_enteranceID != 0) 
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    Enterance enterance = db.Enterances.Where(x => x.ID == _enteranceID).FirstOrDefault();

                    if (enterance == null)
                    {
                        MessageBox.Show("Подъезд не найден!");
                        this.Close();

                    }

                    TB_Name.Text = enterance.Name;
                }
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (_enteranceID == 0)
            {
                Enterance enterance = new Enterance();
                enterance.Name = TB_Name.Text;
                enterance.HostelId = _hostelID;

                using(SupplyDbContext db = new SupplyDbContext())
                {
                    try
                    {
                        db.Enterances.Add(enterance);
                        db.SaveChanges();
                        MessageBox.Show("Подъезд создан успешно!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(LogCreation));
                        thread.Start($"Class: AdminEnteranceFormAdd. Method: BTN_Save_Click. {ex.Message}. {ex.InnerException}");

                        MessageBox.Show(ex.Message);
                    }
                }

                
            }
            else
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Enterance enterance = db.Enterances.Where(x => x.ID == _enteranceID).FirstOrDefault();

                    if(enterance==null)
                    {
                        MessageBox.Show("Подъезд не найден!");
                        this.Close();
                    }

                    enterance.Name = TB_Name.Text;

                    try
                    {
                        db.Entry(enterance).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Данные изменены успешно!");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(LogCreation));
                        thread.Start($"Class: AdminEnteranceFormAdd. Method: BTN_Save_Click. {ex.Message}. {ex.InnerException}");

                        MessageBox.Show(ex.Message);
                    }
                }
            }
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
    }
}
