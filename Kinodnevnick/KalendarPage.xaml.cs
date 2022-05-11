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
        public static ObservableCollection<Film_Calendar> eventColl { get; set; }
        public KalendarPage()
        {
            InitializeComponent();
            calendars = KalendarFunction.AllEvent(AuthorizationPage.user.ID);

            foreach (var i in calendars)
            {
                cal_film.SelectedDates.Add((DateTime)i.Date);
            }
            this.DataContext = eventColl;
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
            eventColl = new ObservableCollection<Film_Calendar>();

            foreach (var i in calendars)
            {
                cal_film.SelectedDates.Add((DateTime)i.Date);
            }

            foreach (var i in calendars)
            {
                if (cal_film.SelectedDate == i.Date)
                {
                    eventColl.Add(i);
                }
            }

            lv_event.ItemsSource = eventColl;
            this.DataContext = this;
        }
    }
}
