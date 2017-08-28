using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Monster Class to hold Button functionality on the UI.


public class UIStats : MonoBehaviour {

    GameObject testText;

    // Use this for initialization
    void Start () {
        testText = GameObject.Find("TestText");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowStats() {       
        
        if (testText.activeSelf == true) {
            testText.SetActive(false);
        }else {
            testText.SetActive(true);
        }


    }
}
