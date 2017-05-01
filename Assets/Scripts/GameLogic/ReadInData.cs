using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
/* Initial setup class to read in the static game values at first launch
 * Will need a similar class to read in save games when i get there
 * Will eventually read in a File, could use an array as a short term solution
 */ 
public static class ReadInData {

    public static void ReadInProvinces() {

        FileStream fs = new FileStream(@"Assets\\Configs\\AutoProvinces.csv", FileMode.Open, FileAccess.Read);
        StreamReader readFile = new StreamReader(fs);
        string line;
        string[] row;
        readFile.ReadLine();
        while ((line = readFile.ReadLine()) != null) {
            if (!line.StartsWith("#")) {
                row = line.Split(';');
                Province prov = new Province(row[0], row[1], row[2],row[3],row[4],row[5]);
                ListMaster.AddProvince(prov);
            }
        }

    }

    public static void ReadInCountries() {


    }

    public static void ConnectHexToProv() {
        FileStream fs = new FileStream(@"Assets\\Configs\\AutoHexProv.csv", FileMode.Open,FileAccess.Read);
        StreamReader readFile = new StreamReader(fs);
        string line;
        string[] row;
        readFile.ReadLine();
        while ((line = readFile.ReadLine()) != null) {
            if (!line.StartsWith("#")) { 
                row = line.Split(';');
                ListMaster.AddProvID(row[0], row[1]);
            }
        }
        readFile.Close();

    }


}
