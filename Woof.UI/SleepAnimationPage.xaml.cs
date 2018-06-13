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
        public Animal animal { get; set; }
        IRepository _storage = Factory.Instance.GetStorage();
        public SleepAnimationPage(Animal an)
        {
            InitializeComponent();
            animal = an;
            UpdateProgressSleep();
            
        }
        
        public void UpdateProgressSleep()
        {
            _storage.IncreaseSleepValue(true);
            if (animal.SleepPoints == 0)
            {
                NavigationService.Navigate(new DeathPage());
            }
            ProgressSleep.Value = animal.SleepPoints;
        }
        private void wakingupButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BedRoom(animal));
        }
    }
}
