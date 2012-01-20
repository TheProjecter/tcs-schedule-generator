using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulerGUI.ClassInformation
{
	/**
     * TeacherSchedule holds class information for each teacher extends from Schedule.
	 * TeacherSchedule should not be full when the CSP solver finishes.
     */
    class TeacherSchedule : Schedule
    {
		//Name of the teacher for which this schedule applies.
        string teacherName;
		
		//Name of the homeroom which this teacher presides over.
        string homeroomName;
		
		//Total number of hours taught by the teacher.
        int totalHours;

        public TeacherSchedule(Schedule schedule)
            : base(schedule)
        {
        }

		/**
         * Exports the schedule information to the Excel file with the given outputFileName
         */
        public void exportToExcel(string outputFileName)
        {
            
        }
		
		/**
         * Getter for the teacher's name.
         */
        public string getTeacherName()
        {
			//return the teacher's name.
            return teacherName;
        }
    }
}
