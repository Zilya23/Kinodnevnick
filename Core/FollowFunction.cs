using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DateBase;
using System.Collections.ObjectModel;

namespace Core
{
	public class FollowFunction
	{
		public static ObservableCollection<Follow> follows { get; set; }
		public static ObservableCollection<Follow> GetFollows(int id) 
		{
			return follows = new ObservableCollection<Follow>(bd_connection.connection.Follow.Where(x => x.ID_Follower_User == id).ToList());
		}
	}
}
