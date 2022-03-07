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
    /// Логика взаимодействия для PageUpdateClient.xaml
    /// </summary>
    public partial class PageUpdateClient : Page
    {
        public PageUpdateClient(Client client)
        {
            InitializeComponent();

            For_name.Text = client.for_name;
            Name.Text = client.name;
            Last_name.Text = client.last_name;
            Connection.Text = client.connection;
            Id_need.Text = Convert.ToString(client.id_need);
            CmbxType.Text = client.active;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Client> clients = ConnectOdb.conObj.Client.Where(x => x.id_client == ClassIdObj.Id_client).AsEnumerable().
                Select(x =>
                {
                    x.for_name = For_name.Text;
                    x.name = Name.Text;
                    x.last_name = Last_name.Text;
                    x.connection = Connection.Text;
                    x.id_need = Convert.ToInt32(Id_need.Text);
                    x.active = CmbxType.Text;
                    return x;
                });

            foreach (Client clnt in clients)
            {
                ConnectOdb.conObj.Entry(clnt).State = System.Data.Entity.EntityState.Modified;
            }
            ConnectOdb.conObj.SaveChanges();
            MessageBox.Show("Данные изменены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
