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
    /// Логика взаимодействия для PageClients.xaml
    /// </summary>
    public partial class PageClients : Page
    {
        public PageClients()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            timer.Tick += UpdateData;
            timer.Start();
        }

        public void UpdateData(object sender, object e)
        {
            var Client = ConnectOdb.conObj.Client.ToList();
            ListClients.ItemsSource = Client;
            ListClients.ItemsSource = ConnectOdb.conObj.Client.Where(c => c.for_name.StartsWith(Name.Text)
                                                                         || c.name.StartsWith(Name.Text)
                                                                         || c.last_name.StartsWith(Name.Text)
                                                                         || c.active.StartsWith(CmbxType.Text)).ToList();
        }

        private void btnCreateClient_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageCreateClient());
        }

        private void btnUpdateClient_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Client)ListClients.SelectedItem).id_client;

            ClassIdObj.Id_client = id;

            Client client = ConnectOdb.conObj.Client.Where(c => c.id_client == id).FirstOrDefault();
            FrameObj.frameMain.Navigate(new PageUpdateClient(client));
        }
    }
}
