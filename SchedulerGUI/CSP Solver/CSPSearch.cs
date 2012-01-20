using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SchedulerGUI.CSP_Solver
{
	/**
     * Class to provide the backtracking search.
     */
    class CSPSearch
    {
		/**
         * Backtracking search method that returns the completed schedule state.  This is the search called
         * by the form.  The recursive method defines the business operations.
         */
        public ScheduleState backtrackingSearch(CSPSearchAgent startingProblem)
        {
			//Calls to the recursive method for backtracking search.
            return recursiveBacktrackingSearch(startingProblem);
        }
		
		/**
         * Recursive backtracking search method using the remaining problem.  This method contains the algorithm
         * for the backtracking search.
         */
        private ScheduleState recursiveBacktrackingSearch(CSPSearchAgent remainingProblem)
        {
			//Check if the problem is complete.
            if (remainingProblem.isComplete())
            {
				//If so, return the completed scheduleState
                return remainingProblem.getScheduleState();
            }
			
			//Retrieve an array of successorStates from the CSPSearchAgent.
            List<ScheduleState> successorStates = remainingProblem.getSuccessors();
			
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
