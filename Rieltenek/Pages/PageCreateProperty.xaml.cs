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
    /// Логика взаимодействия для PageCreateProperty.xaml
    /// </summary>
    public partial class PageCreateProperty : Page
    {
        public PageCreateProperty()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if ((Area.Text != "") && (Price.Text != "") && (Number_of_rooms.Text != "") && (Number_of_floors.Text != "") && (Floor_number.Text != ""))
            {
                Property property = new Property()
                {
                    area = Convert.ToDouble(Area.Text),
                    number_of_rooms = Convert.ToInt32(Number_of_rooms.Text),
                    number_of_floors = Convert.ToInt32(Number_of_floors.Text),
                    floor_number = Convert.ToInt32(Floor_number.Text),
                    price = Convert.ToDecimal(Price.Text),
                    type_property = CmbxType.Text

                };

                ConnectOdb.conObj.Property.Add(property);
                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Недвижимость добавлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                FrameObj.frameMain.GoBack();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
