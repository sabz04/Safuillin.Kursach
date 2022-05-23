using Safuillin.Kursach.DBModel;
using Safuillin.Kursach.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Safuillin.Kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            MainWindow.main.logpageBTN.Opacity = 1;
            MainWindow.main.regpageBTN.Opacity = 0.5;
        }

 

        private void submitBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Regist(logTB.Text, passTB.Text));
        }

        public static string Regist(string login, string password)
        {
            string role = "";
            if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password))
            {
                return "Поля не должны быть пустыми.";
            }
            using (DbModelContainer db = new DbModelContainer())
            {
                var user = db.Users.FirstOrDefault(x => x.Login == login &&
                                                      x.Password == password);
                if (user != null)
                {
                    return "Вы уже есть в моей базе, пройдите авторизацию!";
                }
                if (login == "admin" &&password == "admin")
                {
                    role = "admin";
                }
                else
                {
                    role = "user";
                }
                db.Users.Add(
                    new User() { Login = login, Password = password, Receipt = null, Role = role });
                db.SaveChanges();
                return "Регистрация успешна!";
            }
        }
    }
}
