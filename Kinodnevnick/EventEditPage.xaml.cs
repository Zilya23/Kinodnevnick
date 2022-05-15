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
    /// Логика взаимодействия для EventEditPage.xaml
    /// </summary>
    public partial class EventEditPage : Page
    {
        public static Film filmName { get; set; }
        Film_Calendar event_ { get; set; }
        public EventEditPage(Film_Calendar Event_)
        {
            InitializeComponent();
            event_ = Event_;
            filmName = bd_connection.connection.Film.Where(a => a.ID == event_.ID_Film).FirstOrDefault();

            ObservableCollection<Film> filmCB = FilmFunction.GetFilm();
            cb_film.ItemsSource = filmCB;
            cb_film.DisplayMemberPath = "Name";
            cb_film.SelectedItem = filmCB.Where(a => a.Name == filmName.Name).FirstOrDefault();
            tb_comment.Text = event_.Description;
            tb_date.Text = event_.Date.ToString().Split(' ')[0];
            tp_startTime.Text = event_.Start_Time.ToString();
            tb_end_time.Text = event_.End_Time.ToString().Split(':')[0];
            tb_end_time.Text = tb_end_time.Text + ":" + event_.End_Time.ToString().Split(':')[1];
        }

        private void tp_startTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            event_.ID_Film = (cb_film.SelectedItem as Film).ID;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
