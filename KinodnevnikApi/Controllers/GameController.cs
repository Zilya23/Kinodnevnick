using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinodnevnikApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using Core;
using Core.DateBase;

namespace KinodnevnikApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController
	{
        [HttpGet]
        public ActionResult<List<User>> Getleader()
        {
            var users = new List<User>(GameService.Getleader());
            foreach (var f in users)
            {
                f.Login = null;
                f.Password = null;
            }
            return users;
        }
        [HttpGet]
        public ActionResult<ObservableCollection<Award>> GetAward() 
        {
            var awards = new ObservableCollection<Award>(GameService.GetAwards());
            return awards;
        }
	}
}
