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

namespace Kinodnevnick
{
    /// <summary>
    /// Логика взаимодействия для NewCollectionWindow.xaml
    /// </summary>
    public partial class NewCollectionWindow : Window
    {
        public int ID;
        public NewCollectionWindow(int UserID)
        {
            InitializeComponent();
            ID = UserID;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string collectionName = tb_name.Text;
            CollectionFunction.NewCollection(collectionName, ID);
            this.DialogResult = true;
        }
    }
}
