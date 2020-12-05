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
using Supply_Admin.Models;

namespace Supply_Admin
{
    public partial class HumanCreate : Form
    {
        SupplyDbContext _db;
        
        public HumanCreate(SupplyDbContext db)
        {
            InitializeComponent();
            _db = db;

            try
            {
                var hostels = db.Hostels.ToList();
                CB_HostelNumber.DataSource = hostels;
                CB_HostelNumber.DisplayMember = "Name";
                CB_HostelNumber.ValueMember = "Id";
            }
            catch
            {
                Close();
            }
        }

        private void CB_HostelNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rooms = _db.Rooms.Where(x => x.HostelId == (int)CB_HostelNumber.SelectedValue).ToList();
            CB_RoomNumber.DataSource = rooms;
            CB_RoomNumber.DisplayMember = "Name";
            CB_RoomNumber.ValueMember = "Id";
        }
        private void CB_RoomNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BTN_SaveHuman_Click(object sender, EventArgs e)
        {
            Human human = new Human();
            
            try
            {
                human.Name = TB_Name.Text;
                human.Surename = TB_Surename.Text;
                human.Patronymic = TB_Patronymic.Text;

                if (TB_PhoneNumber.Text != null)
                    human.PhoneNumber = TB_PhoneNumber.Text;

                human.DocType = CB_DocType.SelectedItem.ToString();
                human.Series = TB_Series.Text;
                human.Number = TB_NumberOfDoc.Text;
                human.GivenDate = TB_GivenDate.Text;
                human.Citizenship = TB_Citizen.Text;
                human.Given = RTB_Given.Text;
                if (TB_GivenCode.Text != null)
                    human.GivenCode = TB_GivenCode.Text;
                human.Registration = TB_Registration.Text;

                if (CB_Benifit.Checked)
                {
                    human.Benifit = 1;
                    human.BenifitCategory = CB_BenifitCategory.SelectedItem.ToString();
                    human.BenifitBase = RTB_BenifitBase.Text;
                    human.BenefitStart = TB_StartDate.Text;
                    human.BenefitEnd = TB_EndDate.Text;
                }
                else human.Benifit = 0;

                human.ToTime = CB_ToTime.SelectedItem.ToString();
                human.OrderStart = TB_OrderStart.Text;
                human.OrderEnd = TB_OrderEnd.Text;

                if (CB_ToTime.SelectedItem.ToString() != "работы")
                    human.EducationType = CB_EducationType.SelectedItem.ToString();

                human.RoomId = (int)CB_RoomNumber.SelectedValue;

                human.Status = 1;

                _db.Humen.Add(human);
                _db.SaveChanges();
                MessageBox.Show("Жилец успешно сохранен");

                TB_Name.Clear();
                TB_Surename.Clear();
                TB_Patronymic.Clear();
                TB_PhoneNumber.Clear();
                TB_Series.Clear();
                TB_StartDate.Clear();
                TB_Registration.Clear();
                RTB_BenifitBase.Clear();
                TB_EndDate.Clear();
                TB_OrderEnd.Clear();
                TB_OrderStart.Clear();
                TB_Citizen.Clear();
                TB_GivenDate.Clear();
                TB_GivenDate.Clear();
                RTB_Given.Clear();
                TB_NumberOfDoc.Clear();
                TB_GivenCode.Clear();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка! Попробуйте ещё раз!");
            }
            
            

        }

        
    }
}
