using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Just testing out the UI connectivity
//Dont forget to import UnityEnginge.UI ;)

public class TextTest : MonoBehaviour {

	Province prov;
    Text text;

	void Start () {
        ListMaster.provinces.TryGetValue("STU",out prov);
	    Text text = GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update () {



    // text.text = prov.GetName() + " : " + prov.GetPopulation();
    }
}
