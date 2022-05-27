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
            NewUserCollection();
            User newRegUser = FriendFunction.GetUsers().Last();
            TestFunction.CreateUser_Test(newRegUser.ID);
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

        public static void NewUserCollection()
        {
            users = new ObservableCollection<User>(bd_connection.connection.User.ToList());

            Collection favouritesСollection = new Collection();
            Collection viewedCollection = new Collection();
            favouritesСollection.ID_User = users.Last().ID;
            favouritesСollection.Name = "Избранное";
            viewedCollection.ID_User = users.Last().ID;
            viewedCollection.Name = "Просмотрено";
            bd_connection.connection.Collection.Add(favouritesСollection);
            bd_connection.connection.Collection.Add(viewedCollection);
            bd_connection.connection.SaveChanges();
        }
    }
}
