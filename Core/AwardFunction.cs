using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.DateBase;

namespace Core
{
	public class AwardFunction
	{ 
		public static ObservableCollection<Award> awards { get; set; }
		public static ObservableCollection<Award> GetAwards()
		{
			return new ObservableCollection<Award>(bd_connection.connection.Award.ToList());
		}
	}
}
