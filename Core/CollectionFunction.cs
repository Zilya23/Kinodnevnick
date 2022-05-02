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

        public static void NewCollection(string nameCollection, int UserID)
        {
            Collection newCollection = new Collection();

            newCollection.ID_User = UserID;
            newCollection.Name = nameCollection;
            bd_connection.connection.Collection.Add(newCollection);
            bd_connection.connection.SaveChanges();
        }
    }
}
