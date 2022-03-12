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
    /// Логика взаимодействия для PageCreateClient.xaml
    /// </summary>
    public partial class PageCreateClient : Page
    {
        public PageCreateClient()
        {
            InitializeComponent();
            lblLastNeed.Content = ClassIdObj.LastNeed;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client()
            {
                for_name = For_name.Text,
                name = Name.Text,
                last_name = Last_name.Text,
                connection = Connection.Text,
                id_need = Convert.ToInt32(Id_need.Text),
                active = CmbxType.Text
            };

            ConnectOdb.conObj.Client.Add(client);
            ConnectOdb.conObj.SaveChanges();
            MessageBox.Show("Клиент добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
