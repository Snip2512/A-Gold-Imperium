using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producer  {

    private PopGroup employees;
    private string provID;
    private string outputType;
    private int outputCount;
    private int maxPop;


    public Producer(string pID, string o) {
        provID = pID;
        outputType = o;
        PopGroup pg = new PopGroup(0, o);
        employees = pg;
        maxPop = 2000;       
    }

    public string GetProductType() {
        return outputType;
    }

    public int GetAvailableJobs() {
        int availJobs = maxPop - employees.GetPopulation();          
        if (availJobs < 0) {
            return 0;
        }
        else {
            return availJobs;
        }
    }

    public void AddNewEmployees(int i) {
        employees.AddPopulation(i);
    }

    public int GetEmployeeCount() {
       return employees.GetPopulation();
    }


}
