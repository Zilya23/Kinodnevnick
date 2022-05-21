using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.DateBase
{
	public partial class Follow
	{
		public User Following => User1;
		public User Follower => User;
	}
}
