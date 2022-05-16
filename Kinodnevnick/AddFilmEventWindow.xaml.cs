using System;
using System.Collections.Generic;
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

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для AddFilmEventWindow.xaml
    /// </summary>
    public partial class AddFilmEventWindow : Window
    {
        public static Film updateFilm { get; set; }
        public AddFilmEventWindow(Film film)
        {
            InitializeComponent();
            tb_film.Text = film.Name;
            updateFilm = film;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Film_Calendar events = new Film_Calendar();
                TimeSpan timeStart = TimeSpan.Parse(tp_startTime.Text);
                TimeSpan timeEnd = TimeSpan.Parse(tb_end_time.Text);
                events.Date = dt_date.SelectedDate;
                events.ID_User = AuthorizationPage.user.ID;
                events.ID_Film = updateFilm.ID;
                events.Description = tb_comment.Text;
                events.Start_Time = timeStart;
                events.End_Time = timeEnd;
                KalendarFunction.AddEvent(events);
                this.DialogResult = true;
            }
            catch
            {
                MessageBox.Show("Заполните все обязательные поля");
            }
        }

        private void tp_startTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            TimeSpan timeStart = TimeSpan.Parse(tp_startTime.Text);
            TimeSpan timeDuration = TimeSpan.FromMinutes(Convert.ToDouble(updateFilm.Duration));
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

        private void dt_date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dt_date.SelectedDate != null)
            {
                tp_startTime.Visibility = Visibility.Visible;
            }
        }
    }
}
