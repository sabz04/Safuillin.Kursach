using Safuillin.Kursach.DBModel;
using Safuillin.Kursach.Models;
using Safuillin.Kursach.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private Receipt rec;
        private byte[] _data;
        public AdminPage()
        {
            InitializeComponent();
            LoadRecs();
        }
        private void LoadRecs()
        {
            receiptsGrid.ItemsSource = null;
            receiptsGrid.Items.Clear();
            
            using (DbModelContainer db = new DbModelContainer())
            {
                foreach(var item in db.Receipts)
                {
                    receiptsGrid.Items.Add(new MyData()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Time = item.Time,
                        ImageFile = Operations.LoadImage(item.Photo),
                        Type = item.Type
                    });
                }
            }
        }

        private void receiptsGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if((sender as DataGrid).SelectedItem == null) return;
            var item = (MyData)(sender as DataGrid).SelectedItem;
            if (item == null) return;
            using (DbModelContainer db = new DbModelContainer())
            {
                
                var curRec = db.Receipts.FirstOrDefault(x => x.Id == item.Id);
                rec = curRec;
                if (curRec == null) return;
                _data = curRec.Photo;
                logTB.Text = curRec.Name;
                timeTB.Text = curRec.Time;
                typeTB.Text = curRec.Type;
                descTB.Text = curRec.Desc;
                recIMG.Source = Operations.LoadImage(curRec.Photo);
            }
        }

        private void submitBTN_Click(object sender, RoutedEventArgs e)
        {
            
            if (rec == null) return;
            using (DbModelContainer db = new DbModelContainer())
            {
                var curRec = db.Receipts.FirstOrDefault(x => x.Id == rec.Id);
                if (curRec == null) return;
               
                curRec.Name = logTB.Text;
                curRec.Time = timeTB.Text;
                curRec.Type = typeTB.Text;
                curRec.Photo = _data;
                curRec.Desc = descTB.Text;
                db.SaveChanges();
                LoadRecs();
                HomeWindow.home.LoadCB();
            }
        }


        private void deleteBTN_Click(object sender, RoutedEventArgs e)
        {
            if(rec == null) return; 
            using (DbModelContainer db = new DbModelContainer())
            {
                var curRec = db.Receipts.FirstOrDefault(x => x.Id == rec.Id);
                if(curRec == null) return;
                curRec.User.Clear();
                db.Receipts.Remove(curRec);
                db.SaveChanges();
                LoadRecs();
                HomeWindow.home.LoadCB();
            }
        }

        private void addBTN_Click(object sender, RoutedEventArgs e)
        {
            using (DbModelContainer db = new DbModelContainer())
            {
                if (_data == null)
                {
                    _data = File.ReadAllBytes(@"../Images/icon.png");
                }
                Receipt rec = ValidateRec(logTB.Text, timeTB.Text, descTB.Text, typeTB.Text, _data);
                if (rec != null)
                {
                    db.Receipts.Add(rec);
                    db.SaveChanges();
                    LoadRecs();
                    HomeWindow.home.LoadCB();
                }
                else
                {
                    MessageBox.Show("Проверьте поля");
                }
            }
        }

        public static Receipt ValidateRec(string naim, string time, string desc, string type, byte[] photo)
        {
            if (String.IsNullOrEmpty(naim) || String.IsNullOrEmpty(time) || String.IsNullOrEmpty(desc) || String.IsNullOrEmpty(type)) return null;
            return new Receipt()
            {
                Name = naim,
                Time = time,
                Desc = desc,
                Type = type,
                Photo = photo
            };
        }

        private void recIMG_Drop(object sender, DragEventArgs e)
        {
            using (DbModelContainer db = new DbModelContainer())
            {
                var user = db.Users.FirstOrDefault(
                    x => x.Login == HomeWindow.curUser.Login && x.Password == HomeWindow.curUser.Password);
                if (user == null)
                {
                    MessageBox.Show("empty user");
                    return;
                }
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    // Note that you can have more than one file.
                    byte[] file = File.ReadAllBytes(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);

                    _data = file;
                    recIMG.Source = Operations.LoadImage(file);

                    // Assuming you have one file that you care about, pass it off to whatever
                    // handling code you have defined.
                }
            }
        }

        private void recIMG_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            byte[] data = Operations.GetByteFileFromExplorer();
            _data = data;
            if(data == null)
            {
                recIMG.Source = Operations.LoadImage(File.ReadAllBytes(@"../Images/icon.png"));
                return;
            }
            recIMG.Source = Operations.LoadImage(data);
        }

        private void backBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

public partial class MyData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Time { get; set; }
    public BitmapImage ImageFile { get; set; }

}