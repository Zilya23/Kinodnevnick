using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Core;
using Core.DateBase;

namespace Kinodnevnick.Pages
{
    /// <summary>
    /// Логика взаимодействия для FilmMainPage.xaml
    /// </summary>
    public partial class FilmMainPage : Page
    {
        public static User profil { get; set; }
        public static ObservableCollection<Film> filmList { get; set; }
        public FilmMainPage(User user)
        {
            InitializeComponent();
            profil = user;
            tb_Name.Text = user.Nickname;
            filmList = FilmFunction.GetFilm();
            Level lvl = StatisticFunction.GetUserLevel(profil);
            pb_lvl.Minimum = (double)lvl.Min_Count_XP;
            pb_lvl.Maximum = (double)lvl.Max_Count_XP;
            pb_lvl.Value = (double)profil.Count_XP;
            this.DataContext = this;
            this.DataContext = this;
        }

        private void lv_films_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var isSelected = lv_films.SelectedItem as Film;
            if(isSelected != null)
            {
                NavigationService.Navigate(new FilmInfoPage(isSelected));
            }  
        }

        private void tbx_search_SelectionChanged(object sender, RoutedEventArgs e)
        {
            filmList = FilmFunction.GetFilm();
            if (tbx_search.Text != "")
            {
                filmList = new ObservableCollection<Film>(bd_connection.connection.Film.Where(a => a.Name.Contains(tbx_search.Text)).ToList());
            }

            if (filmList.Count == 0)
            {
                tb_isEmpty.Visibility = Visibility.Visible;
            }
            else
            {
                tb_isEmpty.Visibility = Visibility.Hidden;
            }
            lv_films.ItemsSource = filmList;
        }

        private void btn_collection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CollectionMainPage());
        }

        private void btn_dairy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new KalendarPage());
        }

        private void btn_searchFriend_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FriendCollectionPage());
        }

		private void btn_Statistic_Click(object sender, RoutedEventArgs e)
		{
            NavigationService.Navigate(new StatisticsPage(AuthorizationPage.user));
		}

		private void btn_Exit_Click(object sender, RoutedEventArgs e)
		{
            NavigationService.Navigate(new AuthorizationPage());
		}

		private void btn_Tests_Click(object sender, RoutedEventArgs e)
		{
            NavigationService.Navigate(new TestsPage());
		}
	}
}
