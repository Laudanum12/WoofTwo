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
using WoofTwo;
using WoofTwo.Classes;
using WoofTwo.Helpers;

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        IRepository _storage = Factory.Instance.GetStorage();
        
        public LogIn()
        {
            InitializeComponent();
            
            ShowsNavigationUI = false;
            
        }

        private void pswrdCheckBox_Click(object sender, RoutedEventArgs e)
        {
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

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var pswrd = pswrdPasswordBox.Password;
            if (_storage.UserInStorage(login, pswrd) != null)
            {
                if (_storage.UserInStorage(login, pswrd).Animal == null)
                    NavigationService.Navigate(new PetsChoosing());
                else {
                    var animal = _storage.FindAnimal(_storage.CurrentUser);
                    _storage.DecreaseNeeds();
                    NavigationService.Navigate(new SittingRoom(animal));
                }
               
            }
            else
            {
                MessageBox.Show("Please make sure that you've entered your login and password correctly", "Error");
            }

        }

        private void signupButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SigningUp());
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                loginButton_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
