﻿using System;
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
using Core.DateBase;

namespace Kinodnevnick.Pages
{
    /// <summary>
    /// Логика взаимодействия для EventWindow.xaml
    /// </summary>
    public partial class EventWindow : Window
    {
        public EventWindow(Film_Calendar Event_)
        {
            InitializeComponent();
            frame_event.NavigationService.Navigate(new EventInfoPage(Event_));
        }
    }
}
