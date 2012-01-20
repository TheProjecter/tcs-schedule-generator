using System;
using System.Collections;
using System.Linq;
using System.Text;
using SchedulerGUI.ClassInformation;

namespace SchedulerGUI.CSP_Solver
{
	//SearchAgent includes the methods required for the CSPSolver.  Contains the ScheduleState,
	//provides access to successors, and provides checkers for goal states and completeness.
    class CSPSearchAgent
    {
		
		//The current ScheduleState for successor generation and constraint checking.
        ScheduleState currentState;
		
		//Constructor taking the ScheduleState
        public CSPSearchAgent(ScheduleState scheduleState)
        {
			//Assign it as the local variable.
            this.currentState = scheduleState;
        }
		
		//Method to check whether any constraints have been violated.  This does not require the 
		//ScheduleState to be complete.  Includes checks for:
		// - Constraint 1
		// - Constraint 2
		// - Constraint 3
        public bool checkConstraints()
        {
            // Set up constraints.

            // For period X in Teacher.Unavailable, Course.Teacher != Schedule.Period
            return false;
        }
		
		//Method to check if the ScheduleState is complete.  Completeness occurs when the domain of courses left
		//to schedule is empty.
        public bool isComplete()
        {
			//Check to see if the array containing the courses is empty.
            if (currentState.getCourses().Length == 0)
            {
				//If it is, then the state is complete.
                return true;
            }
			//If not, the state is incomplete.
            return false;
        }
		
		//Method for generating the successors for the given state.  Includes slight forward checking to make
		//sure course is added only to the correct homeroom and teacher's schedules and that there are enough
		//open spots in the homeroom and teacher's schedule during the necessary class period for the week.
        public ScheduleState[] getSuccessors()
        {
			//Start by initializing an Arraylist of ScheduleStates that will house the successors.  ArrayList
			//is used to allow dynamic size.
            ArrayList<ScheduleState> successors = new ArrayList<ScheduleState>();
			
			//For each course remaining in the domain
            foreach (Course course in currentState.getCourses())
            {
				//Get the class and teacher's schedules for the given course.
                Schedule classSchedule = currentState.getSchedule(course.getCourseRoom());
                Schedule teacherSchedule = currentState.getSchedule(course.getTeacherName());
				
				//For each period in the day
                for (int i = 0; i < classSchedule.getNumberOfPeriods(); i++)
                {
					//Check if the course fits into the schedule
                    if (course.getDaysPerWeek() <= classSchedule.getEmptySlots(i)) 
                    {
						//Check for double periods.
						if(course.getDoublePeriods > 0 && i + 1 < classSchedule.getNumberOfPeriods())
						{
							//Check if the course fits into the schedule still.
						}
						//Insert it into the schedule.
						
                    }
					//Otherwise
					else 
					{
						//continue the for loop.
						continue;
					}

                }
            }
			
			//Create an array of ScheduleStates to return
			ScheduleState[] successorArray = new ScheduleState[successors.Length()];
			//Create counter.
			int j = 0;
			
			//Copy the successorStates to the successorArray
		    foreach (ScheduleState state in successors) {
				successorArray[j] = state;
				j++;
			}
			
			//Return the successorArray.
            return successorArray;
        }
		
		//Getter method for the scheduleState
        public ScheduleState getScheduleState()
        {
			//return the scheduleState
            return this.currentState;
        }
    }
}
