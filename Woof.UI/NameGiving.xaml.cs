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

namespace Woof.UI
{
    /// <summary>
    /// Логика взаимодействия для NameGiving.xaml
    /// </summary>
    public partial class NameGiving : Page
    {
        public NameGiving()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PetsChoosing());
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SittingRoom());
        }
    }
}
