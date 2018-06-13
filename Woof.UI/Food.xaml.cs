﻿using System;
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
            UpdateProgressFood();
            //TimerStart();
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
            UpdateProgressFood();
            animal.SleepPoints -= 1;
            animal.PoopPoints -= 1;
        }
        public void UpdateProgressFood()
        {
            ProgressFood.Value = animal.FoodPoints;
           
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
