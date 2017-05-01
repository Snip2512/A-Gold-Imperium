using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class is a static class used to calculate needs of a province
 * Values required will be passed by each object
 * Modifiers and such will also be passed
 * This class will simply hold the formulae to calculate the various needs
 * This means it does not need to be replicated on every single province class instead
 */

public static class NeedsCalculator{

	
	 public static int CalculateCornNeeds (int pop) {
        int demand = 0;
        demand = pop * 1;
        return demand;
    }
	

}
