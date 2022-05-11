﻿using System;
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
    /// Логика взаимодействия для FilmInCollectionPage.xaml
    /// </summary>
    public partial class FilmInCollectionPage : Page
    {
        public static ObservableCollection<Film_Collection> filmsToFill { get; set; }
        public int IDCollection;
        public FilmInCollectionPage(Collection collection)
        {
            InitializeComponent();
            filmsToFill = CollectionFunction.GetFilmInCollection(collection.ID);
            IDCollection = collection.ID;
            this.DataContext = this;
        }

        private void tb_back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CollectionMainPage());
        }

        private void tb_back_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_back.Foreground = new SolidColorBrush(Colors.White);
        }

        private void tb_back_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_back.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void img_redaction_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EditCollectionWindow editCollection = new EditCollectionWindow(IDCollection);
            editCollection.ShowDialog();
        }
    }
}