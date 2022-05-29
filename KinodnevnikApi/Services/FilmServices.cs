using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core;
using Core.DateBase;

namespace KinodnevnikApi.Services
{
    public static class FilmServices
    {
        static ObservableCollection<Film> films = Core.FilmFunction.GetFilm();
        public static ObservableCollection<Film> GetAllFilm() => films;
        public static Film GetFilm(int id) => films.FirstOrDefault(p => p.ID == id);
    }
}
