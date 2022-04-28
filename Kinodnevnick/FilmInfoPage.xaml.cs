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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Core;

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для FilmInfoPage.xaml
    /// </summary>
    public partial class FilmInfoPage : Page
    {
        public static Core.DateBase.Film filmToFill { get; set; }
        public FilmInfoPage(Core.DateBase.Film film)
        {
            InitializeComponent();
            filmToFill = FilmFunction.GetFilmInfo(film);

            tbl_name.Text = filmToFill.Name;
            tbl_discription.Text = filmToFill.Description;
            this.DataContext = this;
        }
    }
}