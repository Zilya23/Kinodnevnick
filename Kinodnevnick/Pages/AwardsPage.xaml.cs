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
	/// Interaction logic for AwardsPage.xaml
	/// </summary>
	public partial class AwardsPage : Page
	{
		public static User profil { get; set; }
		public static ObservableCollection<Award> awardList { get; set; }
		public AwardsPage(User user)
		{
			InitializeComponent();
			awardList = AwardFunction.GetAwards();
			tb_name.Text = user.Nickname + ".Награды";
			this.DataContext = this;
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

		private void lv_Awards_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var award = lv_Awards.SelectedItem as Award; 
			AwardInfoWindow awardInfo = new AwardInfoWindow(award);
			awardInfo.ShowDialog();
		}
	}
}
