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

		}

		private void btn_add_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
