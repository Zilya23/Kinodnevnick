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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kinodnevnick.Pages
{
	/// <summary>
	/// Interaction logic for StoryPage.xaml
	/// </summary>
	public partial class StoryPage : Page
	{
		public StoryPage()
		{
			InitializeComponent();
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
