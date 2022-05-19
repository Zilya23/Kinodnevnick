using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.DateBase;

namespace Core
{
	public class TestFunction
	{
		public static ObservableCollection<Test> tests { get; set; }

		public static ObservableCollection<Test> GetTests() 
		{
			return new ObservableCollection<Test>(bd_connection.connection.Test.ToList());
		}

	}
}
