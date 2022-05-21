using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DateBase;
using System.Collections.ObjectModel;

namespace Core
{
	public class FollowersFunction
	{
		public static ObservableCollection<Follow> followers { get; set; }
		public static ObservableCollection<Follow> GetFollowers(int id)
		{
			return followers = new ObservableCollection<Follow>(bd_connection.connection.Follow.Where(x => x.ID_Following_User == id).ToList());
		}
	}
}
