using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using WoofTwo;

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для SigningUp.xaml
    /// </summary>
    public partial class SigningUp : Page
    {
        IRepository _storage = Factory.Instance.GetStorage();

        public SigningUp()
        {
            InitializeComponent();
        }

        private void signingupButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PetsChoosing());
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogIn());
        }

        private void pswrdCheckBox_Click(object sender, RoutedEventArgs e)
        {
            //Image a = new Image();
            BitmapImage bi3 = new BitmapImage();
            //string path = System.IO.Path.GetFullPath("кролик.png");
            //bi3.BeginInit();

            //bi3.UriSource = new Uri("../../../Woof.UI/Images/backgrounds/гостиная1.jpg", UriKind.Relative);
            //bi3.EndInit();
            //pet.Stretch = Stretch.Fill;
            //pet.Source = bi3;
            
            
           
            Uri imgUri = new Uri(_storage.FindImages());
            ImageSource img = new BitmapImage(imgUri);
            pet.Source = img;
           // \WoofTwo\Woof.UI\Images\pets
            //pet.Source = new BitmapImage(new Uri(, "/ assets / your_image.png"));
            //var favouritesJsonAll =
            //  GetEmbeddedResourceAsString("Woof.UI.Images.pets.скотч.png");
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                pswrdTextBox.Text = pswrdPasswordBox.Password;
                pswrdTextBox.Visibility = Visibility.Visible;
                pswrdPasswordBox.Visibility = Visibility.Hidden;
            }
            else
            {
                pswrdPasswordBox.Password = pswrdTextBox.Text;
                pswrdTextBox.Visibility = Visibility.Hidden;
                pswrdPasswordBox.Visibility = Visibility.Visible;
            }
        }

        private void cityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private string GetEmbeddedResourceAsString(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var names = assembly.GetManifestResourceNames();

            string result;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Image pet = sender as Image;
            BitmapImage bitmapImage = new BitmapImage();
            pet.Width = bitmapImage.DecodePixelWidth = 80; //natural px width of image source
                                                           // don't need to set Height, system maintains aspect ratio, and calculates the other
                                                           // dimension, so long as one dimension measurement is provided
            //bitmapImage.UriSource = new Uri(pet.BaseUri, "Images/myimage.png");
        }
    }
}
