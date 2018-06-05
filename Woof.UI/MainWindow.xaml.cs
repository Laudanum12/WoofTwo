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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository _repository = new Repository();
        public MainWindow()
        {
            InitializeComponent();
            Window1.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Window1.Navigate(new LogIn());
        }
    }
}
