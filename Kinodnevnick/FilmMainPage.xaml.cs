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

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для FilmMainPage.xaml
    /// </summary>
    public partial class FilmMainPage : Page
    {
        public static ObservableCollection<Core.DateBase.Film> filmList { get; set; }
        public FilmMainPage()
        {
            InitializeComponent();
            //filmList = Core.FilmFunction.GetFilm();
            //this.DataContext = this;
        }

        private void lv_films_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var isSelected = lv_films.SelectedItem as Core.DateBase.Film;
            if(isSelected != null)
            {
                NavigationService.Navigate(new FilmInfoPage(isSelected));
            }  
        }
    }
}
