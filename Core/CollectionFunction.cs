using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DateBase;
using System.Collections.ObjectModel;

namespace Core
{
    public class CollectionFunction
    {
        public static ObservableCollection<Collection> collections { get; set; }
        public static ObservableCollection<Film_Collection> films { get; set; }
        public static Collection collectionForDelete { get; set; }
        public static Film_Collection Film_CollectionForDelete { get; set; } 

        public static ObservableCollection<Collection> GetCollection(int idUser)
        {
            return collections = new ObservableCollection<Collection>((bd_connection.connection.Collection.Where(userCollectiom => userCollectiom.ID_User == idUser && userCollectiom.IsDeleted != true)).ToList());
        }

        public static ObservableCollection<Collection> GetFriendCollection(int idUser)
        {
            return collections = new ObservableCollection<Collection>((bd_connection.connection.Collection.Where(userCollectiom => userCollectiom.ID_User == idUser && userCollectiom.IsDeleted != true && userCollectiom.Inkognito!= true)).ToList());
        }

        public static ObservableCollection<Film_Collection> GetFilmInCollection(int idColl)
        {
            return films = new ObservableCollection<Film_Collection>((bd_connection.connection.Film_Collection.Where(a => a.ID_Collection == idColl)).ToList());
        }

        public static bool NewCollection(string nameCollection, int userID)
        {
            Collection newCollection = new Collection();
            if(UniqueCollection(userID, nameCollection))
            {
                newCollection.ID_User = userID;
                newCollection.Name = nameCollection;
                bd_connection.connection.Collection.Add(newCollection);
                bd_connection.connection.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void EditCollectionName(int idColl, string newName)
        {
            Collection editcollection = bd_connection.connection.Collection.Where(userCollectiom => userCollectiom.ID == idColl).FirstOrDefault();
            editcollection.Name = newName;
            bd_connection.connection.SaveChanges();
        }

        public static bool UniqueCollection(int idUser, string name)
        {
            bool uniq = true;
            var unique = GetCollection(idUser);
            foreach(var i in unique)
            {
                if(i.Name == name)
                {
                    uniq = false;
                }
            }
            return uniq;
        }

        public static void ViewedFilm(int idUser, int idFilm)
        {
            var FilmColl = new Film_Collection();
            var allColl = CollectionFunction.GetCollection(idUser);
            int viewedCollection = 0;
            foreach (var i in allColl)
            {
                if (i.Name == "Просмотрено")
                {
                    viewedCollection = i.ID;
                }
            }
            FilmColl.ID_Collection = viewedCollection;
            FilmColl.ID_Film = idFilm;
            FilmColl.Date = DateTime.Now;
            Film_Collection unigue_Film_Collection = bd_connection.connection.Film_Collection.Where(a => a.ID_Collection == FilmColl.ID_Collection && a.ID_Film == FilmColl.ID_Film).FirstOrDefault();
            if (unigue_Film_Collection == null)
            {
                bd_connection.connection.Film_Collection.Add(FilmColl);
                bd_connection.connection.SaveChanges();
            }
        }

        public static void UnviewedFilm(int idUser, int idFilm)
        {
            var FilmColl = new Film_Collection();
            var allColl = CollectionFunction.GetCollection(idUser);
            int viewedCollection = 0;
            foreach (var i in allColl)
            {
                if (i.Name == "Просмотрено")
                {
                    viewedCollection = i.ID;
                }
            }
            FilmColl.ID_Collection = viewedCollection;
            FilmColl.ID_Film = idFilm;
            Film_Collection deleted_Film_Collection = bd_connection.connection.Film_Collection.Where(a => a.ID_Collection == FilmColl.ID_Collection && a.ID_Film == FilmColl.ID_Film).FirstOrDefault();
            bd_connection.connection.Film_Collection.Remove(deleted_Film_Collection);
            bd_connection.connection.SaveChanges();
        }

        public static bool Viewed(int idUser, int idFilm)
        {
            var FilmColl = new Film_Collection();
            var allColl = CollectionFunction.GetCollection(idUser);
            int viewedCollection = 0;
            foreach (var i in allColl)
            {
                if (i.Name == "Просмотрено")
                {
                    viewedCollection = i.ID;
                }
            }
            FilmColl.ID_Collection = viewedCollection;
            FilmColl.ID_Film = idFilm;
            Film_Collection deleted_Film_Collection = bd_connection.connection.Film_Collection.Where(a => a.ID_Collection == FilmColl.ID_Collection && a.ID_Film == FilmColl.ID_Film).FirstOrDefault();
            if(deleted_Film_Collection != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void DeletedCollection(int IDCollection)
        {
            collectionForDelete = bd_connection.connection.Collection.Where(userCollectiom => userCollectiom.ID == IDCollection).FirstOrDefault();
            collectionForDelete.IsDeleted = true;
            bd_connection.connection.SaveChanges();
        }

        public static void DeletedFilmInCollection(int IDColl, int IDFilm)
        {
            Film_CollectionForDelete = bd_connection.connection.Film_Collection.Where(a => a.ID_Collection == IDColl && a.ID_Film == IDFilm).FirstOrDefault();
            bd_connection.connection.Film_Collection.Remove(Film_CollectionForDelete);
            bd_connection.connection.SaveChanges();
        }
    }
}
