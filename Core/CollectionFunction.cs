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

        public static ObservableCollection<Collection> GetCollection(int idUser)
        {
            return collections = new ObservableCollection<Collection>((bd_connection.connection.Collection.Where(userCollectiom => userCollectiom.ID_User == idUser)).ToList());
        }
    }
}
