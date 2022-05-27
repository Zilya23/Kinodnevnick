using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
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
	/// Interaction logic for TestsHistoryPage.xaml
	/// </summary>
	public partial class TestsHistoryPage : Page
	{
		public static ObservableCollection<Test> testList { get; set; }
		public static User profil { get; set; }
		public TestsHistoryPage()
		{
			InitializeComponent();
			testList = TestFunction.TestHistory(AuthorizationPage.user.ID);
			if(testList.Count == 0)
            {
				tb_IsEmpty.Visibility = Visibility.Visible;
            }
			profil = AuthorizationPage.user;
			tb_Name.Text = profil.Nickname;
			Level lvl = StatisticFunction.GetUserLevel(profil);
			pb_lvl.Minimum = (double)lvl.Min_Count_XP;
			pb_lvl.Maximum = (double)lvl.Max_Count_XP;
			pb_lvl.Value = (double)profil.Count_XP;
			this.DataContext = this;
		}

		private void btn_main_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new TestsPage());
		}

		private void btn_TestStatistic_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new LeaderBoardPage());
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
	}
}
