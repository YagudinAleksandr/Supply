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
    public partial class OrderForThreePersons : Form
    {
        private SupplyDbContext _db;
        private int _humnaId;
        public OrderForThreePersons(SupplyDbContext db,int humanId)
        {
            InitializeComponent();
            _db = db;
            _humnaId = humanId;
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            bool flag = false;
            Dictionary<string, string> information = new Dictionary<string, string>();

            information.Add("Surename", TB_Surename.Text);
            information.Add("Name", TB_Name.Text);
            information.Add("Patronymic", TB_Patronymic.Text);
            information.Add("Serie", TB_Series.Text);
            information.Add("Number", TB_Number.Text);
            information.Add("Citizenship", TB_Citizenship.Text);
            information.Add("Code", TB_Code.Text);
            information.Add("Given", RTB_Given.Text);
            information.Add("GivenDate", TB_GivenDate.Text);
            information.Add("Registration", RTB_Registartion.Text);

            flag = WordExcelIO.CreateOrderForThreePersons(_db, _humnaId, information);

            if(flag==true)
            {
                MessageBox.Show("Документ сформирован");
                Close();
            }
            else
            {
                MessageBox.Show("Возникли проблемы с созданием документа!");
                return;
            }
        }
    }
}
