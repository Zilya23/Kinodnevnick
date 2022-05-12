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

        public static ObservableCollection<Collection> GetCollection(int idUser)
        {
            return collections = new ObservableCollection<Collection>((bd_connection.connection.Collection.Where(userCollectiom => userCollectiom.ID_User == idUser)).ToList());
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
    }
}
