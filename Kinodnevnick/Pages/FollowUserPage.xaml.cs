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
	}
}
