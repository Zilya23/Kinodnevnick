using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DateBase;
using System.Collections.ObjectModel;

namespace Core
{
    public class Registration
    {
        public static ObservableCollection<User> users { get; set; }

        public static void RegistrationUser(string nick, string login, string password)
        {
            User newUser = new User();
            int startXP = 0;
            int startLvl = 1;

            newUser.Nickname = nick;
            newUser.Login = login;
            newUser.Password = password;
            newUser.User_Level = startLvl;
            newUser.Count_XP = startXP;

            bd_connection.connection.User.Add(newUser);
            bd_connection.connection.SaveChanges();
        }
    }
}
