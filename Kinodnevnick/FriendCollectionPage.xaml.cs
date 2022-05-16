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
using Core.DateBase;
using Core;
using System.Collections.ObjectModel;

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для FriendCollectionPage.xaml
    /// </summary>
    public partial class FriendCollectionPage : Page
    {
        public static ObservableCollection<Collection> collectionsFriend { get; set; }
        public static ObservableCollection<User> users { get; set; }
        public FriendCollectionPage()
        {
            InitializeComponent();
            ObservableCollection<User> allUser = FriendFunction.GetUsers();
            cb_searchFriend.ItemsSource = allUser;
            cb_searchFriend.DisplayMemberPath = "Nickname";
        }

        private void cb_searchFriend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cb_searchFriend.SelectedItem != null)
            {
                lv_friendColl.Visibility = Visibility.Visible;
                ObservableCollection<Collection> friendCollections = CollectionFunction.GetCollection((cb_searchFriend.SelectedItem as User).ID);
                lv_friendColl.ItemsSource = friendCollections;
            }
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
        private void btn_main_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FilmMainPage(AuthorizationPage.user));
        }
    }
}
