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
using System.Windows.Shapes;
using Core;
using Core.DateBase;

namespace Kinodnevnick.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEventWindow.xaml
    /// </summary>
    public partial class AddEventWindow : Window
    {
        Film_Calendar event_ { get; set; }
        DateTime dateEvents { get; set; }
        public AddEventWindow(DateTime dateEvent)
        {
            InitializeComponent();
            dateEvents = dateEvent;
            ObservableCollection<Film> filmCB = FilmFunction.GetFilm();
            cb_film.ItemsSource = filmCB;
            cb_film.DisplayMemberPath = "Name";
            tb_date.Text = dateEvent.ToString().Split(' ')[0];
        }

        private void tp_startTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            TimeSpan timeStart = TimeSpan.Parse(tp_startTime.Text);
            var filmName = cb_film.SelectedItem as Film;
            TimeSpan timeDuration = TimeSpan.FromMinutes(Convert.ToDouble(filmName.Duration));
            TimeSpan timeEnd = timeStart + timeDuration;
            TimeSpan timeSpanday = new TimeSpan(1, 0, 0, 0);
            if (timeEnd > timeSpanday)
            {
                string time = timeEnd.ToString().Split('.')[1];
                tb_end_time.Text = time.Split(':')[0];
                tb_end_time.Text = tb_end_time.Text + ":" + timeEnd.ToString().Split(':')[1];
            }
            else
            {
                tb_end_time.Text = timeEnd.ToString().Split(':')[0];
                tb_end_time.Text = tb_end_time.Text + ":" + timeEnd.ToString().Split(':')[1];
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Film_Calendar events = new Film_Calendar();
                TimeSpan timeStart = TimeSpan.Parse(tp_startTime.Text);
                TimeSpan timeEnd = TimeSpan.Parse(tb_end_time.Text);
                events.Date = dateEvents;
                events.ID_User = AuthorizationPage.user.ID;
                events.ID_Film = (cb_film.SelectedItem as Film).ID;
                events.Description = tb_comment.Text;
                events.Start_Time = timeStart;
                events.End_Time = timeEnd;
                KalendarFunction.AddEvent(events);
                this.DialogResult = true;
                LevelFunction.EventAddXP(AuthorizationPage.user.ID);
            }
            catch
            {
                MessageBox.Show("Заполните все обязательные поля");
            }
        }

        private void cb_film_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cb_film.SelectedItem != null)
            {
                tp_startTime.Visibility = Visibility.Visible;
            }
        }
    }
}
