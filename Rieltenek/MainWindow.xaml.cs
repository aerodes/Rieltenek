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
using Rieltenek.ConnectBD;
using Rieltenek.Pages;

namespace Rieltenek
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ConnectOdb.conObj = new ReltorsAgencyEntities();
            FrameObj.frameMain = FrmMain;

            FrmMain.Navigate(new PageMain());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.GoBack();
        }

        private void btnFaq_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
