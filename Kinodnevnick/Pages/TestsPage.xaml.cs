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
	/// Interaction logic for TestsPage.xaml
	/// </summary>
	public partial class TestsPage : Page
	{
		public static ObservableCollection<Test> testList { get; set; }
		public TestsPage()
		{
			InitializeComponent();
			testList = TestFunction.GetTests();
			this.DataContext = this;
		}

		private void btn_TestHistory_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btn_TestStatistic_Click(object sender, RoutedEventArgs e)
		{

		}

		private void lv_tests_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var test = lv_tests.SelectedItem as Test;
			NavigationService.Navigate(new QuestionPage(test.ID));
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

		private void btn_Friends_Click(object sender, RoutedEventArgs e)
		{

		}

	}
}
