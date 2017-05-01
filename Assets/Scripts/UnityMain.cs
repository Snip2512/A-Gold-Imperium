using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityMain : MonoBehaviour {

    private float timeNow;
    public float gameTick;

	void Start () {
        //I am the bridge to none unity scripts
        Main.Setup();
        GridGenerator gr = GameObject.Find("GridMasterObj").GetComponent<GridGenerator>();
        gr.init();
        timeNow = Time.time;
	}
	
	
	void Update () {
		if ((Time.time - timeNow) >= gameTick) {
            // Debug.Log("It's been 5 seconds yo  (" + Time.time + ")");
            //insert yo game loop here
            Main.GameLoop();
            timeNow = Time.time;
        }
	}
}
