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

namespace Rieltenek.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCreateRealtor.xaml
    /// </summary>
    public partial class PageCreateRealtor : Page
    {
        public PageCreateRealtor()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string IdCl = Id_clients.Text;
            if (IdCl == "")
            {
                Realtor realtor = new Realtor()
                {
                    for_name = For_name.Text,
                    name = Name.Text,
                    last_name = Last_name.Text,
                    coefficient = Convert.ToDouble(Coefficient.Text),
                    amount_of_deals = Convert.ToInt32(Amount_of_deals.Text),
                    id_clients = null
                };

                ConnectOdb.conObj.Realtor.Add(realtor);
                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Риэлтор добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                FrameObj.frameMain.GoBack();
            }
            else
            {
                Realtor realtor = new Realtor()
                {
                    for_name = For_name.Text,
                    name = Name.Text,
                    last_name = Last_name.Text,
                    coefficient = Convert.ToDouble(Coefficient.Text),
                    amount_of_deals = Convert.ToInt32(Amount_of_deals.Text),
                    id_clients = Convert.ToInt32(IdCl)
                };

                ConnectOdb.conObj.Realtor.Add(realtor);
                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Риэлтор добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                FrameObj.frameMain.GoBack();
            }
        }
    }
}
