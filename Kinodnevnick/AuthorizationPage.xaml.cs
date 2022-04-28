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
using Core;
using Core.DateBase;

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btn_regist_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void btn_authoriz_Click(object sender, RoutedEventArgs e)
        {
            string login = tb_login.Text;
            string password = tb_password.Text;
            User user = Core.Authorization.AuthorizationUser(login, password);
            if(user != null)
            {
                NavigationService.Navigate(new FilmMainPage(user));
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            tb_regist.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            tb_regist.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}