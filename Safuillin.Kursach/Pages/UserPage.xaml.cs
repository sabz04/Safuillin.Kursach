using Safuillin.Kursach.DBModel;
using Safuillin.Kursach.Models;
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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            LoadReceipts();
        }
        Style tbstyle = Application.Current.FindResource("tbReceipt") as Style;
        Style btnstyle = App.Current.FindResource("btnStyleReceipt") as Style;
        
        private void LoadReceipts()
        {
            using (DbModelContainer dbModel = new DbModelContainer())
            {
                Connector.DelConnectors.Clear();
                var mrg = new Thickness(0, 10, 0, 10);

                var user = dbModel.Users.FirstOrDefault(x => x.Id == HomeWindow.curUser.Id);
                if (user == null) return;
                foreach (var item in user.Receipt)
                {
                    var wrp = new WrapPanel() { MaxHeight = 200, Margin = new Thickness(10), };
                    var wrpBTNS = new WrapPanel() { Margin = mrg };
                    var stck = new StackPanel()
                    {
                        Margin = new Thickness(5),

                    };
                    var wrpBtn = new WrapPanel()
                    {
                        Margin = mrg

                    };
                    wrpBtn.Children.Add(new Image
                    {
                        Margin = new Thickness(0, 0, 5, 0),
                        Height = 20,
                        Source = new BitmapImage(new Uri(@"/Images/clock.png", UriKind.Relative))
                    });
                    wrpBtn.Children.Add(new TextBlock()
                    {
                        Text = item.Time,
                        Margin = mrg,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Left,
                        Style = tbstyle
                    });

                    stck.Children.Add(new TextBlock()
                    {
                        Text = item.Type,
                        FontSize = 14,
                        Foreground = Brushes.LightSeaGreen,

                        Style = tbstyle
                    });
                    stck.Children.Add(new TextBlock()
                    {
                        Text = item.Name,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Left,
                        MaxWidth = 500,
                        FontWeight = FontWeights.Bold,
                        FontSize = 26,
                        Margin = mrg,
                        Style = tbstyle,

                    });

                    stck.Children.Add(wrpBtn);
                    Button btn = new Button()
                    {

                        Style = btnstyle,
                        Height = 30,
                        FontSize = 18,
                        Margin = new Thickness(0,0,5,0),
                        Foreground = Brushes.OrangeRed,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        Content = "Удалить"
                    };
                    Button btn2 = new Button()
                    {

                        Style = btnstyle,
                        Height = 30,
                        Width = 100,
                        FontSize = 18,
                        Foreground = Brushes.Green,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        Content = "Рецепт"
                    };
                    wrpBTNS.Children.Add(btn);
                    wrpBTNS.Children.Add(btn2);
                    btn.Click += Btn_Click;
                    btn2.Click += Btn2_Click;
                    stck.Children.Add(wrpBTNS);
                    wrp.Children.Add(new Image()
                    {
                        Height = 180,
                        Width = 200,
                        Stretch = Stretch.Uniform,
                        Source = Operations.LoadImage(item.Photo)
                    });
                    wrp.Children.Add(stck);
                    receiptsPanel.Children.Add(wrp);
                    Connector.DelConnectors.Add(new Connector
                    {
                        btn = btn,
                        receipt = item, btn2=btn2,
                    });
                    

                }
                var backBTN = new Button()
                {

                    Style = btnstyle,
                    Height = 30,
                    Margin = mrg,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Content = "<-Назад"
                };
                backBTN.Click += BackBTN_Click;
                receiptsPanel.Children.Add(backBTN);
            }
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            using (DbModelContainer db = new DbModelContainer())
            {
                var rec = Connector.DelConnectors.
                    FirstOrDefault(x => x.btn2 == ((sender) as Button)).receipt;
                if (rec == null) return;
                var item =
                    db.Receipts.
                    FirstOrDefault(y => y.Id == rec.Id);
                if (item == null)
                {

                    return;
                }
                MessageBox.Show($"~Рецепт приготовления {item.Name}:\n{ item.Desc}\n~Приятного аппетита!");
            }
        }
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow.home.mainFrame.Navigate(new ReceiptPage());
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            using (DbModelContainer db = new DbModelContainer())
            {
                var rec = Connector.DelConnectors.
                    FirstOrDefault(x => x.btn == ((sender) as Button)).receipt;
                if (rec == null) return;
                var item =
                    db.Receipts.
                    FirstOrDefault(y => y.Id == rec.Id);
                if (item == null)
                {
                    
                    return;
                }
                var user = db.Users.FirstOrDefault(x => x.Id == HomeWindow.curUser.Id);
                user.Receipt.Remove(item);
                
                
                db.SaveChanges();
                HomeWindow.home.mainFrame.Navigate(new UserPage()); 
            }
        }
    }
}
