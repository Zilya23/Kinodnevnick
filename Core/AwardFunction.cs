using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.DateBase;

namespace Core
{
	public class AwardFunction
	{ 
		public static ObservableCollection<Award> awards { get; set; }
		public static ObservableCollection<Award> GetAwards()
		{
			return new ObservableCollection<Award>(bd_connection.connection.Award.ToList());
		}

		public static void CreateUser_Award(int IDUser)
        {
			Award_User award_User = new Award_User();
			var allAwards = GetAwards();
			foreach(var award in allAwards)
            {
				List<Award_User> newAward = bd_connection.connection.Award_User.Where(a => a.ID_Award == award.ID && a.ID_User == IDUser).ToList();
				if (newAward.Count == 0)
                {
					award_User.ID_Award = award.ID;
					award_User.ID_User = IDUser;
					bd_connection.connection.Award_User.Add(award_User);
					bd_connection.connection.SaveChanges();
				}
            }
        }

		public static void FilmAward(int idUser)
        {
			FirstFilmAward(idUser);
			TenFilmAward(idUser);
        }
		public static void EventAward(int idUser)
        {
			FirstEventAward(idUser);
			TenEventAward(idUser);
        }
		public static void TestAward(int idUser)
        {
			FirstTestAward(idUser);
			TenTestAward(idUser);
        }


		public static void RegistrationAward(int IDUser)
        {
			Award_User award_User = bd_connection.connection.Award_User.Where(a => a.ID_User == IDUser && a.ID_Award == 1).FirstOrDefault();
			award_User.IsDone = true;
			bd_connection.connection.SaveChanges();
        }

		public static void FirstFilmAward(int IDUser)
        {
			Collection collection = bd_connection.connection.Collection.Where(c => c.ID_User == IDUser && c.Name == "Просмотрено").FirstOrDefault();
			List<Film_Collection> film_Collections = bd_connection.connection.Film_Collection.Where(a => a.ID_Collection == collection.ID).ToList();
			if(film_Collections.Count == 1)
            {
				Award_User award_User = bd_connection.connection.Award_User.Where(a => a.ID_User == IDUser && a.ID_Award == 2).FirstOrDefault();
				if(award_User.IsDone != true)
                {
					award_User.IsDone = true;
					bd_connection.connection.SaveChanges();
				}
			}
        }

		public static void FirstEventAward(int IDUser)
        {
			List<Film_Calendar> film_Calendars = bd_connection.connection.Film_Calendar.Where(x => x.ID_User == IDUser).ToList();
			if(film_Calendars.Count == 1)
            {
				Award_User award_User = bd_connection.connection.Award_User.Where(a => a.ID_User == IDUser && a.ID_Award == 3).FirstOrDefault();
				if (award_User.IsDone != true)
                {
					award_User.IsDone = true;
					bd_connection.connection.SaveChanges();
				}
            }
        }

		public static void FirstTestAward(int IDUser)
        {
			List<User_Test> user_Tests = bd_connection.connection.User_Test.Where(x => x.ID_User == IDUser && x.IsComplite == true).ToList();
			if(user_Tests.Count == 1)
            {
				Award_User award_User = bd_connection.connection.Award_User.Where(a => a.ID_User == IDUser && a.ID_Award == 6).FirstOrDefault();
				if (award_User.IsDone != true)
				{
					award_User.IsDone = true;
					bd_connection.connection.SaveChanges();
				}
			}
        }

		public static void TenFilmAward(int IDUser)
		{
			Collection collection = bd_connection.connection.Collection.Where(c => c.ID_User == IDUser && c.Name == "Просмотрено").FirstOrDefault();
			List<Film_Collection> film_Collections = bd_connection.connection.Film_Collection.Where(a => a.ID_Collection == collection.ID).ToList();
			if (film_Collections.Count == 10)
			{
				Award_User award_User = bd_connection.connection.Award_User.Where(a => a.ID_User == IDUser && a.ID_Award == 4).FirstOrDefault();
				if (award_User.IsDone != true)
				{
					award_User.IsDone = true;
					bd_connection.connection.SaveChanges();
				}
			}
		}

		public static void TenEventAward(int IDUser)
		{
			List<Film_Calendar> film_Calendars = bd_connection.connection.Film_Calendar.Where(x => x.ID_User == IDUser).ToList();
			if (film_Calendars.Count == 10)
			{
				Award_User award_User = bd_connection.connection.Award_User.Where(a => a.ID_User == IDUser && a.ID_Award == 5).FirstOrDefault();
				if (award_User.IsDone != true)
				{
					award_User.IsDone = true;
					bd_connection.connection.SaveChanges();
				}
			}
		}

		public static void TenTestAward(int IDUser)
		{
			List<User_Test> user_Tests = bd_connection.connection.User_Test.Where(x => x.ID_User == IDUser && x.IsComplite == true).ToList();
			if (user_Tests.Count == 10)
			{
				Award_User award_User = bd_connection.connection.Award_User.Where(a => a.ID_User == IDUser && a.ID_Award == 7).FirstOrDefault();
				if (award_User.IsDone != true)
				{
					award_User.IsDone = true;
					bd_connection.connection.SaveChanges();
				}
			}
		}
		public static List<Award_User> GetAward_Users(int IDUser)
		{
			List<Award_User> award_Users = bd_connection.connection.Award_User.Where(x => x.ID_User == IDUser).ToList();
			return award_Users;
		}
	}
}
