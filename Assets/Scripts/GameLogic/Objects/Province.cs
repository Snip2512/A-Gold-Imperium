using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* This object should contain mostly values.
 * Logic should be minimal here so avoid replication of code
 * 
 * 
 * 
 */

public class Province {

    private string id;
    private string name;
    private List<Producer> producers = new List<Producer>();
    private PopGroup unemployed;

    public Province(string iDVal, string pname, string p1, string p2, string p3, string pop) {
        id = iDVal;
        name = pname;
        Producer prod1 = new Producer(id, p1);
        Producer prod2 = new Producer(id, p2);
        Producer prod3 = new Producer(id, p3);
        producers.Add(prod1);
        producers.Add(prod2);
        producers.Add(prod3);
        int i = Int32.Parse(pop);
        setUnemployed(i, "unemployed"); //Distribute into the Producers post setup i guess?
    }

    public void setUnemployed(int pop, string gro) {
        unemployed = new PopGroup(pop, gro);
    }

    public string GetName() {
        return name;
    }

    public string GetID() {
        return id;
    }

    public void AddProducer(Producer producer) {
        producers.Add(producer);

    }

    public List<Producer> GetProducers() {
        return producers;
    }
}
