using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.DateBase;

namespace Core
{
	public class TestFunction
	{
		public static ObservableCollection<Test> tests { get; set; }
		public static ObservableCollection<Question> questions { get; set; }

		public static ObservableCollection<Test> GetTests() 
		{
			return new ObservableCollection<Test>(bd_connection.connection.Test.ToList());
		}
		public static ObservableCollection<Question> GetQuestions(int idTest)
		{
			return new ObservableCollection<Question>(bd_connection.connection.Question.Where(x => x.ID__Test == idTest).ToList());
		}
		public static bool IsTrueAnswer(string answer, int idQestion)
		{
			Question question = bd_connection.connection.Question.Where(x => x.ID == idQestion).FirstOrDefault();
			if(question.True_Answer == answer)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static void CreateUser_Test(int idUser)
        {
			User_Test user_Test = new User_Test();
			var allTest = GetTests();
			foreach(var test in allTest)
            {
				user_Test.ID_User = idUser;
				user_Test.ID_Test = test.ID;
				bd_connection.connection.User_Test.Add(user_Test);
				bd_connection.connection.SaveChanges();
			}
        }

		public static void TestDone(int idUser, int idTest)
        {
			var test = bd_connection.connection.User_Test.Where(x => x.ID_Test == idTest && x.ID_User == idUser).FirstOrDefault();
			test.IsComplite = true;
			test.Date = DateTime.Now;
			bd_connection.connection.SaveChanges();
			AwardFunction.TestAward(idUser);
        }

		public static ObservableCollection<Test> TestHistory(int idUser)
        {
			ObservableCollection<User_Test> test = new ObservableCollection<User_Test>(bd_connection.connection.User_Test.Where(x => x.ID_User == idUser && x.IsComplite == true).ToList());
			ObservableCollection<Test> historyTest = new ObservableCollection<Test>();
			foreach(var i in test)
            {
				historyTest.Add(i.Test);
            }
			return historyTest;
		}

		public static ObservableCollection<Test> UnresolvedTest(int idUser)
        {
			ObservableCollection<User_Test> test = new ObservableCollection<User_Test>(bd_connection.connection.User_Test.Where(x => x.ID_User == idUser && x.IsComplite != true).ToList());
			ObservableCollection<Test> unresolvedTest = new ObservableCollection<Test>();
			foreach(var i in test)
            {
				unresolvedTest.Add(i.Test);

			}
			return unresolvedTest;
		}
	}
}
