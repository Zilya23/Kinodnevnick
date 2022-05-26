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
		public LeaderBoardPage()
		{
			InitializeComponent();
			profil = AuthorizationPage.user;
			tb_Name.Text = profil.Nickname;
			this.DataContext = this;
		}
		private void btn_main_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new TestsPage());
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
