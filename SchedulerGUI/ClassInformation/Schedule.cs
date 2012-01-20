using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulerGUI.ClassInformation
{
	/**
     * Class representing the basic form for a schedule.  Includes the number of periods in the schedule,
     * which is configurable.
	 */
    abstract class Schedule
    {
		//Number of periods in any given day.
        private int numberOfPeriods = 6;
		
		//Constant value representing the number of days in a week.
        public const int DAYS_OF_THE_WEEK = 5;

        //Schedule is array of courses [Day, Period]
        Course[,] schedule;
		
		/**
         * Constructor for a blank schedule.
         */
        public Schedule(int numberOfPeriods)
        {
			//Sets the number of periods for the day.
            this.numberOfPeriods = numberOfPeriods;
			//Initializes the schedule using the days of the week and number of periods per day.
            this.schedule = new Course[DAYS_OF_THE_WEEK, numberOfPeriods];
        }

        /**
         * Constructor to create a Schedule from a schedule.
         */
        public Schedule(Schedule schedule)
        {
            Course[,] courses = this.getCourses();
            this.schedule = (Course[,])courses.Clone();
            this.numberOfPeriods = schedule.getNumberOfPeriods();
        }

        /**
         * Setter for course slot
         */
        public void setCourse(int day, int period, Course course)
        {
            schedule[day, period] = course;
        }

        /**
         * Method to determine if the given course fits into the given schedule at the given period. String
         * represents empty days available for class.
         */
        public string openSlotsInSchedule(Course course, int period)
        {
            string days = "";
            int counter = 0;
            if (getCourse(counter++, period) == null)
            {
                days += "M";
            }
            if (getCourse(counter++, period) == null)
            {
                days += "T";
            }
            if (getCourse(counter++, period) == null)
            {
                days += "W";
            }
            if (getCourse(counter++, period) == null)
            {
                days += "R";
            }
            if (getCourse(counter++, period) == null)
            {
                days += "F";
            }
            return days;
        }

		/**
         * Getter method for a course given the day of the week and period.
         */
        public Course getCourse(int day, int period)
        {
			//returns that course
            return this.schedule[day, period];
        }

        private Course[,] getCourses()
        {
            return this.schedule;
        }
		
		/**
         * Getter for number of periods in the day.
         */
        public int getNumberOfPeriods()
        {
			//returns that number of periods.
            return this.numberOfPeriods;
        }
    }
}
