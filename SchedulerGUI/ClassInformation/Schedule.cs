using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulerGUI.ClassInformation
{
	//Class representing the basic form for a schedule.  Includes the size of the schedule which is configurable.
	//
    abstract class Schedule
    {
		//Number of periods in any given day.
        private int numberOfPeriods = 6;
		
		//Constant value representing the number of days in a week.
        public const int DAYS_OF_THE_WEEK = 5;

        //Schedule is array of courses [Day, Period]
        Course[,] schedule;
		
		//Constructor for a blank schedule.
        public Schedule(int numberOfPeriods)
        {
			//Sets the number of periods for the day.
            this.numberOfPeriods = numberOfPeriods;
			//Initializes the schedule using the days of the week and number of periods per day.
            this.schedule = new Course[DAYS_OF_THE_WEEK, numberOfPeriods];
        }
		
		//Gets the number of empty course slots in a given period.
		public int getEmptySlots(int period) 
		{
			int counter = 0;
			//Loop through the days of the week in the given period.
			for(int i = 0; i<DAYS_OF_THE_WEEK; i++)
			{
				//If the course is empty,
				if (schedule[i, period-1] == null) 
				{
					//increase the counter
					counter++;
				}
			}
			//Return the number of empties.
			return counter;
		}
		
		//Getter method for a course given the day of the week and period.
        public Course getCourse(int day, int period)
        {
			//returns that course
            return this.schedule[day, period];
        }
		
		//Getter for number of periods in the day.
        public int getNumberOfPeriods()
        {
			//returns that number of periods.
            return this.numberOfPeriods;
        }
    }
}
