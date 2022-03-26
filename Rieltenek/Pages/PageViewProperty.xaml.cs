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
    /// Логика взаимодействия для PageViewProperty.xaml
    /// </summary>
    public partial class PageViewProperty : Page
    {
        public PageViewProperty(Photo photo)
        {
            InitializeComponent();

            Property Property = ConnectOdb.conObj.Property.Where(x => x.id_property == ClassIdObj.Id_property).FirstOrDefault();
            lblArea.Content = "Площадь: " + Property.area;
            lblRooms.Content = "Кол-во комнат: " + Property.number_of_rooms;
            lblFloor.Content = "Этаж: " + Property.floor_number;
            lblFloors.Content = "Кол-ва этажей: " + Property.number_of_floors;
            lblPrice.Content = "Цена: " + Property.price;
            lblType.Content = "Тип: " + Property.type_property;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += EditPhoto;
            timer.Start();

            ClassIdObj.NumPhoto = 1;

            void EditPhoto(object sender, object e)
            {
                switch (ClassIdObj.NumPhoto)
                {
                    case 1:
                        if(photo.photo_1 == null)
                        {
                            StringImage.Content = "../ImageProperty/1.jpg";
                        }
                        else
                        {
                            StringImage.Content = $"{photo.photo_1}";
                        }
                        break;
                    case 2:
                        if(photo.photo_2 == null)
                        {
                            StringImage.Content = $"{photo.photo_1}";
                            ClassIdObj.NumPhoto = 1;
                        }
                        else
                        {
                            StringImage.Content = $"{photo.photo_2}";
                        }
                        break;
                    case 3:
                        if (photo.photo_3 == null)
                        {
                            StringImage.Content = $"{photo.photo_1}";
                            ClassIdObj.NumPhoto = 1;
                        }
                        else
                        {
                            StringImage.Content = $"{photo.photo_3}";
                        }
                        break;
                    case 4:
                        if (photo.photo_4 == null)
                        {
                            StringImage.Content = $"{photo.photo_1}";
                            ClassIdObj.NumPhoto = 1;

                        }
                        else
                        {
                            StringImage.Content = $"{photo.photo_4}";
                        }
                        break;
                    case 5:
                        if (photo.photo_5 == null)
                        {
                            StringImage.Content = $"{photo.photo_1}";
                            ClassIdObj.NumPhoto = 1;
                        }
                        else
                        {
                            StringImage.Content = $"{photo.photo_5}";
                        }
                        break;
                    case 6:
                        if (photo.photo_6 == null)
                        {
                            StringImage.Content = $"{photo.photo_1}";
                            ClassIdObj.NumPhoto = 1;
                        }
                        else
                        {
                            StringImage.Content = $"{photo.photo_6}";
                        }
                        break;
                    case 7:
                        if (photo.photo_7 == null)
                        {
                            StringImage.Content = $"{photo.photo_1}";
                            ClassIdObj.NumPhoto = 1;
                        }
                        else
                        {
                            StringImage.Content = $"{photo.photo_7}";
                        }
                        break;
                    case 8:
                        if (photo.photo_8 == null)
                        {
                            StringImage.Content = $"{photo.photo_1}";
                            ClassIdObj.NumPhoto = 1;
                        }
                        else
                        {
                            StringImage.Content = $"{photo.photo_8}";
                        }
                        break;
                    case 9:
                        if (photo.photo_9 == null)
                        {
                            StringImage.Content = $"{photo.photo_1}";
                            ClassIdObj.NumPhoto = 1;

                        }
                        else
                        {
                            StringImage.Content = $"{photo.photo_9}";
                        }
                        break;
                    case 10:
                        if (photo.photo_10 == null)
                        {
                            StringImage.Content = $"{photo.photo_1}";
                            ClassIdObj.NumPhoto = 1;
                        }
                        else
                        {
                            StringImage.Content = $"{photo.photo_10}";
                        }
                        break;
                }
            }
        }

        private void btnBackPhoto_Click(object sender, RoutedEventArgs e)
        {
            if (ClassIdObj.NumPhoto == 1)
            {
                ClassIdObj.NumPhoto = 10;
            }
            else
            {
                ClassIdObj.NumPhoto -= 1;
            }
        }

        private void btnNextPhoto_Click(object sender, RoutedEventArgs e)
        {
            if(ClassIdObj.NumPhoto == 10)
            {
                ClassIdObj.NumPhoto = 1;
            }
            else
            {
                ClassIdObj.NumPhoto += 1;
            }
        }
    }
}
