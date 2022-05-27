using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
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
using Core;
using Core.DateBase;

namespace Kinodnevnick.Pages
{
	/// <summary>
	/// Interaction logic for StatisticsPage.xaml
	/// </summary>
	public partial class StatisticsPage : Page
	{
		public static User profil { get; set; }
		public static User frienfUser { get; set; }
		public StatisticsPage(User user)
		{
			InitializeComponent();
			profil = user;
			tb_viewedCount.Text = tb_viewedCount.Text + StatisticFunction.CountViewedFilm(user.ID);
			tb_viewedTime.Text = tb_viewedTime.Text + StatisticFunction.CountTimeViewedFilm(user.ID) + " мин.";
			tb_doneTest.Text = tb_doneTest.Text + StatisticFunction.CountDoneTest(user.ID);
			tb_raitingPlace.Text = tb_raitingPlace.Text + StatisticFunction.RatingUser(user.ID);
			this.DataContext = this;
		}

		private void btn_awards_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AwardsPage(profil));
		}
		private void btn_save_Click(object sender, RoutedEventArgs e)
		{

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
		private void img_redaction_MouseDown(object sender, MouseButtonEventArgs e)
		{
			EditProfilWindow editProfil = new EditProfilWindow(profil);
			editProfil.ShowDialog();
		}

		private void tb_Folowers_MouseDown(object sender, MouseButtonEventArgs e)
		{
			FollowersWindow followers = new FollowersWindow();
			if (followers.ShowDialog() == true)
			{
				NavigationService.Navigate(new FollowUserPage(frienfUser));
			}
		}

		private void tb_Folowers_MouseEnter(object sender, MouseEventArgs e)
		{
			tb_Folowers.Foreground = new SolidColorBrush(Colors.White);
		}

		private void tb_Folowers_MouseLeave(object sender, MouseEventArgs e)
		{
			tb_Folowers.Foreground = new SolidColorBrush(Colors.Black);
		}

		private void tb_Following_MouseDown(object sender, MouseButtonEventArgs e)
		{
			FollowingWindow following = new FollowingWindow();
			if (following.ShowDialog() == true)
			{
				NavigationService.Navigate(new FollowUserPage(frienfUser));
			}
		}

		private void tb_Following_MouseEnter(object sender, MouseEventArgs e)
		{
			tb_Following.Foreground = new SolidColorBrush(Colors.White);
		}

		private void tb_Following_MouseLeave(object sender, MouseEventArgs e)
		{
			tb_Following.Foreground = new SolidColorBrush(Colors.Black);
		}
	}
}
