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
    /// Логика взаимодействия для FilmInCollectionPage.xaml
    /// </summary>
    public partial class FilmInCollectionPage : Page
    {
        public static ObservableCollection<Film_Collection> filmsToFill { get; set; }
        public int IDCollection;
        public Collection updateCollection { get; set; }
        public FilmInCollectionPage(Collection collection)
        {
            InitializeComponent();
            updateCollection = collection;
            if(collection.Name == "Избранное" || collection.Name == "Просмотрено")
            {
                img_redaction.Visibility = Visibility.Hidden;
                img_delete.Visibility = Visibility.Hidden;
            }
            filmsToFill = CollectionFunction.GetFilmInCollection(collection.ID);
            if(filmsToFill.Count == 0)
            {
                tb_isEmpty.Visibility = Visibility.Visible;
            }
            else
            {
                tb_isEmpty.Visibility = Visibility.Hidden;
            }
            if(collection.Inkognito == true)
            {
                img_inckognito.Source = new BitmapImage(new Uri("img/locked.png", UriKind.Relative));
            }
            IDCollection = collection.ID;
            this.DataContext = this;
        }

        private void tb_back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CollectionMainPage());
        }

        private void tb_back_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_back.Foreground = new SolidColorBrush(Colors.White);
        }

        private void tb_back_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_back.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void img_redaction_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EditCollectionWindow editCollection = new EditCollectionWindow(updateCollection.ID);
            editCollection.ShowDialog();
        }

        private void lv_film_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Film selected = (lv_film.SelectedItem as Film_Collection).Film;
            NavigationService.Navigate(new FilmInfoPage(selected));
        }

        private void img_delete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow();
            if(deleteWindow.ShowDialog() == true)
            {
                CollectionFunction.DeletedCollection(IDCollection);
                NavigationService.Navigate(new CollectionMainPage());
            }
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            var senderButton = sender as Button;
            var film = senderButton.DataContext as Film_Collection;
            Collection delFilmColl = bd_connection.connection.Collection.Where(a => a.ID == film.ID_Collection).FirstOrDefault();

            if (delFilmColl.Name != "Просмотрено")
            {
                CollectionFunction.DeletedFilmInCollection(IDCollection, Convert.ToInt32(film.ID_Film));
                UpdateFilm();
            }
            else
            {
                MessageBox.Show("Просмотрено не доступно для редактирования");
            }
        }

        public void UpdateFilm()
        {
            if (updateCollection.Name == "Избранное" || updateCollection.Name == "Просмотрено")
            {
                img_redaction.Visibility = Visibility.Hidden;
                img_delete.Visibility = Visibility.Hidden;
            }
            filmsToFill = CollectionFunction.GetFilmInCollection(updateCollection.ID);
            if (filmsToFill.Count == 0)
            {
                tb_isEmpty.Visibility = Visibility.Visible;
            }
            else
            {
                tb_isEmpty.Visibility = Visibility.Hidden;
            }

            lv_film.ItemsSource = filmsToFill;
        }

        private void img_inckognito_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(updateCollection.Inkognito != true)
            {
                CollectionFunction.InkognitoCollection(IDCollection);
                img_inckognito.Source = new BitmapImage(new Uri("/img/locked.png", UriKind.Relative));
            }
            else
            {
                CollectionFunction.NotInkognitoCollection(IDCollection);
                img_inckognito.Source = new BitmapImage(new Uri("/img/open.png", UriKind.Relative));
            }
        }
    }
}
