using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopGroup  {

    private int population;
    private string group;
    private float income;
    private int cornNeed;
    private float capital;


    public PopGroup(int pop, string product) {

        population = pop;
        if (product == "grain") {
            group = "farmer";
        }
        if (product == "timber") {
            group = "labourer";
        }


    }

    public void CornNeeds() {
        cornNeed = NeedsCalculator.CalculateCornNeeds(population);

    }

    public int GetPopulation() {
        return population;
    }

    public void AddPopulation(int i) {
        population = population + i;
    }

    public void SetPopulation(int i) {
        population = i;
    }

}
