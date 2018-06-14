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
using WoofTwo;
using WoofTwo.Classes;

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для Kitchen.xaml
    /// </summary>
    public partial class Kitchen : Page
    {
        
        IRepository _storage = Factory.Instance.GetStorage();
        DispatcherTimer timer = new DispatcherTimer();
        public Kitchen()
        {
            InitializeComponent();
            
           
            img.Source = new ImageSourceConverter().ConvertFromString(_storage.GetAPath(_storage.GetImageHelper(_storage.CurrentUser.Animal))) as ImageSource;
            ProgressFood.Maximum = _storage.FindFoodPoints(_storage.FindSpecies(_storage.GetImageHelper(_storage.CurrentUser.Animal)));
            //img.Source = new ImageSourceConverter().ConvertFromString(_storage.GetAPath(animal.Species.SpeciesName)) as ImageSource;

           // _storage.DecreaseNeeds();
            UpdateProgressFood();
            TimerStart();
        }
        public void TimerStart()
        {
            timer.Tick += new EventHandler(TimerTick);
            timer.Tick += new EventHandler(_storage.NeedsDecrease);
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            UpdateProgressFood();
        }

        private void foodButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new Food(_storage.CurrentUser.Animal));
        }
        public void UpdateProgressFood()
        {
            NavigationService navigation = frame.NavigationService;
            ProgressFood.Value = _storage.CurrentUser.Animal.FoodPoints;
            if (_storage.IsAnimalDead() == true)
            {
                timer.Stop();
                _storage.AnimalIsDead();
                navigation.Navigate(new DeathPage());
            }
            frame.NavigationService.Refresh();
        }

        private void totheSittingRoom_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new SittingRoom());
        }

        private void totheBedroom_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new BedRoom());
        }

        private void totheWC_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new WC());
        }
    }
}
