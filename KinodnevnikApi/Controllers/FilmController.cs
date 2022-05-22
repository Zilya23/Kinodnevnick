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
    public class FilmController : ControllerBase
    {
        public FilmController()
        {

        }
        //GET ALL Film
        
        [HttpGet]
        public ActionResult<List<Core.DateBase.Film>> GetAllFilm()
        {
            var films = new List<Core.DateBase.Film>(FilmServices.GetAllFilm());
            //ICollection<Core.DateBase.Film_Calendar> film_Calendars = new Collection<Core.DateBase.Film_Calendar>();
            //ICollection<Core.DateBase.Film_Collection> film_Collections = new Collection<Core.DateBase.Film_Collection>();
            List<Film> films2 = new List<Film>();
            foreach (var f in films)
            {
                f.Poster = null;
                films2.Add(f);
            }
            return films2;
        }


        // GET by ID Film
        [HttpGet("{id}")]
        public ActionResult<Core.DateBase.Film> GetFilm(int id)
        {
            var films = FilmServices.GetFilm(id);
            if (films == null)
                return NotFound();
            return films;
        }
    }
}
