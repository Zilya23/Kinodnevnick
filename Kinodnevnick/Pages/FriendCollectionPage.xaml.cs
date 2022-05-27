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
using System.IO;

namespace Kinodnevnick.Pages
{
    /// <summary>
    /// Логика взаимодействия для FriendCollectionPage.xaml
    /// </summary>
    public partial class FriendCollectionPage : Page
    {
        public static ObservableCollection<Collection> collectionsFriend { get; set; }
        public static ObservableCollection<User> users { get; set; }
        public static User profil { get; set; }
        public FriendCollectionPage()
        {
            InitializeComponent();
            ObservableCollection<User> allUser = FriendFunction.GetUsers();
            cb_searchFriend.ItemsSource = allUser;
            cb_searchFriend.DisplayMemberPath = "Nickname";
            profil = AuthorizationPage.user;
            tb_Name.Text = profil.Nickname;
            Level lvl = StatisticFunction.GetUserLevel(profil);
            pb_lvl.Minimum = (double)lvl.Min_Count_XP;
            pb_lvl.Maximum = (double)lvl.Max_Count_XP;
            pb_lvl.Value = (double)profil.Count_XP;
            this.DataContext = this;
            this.DataContext = this;
        }

        private void cb_searchFriend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_searchFriend.SelectedItem != null)
            {
                lv_friendColl.Visibility = Visibility.Visible;
                img_photo.Visibility = Visibility.Visible;
                tb_friendName.Visibility = Visibility.Visible;
                btn_follow.Visibility = Visibility.Visible;
                ObservableCollection<Collection> friendCollections = CollectionFunction.GetFriendCollection((cb_searchFriend.SelectedItem as User).ID);
                User frienduser = cb_searchFriend.SelectedItem as User;
                BitmapImage bd = ToBitmapImage(frienduser.Photo);
                img_photo.Source = bd;
                tb_friendName.Text = frienduser.Nickname;
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

        private void lv_friendColl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Collection collection = lv_friendColl.SelectedItem as Collection;
            if (collection != null)
            {
                NavigationService.Navigate(new FilmInCollectionFriendsPage(collection));
            }
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

        public static BitmapImage ToBitmapImage(byte[] data)
        {
            if(data != null)
            {
                using (MemoryStream ms = new MemoryStream(data))
                {

                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.CacheOption = BitmapCacheOption.OnLoad;
                    img.StreamSource = ms;
                    img.EndInit();

                    if (img.CanFreeze)
                    {
                        img.Freeze();
                    }
                    return img;
                }
            }
            else
            {
                return null;
            }
        }

        private void btn_follow_Click(object sender, RoutedEventArgs e)
        {
            var follower = new Follow();
            User frienduser = cb_searchFriend.SelectedItem as User;
            follower.ID_Following_User = frienduser.ID;
            follower.ID_Follower_User = AuthorizationPage.user.ID;
            follower.Date_follow = DateTime.Now;
            var isFolvr = bd_connection.connection.Follow.Where(a => a.ID_Following_User == follower.ID_Following_User && a.ID_Follower_User == follower.ID_Follower_User).Count();
            if (isFolvr == 0)
            {
                bd_connection.connection.Follow.Add(follower);
                bd_connection.connection.SaveChanges();
                MessageBox.Show("Вы успешно подписались");

            }
            else
            {
                MessageBox.Show("Вы уже подписаны на этого пользователя", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
