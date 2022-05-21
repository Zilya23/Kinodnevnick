using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
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
	/// Interaction logic for FollowWindow.xaml
	/// </summary>
	public partial class FollowingWindow : Window
	{
		public static ObservableCollection<Follow> folowingList { get; set; }
		public FollowingWindow()
		{
			InitializeComponent();
			folowingList = FollowFunction.GetFollows(AuthorizationPage.user.ID);
			this.DataContext = this;
		}

		private void lv_follow_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (lv_follow.SelectedItem != null)
			{
				var frnd = (lv_follow.SelectedItem as Follow).User1;
				StatisticsPage.frienfUser = frnd;
				this.DialogResult = true;
			}
		}

		private void btn_del_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
