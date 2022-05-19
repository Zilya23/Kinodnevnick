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
	/// Interaction logic for EditProfilWindow.xaml
	/// </summary>
	public partial class EditProfilWindow : Window
	{
		public static User profil { get; set; }
		public byte[] user_photo;
		public EditProfilWindow(User user)
		{
			InitializeComponent();
			profil = user;
			tb_Name.Text = profil.Nickname;	
			user_photo = profil.Photo;
			this.DataContext = this;
		}

		private void btn_Save_Click(object sender, RoutedEventArgs e)
		{
			string nickName = tb_Name.Text.Trim();
			if (nickName != "")
			{
				Authorization.EditUser(profil.ID, user_photo, nickName);
				System.Windows.MessageBox.Show("Профиль успешно изменен!");
				this.DialogResult = true;
			}
			else 
			{
				System.Windows.MessageBox.Show("Заполните все поля!");
			}
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
	}
}
