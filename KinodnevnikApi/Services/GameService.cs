using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core;
using Core.DateBase;

namespace KinodnevnikApi.Services
{
	public class GameService
	{
		static List<User> leaderboards = FriendFunction.GetLeader();
		static ObservableCollection<Award> awards = AwardFunction.GetAwards();

		public static List<User> Getleader() => leaderboards;
		public static ObservableCollection<Award> GetAwards() => awards;
	}
}
