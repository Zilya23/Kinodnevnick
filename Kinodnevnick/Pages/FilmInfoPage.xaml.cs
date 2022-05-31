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
using Prism.Commands;

namespace Kinodnevnick.Pages
{
    /// <summary>
    /// Логика взаимодействия для FilmInfoPage.xaml
    /// </summary>
    public partial class FilmInfoPage : Page
    {
        public Film filmToFill { get; set; }
        private void NavHomeView(object ID)
        {
            if (ID is string destinationurl)
                System.Diagnostics.Process.Start(filmToFill.Film_link);  
        }
        public string ExternalURL { get => filmToFill.Film_link; }
        private readonly ICommand navHomeViewCommand;
        public ICommand NavHomeViewCommand
        {
            get { return navHomeViewCommand; }
        }
        public FilmInfoPage(Film film)
        {
            InitializeComponent();
            filmToFill = film;
            navHomeViewCommand = new DelegateCommand<object>(NavHomeView);
            tb_duration.Text = filmToFill.Duration + " мин.";
            if(CollectionFunction.Viewed(AuthorizationPage.user.ID, filmToFill.ID))
            {
                cb_watch.IsChecked = true;
            }
            this.DataContext = this;
        }

        private void tb_back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
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
            LevelFunction.WachedFilmXP(AuthorizationPage.user.ID);
        }

        private void cb_watch_Unchecked(object sender, RoutedEventArgs e)
        {
            CollectionFunction.UnviewedFilm(AuthorizationPage.user.ID, filmToFill.ID);
        }

        private void img_calendar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddFilmEventWindow filmEventWindow = new AddFilmEventWindow(filmToFill);
            filmEventWindow.ShowDialog();
        }
    }
}
