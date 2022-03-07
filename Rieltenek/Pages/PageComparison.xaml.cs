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

namespace Rieltenek.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageComparison.xaml
    /// </summary>
    public partial class PageComparison : Page
    {
        public PageComparison()
        {
            InitializeComponent();

            var client = ConnectOdb.conObj.Client.ToList();
            ListClient.ItemsSource = client;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += UpdateClient;
            timer.Start();

        }
        public void UpdateClient(object sender, object e)
        {
            ListClient.ItemsSource = ConnectOdb.conObj.Client.Where(c => c.for_name.StartsWith(Name.Text)
                                                                         || c.name.StartsWith(Name.Text)
                                                                         || c.last_name.StartsWith(Name.Text)).ToList();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Client)ListClient.SelectedItem).id_need;

            Need need = ConnectOdb.conObj.Need.Where(c => c.id_need == id).FirstOrDefault();

            var Property = ConnectOdb.conObj.Property.ToList();
            ListProperty.ItemsSource = Property.Where(x => x.price <= need.price_MAX);
        }
    }
}
