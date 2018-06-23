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
    /// Логика взаимодействия для SittingRoom.xaml
    /// </summary>
    public partial class SittingRoom : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        IRepository _storage = Factory.Instance.GetStorage();
        public SittingRoom()
        {
            InitializeComponent();
            
            var name = _storage.GetImageHelper(_storage.CurrentUser.Animal);
            img.Source = new ImageSourceConverter().ConvertFromString(_storage.GetAPath(name)) as ImageSource;
            //_storage.DecreaseNeeds();
            ProgressFood.Maximum = _storage.FindFoodPoints(_storage.FindSpecies(name));
            ProgressSleep.Maximum = _storage.FindSleepPoints(_storage.FindSpecies(name));
            ProgressPoop.Maximum = _storage.FindPoopPoints(_storage.FindSpecies(name));
            ProgressFood.Value = _storage.CurrentUser.Animal.FoodPoints;
            ProgressSleep.Value = _storage.CurrentUser.Animal.SleepPoints;
            ProgressPoop.Value = _storage.CurrentUser.Animal.PoopPoints;
            TimerStart();
            if(_storage.IsAnimalDead()==true)
            {
                timer.Stop();
                NavigationService.Navigate(new DeathPage());
            }
        }
        
        private void TimerStart()
        {
            timer.Tick += new EventHandler(TimerTick);
            timer.Tick += new EventHandler(_storage.NeedsDecrease);
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            ProgressFood.Value = _storage.CurrentUser.Animal.FoodPoints;
            ProgressSleep.Value = _storage.CurrentUser.Animal.SleepPoints;
            ProgressPoop.Value = _storage.CurrentUser.Animal.PoopPoints;
            frame.NavigationService.Refresh();
        }

        private void totheKitchen_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new Kitchen());
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
