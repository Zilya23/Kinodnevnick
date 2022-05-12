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
using System.Collections.ObjectModel;
using Core;
using Core.DateBase;

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для FilmInfoPage.xaml
    /// </summary>
    public partial class FilmInfoPage : Page
    {
        public static Film filmToFill { get; set; }
        public FilmInfoPage(Film film)
        {
            InitializeComponent();
            filmToFill = FilmFunction.GetFilmInfo(film);
            tb_duration.Text = filmToFill.Duration + " мин.";
            if(CollectionFunction.Viewed(AuthorizationPage.user.ID, filmToFill.ID))
            {
                cb_watch.IsChecked = true;
            }
            this.DataContext = this;
        }

        private void tb_back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new FilmMainPage(AuthorizationPage.user));
        }

        private void tb_back_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_back.Foreground = new SolidColorBrush(Colors.White);
        }

        private void tb_back_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_back.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void img_plus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectionCollectionWindow selectionCollectionWindow = new SelectionCollectionWindow(filmToFill.ID);
            selectionCollectionWindow.ShowDialog();
        }

        private void cb_watch_Checked(object sender, RoutedEventArgs e)
        {
            CollectionFunction.ViewedFilm(AuthorizationPage.user.ID, filmToFill.ID);
        }

        private void cb_watch_Unchecked(object sender, RoutedEventArgs e)
        {
            CollectionFunction.UnviewedFilm(AuthorizationPage.user.ID, filmToFill.ID);
        }
    }
}
