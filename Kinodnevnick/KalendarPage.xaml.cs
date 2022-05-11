using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;
using Core.DateBase;

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для KalendarPage.xaml
    /// </summary>
    public partial class KalendarPage : Page
    {
        public static ObservableCollection<Film_Calendar> calendars { get; set; }
        public KalendarPage()
        {
            InitializeComponent();
            calendars = KalendarFunction.AllEvent(AuthorizationPage.user.ID);

            //cal_film.SelectedDates = calendars.Select(x=> x.Date);
            //cal_film.SelectedDates.Add(
            //   new DateTime(2022, 5, 5));
            ////cal_film.SelectedDates.AddRange(
            ////    new DateTime(2022, 5, 12), new DateTime(2009, 1, 15));
            //cal_film.SelectedDates.Add(
            //    new DateTime(2022, 5, 27));
            foreach (var i in calendars)
            {
                cal_film.SelectedDates.Add((DateTime)i.Date);
            }
            //cal_film.BlackoutDates.Add(new CalendarDateRange(new DateTime(2022, 5, 2), new DateTime(2022, 5, 30)));
        }

        private void btn_collection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CollectionMainPage());
        }

        private void btn_main_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FilmMainPage(AuthorizationPage.user));
        }

        private void cal_film_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            //cal_film.BlackoutDates.Clear();
            foreach (var i in calendars)
            {
                cal_film.SelectedDates.Add((DateTime)i.Date);
            }
        }
    }
}
