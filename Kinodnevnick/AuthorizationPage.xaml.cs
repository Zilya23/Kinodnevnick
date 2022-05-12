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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static User user;
        public static int pass_count = 0;
        public AuthorizationPage()
        {
            InitializeComponent();
            tb_login.Text = Properties.Settings.Default.Login;
        }

        private void btn_regist_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void btn_authoriz_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Password < DateTime.Now)
            {
                string login = tb_login.Text.Trim();
                string password = tb_password.Password.Trim();
                user = Core.Authorization.AuthorizationUser(login, password);
                if (user != null)
                {
                    if (cb_saveLogin.IsChecked.GetValueOrDefault())
                    {
                        Properties.Settings.Default.Login = tb_login.Text.Trim();
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.Login = null;
                        Properties.Settings.Default.Save();
                    }
                    NavigationService.Navigate(new FilmMainPage(user));
                }
                else
                {
                    pass_count++;
                    MessageBox.Show("Неверный логин или пароль", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (pass_count == 3)
                    {
                        pass_count = 0;
                        Properties.Settings.Default.Password = DateTime.Now.AddMinutes(1);
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы ввели неверный пароль 3 раза, возможность входа заблокирована на: \n" + (Properties.Settings.Default.Password - DateTime.Now).Seconds + " сек.");
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
            tb_regist.Foreground = new SolidColorBrush(Colors.White);
        }
    }
}
