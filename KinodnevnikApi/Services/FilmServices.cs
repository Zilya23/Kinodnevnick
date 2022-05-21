using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core;

namespace KinodnevnikApi.Services
{
    public static class FilmServices
    {
        static ObservableCollection<Core.DateBase.Film> films = Core.FilmFunction.GetFilm();
        public static ObservableCollection<Core.DateBase.Film> GetAllFilm() => films;
        public static Core.DateBase.Film GetFilm(int id) => films.FirstOrDefault(p => p.ID == id);
    }
}
