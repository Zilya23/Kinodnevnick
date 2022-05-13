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
using System.Windows.Shapes;
using Core;
using Core.DateBase;
using System.Collections.ObjectModel;

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для SelectionCollectionWindow.xaml
    /// </summary>
    public partial class SelectionCollectionWindow : Window
    {
        public int FilmId;
        public SelectionCollectionWindow(int FilmID)
        {
            InitializeComponent();
            FilmId = FilmID;
            ObservableCollection<Collection> collection = CollectionFunction.GetCollection(AuthorizationPage.user.ID);
            ObservableCollection<Collection> trueCollection = new ObservableCollection<Collection>();
            foreach (var i in collection)
            {
                if(i.Name != "Просмотрено")
                {
                    trueCollection.Add(i);
                }
            }
            cb_collection.ItemsSource = trueCollection;
            cb_collection.DisplayMemberPath = "Name";
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (cb_collection.SelectedIndex >= 0)
            {
                var FilmColl = new Film_Collection();
                var select = cb_collection.SelectedItem as Collection;
                FilmColl.ID_Collection = select.ID;
                FilmColl.ID_Film = FilmId;
                var isColl = bd_connection.connection.Film_Collection.Where(a => a.ID_Collection == select.ID && a.ID_Film == FilmId).Count();
                if (isColl == 0)
                {
                    bd_connection.connection.Film_Collection.Add(FilmColl);
                    bd_connection.connection.SaveChanges();
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Фильм уже добавлен в коллекцию", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void img_plus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NewCollectionWindow newCollection = new NewCollectionWindow(AuthorizationPage.user.ID);
            newCollection.ShowDialog();
            UpdateCollection();
        }

        public void UpdateCollection()
        {
            ObservableCollection<Collection> collection = CollectionFunction.GetCollection(AuthorizationPage.user.ID);
            ObservableCollection<Collection> trueCollection = new ObservableCollection<Collection>();
            foreach (var i in collection)
            {
                if (i.Name != "Просмотрено")
                {
                    trueCollection.Add(i);
                }
            }
            cb_collection.ItemsSource = trueCollection;
            cb_collection.DisplayMemberPath = "Name";
        }
    }
}
