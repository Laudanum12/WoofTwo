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
using WoofTwo.Classes;

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для Food.xaml
    /// </summary>
    public partial class Food : Page
    {
        public Animal animal { get; set; }
        public Food(Animal an)
        {
            InitializeComponent();
            animal = an;
        }

        private void OladushkiButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FastfoodButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PizzaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PechenyeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SushiButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EggsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void gobackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Kitchen(animal));
        }
    }
}
