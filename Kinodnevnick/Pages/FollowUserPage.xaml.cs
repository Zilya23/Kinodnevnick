using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
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
	/// Interaction logic for FollowUserPage.xaml
	/// </summary>
	public partial class FollowUserPage : Page
	{
		public static ObservableCollection<Collection> collections { get; set; }
		public static User profil { get; set; }
		public FollowUserPage(User user)
		{
			InitializeComponent();
			profil = user;
			collections = CollectionFunction.GetFriendCollection(user.ID);
			lv_userColl.ItemsSource = collections;
			var follower = bd_connection.connection.Follow.Where(z => z.ID_Follower_User == AuthorizationPage.user.ID && z.ID_Following_User == user.ID).FirstOrDefault();

			if (follower == null)
            {
				btn_follow.Visibility = Visibility.Visible;
            }

			if (user.ID == AuthorizationPage.user.ID)
			{
				btn_follow.Visibility = Visibility.Hidden;
			}

			this.DataContext = this;
		}

		private void lv_userColl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Collection collection = lv_userColl.SelectedItem as Collection;
			if (collection != null)
			{
				NavigationService.Navigate(new FilmInCollectionFriendsPage(collection));
			}
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

        private void btn_follow_Click(object sender, RoutedEventArgs e)
        {
			var follower = new Follow();
			follower.ID_Following_User = profil.ID;
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
