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
    /// Логика взаимодействия для PoopAnimationPage.xaml
    /// </summary>
    public partial class PoopAnimationPage : Page
    {
        public Animal animal { get; set; }
        IRepository _storage = Factory.Instance.GetStorage();
        DispatcherTimer timer = new DispatcherTimer();
        public PoopAnimationPage(Animal an)
        {
            InitializeComponent();
            animal = an;
            UpdateProgressPoop();
            //_storage.DecreaseNeeds();
            TimerStart();
        }
        public void TimerStart()
        {
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
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
        private void gettingbackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WC(animal));
        }
    }
}
