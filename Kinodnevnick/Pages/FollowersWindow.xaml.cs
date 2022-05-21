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
			//var Usr = new User();
			//Usr.ID = usrId;
			//var frnd = (lv_followers.SelectedItem as Follow).User;
			//var isUsr = bd_connection.connection.Follow.Where(a => a.ID_Following_User == frnd.ID && a.ID_Following_User != a.ID_Follower_User).Count();
			//if (isUsr == 0)
			//{
			//	bd_connection.connection.Film_Collection.Add(FilmColl);
			//	bd_connection.connection.SaveChanges();
			//	this.DialogResult = true;
			//}
			//else
			//{
			//	MessageBox.Show("Фильм уже добавлен в коллекцию", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			//}

		}
	}
}
