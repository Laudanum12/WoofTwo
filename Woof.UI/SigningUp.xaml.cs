using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
using WoofTwo.Helpers;

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
            var login = loginTextBox.Text;
            var email = emailTextBox.Text;
            var pswrd = PasswordHelper.GetHash(pswrdPasswordBox.Password);
            var city = cityComboBox.SelectedItem.ToString();
            if (login !="" || email !="" || pswrd !="" || city != null)
            {
                if (_storage.CanAddUser(login) == true)
                {
                    _storage.AddUSer(city, DateTime.Now, email, pswrd, login);
                    NavigationService.Navigate(new PetsChoosing());
                }
                else MessageBox.Show("Such login already exists!", "Oops!", MessageBoxButton.OK);
            }
            else MessageBox.Show("You can't left any fields empty!", "Oops!", MessageBoxButton.OK);

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogIn());
        }

        private void pswrdCheckBox_Click(object sender, RoutedEventArgs e)
        {

            //Uri imgUri = new Uri(_storage.FindImages());
            //ImageSource img = new BitmapImage(imgUri);
            //pet.Source = img; //пользовательская картинка

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


    }
}
