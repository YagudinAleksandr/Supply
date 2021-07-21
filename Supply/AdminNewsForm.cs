using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminNewsForm : Form
    {
        public AdminNewsForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Information information = new Information();
            information.ID = Guid.NewGuid();
            information.CreatedAt = DateTime.Now.ToString();
            information.UpdatedAt = DateTime.Now.ToString();
            information.StartInformation = TB_StartDate.Text;
            information.EndInformation = TB_EndDate.Text;
            information.Status = true;
            information.Title = TB_Title.Text;
            information.Topic = TB_News.Text;

            try
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    db.Informations.Add(information);
                    db.SaveChanges();
                    MessageBox.Show("Новость добавлена успешно!");
                }
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.ID = Guid.NewGuid();
                log.Type = "ERROR";
                log.CreatedAt = DateTime.Now.ToString();
                log.Caption = $"Class: AdminNewsForm. Method:Button1_Click. " + ex.Message + "." + ex.InnerException;
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    db.Logs.Add(log);
                    db.SaveChanges();
                }
                MessageBox.Show(ex.Message);
            }
        }
    }
}
