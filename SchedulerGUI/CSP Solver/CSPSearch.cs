using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulerGUI.CSP_Solver
{
	//Class to provide the backtracking search.
    class CSPSearch
    {
		//backtracking search method that returns the completed schedule state
        public ScheduleState backtrackingSearch(CSPSearchAgent startingProblem)
        {
			//Calls to the recursive method for backtracking search
            return recursiveBacktrackingSearch(startingProblem);
        }
		
		//Recursive backtracking search method using the remaining problem.
        private ScheduleState recursiveBacktrackingSearch(CSPSearchAgent remainingProblem)
        {
			//Check if the problem is complete.
            if (remainingProblem.isComplete())
            {
				//If so, return the completed scheduleState
                return remainingProblem.getScheduleState();
            }
			
			//Retrieve an array of successorStates from the CSPSearchAgent.
            ScheduleState[] successorStates = remainingProblem.getSuccessors();
			
			//Loop through the successor states.
            foreach (ScheduleState state in successorStates)
            {
				//Create a new CSPSearchAgent using the new successor state
                CSPSearchAgent nextProblem = new CSPSearchAgent(state);
				
				//If the problem does not violate constraints
                if (nextProblem.checkConstraints() == true)
                {
					//Recursively search the next set.
                    ScheduleState result = recursiveBacktrackingSearch(nextProblem);
					
					//If the result from the recursion is null,
                    if (result == null)
                    {
						//continue with the next state in the for loop.
                        continue;
                    }
					//Otherwise,
                    else
                    {
						//return the result.
                        return result;
                    }
                }

            }
			//If no solution is found, return null.
            return null;
        }
    }
}
