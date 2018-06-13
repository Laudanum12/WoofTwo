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
using WoofTwo.Classes;

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для SleepAnimationPage.xaml
    /// </summary>
    public partial class SleepAnimationPage : Page
    {
        public Animal animal { get; set; }
        DispatcherTimer timer = new DispatcherTimer();
        public SleepAnimationPage(Animal an)
        {
            InitializeComponent();
            animal = an;
            UpdateProgressSleep();
            TimerStart();
        }
        public void TimerStart()
        {
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            animal.FoodPoints -= 1;
            animal.SleepPoints -= 1;
            UpdateProgressSleep();
            animal.PoopPoints -= 1;
        }
        public void UpdateProgressSleep()
        {
            ProgressSleep.Value = animal.SleepPoints;
        }
        private void wakingupButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BedRoom(animal));
        }
    }
}
