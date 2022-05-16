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
    /// Логика взаимодействия для FilmInCollectionFriendsPage.xaml
    /// </summary>
    public partial class FilmInCollectionFriendsPage : Page
    {
        public static ObservableCollection<Film_Collection> filmsToFill { get; set; }
        public static Collection friendCollection { get; set; }
        public FilmInCollectionFriendsPage(Collection collection)
        {
            InitializeComponent();
            if(collection.ID_User == AuthorizationPage.user.ID)
            {
                img_merge.Visibility = Visibility.Hidden;
            }
            filmsToFill = CollectionFunction.GetFilmInCollection(collection.ID);
            if (filmsToFill == null)
            {
                tb_isEmpty.Visibility = Visibility.Visible;
            }
            friendCollection = collection;
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

        private void lv_film_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void img_merge_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MergeWindow mergeWindow = new MergeWindow(friendCollection.ID);
            mergeWindow.ShowDialog();
        }
    }
}
