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
    /// Логика взаимодействия для LogPage.xaml
    /// </summary>
    public partial class LogPage : Page
    {
        public LogPage()
        {
            InitializeComponent();
            MainWindow.main.logpageBTN.Opacity = 0.5;
            MainWindow.main.regpageBTN.Opacity = 1;
        }

        private void submitBTN_Click(object sender, RoutedEventArgs e)
        {

            User user = Login(logTB.Text, passTB.Text);
            if (user != null)
            {
                HomeWindow.curUser = user;
                MainWindow.main.Hide();

                HomeWindow homeWindow = new HomeWindow();
                homeWindow.Show();
                return;
            }
            MessageBox.Show("Пройдите регистрацию!");

        }

        public static User Login(string login, string password)
        {
            using (DbModelContainer db = new DbModelContainer())
            {
                return db.Users.FirstOrDefault(x => x.Login == login &&
                                                          x.Password == password);
            }
        }
    }
}
