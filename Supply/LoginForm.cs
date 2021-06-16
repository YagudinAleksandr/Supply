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
            if (Properties.Settings.Default.connect == "") 
            {
                MessageBox.Show("Строка подключения к БД пустая!");
                AppSettingsForm appSettingsForm = new AppSettingsForm();
                appSettingsForm.ShowDialog();
            }
            else
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    if (!db.Database.Exists())
                    {
                        MessageBox.Show("Невозможно подключиться к базе данных!");
                        AppSettingsForm appSettingsForm = new AppSettingsForm();
                        appSettingsForm.ShowDialog();
                        Application.Restart();
                    }
                }
                    
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

                string error = FirstStart.Start();
                if(error!=string.Empty)
                {
                    Log logInfo = new Log();
                    logInfo.ID = Guid.NewGuid();
                    logInfo.Type = "ERROR";
                    logInfo.Caption = $"LoginForm.cs. Class: FirstStart. Method: Start."+error;
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(logInfo);
                    db.SaveChanges();
                }

                //Начало проверки на существование пользователя
                try
                {
                    User user = db.Users.Where(x => x.Login == TB_Login.Text).FirstOrDefault();
                    if (user == null)
                    {
                        MessageBox.Show("Пользователь с такими данными не найден!");
                        TB_Password.Text = "";
                        return;
                    }
                    if (user.Password != GetHashPass(TB_Password.Text))
                    {
                        MessageBox.Show("Пользователь с такими данными не найден!");
                        TB_Password.Text = "";
                        return;
                    }
                    _user = user;
                }
                catch(Exception ex)
                {
                    Log logInfo = new Log();
                    logInfo.ID = Guid.NewGuid();
                    logInfo.Type = "ERROR";
                    logInfo.Caption = $"LoginForm.cs. Login form exception." + ex.Message + "." + ex.InnerException;
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(logInfo);
                    db.SaveChanges();
                }

                
            }

            TB_Login.Text = String.Empty;
            TB_Password.Text = String.Empty;

            this.Hide();
            Form1 mainForm = new Form1(_user);
            mainForm.Show();
            mainForm.FormClosed += (object s, FormClosedEventArgs ev) => { this.Show(); };
        }

        
        /// <summary>
        /// Метод создания хэша 
        /// </summary>
        /// <param name="password">Строка с паролем</param>
        /// <returns>Хэш</returns>
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
