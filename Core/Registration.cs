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

        public static void RegistrationUser(string nick, string login, string password, byte[] photo)
        {
            User newUser = new User();
            int startXP = 0;
            int startLvl = 1;

            newUser.Nickname = nick;
            newUser.Login = login;
            newUser.Password = password;
            newUser.User_Level = startLvl;
            newUser.Count_XP = startXP;
            newUser.Photo = photo;

            bd_connection.connection.User.Add(newUser);
            bd_connection.connection.SaveChanges();
        }

        public static bool UniqueLogin(string login)
        {
            users = new ObservableCollection<User>(bd_connection.connection.User.ToList());
            bool login_unic = true;
            foreach (var i in users)
            {
                if (i.Login == login)
                {
                    login_unic = false;
                }
            }
            return login_unic;
        }
    }
}
