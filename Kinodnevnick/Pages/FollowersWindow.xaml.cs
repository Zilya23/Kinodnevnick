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
using System.Windows.Shapes;
using Core.DateBase;
using Core;

namespace Kinodnevnick.Pages
{
	/// <summary>
	/// Interaction logic for FollowersWindow.xaml
	/// </summary>
	public partial class FollowersWindow : Window
	{
		public static ObservableCollection<Follow> folowersList { get; set; }
		public FollowersWindow()
		{
			InitializeComponent();
			folowersList = FollowersFunction.GetFollowers(AuthorizationPage.user.ID);
			this.DataContext = this;
		}

		private void lv_followers_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (lv_followers.SelectedItem != null)
			{
				var frnd = (lv_followers.SelectedItem as Follow).User;
				StatisticsPage.frienfUser = frnd;
				this.DialogResult = true;
			}
		}

		private void btn_add_Click(object sender, RoutedEventArgs e)
		{
			var follower = new Follow();
			var senderButton = sender as Button;
			var followr = senderButton.DataContext as Follow;
			follower.ID_Following_User = followr.ID_Follower_User;
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
