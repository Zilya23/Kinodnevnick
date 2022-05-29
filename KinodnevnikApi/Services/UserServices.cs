using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.DateBase;

namespace KinodnevnikApi.Services
{
    public class UserServices
    {
        static ObservableCollection<User> users = FriendFunction.GetUsers();
        

        public static ObservableCollection<User> GetAllUser() => users;
    }
}
