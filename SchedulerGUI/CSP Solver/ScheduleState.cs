using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchedulerGUI.ClassInformation;
using System.Collections;

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
        Stack<Course> domainOfCourses;
		
		//Original constructor using an array of Schedules before the dictionary is made.
        public ScheduleState(List<Schedule> schedules, Course[] domainOfCourses) : this(schedules)
        {
			//Set the class variable to the courses remaining for scheduling.
            this.domainOfCourses = new Stack<Course>();
            
            foreach (Course course in domainOfCourses)
            {
                this.domainOfCourses.Push(course);
            }
			
			
        }

        public ScheduleState(List<Schedule> schedules, Stack<Course> domainOfCourses) : this(schedules)
        {
            this.domainOfCourses = domainOfCourses;
        }

        private ScheduleState(List<Schedule> schedules)
        {
            //For each schedule in the array, add it to the dictionary as a value.
            foreach (Schedule schedule in schedules)
            {
                //The key for HomeroomSchedules is the room name.
                if (schedule is HomeroomSchedule)
                {
                    this.schedules.Add(((HomeroomSchedule)schedule).getHomeroomName(), new HomeroomSchedule(schedule));
                }
                //The key for TeacherSchedules is the teacher's name.
                else if (schedule is TeacherSchedule)
                {
                    this.schedules.Add(((TeacherSchedule)schedule).getTeacherName(), new TeacherSchedule(schedule));
                }
            }
        }

		//Overloaded constructor for inputting the dictionary directly.
		public ScheduleState(Dictionary<string, Schedule> schedules, Stack<Course> domainOfCourses)
        {
            foreach (string str in schedules.Keys)
            {
                if (schedules[str] is HomeroomSchedule)
                {
                    this.schedules.Add(str, new HomeroomSchedule(schedules[str]));
                }
                if (schedules[str] is TeacherSchedule)
                {
                    this.schedules.Add(str, new TeacherSchedule(schedules[str]));
                }
            }

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
        public Stack<Course> getCourses()
        {
            return this.domainOfCourses;
        }

    }
}