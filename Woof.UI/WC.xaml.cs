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
    /// Логика взаимодействия для WC.xaml
    /// </summary>
    public partial class WC : Page
    {
        IRepository _storage = Factory.Instance.GetStorage();
        
        DispatcherTimer timer = new DispatcherTimer();
        public WC()
        {
            InitializeComponent();
           
            var name = _storage.GetImageHelper(_storage.CurrentUser.Animal);
            img.Source = new ImageSourceConverter().ConvertFromString(_storage.GetAPath(name)) as ImageSource;
            ProgressPoop.Maximum = _storage.FindPoopPoints(_storage.FindSpecies(name));
            UpdateProgressPoop();
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
            UpdateProgressPoop();
        }
        public void UpdateProgressPoop()
        {
            ProgressPoop.Value = _storage.CurrentUser.Animal.PoopPoints;
            if (_storage.IsAnimalDead() == true)
            {
                timer.Stop();
                _storage.AnimalIsDead();
                NavigationService.Navigate(new DeathPage());
            }
        }
        private void totheBedroom_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new BedRoom());
        }

        private void totheKitchen_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new Kitchen());
        }

        private void totheSittingRoom_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new SittingRoom());
        }

        private void poppButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new PoopAnimationPage());
        }
        
    }
}
