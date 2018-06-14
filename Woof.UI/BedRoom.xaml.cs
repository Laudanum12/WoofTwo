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
using System.Windows.Threading;
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
        DispatcherTimer timer = new DispatcherTimer();
        public BedRoom(Animal an)
        {
            InitializeComponent();
            animal = an;
            var name = _storage.GetImageHelper(animal);
            img.Source = new ImageSourceConverter().ConvertFromString(_storage.GetAPath(name)) as ImageSource;
            ProgressSleep.Maximum = _storage.FindSleepPoints(_storage.FindSpecies(name));
            //_storage.DecreaseNeeds();
            UpdateProgressSleep();
            TimerStart();
        }
        private void TimerStart()
        {
            timer.Tick += new EventHandler(TimerTick);
            timer.Tick += new EventHandler(_storage.NeedsDecrease);
            timer.Interval = new TimeSpan(0, 0, 15);
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            UpdateProgressSleep();
        }

        public void UpdateProgressSleep()
        {
            ProgressSleep.Value = animal.SleepPoints;
            if (_storage.IsAnimalDead() == true)
            {
                timer.Stop();
                _storage.AnimalIsDead();
                NavigationService.Navigate(new DeathPage());
            }
            frame.NavigationService.Refresh();
        }
        private void totheKitchen_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new Kitchen(animal));
        }

        private void totheSittingRoom_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new SittingRoom(animal));
        }

        private void totheWC_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new WC(animal));
        }

        private void letssleepButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new SleepAnimationPage(animal));
            
        }
        
    }
}
