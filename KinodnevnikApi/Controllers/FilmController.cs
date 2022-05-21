using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinodnevnikApi.Models;
using KinodnevnikApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using Core;

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
        //ICollection<Core.DateBase.Film_Calendar> film_Calendars { get; set; }
        //ICollection<Core.DateBase.Film_Collection> film_Collections { get; set; }
        [HttpGet]
        public ActionResult<ObservableCollection<Core.DateBase.Film>> GetAllFilm()
        {
            var films = FilmServices.GetAllFilm();
            foreach (var f in films)
            {
                f.Poster = null;
                //f.Film_Calendar = film_Calendars;
                //f.Film_Collection = film_Collections;
            }
            return films;
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
