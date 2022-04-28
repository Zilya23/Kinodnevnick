using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.DateBase;

namespace Core
{
    public class Authorization
    {
        public static ObservableCollection<User> users { get; set; }
        public static DateBase.User AuthorizationUser(string login, string password)
        {
            users = new ObservableCollection<User>(bd_connection.connection.User.ToList());
            var userExists = users.Where(user => user.Login == login && user.Password == password).FirstOrDefault();
            if(userExists != null)
            {
                return userExists;
            }
            else
            {
                return userExists;
            }
        }
    }
}
