using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputTracker : MonoBehaviour {

    int hexLifted = 0;
    public float liftHeight = 2f;
    private Transform lastLifted;

    public GameObject HexEarth;
    public Material EarthMat;
    private GameObject EarthHex;

    void Start () {
		
	}
	
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);           
            if (Physics.Raycast(ray,out hit, 20)) {
                if (hit.transform.tag == "Hex") {
                    if (hexLifted == 0) {
                        LiftHex(hit.transform);                       
                    }
                    else {
                        lastLifted.Translate(0, 0, liftHeight * -1);
                        Destroy(EarthHex);
                        hexLifted = 0;
                        LiftHex(hit.transform);
                    }
                }
            }
        }
        //Reset Lifted Hex on Right Click
        if (Input.GetMouseButtonDown(1)) {
            if (hexLifted == 1) {
                lastLifted.Translate(0, 0, liftHeight * -1);
                Destroy(EarthHex);
                hexLifted = 0;
            }
        }

        }

    void LiftHex(Transform hitObj) {
        //Create Earth Patch underneath Lifted Hex
        EarthHex = Instantiate(HexEarth, new Vector3(hitObj.position.x, hitObj.position.y - 0.4f, hitObj.position.z), Quaternion.Euler(-90f, 0, 0));
        EarthHex.GetComponent<Renderer>().material = EarthMat;

        hitObj.Translate(0, 0, liftHeight);
        lastLifted = hitObj.transform;
        hexLifted = 1;
        GetProvInfo(hitObj);
    }

    void GetProvInfo(Transform hitObj) {
        //Read Hex name ie "Hex (0,0) and lookup on Lookup Array read from File
        string hex = hitObj.name;
        string name;
        if (ListMaster.provID.TryGetValue(hex, out name)){
            Debug.Log("This Prov is: " + name);
            //Can use this ID to do a lookup on the Province List and get all the Juicy details
        }
        else {
            Debug.Log("This Prov is not in the ProvID List and hence can be considered to be OCEAN!");
        }
    }

}

