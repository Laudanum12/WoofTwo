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
    /// Логика взаимодействия для NameGiving.xaml
    /// </summary>
    public partial class NameGiving : Page
    {
        IRepository _storage = Factory.Instance.GetStorage();
        public Animal an { get; set; }
        public NameGiving(Animal animal)
        {
            InitializeComponent();
            an = animal;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PetsChoosing());
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var name = nameTextBox.Text;
            an.Name = name;
            _storage.AddAnAnimal(an);
            NavigationService.Navigate(new SittingRoom());
        }
    }
}
