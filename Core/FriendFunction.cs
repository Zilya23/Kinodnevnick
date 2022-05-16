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
    }
}
