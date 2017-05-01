using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producer  {

    private List<PopGroup> popGroups = new List<PopGroup>();
    private string provID;
    private string outputType;
    private int outputCount;

    public Producer(string pID, string o) {
        provID = pID;
        outputType = o;
        PopGroup pg = new PopGroup(0, o);
        popGroups.Add(pg);

    }

    public string GetProductType() {
        return outputType;
    }

}
