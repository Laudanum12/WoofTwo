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
        public Animal animal { get; set; }
        public WC(Animal an)
        {
            InitializeComponent();
            animal = an;
            var name = _storage.GetImageHelper(animal);
            img.Source = new ImageSourceConverter().ConvertFromString(_storage.GetAPath(name)) as ImageSource;
            UpdateProgressPoop();
        }
        
        public void UpdateProgressPoop()
        {
            _storage.NormalizePoopValue(true);
            ProgressPoop.Value = animal.PoopPoints;
            if (animal.PoopPoints == 0)
            {
                NavigationService.Navigate(new DeathPage());
            }
        }
        private void totheBedroom_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BedRoom(animal));
        }

        private void totheKitchen_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Kitchen(animal));
        }

        private void totheSittingRoom_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SittingRoom(animal));
        }

        private void poppButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PoopAnimationPage(animal));
        }
        
    }
}
