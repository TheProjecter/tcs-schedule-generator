using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulerGUI.ClassInformation
{
	//Class for a course to be taught.
    class Course
    {
		//The course code, strictly numeric.
        int courseCode;
		
		//The course name to be put on the schedule.
        string courseName; 
        
		//The teacher for the course.
        string teacherName;
		
		//The room where the course will be taught.
        string courseRoom;
		
		//Number of hours per week that the course is taught.
        int hoursPerWeek;
		
		//Number of times the course has a double period.
        int doublePeriods;
		
		//Number of days the course is taught per week.
        int daysPerWeek;

		//Constructor for the Course which sets the parameter information calls the second constructor.
        public Course(int courseCode, string teacherName, string courseName, string courseRoom, int hoursPerWeek) 
            : this(courseCode, teacherName, courseName, courseRoom, hoursPerWeek, 0)
        {
        }
		
		//Constructor for the Course.  First checks null and throws IllegalArgumentException if nulls exist.
        public Course(int courseCode, string teacherName, string courseName, string courseRoom, int hoursPerWeek, int doublePeriods)
        {
			//Sets the namesake variables.
            this.courseCode = courseCode;
            this.teacherName = teacherName;
            this.courseName = courseName;
            this.courseRoom = courseRoom;
            this.hoursPerWeek = hoursPerWeek;
            this.doublePeriods = doublePeriods;
			
			//Days per week is the same as number of hours per week minus the number of times the course has double periods.
            this.daysPerWeek = hoursPerWeek - doublePeriods;        
        }
		
		//Getter for the course code.  Formatted as a string for the output schedule
        public string getCourseCode()
        {
            //Concatenate the course name and course code for formatting
            string information = courseName + courseCode;
            return information;
        }
		
		//Getter for the teacher's name.  Formatted for the output schedule.
        public string getTeacherName()
        {
            //Concatenate the teacher abbreviation with teacher's name for formatting.
            string information = " T. " + teacherName;
            return information;
        }
		
		//Getter for the course room.  Formatted for the output schedule.
        public string getCourseRoom()
        {
            //Concatenate grade abbreviation with course room for formatting
            string information = "G." + courseRoom;
            return information;
        }
		
		//Getter for the days per week.
        public int getDaysPerWeek()
        {
            return daysPerWeek;
        }
		
		//Getter for the number of double periods.
		public int getDoublePeriods()
		{
			return doublePeriods;
		}
    }
}
