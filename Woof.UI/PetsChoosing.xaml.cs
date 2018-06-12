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
using WoofTwo;
using WoofTwo.Classes;

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для PetsChoosing.xaml
    /// </summary>
    public partial class PetsChoosing : Page
    {
        IRepository _storage = Factory.Instance.GetStorage();
        public PetsChoosing()
        {
            InitializeComponent();
        }

        private void dinosaurButton_Click(object sender, RoutedEventArgs e)
        {
            //var animal = new Animal
            //{
            //    Species = _storage.FindSpecies(Dinosaur.Name),
            //    SpeciesId = _storage.FindSpecies(Dinosaur.Name).SpeciesId
            //};
            NavigationService.Navigate(new NameGiving(_storage.AddIncompleteAnimal(Dinosaur.Name)));
        }

        private void catbugButton_Click(object sender, RoutedEventArgs e)
        {

            //var animal = new Animal
            //{
            //    Species = _storage.FindSpecies(Catbug.Name),
            //    SpeciesId = _storage.FindSpecies(Catbug.Name).SpeciesId
            //};
            NavigationService.Navigate(new NameGiving(_storage.AddIncompleteAnimal(Catbug.Name)));
        }

        private void rabbitButton_Click(object sender, RoutedEventArgs e)
        {
            //var animal = new Animal
            //{
            //    Species = _storage.FindSpecies(Rabbit.Name),
            //    SpeciesId = _storage.FindSpecies(Rabbit.Name).SpeciesId
            //};
            NavigationService.Navigate(new NameGiving(_storage.AddIncompleteAnimal(Rabbit.Name)));
        }

        private void foxButton_Click(object sender, RoutedEventArgs e)
        {
            //var animal = new Animal
            //{
            //    Species = _storage.FindSpecies(Fox.Name),
            //    SpeciesId = _storage.FindSpecies(Fox.Name).SpeciesId
            //};
            NavigationService.Navigate(new NameGiving(_storage.AddIncompleteAnimal(Fox.Name)));
        }

        private void dogButton_Click(object sender, RoutedEventArgs e)
        {
            //var animal = new Animal
            //{
            //    Species = _storage.FindSpecies(),
            //    SpeciesId = _storage.FindSpecies(Dog.Name).SpeciesId
            //};
            NavigationService.Navigate(new NameGiving(_storage.AddIncompleteAnimal(Dog.Name)));
        }

        private void deerButton_Click(object sender, RoutedEventArgs e)
        {
            //_storage.AddIncompleteAnimal(Deer.Name);
            //var animal = new Animal
            //{
            //    Species = _storage.FindSpecies(Deer.Name),
            //    SpeciesId = _storage.FindSpecies(Deer.Name).SpeciesId,
                
                
            //};
            NavigationService.Navigate(new NameGiving(_storage.AddIncompleteAnimal(Deer.Name)));
        }
    }
}
