using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchedulerGUI.ClassInformation;

namespace SchedulerGUI.CSP_Solver
{
	//Class holding the state of the CSP solver.  Holds a dictionary of schedules and remaining courses to schedule.
	//The ScheduleState is the element that will remain on the fringe.
    class ScheduleState
    {
		//Dictionary keeping the schedules of both teachers and homerooms.
		//Key = room name or teacher's name, Value = corresponding schedule.
        Dictionary<string, Schedule> schedules;
		
		//The remaining courses to schedule.
        Course[] domainOfCourses;
		
		//Original constructor using an array of Schedules before the dictionary is made.
        public ScheduleState(Schedule[] schedules, Course[] domainOfCourses)
        {
			//Set the class variable to the courses remaining for scheduling.
			this.domainOfCourses = domainOfCourses;
			
			//For each schedule in the array, add it to the dictionary as a value.
            foreach (Schedule schedule in schedules)
            {
				//The key for HomeroomSchedules is the room name.
                if (schedule is HomeroomSchedule)
                {
                    schedules.Add(((HomeroomSchedule)schedule).getHomeroomName(), schedule);
                }
				//The key for TeacherSchedules is the teacher's name.
                else if (schedule is TeacherSchedule)
                {
                    schedules.Add(((TeacherSchedule)schedule).getTeacherName(), schedule);
                }
            }
        }
		
		//Overloaded constructor for inputting the dictionary directly.
		public ScheduleState(Dictionary<string, Schedule> schedules, Course[] domainOfCourses) 
		{
			this.schedules = schedules;
			this.domainOfCourses = domainOfCourses;
		}
		
		//Getter method for schedules dictionary.
        public Dictionary<string, Schedule> getSchedules()
        {
            return this.schedules;
        }
		
		//Getter method for a schedule from the dictionary, when given a room name or teacher's name.
        public Schedule getSchedule(string classOrTeacher)
        {
            return schedules[classOrTeacher];
        }
		
		//Getter method for the remaining courses.
        public Course[] getCourses()
        {
            return this.domainOfCourses;
        }

    }
}