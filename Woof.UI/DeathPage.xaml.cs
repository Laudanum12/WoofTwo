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

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для DeathPage.xaml
    /// </summary>
    public partial class DeathPage : Page
    {
        IRepository _storage = Factory.Instance.GetStorage();

        public DeathPage()
        {
            InitializeComponent();
            _storage.AnimalIsDead();
        }

        private void tryagainButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigation = frame.NavigationService;
            navigation.Navigate(new PetsChoosing());
        }
    }
}
