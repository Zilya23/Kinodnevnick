using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.DateBase;
using System.Collections.ObjectModel;
using KinodnevnikApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace KinodnevnikApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        [HttpGet]
        public ActionResult<ObservableCollection<User>> GetAllUser()
        {
            var users = new ObservableCollection<User>(UserServices.GetAllUser());
            //foreach (var f in users)
            //{
            //    f.Poster = null;
            //    films2.Add(f);
            //}
            return users;
        }
    }
}
