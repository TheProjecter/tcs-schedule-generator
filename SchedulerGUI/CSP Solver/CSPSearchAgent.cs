using System;
using System.Collections;
using System.Linq;
using System.Text;
using SchedulerGUI.ClassInformation;
using System.Collections.Generic;

namespace SchedulerGUI.CSP_Solver
{
	/**
     * SearchAgent includes the methods required for the CSPSolver.  Contains the ScheduleState,
	 * provides access to successors, and provides checkers for goal states and completeness.
     */
    class CSPSearchAgent
    {
		
		//The current ScheduleState for successor generation and constraint checking.
        ScheduleState currentState;
		
		/**
         * Constructor taking the ScheduleState and creating a search agent for it.
         */
        public CSPSearchAgent(ScheduleState scheduleState)
        {
			//Assign it as the local variable.
            this.currentState = scheduleState;
        }
		
		/**
         * Method to check whether any constraints have been violated.  This does not require the 
		 * ScheduleState to be complete.  Includes checks for:
		 * Constraint 1: Teacher cannot have more than 5 periods in a day.
		 * Constraint 2: 
		 * Constraint 3:
         */
        public bool checkConstraints()
        {
            // Set up constraints.

            // For period X in Teacher.Unavailable, Course.Teacher != Schedule.Period
            return false;
        }
		
		/**
         * Method to check if the ScheduleState is complete.  Completeness occurs when the domain of courses left
		 * to schedule is empty.
         */
        public bool isComplete()
        {
			//Check to see if the Stack containing the courses is empty.
            if (currentState.getCourses().Peek() == null)
            {
				//If it is, then the state is complete.
                return true;
            }
			//If not, the state is incomplete.
            return false;
        }
		
		/**
         * Method for generating the successors for the given state.  Includes slight forward checking to make
		 * sure course is added only to the correct homeroom and teacher's schedules and that there are enough
		 * open spots in the homeroom and teacher's schedule during the necessary class period for the week.
         */
        public List<ScheduleState> getSuccessors()
        {
			//Start by initializing an Arraylist of ScheduleStates that will house the successors.  ArrayList
			//is used to allow dynamic size.
            List<ScheduleState> successors = new List<ScheduleState>();
			
			//For the next course remaining in the domain
            Course course = currentState.getCourses().First();

            successors.AddRange(getArrayListOfSuccessors(currentState, course));

			//Return the successorArray.
            return successors;
        }

        /**
         * Takes the course and finds all successor states for that course.  Returns an ArrayList containing the
         * successors.
         */
        private List<ScheduleState> getArrayListOfSuccessors(ScheduleState currentState, Course course)
        {
            //ArrayList of ScheduleStates to house results.
            List<ScheduleState> results = new List<ScheduleState>();

            //Get the class and teacher's schedules for the given course.
            Schedule classSchedule = currentState.getSchedule(course.getCourseRoom());
            Schedule teacherSchedule = currentState.getSchedule(course.getTeacherName());

            //For each period in the day
            for (int period = 0; period < classSchedule.getNumberOfPeriods(); period++)
            {

                //Get the list of possible days between the teacher and class schedules
                string daysPossible = intersectionOfStrings(classSchedule.openSlotsInSchedule(course, period),
                    teacherSchedule.openSlotsInSchedule(course, period));

                //Get the possible schedules for the class.
                List<string> possibleSchedules = getPossibleSchedules(daysPossible, course.getDaysPerWeek());
                results.AddRange(insertIntoSchedule(currentState, course, period, possibleSchedules));
                
            }
            return results;
        }

        /**
         * Method returning an ArrayList of possible schedules given the available days and the number
         * of periods required.
         */
        private List<string> getPossibleSchedules(string daysPossible, int periodsNeeded)
        {
            List<string> possibleDaySlots = new List<string>();
            switch (periodsNeeded)
            {
                case 1:
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "M"));
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "T"));
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "W"));
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "R"));
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "F"));
                    break;
                case 2:
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "TR"));
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "MW"));
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "WF"));
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "MF"));
                    break;
                case 3:
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "MWF"));
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "MTF"));
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "MRF"));
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "TRF"));
                    break;
                case 4:
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "MTRF"));
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "MWRF"));
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "MTWF"));
                    break;
                case 5:
                    possibleDaySlots.Add(intersectionOfStrings(daysPossible, "MTWRF"));
                    break;
            }
            return possibleDaySlots;
        }

        /**
         * Returns an List of ScheduleStates with the schedules from the currentstate updated with the 
         * new schedules with course in place.
         */
        private List<ScheduleState> insertIntoSchedule(ScheduleState currentState, Course course, 
            int period, List<string> possibleSchedules)
        {
            List<ScheduleState> results = new List<ScheduleState>();
            //Get the domainOfCourses and pop the first one off the stack.
            Stack<Course> domainOfCourses = currentState.getCourses();
            Course currentCourse = domainOfCourses.Pop();

            //Loop through the possible schedules.
            foreach (string possSchedule in possibleSchedules)
            {
                //Create a new ScheduleState with the current schedules and the remaining domainOfCourses.
                ScheduleState state = new ScheduleState(currentState.getSchedules(), domainOfCourses);
                Schedule classSchedule = state.getSchedule(currentCourse.getCourseRoom());
                Schedule teacherSchedule = state.getSchedule(currentCourse.getTeacherName());

                //Update the schedule.
                for (int i = 0; i < possSchedule.Length; i++)
                {
                    switch (possSchedule[i])
                    {
                        case 'M':
                            classSchedule.setCourse(0, period, currentCourse);
                            teacherSchedule.setCourse(0, period, currentCourse);
                            break;
                        case 'T':
                            classSchedule.setCourse(1, period, currentCourse);
                            teacherSchedule.setCourse(1, period, currentCourse);
                            break;
                        case 'W':
                            classSchedule.setCourse(2, period, currentCourse);
                            teacherSchedule.setCourse(2, period, currentCourse);
                            break;
                        case 'R':
                            classSchedule.setCourse(3, period, currentCourse);
                            teacherSchedule.setCourse(3, period, currentCourse);
                            break;
                        case 'F':
                            classSchedule.setCourse(4, period, currentCourse);
                            teacherSchedule.setCourse(4, period, currentCourse);
                            break;
                    }
                }
                results.Add(state);
            }
            return results;
        }

		//Getter method for the scheduleState
        public ScheduleState getScheduleState()
        {

			//return the scheduleState
            return this.currentState;
        }

        private string intersectionOfStrings(string string1, string string2)
        {
            string result = "";

            for (int i = 0; i < string1.Length; i++)
            {
                for (int j = 0; j < string2.Length; j++)
                {
                    if (string1[i] == string2[j])
                    {
                        result += string1[i];
                    }
                }
            }

            return result;
        }
    }
}
