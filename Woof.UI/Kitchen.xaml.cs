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

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для Kitchen.xaml
    /// </summary>
    public partial class Kitchen : Page
    {
        public Animal animal { get; set; }
        IRepository _storage = Factory.Instance.GetStorage();
        public Kitchen(Animal an)
        {
            InitializeComponent();
            animal = an;
            img.Source = new ImageSourceConverter().ConvertFromString(_storage.GetAPath(animal.Species.SpeciesName)) as ImageSource;
            //UpdateProgressFood();
        }

        private void foodButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Food());
        }
        public void UpdateProgressFood()
        {
            //ProgressFood.Value =
        }

        private void totheSittingRoom_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SittingRoom(animal));
        }

        private void totheBedroom_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BedRoom(animal));
        }

        private void totheWC_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WC(animal));
        }
    }
}
