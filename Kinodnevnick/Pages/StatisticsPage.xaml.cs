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
		public StatisticsPage(User user)
		{
			InitializeComponent();
			profil = user;
			//tb_name.Text = user.Nickname;
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
			
		}
	}
}
