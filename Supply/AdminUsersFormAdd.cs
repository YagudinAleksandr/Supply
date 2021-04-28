using Supply.Domain;
using Supply.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Supply
{
    public partial class AdminUsersFormAdd : Form
    {
        private int _selectedIndexOfRole;
        public AdminUsersFormAdd()
        {
            InitializeComponent();
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if(TB_Name.Text=="")
            {
                MessageBox.Show("Заполните поле Ф.И.О.!");
                return;
            }
            if(TB_Login.Text=="")
            {
                MessageBox.Show("Заполните поле Логин!");
                return;
            }
            if(TB_Password.Text=="")
            {
                MessageBox.Show("Заполните поле Пароль!");
                return;
            }
            if(_selectedIndexOfRole==0)
            {
                MessageBox.Show("Выбирите роль!");
                return;
            }

            using(SupplyDbContext db = new SupplyDbContext())
            {
                User user = new User();
                user.Name = TB_Name.Text;
                user.Login = TB_Login.Text;
                user.Password = GetHashPass(TB_Password.Text);
                user.RoleID = _selectedIndexOfRole;

                db.Users.Add(user);
                db.SaveChanges();
            }

            MessageBox.Show($"Пользователь {TB_Name.Text} успешно добавлен в систему! Логин: {TB_Login.Text} Пароль: {TB_Password.Text}");
            this.Close();
        }

        private void AdminUsersFormAdd_Shown(object sender, EventArgs e)
        {
            _selectedIndexOfRole = 0;

            using (SupplyDbContext db = new SupplyDbContext())
            {
                var roles = db.Roles.ToList();

                CB_Roles.DataSource = roles;
                CB_Roles.DisplayMember = "Title";
                CB_Roles.ValueMember = "ID";
            }
        }

        private void CB_Roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _selectedIndexOfRole = (int)CB_Roles.SelectedValue;

            }
            catch
            {
                return;
            }
        }
        string GetHashPass(string password)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(password);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}
