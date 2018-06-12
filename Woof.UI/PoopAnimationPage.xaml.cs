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
using WoofTwo.Classes;

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для PoopAnimationPage.xaml
    /// </summary>
    public partial class PoopAnimationPage : Page
    {
        public Animal animal { get; set; }
        public PoopAnimationPage(Animal an)
        {
            InitializeComponent();
            animal = an;
        }

        private void gettingbackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WC(animal));
        }
    }
}
