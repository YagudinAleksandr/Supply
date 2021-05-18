using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using Supply.Domain;
using Supply.Models;
using System.Linq;
using System.IO;

namespace Supply
{
    public partial class LoginForm : Form
    {
        private User _user;
        public LoginForm()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            string directory = domain.BaseDirectory;

            

            InitializeComponent();

            if (File.Exists(directory + "UserSettingsFile.xml"))
            {
                AppSettings.GetTemplateSetting("connectionString");
            }
            else
            {
                AppSettingsForm appSettingsForm = new AppSettingsForm();
                appSettingsForm.ShowDialog();
            }
        }

        private void BT_Enter_Click(object sender, EventArgs e)
        {
            if (TB_Login.Text == "")
            {
                MessageBox.Show("Введите логин!");
                return;
            }
            if(TB_Password.Text=="")
            {
                MessageBox.Show("Введите пароль!");
                return;
            }


            using(SupplyDbContext db = new SupplyDbContext())
            {
                User user = db.Users.Where(x => x.Login == TB_Login.Text).FirstOrDefault();
                if(user==null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    TB_Password.Text = "";
                    return;
                }
                if(user.Password!=GetHashPass(TB_Password.Text))
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    TB_Password.Text = "";
                    return;
                }
                _user = user;

                Log logInfo = new Log();
                logInfo.ID = Guid.NewGuid();
                logInfo.Type = "Вход в систему";
                logInfo.Caption = $"Удачный вход в систему пользователя: {_user.ID} - {_user.Name}";
                logInfo.CreatedAt = DateTime.Now.ToString();
                db.Logs.Add(logInfo);
                db.SaveChanges();
            }

            TB_Login.Text = String.Empty;
            TB_Password.Text = String.Empty;

            this.Hide();
            Form1 mainForm = new Form1(_user);
            mainForm.Show();
            mainForm.FormClosed += (object s, FormClosedEventArgs ev) => { this.Show(); };
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
