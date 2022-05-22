using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.DateBase;
using System.Collections.ObjectModel;

namespace KinodnevnicckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ObservableCollection<Film>> GetAllFilm()
        {
            var films = FilmFunction.GetFilm();
            //ICollection<Core.DateBase.Film_Calendar> film_Calendars = new Collection<Core.DateBase.Film_Calendar>();
            //ICollection<Core.DateBase.Film_Collection> film_Collections = new Collection<Core.DateBase.Film_Collection>();
            foreach (var f in films)
            {
                f.Poster = null;
            }
            return films;
        }
    }
}
