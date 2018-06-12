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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WoofTwo;
using WoofTwo.Classes;

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для BedRoom.xaml
    /// </summary>
    public partial class BedRoom : Page
    {
        public Animal animal { get; set; }
        IRepository _storage = Factory.Instance.GetStorage();
        BlurEffect ef = new BlurEffect();
        public BedRoom(Animal an)
        {
            InitializeComponent();
            animal = an;
            img.Source = new ImageSourceConverter().ConvertFromString(_storage.GetAPath(animal.Species.SpeciesName)) as ImageSource;
        }

        private void totheKitchen_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Kitchen(animal));
        }

        private void totheSittingRoom_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SittingRoom(animal));
        }

        private void totheWC_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WC(animal));
        }

        private void letssleepButton_Click(object sender, RoutedEventArgs e)
        {
            ef.Radius = 10;
            Effect = ef;
            NavigationService.Navigate(new SleepAnimationPage(animal));
            ef.Radius = 0;
            Effect = ef;
        }
        public void Simulator()
        {

        }
    }
}
