using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ProvinceGenerator : MonoBehaviour {

    public int xCount;
    public int zCount;


	//This script can be used to generate a random terrain layout.
    //Good for testing shit
    //Could redevelop eventually as an easy way to add new provs and create the final map
	void Start () {

        
        string[] products = new string[3];       
        string provID = "a";
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var stringChars = new char[3];
        System.Random random = new System.Random();
        

        FileStream fs = new FileStream(@"Assets\\Configs\\AutoHexProv.csv", FileMode.Create, FileAccess.Write);
        StreamWriter writeFile = new StreamWriter(fs);
        FileStream fs2 = new FileStream(@"Assets\\Configs\\AutoProvinces.csv", FileMode.Create, FileAccess.Write);
        StreamWriter writeFile2 = new StreamWriter(fs2);
        writeFile.WriteLine("#This was created for a grid of the following size:");
        writeFile.WriteLine("#X axis: " + xCount);
        writeFile.WriteLine("#Z axis: " + zCount);
        writeFile2.WriteLine("#This was created for a grid of the following size:");
        writeFile2.WriteLine("#X axis: " + xCount);
        writeFile2.WriteLine("#Z axis: " + zCount);
        
        for (int i = 0; i < zCount; i++) {
            for (int ii = 0; ii < xCount; ii++) {

                for (int z = 0; z < stringChars.Length; z++) {
                    //generate a random 3 letter string for provID. This'll crash if it happens to generate a duplicate.
                    stringChars[z] = chars[random.Next(chars.Length)];
                    
                }
                provID = new string(stringChars);

                for (int val = 0; val < products.Length; val++) {
                    ;
                    if (random.Next(2) == 0) {
                        products[val] = "grain";
                    }
                    else {
                        products[val] = "timber";
                    }
                }

                writeFile.WriteLine("Hex (" + i + "," + ii + ");" + provID);
                writeFile2.WriteLine(provID +";"+ provID + ";" + products[0] + ";" + products[1] + ";" + products[2] + ";" + 0);
            }
        }
        writeFile.Close();
        writeFile2.Close();



    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
