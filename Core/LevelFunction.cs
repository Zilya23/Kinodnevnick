using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DateBase;

namespace Core
{
	public class LevelFunction
	{
		public static void WachedFilmXP(int UserId)
		{
			User user = bd_connection.connection.User.Where(x => x.ID == UserId).FirstOrDefault();
			user.Count_XP += 1;
			bd_connection.connection.SaveChanges();
		}
		public static void EventAddXP(int UserId)
		{
			User user = bd_connection.connection.User.Where(x => x.ID == UserId).FirstOrDefault();
			user.Count_XP += 1;
			bd_connection.connection.SaveChanges();
		}
		public static void CollectionAddXP(int UserId)
		{
			User user = bd_connection.connection.User.Where(x => x.ID == UserId).FirstOrDefault();
			user.Count_XP += 2;
			bd_connection.connection.SaveChanges();
		}
		public static void FilmAddCollXP(int UserId)
		{
			User user = bd_connection.connection.User.Where(x => x.ID == UserId).FirstOrDefault();
			user.Count_XP += 1;
			bd_connection.connection.SaveChanges();
		}
		public static void AwardIsDoneXP(int UserId, Award award)
		{
			User user = bd_connection.connection.User.Where(x => x.ID == UserId).FirstOrDefault();
			user.Count_XP = user.Count_XP + award.CountXP;
			bd_connection.connection.SaveChanges();
		}
		public static void TestIsDoneXP(int UserId, int countXpForTest) 
		{
			User user = bd_connection.connection.User.Where(x => x.ID == UserId).FirstOrDefault();
			user.Count_XP = user.Count_XP + countXpForTest;
			bd_connection.connection.SaveChanges();
		}
	}
}
