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

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            string IdCl = Id_clients.Text;
            if (IdCl == "")
            {
                Realtor  realtor = new Realtor()
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
                MessageBox.Show("Данные изменены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
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
                MessageBox.Show("Данные добавлены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string IdCl = Id_clients.Text;

            if (IdCl == "")
            {
                IEnumerable<Realtor> realtors = ConnectOdb.conObj.Realtor.Where(x => x.id_realtor == ClassIdObj.Id_realtor).AsEnumerable().
                 Select(x =>
                 {
                     x.for_name = For_name.Text;
                     x.name = Name.Text;
                     x.last_name = Last_name.Text;
                     x.coefficient = Convert.ToDouble(Coefficient.Text);
                     x.amount_of_deals = Convert.ToInt32(Amount_of_deals.Text);
                     x.id_clients = null;
                     return x;
                 });

                foreach (Realtor rltr in realtors)
                {
                    ConnectOdb.conObj.Entry(rltr).State = System.Data.Entity.EntityState.Modified;
                }

                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Данные изменены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                IEnumerable<Realtor> realtors = ConnectOdb.conObj.Realtor.Where(x => x.id_realtor == ClassIdObj.Id_realtor).AsEnumerable().
                 Select(x =>
                 {
                     x.for_name = For_name.Text;
                     x.name = Name.Text;
                     x.last_name = Last_name.Text;
                     x.coefficient = Convert.ToDouble(Coefficient.Text);
                     x.amount_of_deals = Convert.ToInt32(Amount_of_deals.Text);
                     x.id_clients = Convert.ToInt32(Id_clients.Text);
                     return x;
                 });

                foreach (Realtor rltr in realtors)
                {
                    ConnectOdb.conObj.Entry(rltr).State = System.Data.Entity.EntityState.Modified;
                }

                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Данные изменены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }

        private void ListRealtors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = ((Realtor)ListRealtors.SelectedItem).id_realtor;
            ClassIdObj.Id_realtor = id;
            Realtor realtor = ConnectOdb.conObj.Realtor.Where(x => x.id_realtor == id).FirstOrDefault();

            For_name.Text = realtor.for_name;
            Name.Text = realtor.name;
            Last_name.Text = realtor.last_name;
            Coefficient.Text = Convert.ToString(realtor.coefficient);
            Amount_of_deals.Text = Convert.ToString(realtor.amount_of_deals);
            Id_clients.Text = Convert.ToString(realtor.id_clients);
        }
    }
}
