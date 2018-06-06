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

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для SigningUp.xaml
    /// </summary>
    public partial class SigningUp : Page
    {
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
