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
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;
using Core.DateBase;

namespace Kinodnevnick.Pages
{
	/// <summary>
	/// Interaction logic for LeaderBoardPage.xaml
	/// </summary>
	public partial class LeaderBoardPage : Page
	{
		public static User profil { get; set; }
		public static List<User> leaders { get; set; }

		public LeaderBoardPage()
		{
			InitializeComponent();
			profil = AuthorizationPage.user;
			tb_Name.Text = profil.Nickname;
			leaders = FriendFunction.GetLeader();
			Level lvl = StatisticFunction.GetUserLevel(profil);
			pb_lvl.Minimum = (double)lvl.Min_Count_XP;
			pb_lvl.Maximum = (double)lvl.Max_Count_XP;
			pb_lvl.Value = (double)profil.Count_XP;
			this.DataContext = this;
		}
		private void btn_main_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new FilmMainPage(AuthorizationPage.user));
		}


		private void btn_searchFriend_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new FriendCollectionPage());
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

		private void prod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			FollowersWindow followers = new FollowersWindow();
			if(lv_leader.SelectedItem != null)
			{
				var leadUser = lv_leader.SelectedItem as User;
				NavigationService.Navigate(new FollowUserPage(leadUser));
			}
		}

        private void btn_TestHistory_Click(object sender, RoutedEventArgs e)
        {
			NavigationService.Navigate(new TestsHistoryPage());
        }
    }
    public class OrdinalConverter : IValueConverter
	{
		public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{

			ListViewItem lvi = value as ListViewItem;
			int ordinal = 0;

			if (lvi != null)
			{
				ListView lv = ItemsControl.ItemsControlFromItemContainer(lvi) as ListView;
				ordinal = lv.ItemContainerGenerator.IndexFromContainer(lvi) + 1;
			}

			return ordinal;

		}

		public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// This converter does not provide conversion back from ordinal position to list view item
			throw new System.InvalidOperationException();
		}
	}
}
