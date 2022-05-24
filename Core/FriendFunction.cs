using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DateBase;
using System.Collections.ObjectModel;

namespace Core
{
    public class FriendFunction
    {
        public static ObservableCollection<User> users { get; set; }  
        public static ObservableCollection<User> GetUsers()
        {
            return users = new ObservableCollection<User>(bd_connection.connection.User.ToList());
        }

        public static void MergeCollection(int idFriendColl, int idColl, int idUser)
        {
            ObservableCollection<Film_Collection> friendFilms = CollectionFunction.GetFilmInCollection(idFriendColl);
            ObservableCollection<Film_Collection> userFilms = CollectionFunction.GetFilmInCollection(idColl);

            Collection newUserCollection = new Collection();
            newUserCollection.Name = "Объединение от " + DateTime.Now.ToString();
            newUserCollection.ID_User = idUser;
            bd_connection.connection.Collection.Add(newUserCollection);
            bd_connection.connection.SaveChanges();
            ObservableCollection<Collection> userCollection = new ObservableCollection<Collection>(bd_connection.connection.Collection.ToList());
            int IDUserColl = userCollection.Last().ID;

            foreach (var friends in friendFilms)
            {
                foreach(var users in userFilms)
                {
                    if(friends.ID_Film == users.ID_Film)
                    {
                        Film_Collection newFilm_Collection = new Film_Collection();
                        newFilm_Collection.ID_Film = users.ID_Film;
                        newFilm_Collection.ID_Collection = IDUserColl;
                        var isColl = bd_connection.connection.Film_Collection.Where(a => a.ID_Collection == IDUserColl && a.ID_Film == users.ID_Film).Count();
                        if (isColl == 0)
                        {
                            bd_connection.connection.Film_Collection.Add(newFilm_Collection);
                            bd_connection.connection.SaveChanges();
                        }
                    }
                }
            }
        }

        public static List<Film_Collection> TestMerge()
        {
            ObservableCollection<Film_Collection> friendFilms = CollectionFunction.GetFilmInCollection(3);
            ObservableCollection<Film_Collection> userFilms = CollectionFunction.GetFilmInCollection(1);

            int IDUserColl = 15;
            List<Film_Collection> allFIlm = new List<Film_Collection>();

            foreach (var friends in friendFilms)
            {
                foreach (var users in userFilms)
                {
                    if (friends.ID_Film == users.ID_Film)
                    {
                        Film_Collection newFilm_Collection = new Film_Collection();
                        newFilm_Collection.ID_Film = users.ID_Film;
                        newFilm_Collection.ID_Collection = IDUserColl;
                        var isColl = bd_connection.connection.Film_Collection.Where(a => a.ID_Collection == IDUserColl && a.ID_Film == users.ID_Film).Count();
                        if (isColl == 0)
                        {
                            allFIlm.Add(newFilm_Collection);
                        }
                    }
                }
            }
            return allFIlm;
        }
    }
}
