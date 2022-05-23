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
    
    public partial class ReceiptPage : Page
    {
        private Thickness mrg = new Thickness(0, 10, 0, 10);
        public ReceiptPage()
        {
            InitializeComponent();
            LoadReceipts();
           
        }
        public ReceiptPage(string type)
        {
            InitializeComponent();
            LoadReceipts(type);

        }
        public ReceiptPage(string type, string name)
        {
            InitializeComponent();
            LoadReceipts(type,name);

        }
        Style tbstyle = Application.Current.FindResource("tbReceipt") as Style;
        Style btnstyle = App.Current.FindResource("btnStyleReceipt") as Style;
        private void LoadUI(List<Receipt> recs)
        {
            Connector.Connectors.Clear();
            foreach (var item in recs)
            {
                var wrp = new WrapPanel() { MaxHeight = 200, Margin = new Thickness(10), };
                var stck = new StackPanel()
                {
                    Margin = new Thickness(5),
                };
                var wrpBTns = new WrapPanel() { Margin=mrg};
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
                    Margin = new Thickness(0),
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
                if (item.User.Count > 0)
                {
                    if (item.User.Any(x => x.Id == HomeWindow.curUser.Id))
                    {
                        
                        Button btn = new Button()
                        {

                            Style = btnstyle,
                            Height = 30,
                            Margin= new Thickness(0,0,5,0),
                            Foreground = Brushes.Green,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Bottom,
                            Content = "Сохранено"
                        };
                        Button btn2 = new Button()
                        {

                            Style = btnstyle,
                            Height = 30,
                            Width = 100,
                            
                            Foreground = Brushes.Green,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Bottom,
                            Content = "Рецепт"
                        };
                        btn2.Click += Btn2_Click;
                        wrpBTns.Children.Add(btn);
                        wrpBTns.Children.Add(btn2);
                        stck.Children.Add(wrpBTns);
                        Connector.Connectors.Add(new Connector
                        {
                            btn = btn,
                            receipt = item, 
                            btn2 = btn2
                        });
                    }
                }
                else
                {
                    Button btn = new Button()
                    {

                        Style = btnstyle,
                        Height = 30,
                        Margin = new Thickness(0, 0, 5, 0),
                        
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        Content = "В избранное!"
                    };
                    Button btn2 = new Button()
                    {

                        Style = btnstyle,
                        Height = 30,
                        Width = 100,
                        Foreground = Brushes.Green,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        Content = "Рецепт"
                    };
                    btn.Click += Btn_Click;
                    btn2.Click += Btn2_Click;
                    wrpBTns.Children.Add(btn);
                    wrpBTns.Children.Add(btn2);
                    stck.Children.Add(wrpBTns);
                    Connector.Connectors.Add(new Connector
                    {
                        btn = btn,
                        receipt = item,
                        btn2 = btn2
                    });
                }

                wrp.Children.Add(new Image()
                {
                    Height = 180,
                    Width = 200,
                    Stretch = Stretch.Uniform,
                    Source = Operations.LoadImage(item.Photo)
                });
                wrp.Children.Add(stck);
                receiptsPanel.Children.Add(wrp);


            }
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            using (DbModelContainer db = new DbModelContainer())
            {
                var rec = Connector.Connectors.
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

        private void LoadReceipts()
        {
            using (DbModelContainer dbModel = new DbModelContainer())
            {
                
                LoadUI(dbModel.Receipts.ToList());
                
            }
        }
        private void LoadReceipts(string type)
        {
            using (DbModelContainer dbModel = new DbModelContainer())
            {
                
                var recs = new List<Receipt>();
                if (type != "Показать все")
                {
                    recs = dbModel.Receipts.Where(x =>
                    x.Type == type).ToList();
                }
                else
                {
                    recs = dbModel.Receipts.ToList();
                }
                LoadUI(recs);
            }
        }
        private void LoadReceipts(string type,string name)
        {
            using (DbModelContainer dbModel = new DbModelContainer())
            {
                
                
                var recs = new List<Receipt>();
                if(type != "Показать все")
                {
                    recs = dbModel.Receipts.Where(x => 
                    x.Type == type 
                    && 
                    x.Name.Contains(name)).ToList();

                }
                else
                {
                    recs = dbModel.Receipts.Where(x => x.Name.Contains(name)).ToList();
                }
                LoadUI((recs));
            }
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            using (DbModelContainer db = new DbModelContainer())
            {
                var rec = Connector.Connectors.
                    FirstOrDefault(x => x.btn == ((sender) as Button)).receipt;
                if(rec == null) return;
                var item = 
                    db.Receipts.
                    FirstOrDefault(y=>y.Id == rec.Id);
                if (item==null)
                {
                    
                    return;
                }
                var user = db.Users.FirstOrDefault(x => x.Id == HomeWindow.curUser.Id);
                user.Receipt.Add(item);
                (sender as Button).Foreground = Brushes.Green;
                (sender as Button).Content = "Сохранено";
                db.SaveChanges();
            }
        }
    }
}
