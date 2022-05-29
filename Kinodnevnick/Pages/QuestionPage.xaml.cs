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
using System.Collections.ObjectModel;
using Core;
using Core.DateBase;
using System.Drawing;
using System.IO;

namespace Kinodnevnick.Pages
{
	/// <summary>
	/// Interaction logic for QuestionPage.xaml
	/// </summary>
	public partial class QuestionPage : Page
	{
		public static ObservableCollection<Question> questionList { get; set; }
		public static int viewedQuestion;
		public static int numberQuestion;
		public static Question question;
		public static int countTrueAnswer = 0;
		public static int IDTest;

		public QuestionPage(int testId)
		{
			InitializeComponent();
			IDTest = testId;
			questionList = TestFunction.GetQuestions(testId);
			viewedQuestion = questionList.Count - 1;
			numberQuestion = 0;
			tb_QuestionCount.Text = (numberQuestion + 1).ToString() + " из " + (viewedQuestion + 1).ToString();

			question = questionList[numberQuestion];
			BitmapImage bd = ToBitmapImage(question.Photo);
			img_Qphoto.Source = bd;

			tb_Qestion.Text = question.Question1;
			btn_answr1.Content = question.Answer_One.Trim();
			btn_answr2.Content = question.Answer_Two.Trim();
			btn_answr3.Content = question.Answer_Three.Trim();
			btn_answr4.Content = question.Answer_Four.Trim();
			this.DataContext = this;
		}
		private void tb_back_MouseDown(object sender, MouseButtonEventArgs e)
		{
			numberQuestion = 0;
			countTrueAnswer = 0;
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

		private void btn_answr4_Click(object sender, RoutedEventArgs e)
		{
			if (numberQuestion != viewedQuestion)
			{
				if (TestFunction.IsTrueAnswer(btn_answr4.Content.ToString(), question.ID))
				{
					countTrueAnswer++;
				}
				numberQuestion++;
				question = questionList[numberQuestion];
				BitmapImage bd = ToBitmapImage(question.Photo);
				img_Qphoto.Source = bd;
				tb_Qestion.Text = question.Question1;
				btn_answr1.Content = question.Answer_One.Trim();
				btn_answr2.Content = question.Answer_Two.Trim();
				btn_answr3.Content = question.Answer_Three.Trim();
				btn_answr4.Content = question.Answer_Four.Trim();
				tb_QuestionCount.Text = (numberQuestion + 1).ToString() + " из " + (viewedQuestion + 1).ToString();
			}
			else 
			{
				if (TestFunction.IsTrueAnswer(btn_answr4.Content.ToString(), question.ID))
				{
					countTrueAnswer++;
				}
				MessageBox.Show("Тест пройден! \nРезультаты теста:" + " правильных ответов " + countTrueAnswer + " из " + (viewedQuestion + 1));
				TestFunction.TestDone(AuthorizationPage.user.ID ,IDTest);
				LevelFunction.TestIsDoneXP(AuthorizationPage.user.ID, (countTrueAnswer * 5));
				numberQuestion = 0;
				countTrueAnswer = 0;
				NavigationService.Navigate(new TestsPage());
			}
		}

		public static BitmapImage ToBitmapImage(byte[] data)
		{
			using (MemoryStream ms = new MemoryStream(data))
			{

				BitmapImage img = new BitmapImage();
				img.BeginInit();
				img.CacheOption = BitmapCacheOption.OnLoad;
				img.StreamSource = ms;
				img.EndInit();

				if (img.CanFreeze)
				{
					img.Freeze();
				}
				return img;
			}
		}

		private void btn_answr3_Click(object sender, RoutedEventArgs e)
		{
			if (numberQuestion != viewedQuestion)
			{
				if (TestFunction.IsTrueAnswer(btn_answr3.Content.ToString(), question.ID))
				{
					countTrueAnswer++;
				}
				numberQuestion++;
				question = questionList[numberQuestion];
				BitmapImage bd = ToBitmapImage(question.Photo);
				img_Qphoto.Source = bd;
				tb_Qestion.Text = question.Question1;
				btn_answr1.Content = question.Answer_One.Trim();
				btn_answr2.Content = question.Answer_Two.Trim();
				btn_answr3.Content = question.Answer_Three.Trim();
				btn_answr4.Content = question.Answer_Four.Trim();
				tb_QuestionCount.Text = (numberQuestion + 1).ToString() + " из " + (viewedQuestion + 1).ToString();
			}
			else 
			{
				if (TestFunction.IsTrueAnswer(btn_answr3.Content.ToString(), question.ID))
				{
					countTrueAnswer++;
				}
				MessageBox.Show("Тест пройден! \nРезультаты теста:" + " правильных ответов " + countTrueAnswer + " из " + (viewedQuestion + 1));
				TestFunction.TestDone(AuthorizationPage.user.ID, IDTest);
				LevelFunction.TestIsDoneXP(AuthorizationPage.user.ID, (countTrueAnswer * 5));
				numberQuestion = 0;
				countTrueAnswer = 0;
				NavigationService.Navigate(new TestsPage());
			}
		}

		private void btn_answr2_Click(object sender, RoutedEventArgs e)
		{
			if (numberQuestion != viewedQuestion)
			{
				if (TestFunction.IsTrueAnswer(btn_answr2.Content.ToString(), question.ID))
				{
					countTrueAnswer++;
				}
				numberQuestion++;
				question = questionList[numberQuestion];
				BitmapImage bd = ToBitmapImage(question.Photo);
				img_Qphoto.Source = bd;
				tb_Qestion.Text = question.Question1;
				btn_answr1.Content = question.Answer_One.Trim();
				btn_answr2.Content = question.Answer_Two.Trim();
				btn_answr3.Content = question.Answer_Three.Trim();
				btn_answr4.Content = question.Answer_Four.Trim();
				tb_QuestionCount.Text = (numberQuestion + 1).ToString() + " из " + (viewedQuestion + 1).ToString();
			}
			else
			{
				if (TestFunction.IsTrueAnswer(btn_answr2.Content.ToString(), question.ID))
				{
					countTrueAnswer++;
				}
				MessageBox.Show("Тест пройден! \nРезультаты теста:" + " правильных ответов " + countTrueAnswer + " из " + (viewedQuestion + 1));
				TestFunction.TestDone(AuthorizationPage.user.ID, IDTest);
				LevelFunction.TestIsDoneXP(AuthorizationPage.user.ID, (countTrueAnswer * 5));
				numberQuestion = 0;
				countTrueAnswer = 0;
				NavigationService.Navigate(new TestsPage());
			}
		}

		private void btn_answr1_Click(object sender, RoutedEventArgs e)
		{
			if (numberQuestion != viewedQuestion)
			{
				if (TestFunction.IsTrueAnswer(btn_answr1.Content.ToString(), question.ID))
				{
					countTrueAnswer++;
				}
				numberQuestion++;
				question = questionList[numberQuestion];
				BitmapImage bd = ToBitmapImage(question.Photo);
				img_Qphoto.Source = bd;
				tb_Qestion.Text = question.Question1;
				btn_answr1.Content = question.Answer_One.Trim();
				btn_answr2.Content = question.Answer_Two.Trim();
				btn_answr3.Content = question.Answer_Three.Trim();
				btn_answr4.Content = question.Answer_Four.Trim();
				tb_QuestionCount.Text = (numberQuestion + 1).ToString() + " из " + (viewedQuestion + 1).ToString();
			}
			else
			{
				if (TestFunction.IsTrueAnswer(btn_answr1.Content.ToString(), question.ID))
				{
					countTrueAnswer++;
				}
				MessageBox.Show("Тест пройден! \nРезультаты теста:" + " правильных ответов " + countTrueAnswer + " из " + (viewedQuestion + 1));
				TestFunction.TestDone(AuthorizationPage.user.ID, IDTest);
				LevelFunction.TestIsDoneXP(AuthorizationPage.user.ID, (countTrueAnswer * 5));
				numberQuestion = 0;
				countTrueAnswer = 0;
				NavigationService.Navigate(new TestsPage());
			}
		}
	}
}
