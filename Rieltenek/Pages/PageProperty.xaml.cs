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
using System.Windows.Threading;
using Rieltenek.ConnectBD;
using Rieltenek.Pages;

namespace Rieltenek.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProperty.xaml
    /// </summary>
    public partial class PageProperty : Page
    {
        public PageProperty()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += UpdateData;
            timer.Start();
        }

        public void UpdateData(object sender, object e)
        {
            var Property = ConnectOdb.conObj.Property.ToList();
            ListProperty.ItemsSource = Property;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Property property = new Property()
            {
                area = Convert.ToDouble(Area.Text),
                number_of_rooms = Convert.ToInt32(Number_of_rooms.Text),
                number_of_floors = Convert.ToInt32(Number_of_floors.Text),
                floor_number = Convert.ToInt32(Floor_number.Text),
                price = Convert.ToDecimal(Price.Text),
                type_property = CmbxType.Text
                
            };

            ConnectOdb.conObj.Property.Add(property);
            ConnectOdb.conObj.SaveChanges();
            MessageBox.Show("Недвижимость добавлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ClassIdObj.Id_property = ((Property)ListProperty.SelectedItem).id_property;
            Property property = ConnectOdb.conObj.Property.Where(x => x.id_property == ClassIdObj.Id_property).FirstOrDefault();
            FrameObj.frameMain.Navigate(new PageUpdateProperty(property));
        }
    }
}
