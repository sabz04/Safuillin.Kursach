using Safuillin.Kursach.DBModel;
using Safuillin.Kursach.Pages;
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
using System.Windows.Shapes;

namespace Safuillin.Kursach.Windows
{
    /// <summary>
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public static User curUser = new User();
        public static HomeWindow home = new HomeWindow();
        public HomeWindow()
        {
            InitializeComponent();
            LoadCB();
            home = this;
            if(curUser.Role == "admin")
                adminBTN.Visibility = Visibility.Visible;
            else
                adminBTN.Visibility = Visibility.Hidden;
            
            mainFrame.Navigate(new ReceiptPage());
        }
        public void LoadCB()
        {
            typeCB.Items.Clear();
            using (DbModelContainer db = new DbModelContainer())
            {
                var types = db.Receipts.ToList().Select(x => x.Type).Distinct();
                types.ToList().ForEach(type => typeCB.Items.Add(type));
                typeCB.Items.Add("Показать все");
            }
        }

        private void exitBTN_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            
            MainWindow main = new MainWindow();
            main.Show();

        }

        private void likedBTN_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new UserPage());
        }

        private void typeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typeCB.SelectedItem == null) return;
            if (searchTB.Text == "" || searchTB.Text == " ")
                mainFrame.Navigate(new ReceiptPage(typeCB.SelectedItem.ToString()));
            else
            {
                mainFrame.Navigate(new ReceiptPage(typeCB.SelectedItem.ToString(), searchTB.Text));
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (typeCB.SelectedItem == null) return;
            mainFrame.Navigate(new ReceiptPage(typeCB.SelectedItem.ToString(), searchTB.Text));
        }

        private void adminBTN_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(
                                new AdminPage());
        }
    }
}
