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
    /// Логика взаимодействия для CollectionMainPage.xaml
    /// </summary>
    public partial class CollectionMainPage : Page
    {
        public static ObservableCollection<Collection> fullColl { get; set; }
        public CollectionMainPage()
        {
            InitializeComponent();
            fullColl = CollectionFunction.GetCollection(AuthorizationPage.user.ID);
            this.DataContext = this;
        }

        private void btn_main_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FilmMainPage(AuthorizationPage.user));
        }

        private void img_plus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NewCollectionWindow newCollection = new NewCollectionWindow(AuthorizationPage.user.ID);
            newCollection.ShowDialog();
            UpdateCollection();
        }

        private void lv_coll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var collId = (sender as ListView).SelectedItem as Collection;
            NavigationService.Navigate(new FilmInCollectionPage(collId));
        }

        public void UpdateCollection()
        {
            lv_coll.ItemsSource = CollectionFunction.GetCollection(AuthorizationPage.user.ID);
        }

        private void btn_dairy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new KalendarPage());
        }
    }
}