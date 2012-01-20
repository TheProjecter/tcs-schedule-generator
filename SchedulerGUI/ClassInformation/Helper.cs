using System;

namespace SchedulerGUI
{
    /**
     * Helper class to provide common methods used by other classes.
     */
	public class Helper
	{
        /**
         * Private constructor to prevent instantiation.
         */
		private Helper ()
		{

		}
		
        /**
         * Null checking method.  If null, throws a ArgumentNullException.  If not null, returns false.
         */
		public static bool checkNull(object toCheck, string name)
		{
            // Check if null
			if (toCheck == null) {
                //Throw ArgumentNullException with message that the object cannot be null.
				throw new System.ArgumentNullException(name + " can not be null.");
			}
            //Else returns false
			return false;	
		}
	}
}

