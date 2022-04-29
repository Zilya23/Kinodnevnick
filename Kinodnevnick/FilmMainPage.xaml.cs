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

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для FilmMainPage.xaml
    /// </summary>
    public partial class FilmMainPage : Page
    {
        public static ObservableCollection<Film> filmList { get; set; }
        public FilmMainPage(Core.DateBase.User user)
        {
            InitializeComponent();
            filmList = Core.FilmFunction.GetFilm();
            this.DataContext = this;
        }

        private void lv_films_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var isSelected = lv_films.SelectedItem as Core.DateBase.Film;
            if(isSelected != null)
            {
                NavigationService.Navigate(new FilmInfoPage(isSelected));
            }  
        }

        private void tbx_search_SelectionChanged(object sender, RoutedEventArgs e)
        {
            filmList = Core.FilmFunction.GetFilm();
            if (tbx_search.Text != "")
            {
                filmList = new ObservableCollection<Film>(bd_connection.connection.Film.Where(a => a.Name.Contains(tbx_search.Text)).ToList());
            }

            lv_films.ItemsSource = filmList;
        }

        private void btn_collection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CollectionMainPage());
        }
    }
}
