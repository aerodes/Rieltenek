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
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
        }

        private void btnProperty_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageProperty());
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageClients());

        }

        private void btnNeeds_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageNeeds());

        }

        private void btnCreateNeed_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateClient_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageCreateClient());

        }

        private void btnComparison_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageComparison());

        }

        private void btnRealtor_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageRealtors());
        }
    }
}
