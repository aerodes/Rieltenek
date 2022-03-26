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
    /// Логика взаимодействия для PageUpdateProperty.xaml
    /// </summary>
    public partial class PageUpdateProperty : Page
    {
        public PageUpdateProperty(Property property)
        {
            InitializeComponent();

            Area.Text = Convert.ToString(property.area);
            Price.Text = Convert.ToString(property.price);
            Number_of_rooms.Text = Convert.ToString(property.number_of_rooms);
            Number_of_floors.Text = Convert.ToString(property.number_of_floors);
            Floor_number.Text = Convert.ToString(property.floor_number);
            CmbxType.Text = property.type_property;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if ((Area.Text != "") && (Price.Text != "") && (Number_of_rooms.Text != "") && (Number_of_floors.Text != "") && (Floor_number.Text != ""))
            {
                IEnumerable<Property> properties = ConnectOdb.conObj.Property.Where(x => x.id_property == ClassIdObj.Id_property).AsEnumerable().
                Select(x =>
                {
                    x.area = Convert.ToDouble(Area.Text);
                    x.price = Convert.ToDecimal(Price.Text);
                    x.number_of_rooms = Convert.ToInt32(Number_of_rooms.Text);
                    x.number_of_floors = Convert.ToInt32(Number_of_floors.Text);
                    x.floor_number = Convert.ToInt32(Floor_number.Text);
                    x.type_property = CmbxType.Text;
                    return x;
                });
                foreach (Property prprt in properties)
                {
                    ConnectOdb.conObj.Entry(prprt).State = System.Data.Entity.EntityState.Modified;
                }
                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Протребность изменена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
