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
    /// Логика взаимодействия для PageUpdateRealtor.xaml
    /// </summary>
    public partial class PageUpdateRealtor : Page
    {
        public PageUpdateRealtor(Realtor realtor)
        {
            InitializeComponent();

            For_name.Text = realtor.for_name;
            Name.Text = realtor.name;
            Last_name.Text = realtor.last_name;
            Coefficient.Text = Convert.ToString(realtor.coefficient);
            Amount_of_deals.Text = Convert.ToString(realtor.amount_of_deals);
            Id_clients.Text = Convert.ToString(realtor.id_clients);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if ((For_name.Text != "") && (Name.Text != "") && (Last_name.Text != "") && (Coefficient.Text != "") && (Amount_of_deals.Text != ""))
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

                    FrameObj.frameMain.GoBack();
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

                    FrameObj.frameMain.GoBack();
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
