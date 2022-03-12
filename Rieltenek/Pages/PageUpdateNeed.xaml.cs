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
    /// Логика взаимодействия для PageUpdateNeed.xaml
    /// </summary>
    public partial class PageUpdateNeed : Page
    {
        public PageUpdateNeed(Need need)
        {
            InitializeComponent();

            Area.Text = Convert.ToString(need.area);
            Price.Text = Convert.ToString(need.price_MAX);
            Number_of_rooms.Text = Convert.ToString(need.number_of_rooms);
            Number_of_floors.Text = Convert.ToString(need.number_of_floors);
            Floor_number.Text = Convert.ToString(need.floor_number);
            CmbxType.Text = need.type_property;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string FNstr = Floor_number.Text;
            if (FNstr != "")
            {
                IEnumerable<Need> needs = ConnectOdb.conObj.Need.Where(x => x.id_need == ClassIdObj.Id_need).AsEnumerable().
                Select(x =>
                {
                    x.area = Convert.ToDouble(Area.Text);
                    x.price_MAX = Convert.ToDecimal(Price.Text);
                    x.number_of_rooms = Convert.ToInt32(Number_of_rooms.Text);
                    x.number_of_floors = Convert.ToInt32(Number_of_floors.Text);
                    x.floor_number = Convert.ToInt32(FNstr);
                    x.type_property = CmbxType.Text;
                    return x;
                });
                foreach (Need nd in needs)
                {
                    ConnectOdb.conObj.Entry(nd).State = System.Data.Entity.EntityState.Modified;
                }
                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Потребность изменена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                IEnumerable<Need> needs = ConnectOdb.conObj.Need.Where(x => x.id_need == ClassIdObj.Id_need).AsEnumerable().
                Select(x =>
                {
                    x.area = Convert.ToDouble(Area.Text);
                    x.price_MAX = Convert.ToDecimal(Price.Text);
                    x.number_of_rooms = Convert.ToInt32(Number_of_rooms.Text);
                    x.number_of_floors = Convert.ToInt32(Number_of_floors.Text);
                    x.floor_number = null;
                    x.type_property = CmbxType.Text;
                    return x;
                });
                foreach (Need nd in needs)
                {
                    ConnectOdb.conObj.Entry(nd).State = System.Data.Entity.EntityState.Modified;
                }
                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Потребность изменена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
