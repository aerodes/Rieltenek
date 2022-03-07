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
    /// Логика взаимодействия для PageNeeds.xaml
    /// </summary>
    public partial class PageNeeds : Page
    {
        public PageNeeds()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }

        public void UpdateData(object sender, object e)
        {
            var Need = ConnectOdb.conObj.Need.ToList();
            ListNeeds.ItemsSource = Need;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Need need = new Need()
            {
                area = Convert.ToInt32(Area.Text),
                price_MAX = Convert.ToDecimal(Price_MAX.Text),
                number_of_rooms = Convert.ToInt32(Number_of_rooms.Text),
                number_of_floors = Convert.ToInt32(Number_of_floors.Text),
                floor_number = Convert.ToInt32(Floor_number.Text),
                type_property = CmbxType.Text
            };

            ConnectOdb.conObj.Need.Add(need);
            ConnectOdb.conObj.SaveChanges();
            MessageBox.Show("Потребность добавлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ClassIdObj.Id_need = ((Need)ListNeeds.SelectedItem).id_need;
            Need need = ConnectOdb.conObj.Need.Where(x => x.id_need == ClassIdObj.Id_need).FirstOrDefault();

            FrameObj.frameMain.Navigate(new PageUpdateNeed(need));
        }
    }
}
