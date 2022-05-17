using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core.DateBase;
using Core;
using System.IO;

namespace Kinodnevnick.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public byte[] user_photo;
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void TextBlock_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            tb_back.Foreground = new SolidColorBrush(Colors.White);
        }

        private void tb_back_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            tb_back.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btn_newphoto_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "*.jpg|*.jpg|*.png|*.png"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                user_photo = File.ReadAllBytes(openFile.FileName);
                img_photo.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string nickName = tb_nick.Text.Trim();
            string login = tb_login.Text.Trim();
            string pass = tb_pass.Text.Trim();
            if (Registration.UniqueLogin(login))
            {
                if(nickName != "" && login != "" && pass != "")
                {
                    Registration.RegistrationUser(nickName, login, pass, user_photo);

                    System.Windows.MessageBox.Show("Аккаунт успешно создан!");
                    NavigationService.Navigate(new AuthorizationPage());
                }
                else
                {
                    System.Windows.MessageBox.Show("Заполните все поля!");
                }
            }
            else
            {
                tb_login.Text = "";
                System.Windows.MessageBox.Show("Придумайте другой логин");
            }
        }
    }
}
