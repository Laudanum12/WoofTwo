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

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для PetsChoosing.xaml
    /// </summary>
    public partial class PetsChoosing : Page
    {
        public PetsChoosing()
        {
            InitializeComponent();
        }

        private void dinosaurButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NameGiving());
        }

        private void catbugButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NameGiving());
        }

        private void rabbitButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NameGiving());
        }

        private void foxButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NameGiving());
        }

        private void dogButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NameGiving());
        }

        private void deerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NameGiving());
        }
    }
}
