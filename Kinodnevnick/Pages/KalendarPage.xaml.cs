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

namespace Kinodnevnick.Pages
{
    /// <summary>
    /// Логика взаимодействия для KalendarPage.xaml
    /// </summary>
    public partial class KalendarPage : Page
    {
        public static ObservableCollection<Film_Calendar> calendars { get; set; }
        public static EventWindow eventWindow { get; set; }
        public KalendarPage()
        {
            InitializeComponent();
            UpdateCalendar();
            UpdateList();


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
            UpdateList();
        }

        private void lv_event_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var events = lv_event.SelectedItem as Film_Calendar;
            var n = (sender as ListView).SelectedItem as Film_Calendar;
            if (n != null)
            { 
                eventWindow = new EventWindow(n);
                if(eventWindow.ShowDialog() == true)
                {
                    UpdateCalendar();
                }
            }
        }

        private void img_plus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DateTime dateEvent = (DateTime)cal_film.SelectedDate;
            AddEventWindow addEvent = new AddEventWindow(dateEvent);
            addEvent.ShowDialog();
            UpdateCalendar();
            UpdateList();
        }

        public void UpdateCalendar()
        {
            calendars = KalendarFunction.AllEvent(AuthorizationPage.user.ID);

            foreach (var i in calendars)
            {
                cal_film.SelectedDates.Add((DateTime)i.Date);
            }

            cal_film.SelectedDate = DateTime.Now;
            UpdateList();
        }

        public void UpdateList()
        {
            ObservableCollection<Film_Calendar> eventColl = new ObservableCollection<Film_Calendar>();

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
            if (eventColl.Count == 0)
            {
                tb_isEmpty.Visibility = Visibility.Visible;
            }
            else
            {
                tb_isEmpty.Visibility = Visibility.Hidden;
            }

            lv_event.ItemsSource = eventColl;
        }

        private void btn_searchFriend_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FriendCollectionPage());
        }

        private void btn_Statistic_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StatisticsPage(AuthorizationPage.user));
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void btn_Tests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestsPage());
        }
    }
}
