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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Safuillin.Kursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow main = new MainWindow();
        public MainWindow()
        {
            InitializeComponent();
            main = this;
            mainFrame.Navigate(new LogPage());
        }
        private void regpageBTN_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new RegPage());
            
        }

        private void logpageBTN_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new LogPage());
            
        }

        private void exitBTN_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
