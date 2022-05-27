using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DateBase;

namespace Core
{
    public class StatisticFunction
    {
        public static int CountViewedFilm(int UserID)
        {
            var coll = bd_connection.connection.Collection.Where(x => x.ID_User == UserID && x.Name == "Просмотрено").FirstOrDefault();
            var films = bd_connection.connection.Film_Collection.Where(x => x.ID_Collection == coll.ID).Count();
            return films;
        }

        public static int CountTimeViewedFilm(int UserID)
        {
            var coll = bd_connection.connection.Collection.Where(x => x.ID_User == UserID && x.Name == "Просмотрено").FirstOrDefault();
            var films = bd_connection.connection.Film_Collection.Where(x => x.ID_Collection == coll.ID).ToList();
            int time = 0;
            foreach(var i in films)
            {
                time = (int)(time + i.Film.Duration);
            }
            return time;
        }

        public static int CountDoneTest(int UserID)
        {
            var tests = bd_connection.connection.User_Test.Where(x => x.ID_User == UserID && x.IsComplite == true).Count();
            return tests;
        }

        public static int RatingUser(int UserID)
        {
            var leaders = FriendFunction.GetLeader();
            int userPlace = 0;
            foreach(var i in leaders)
            {
                if(i.ID == UserID)
                {
                    userPlace++;
                    break;
                }
                else
                {
                    userPlace++;
                }
            }
            return userPlace;
        }

        public static int CountAward(int idUser)
        {
            var awards = bd_connection.connection.Award_User.Where(x => x.ID_User == idUser && x.IsDone == true).Count();
            return awards;
        }

        public static Level GetUserLevel(User user)
        {
            List<Level> levels = bd_connection.connection.Level.ToList();
            foreach(var lvl in levels)
            {
                if (user.Count_XP < lvl.Max_Count_XP)
                {
                    return lvl;
                }
            }
            return levels.Last();
        }
    }
}
