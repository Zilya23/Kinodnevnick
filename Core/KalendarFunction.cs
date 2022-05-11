using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DateBase;
using System.Collections.ObjectModel;

namespace Core
{
    public class KalendarFunction
    {
        public static ObservableCollection<Film_Calendar> calendars { get; set; }
        public static ObservableCollection<Film_Calendar> AllEvent(int IDUser)
        {
            calendars = new ObservableCollection<Film_Calendar>(bd_connection.connection.Film_Calendar.Where(a => a.ID_User == IDUser).ToList());
            return calendars;
        }
    }
}
