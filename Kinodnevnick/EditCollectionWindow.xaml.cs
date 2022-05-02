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
    /// Логика взаимодействия для EditCollectionWindow.xaml
    /// </summary>
    public partial class EditCollectionWindow : Window
    {
        public int ID;
        public EditCollectionWindow(int idColl)
        {
            InitializeComponent();
            ID = idColl;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string collectionName = tb_name.Text;
            CollectionFunction.EditCollectionName(ID, collectionName);
            this.DialogResult = true;
        }
    }
}
