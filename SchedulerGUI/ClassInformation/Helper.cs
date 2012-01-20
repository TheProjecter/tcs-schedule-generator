using System;

namespace SchedulerGUI
{
	public class Helper
	{
		public Helper ()
		{

		}
		
		public static bool checkNull(object toCheck, string name)
		{
			if (toCheck == null) {
				throw System.IllegalArgumentException(name + " can not be null.");
			}
			return false;	
		}
	}
}

