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
    /// Логика взаимодействия для SleepAnimationPage.xaml
    /// </summary>
    public partial class SleepAnimationPage : Page
    {
        
        IRepository _storage = Factory.Instance.GetStorage();
        DispatcherTimer timer = new DispatcherTimer();

        public SleepAnimationPage()
        {
            InitializeComponent();
           
            var name = _storage.GetImageHelper(_storage.CurrentUser.Animal);
            ProgressSleep.Maximum = _storage.FindSleepPoints(_storage.FindSpecies(name));
            UpdateProgressSleep();
         
            TimerStart();
        }
        public void TimerStart()
        {
            
            timer.Tick += new EventHandler(TimerTick);
            timer.Tick += new EventHandler(_storage.Sleep_Increase);
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            UpdateProgressSleep();
        }

        public void UpdateProgressSleep()
        {
            ProgressSleep.Value = _storage.CurrentUser.Animal.SleepPoints;
            
            NavigationService navigation = frame.NavigationService;
            if (_storage.IsAnimalDead() == true)
            {
                timer.Stop();
                _storage.AnimalIsDead();
                navigation.Navigate(new DeathPage());
              
            }
            frame.NavigationService.Refresh();
        }
        private void wakingupButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new BedRoom());
        }
    }
}
