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

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для KalendarPage.xaml
    /// </summary>
    public partial class KalendarPage : Page
    {
        public KalendarPage()
        {
            InitializeComponent();
        }

        private void btn_collection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CollectionMainPage());
        }

        private void btn_main_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FilmMainPage(AuthorizationPage.user));
        }
    }
}
