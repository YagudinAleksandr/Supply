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

namespace Supply_Admin
{
    public partial class ChangePassport : Form
    {
        private SupplyDbContext _db;
        private int _humanId;
        public ChangePassport(SupplyDbContext db, int humanId)
        {
            InitializeComponent();
            _db = db;
            _humanId = humanId;
        }

        private void ChangePassport_Load(object sender, EventArgs e)
        {
            var human = _db.Humen.Where(x => x.Id == _humanId).First();
            var order = _db.Orders.Where(x => x.HumanId == _humanId).First();

            LB_OrderNumber.Text = order.Id.ToString();

            TB_Name.Text = human.Name;
            TB_Surename.Text = human.Surename;
            TB_Patronimic.Text = human.Patronymic;
            TB_Code.Text = human.GivenCode;
            TB_Citizenship.Text = human.Citizenship;
            TB_GivenDate.Text = human.GivenDate;
            RTB_Given.Text = human.Given;
            TB_Series.Text = human.Series;
            TB_Number.Text = human.Number;
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            try
            {
                var human = _db.Humen.Where(x => x.Id == _humanId).First();

                human.Surename = TB_Surename.Text;
                human.Name = TB_Name.Text;
                human.Patronymic = TB_Patronimic.Text;
                human.Number = TB_Number.Text;
                human.Series = TB_Series.Text;
                human.GivenCode = TB_Code.Text;
                human.Given = RTB_Given.Text;
                human.GivenDate = TB_GivenDate.Text;
                human.Citizenship = TB_Citizenship.Text;

                _db.Entry(human).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                bool flag = WordExcelIO.CreateChangePassport(_db, _humanId);

                if(flag == true)
                {
                    MessageBox.Show("Все создано!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Возникла ошибка!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка!");
                return;
            }
        }
    }
}
