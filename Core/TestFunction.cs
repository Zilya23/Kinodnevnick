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

	}
}
