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
    /// Логика взаимодействия для Food.xaml
    /// </summary>
    public partial class Food : Page
    {
        public Animal animal { get; set; }
        IRepository _storage = Factory.Instance.GetStorage();
        DispatcherTimer timer = new DispatcherTimer();
        public Food(Animal an)
        {
            InitializeComponent();
            animal = an;
            var name = _storage.GetImageHelper(animal);
            ProgressFood.Maximum = _storage.FindFoodPoints(_storage.FindSpecies(name));
            UpdateProgressFood();
            _storage.DecreaseNeeds();
            //TimerStart();
        }
        public void TimerStart()
        {
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            UpdateProgressFood();
        }

        public void UpdateProgressFood()
        {
            NavigationService navigation = frame.NavigationService;
            ProgressFood.Value = animal.FoodPoints;
            //if (animal.FoodPoints == 0)
            //{
            //    NavigationService.Navigate(new DeathPage());
            //}
            //frame.NavigationService.Refresh();
            if (_storage.IsAnimalDead() == true)
            {
                NavigationService.Navigate(new DeathPage());
            }

        }
        private void OladushkiButton_Click(object sender, RoutedEventArgs e)
        {
            _storage.IncreaseFoodValue(int.Parse(OladushkiLabel.Text));
            UpdateProgressFood();
        }

        private void FastfoodButton_Click(object sender, RoutedEventArgs e)
        {
            _storage.IncreaseFoodValue(int.Parse(FastfoodLabel.Text));
            UpdateProgressFood();
        }

        private void PizzaButton_Click(object sender, RoutedEventArgs e)
        {
            _storage.IncreaseFoodValue(int.Parse(PizzaLabel.Text));
            UpdateProgressFood();
        }

        private void PechenyeButton_Click(object sender, RoutedEventArgs e)
        {
            _storage.IncreaseFoodValue(int.Parse(PechenyeLabel.Text));
            UpdateProgressFood();
        }

        private void SushiButton_Click(object sender, RoutedEventArgs e)
        {
            _storage.IncreaseFoodValue(int.Parse(SushiLabel.Text));
            UpdateProgressFood();
        }

        private void EggsButton_Click(object sender, RoutedEventArgs e)
        {
            _storage.IncreaseFoodValue(int.Parse(EggsLabel.Text));
            if (animal.FoodPoints == 0)
            {
                NavigationService.Navigate(new DeathPage());
            }
            UpdateProgressFood();
        }

        private void gobackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Kitchen(animal));
            UpdateProgressFood();
        }
    }
}
