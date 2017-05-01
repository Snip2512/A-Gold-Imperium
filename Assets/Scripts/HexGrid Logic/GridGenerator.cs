using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    private float xVal = 1.732f * 2;
    private float ZVal = 1.5f * 2;

    public int xCount = 10;
    public int ZCount = 10;

    public GameObject HexRaw;
    public Material Woodland;
    public Material TestMat3;
    public Material EarthMat;
    public Material Farmland;
    private GameObject LatestHex;

    public void  init() {
        //Create the Grid!
        for (int i = 0; i < ZCount; i++) {
            for (int ii = 0; ii < xCount; ii++) {
                //Odd or even row?
                if (i % 2 == 0) {
                    LatestHex = Instantiate(HexRaw, new Vector3(ii * xVal, 0, i * ZVal), Quaternion.Euler(-90f, 0, 0));

                }
                else {
                    LatestHex = Instantiate(HexRaw, new Vector3(ii * xVal + (xVal / 2), 0, i * ZVal), Quaternion.Euler(-90f, 0, 0));
                
                }
                LatestHex.transform.parent = this.transform;
                LatestHex.transform.tag = "Hex";
                LatestHex.name = "Hex (" + i + "," + ii + ")";

                //set Hex colors based on Province Resources here!
                Material[] mats = LatestHex.GetComponent<Renderer>().materials;
                Province prov = ListMaster.getProvFromID(LatestHex.name);
                //If null this hex is not a "Province" and hence Ocean or something similar (desert,mountain etc)
                if (prov == null) {
                    mats[0] = TestMat3;
                    mats[1] = TestMat3;
                    mats[2] = TestMat3;
                }
                else {
                    //Otherwise go checkout its produce and paint the hex accordingly.
                    //Bottom of hex is product [0], right is product [1]. left is product [2]
                    List<Producer> producers = prov.GetProducers();
                    int num = 0;
                    foreach (Producer prod in producers) {
                        if (prod.GetProductType() == "timber") {
                            mats[num] = Woodland;
                        }
                        else if (prod.GetProductType() == "grain") {
                            mats[num] = Farmland;
                        }
                        else {
                            mats[num] = TestMat3;
                            Debug.Log("A province has an incorrect product and the hex cannot be painted correctly ");
                        }
                        num = num + 1;
                    }
                }

                mats[3] = EarthMat;
                LatestHex.GetComponent<Renderer>().materials = mats;
                Debug.Log(LatestHex.GetComponent<Renderer>().material.ToString());
            }
            
        }
    }


    void Update() {

    }
}
