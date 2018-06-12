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
           
            //UpdateProgressFood();
            //UpdateProgressSleep();
            //UpdateProgressPoop();

        }
        private void TimerStart()
        {
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            ProgressFood.Value -= 1;
            ProgressSleep.Value -= 1;
            ProgressPoop.Value -= 1;
        }
        public void UpdateProgressFood()
        {
            //Progress.Value =
        }
        public void UpdateProgressSleep()
        {
            //Progress.Value =
        }
        public void UpdateProgressPoop()
        {
            //Progress.Value =
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
