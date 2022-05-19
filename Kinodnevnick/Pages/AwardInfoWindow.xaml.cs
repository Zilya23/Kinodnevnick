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
using System.Collections.ObjectModel;
using Core;
using Core.DateBase;

namespace Kinodnevnick.Pages
{
	/// <summary>
	/// Interaction logic for AwardInfoWindow.xaml
	/// </summary>
	public partial class AwardInfoWindow : Window
	{
		public static Award award { get; set; }
		public AwardInfoWindow(Award awrd)
		{
			InitializeComponent();
			award = awrd;
			tb_AwardName.Text = award.Name;
			tb_AwardDisk.Text = award.Description;
			this.DataContext = this;

		}
	}
}
