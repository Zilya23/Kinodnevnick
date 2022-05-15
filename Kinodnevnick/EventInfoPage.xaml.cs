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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;
using Core.DateBase;

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для EventInfoPage.xaml
    /// </summary>
    public partial class EventInfoPage : Page
    {
        public static Film filmName { get; set; }
        Film_Calendar event_ { get; set; }
        public EventInfoPage(Film_Calendar Event_)
        {
            InitializeComponent();
            event_ = Event_;
            filmName = bd_connection.connection.Film.Where(a => a.ID == event_.ID_Film).FirstOrDefault();
            tb_film.Text = filmName.Name;
            tb_comment.Text = event_.Description;
            tb_date.Text = event_.Date.ToString().Split(' ')[0];
            tb_start_time.Text = event_.Start_Time.ToString().Split(':')[0];
            tb_start_time.Text = tb_start_time.Text+ ":" + event_.Start_Time.ToString().Split(':')[1];
            tb_end_time.Text = event_.End_Time.ToString().Split(':')[0];
            tb_end_time.Text = tb_end_time.Text + ":" + event_.End_Time.ToString().Split(':')[1];
        }

        private void img_redaction_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new EventEditPage(event_));
        }
    }
}
