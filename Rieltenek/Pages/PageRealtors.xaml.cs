using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для PageRealtors.xaml
    /// </summary>
    public partial class PageRealtors : Page
    {
        public PageRealtors()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += UpdateData;
            timer.Start();
        }

        public void UpdateData(object sender, object e)
        {
            ListRealtors.ItemsSource = ConnectOdb.conObj.Realtor.Where(c => c.for_name.StartsWith(Search.Text)
                                                                         || c.name.StartsWith(Search.Text)
                                                                         || c.last_name.StartsWith(Search.Text)).ToList();
        }

        private void btnCreateRealtor_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageCreateRealtor());
        }

        private void btnUpdateRealtor_Click(object sender, RoutedEventArgs e)
        {
            if (ListRealtors.SelectedValue != null)
            {
                int id = ((Realtor)ListRealtors.SelectedItem).id_realtor;
                Realtor realtor = ConnectOdb.conObj.Realtor.Where(x => x.id_realtor == id).FirstOrDefault();
                FrameObj.frameMain.Navigate(new PageUpdateRealtor(realtor));
            }
            else
            {
                MessageBox.Show("Выберите риэлтора!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
