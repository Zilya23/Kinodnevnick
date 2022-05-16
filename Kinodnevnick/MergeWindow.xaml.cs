using Core;
using Core.DateBase;
using System;
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
using System.Windows.Shapes;

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для MergeWindow.xaml
    /// </summary>
    public partial class MergeWindow : Window
    {
        public static int IdFriendColl { get; set; }
        public MergeWindow(int idColl)
        {
            InitializeComponent();
            IdFriendColl = idColl;
            ObservableCollection<Collection> collection = CollectionFunction.GetCollection(AuthorizationPage.user.ID);
            cb_collection.ItemsSource = collection;
            cb_collection.DisplayMemberPath = "Name";
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if(cb_collection.SelectedItem != null)
            {
                var userColl = cb_collection.SelectedItem as Collection;
                FriendFunction.MergeCollection(IdFriendColl, userColl.ID, AuthorizationPage.user.ID);
                SinteszSelectionWindow sinteszSelectionWindow = new SinteszSelectionWindow();
                if(sinteszSelectionWindow.ShowDialog() == true)
                {
                    this.DialogResult = true;
                }
                else
                {
                    this.DialogResult = false;
                }
            }
        }
    }
}
