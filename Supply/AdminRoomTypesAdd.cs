using Supply.Domain;
using Supply.Models;
using System;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminRoomTypesAdd : Form
    {
        public AdminRoomTypesAdd()
        {
            InitializeComponent();
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if(TB_Name.Text=="")
            {
                MessageBox.Show("Заполните поле Название!");
                return;
            }

            using(SupplyDbContext db = new SupplyDbContext())
            {
                RoomType roomType = new RoomType();
                roomType.Name = TB_Name.Text;

                db.RoomTypes.Add(roomType);
                db.SaveChanges();
            }
            MessageBox.Show("Тип комнаты добавлен успещно!");
            this.Close();
        }
    }
}
