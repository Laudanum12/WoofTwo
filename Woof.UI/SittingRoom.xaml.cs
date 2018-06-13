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
        
        public Animal animal { get; set; }
        public SittingRoom(Animal an)
        {
            InitializeComponent();
            animal = an;
            var name = _storage.GetImageHelper(animal);
            img.Source = new ImageSourceConverter().ConvertFromString(_storage.GetAPath(name)) as ImageSource;
            _storage.DecreaseNeeds();
            UpdateProgressFood();
            UpdateProgressSleep();
            UpdateProgressPoop();
            TimerStart();
        }
        private void TimerStart()
        {
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            UpdateProgressFood();
            UpdateProgressSleep();
            UpdateProgressPoop(); 
        }

        public void UpdateProgressFood()
        {
            ProgressFood.Value = animal.FoodPoints;
        }
        public void UpdateProgressSleep()
        {
            ProgressSleep.Value = animal.SleepPoints;
        }
        public void UpdateProgressPoop()
        {
            ProgressPoop.Value = animal.PoopPoints;
        }

        private void totheKitchen_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Kitchen(animal));
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
