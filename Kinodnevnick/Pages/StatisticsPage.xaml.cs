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
using Excel = Microsoft.Office.Interop.Excel;
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
			tb_awardsCount.Text = tb_awardsCount.Text + StatisticFunction.CountAward(user.ID);

			Level lvl = StatisticFunction.GetUserLevel(user);
			pb_lvl.Minimum = (double)lvl.Min_Count_XP;
			pb_lvl.Maximum = (double)lvl.Max_Count_XP;
			pb_lvl.Value = (double)user.Count_XP;

			tb_lvl.Text = lvl.ID.ToString() + " ур.";
			this.DataContext = this;
		}

		private void btn_awards_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AwardsPage(profil));
		}
		private void btn_save_Click(object sender, RoutedEventArgs e)
		{
			Exportcs export = new Exportcs();
			export.nikcname = profil.Nickname;
			export.countViewedFilm = ( StatisticFunction.CountViewedFilm(profil.ID).ToString());
			export.countTimeViewedFilm = ( StatisticFunction.CountTimeViewedFilm(profil.ID).ToString());
			export.countDoneTest = (StatisticFunction.CountDoneTest(profil.ID).ToString());
			export.countAward = (StatisticFunction.CountAward(profil.ID).ToString());
			export.ratingUser = ( StatisticFunction.RatingUser(profil.ID).ToString());
			var application = new Excel.Application();

			Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
			Excel.Worksheet worksheet = application.Worksheets.Item[1];
			int rowIndex = 2;
			worksheet.Name = $"Статистика";
			worksheet.Columns.AutoFit();
			worksheet.Rows.AutoFit();
			worksheet.Cells[1][1] = "Никнейм";
			worksheet.Cells[2][1] = "Количество просмотренных фильмов";
			worksheet.Cells[3][1] = "Всего времени за просмотром";
			worksheet.Cells[4][1] = "Количество пройденых тестов";
			worksheet.Cells[5][1] = "Рейтинг пользователя";
			worksheet.Cells[6][1] = "Количество наград";

				worksheet.Cells[1][rowIndex] = export.nikcname;
				worksheet.Cells[2][rowIndex] = export.countViewedFilm;
				worksheet.Cells[3][rowIndex] = export.countTimeViewedFilm;
				worksheet.Cells[4][rowIndex] = export.countDoneTest;
				worksheet.Cells[5][rowIndex] = export.ratingUser;
				worksheet.Cells[6][rowIndex] = export.countAward;
			application.Visible = true;




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
