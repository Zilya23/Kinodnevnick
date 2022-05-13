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
    /// Логика взаимодействия для EventWindow.xaml
    /// </summary>
    public partial class EventWindow : Window
    {
        public static Film filmName { get; set; }
        public EventWindow(Film_Calendar Event_)
        {
            InitializeComponent();
            Film_Calendar event_ = Event_;
            filmName = bd_connection.connection.Film.Where(a => a.ID == event_.ID_Film).FirstOrDefault();
            tb_film.Text = filmName.Name;
            tb_comment.Text = event_.Description;
            tb_date.Text = event_.Date.ToString();
            tb_start_time.Text = event_.Start_Time.ToString();
            tb_end_time.Text = event_.End_Time.ToString();
        }
    }
}
