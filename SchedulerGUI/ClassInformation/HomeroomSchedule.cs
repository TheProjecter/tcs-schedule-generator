using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulerGUI.ClassInformation
{
	/**
     * Homeroom schedule extends the Schedule class specific to the homeroom.
	 * The HomeroomSchedule should be completely full when the CSPSolver is complete.
	 * Also stores the homeroom name, and both homeroom teachers (Thai and foreign).
     */
    class HomeroomSchedule : Schedule
    {
		//Name of the homeroom (11a, 9-2, etc.)
        string homeroom;
		
		//Name of the foreign homeroom teacher.
        string homeroomTeacher1;
		
		//Name of the Thai homeroom teacher.
        string homeroomTeacher2;

        public HomeroomSchedule(Schedule schedule)
            : base(schedule)
        {
        }

		/**
         * Getter for the homeroom name.
         */
        public string getHomeroomName()
        {
            return homeroom;
        }

    }
}
