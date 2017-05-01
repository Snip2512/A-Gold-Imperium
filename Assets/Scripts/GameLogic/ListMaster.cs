using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*This class will hold all the lists and enable access to every country,province & business
 * This class can probably also be static as there will only ever be 1 ListMaster? Need to research this.
 * This is the heart of the simulation process 
 */
public static class ListMaster {

    public static Dictionary<string,Province> provinces = new Dictionary<string,Province>();
    public static List<Country> countries = new List<Country>();
    public static Dictionary<string, string> provID = new Dictionary<string, string>();

    public static void AddCountry(Country country) {
        countries.Add(country);

    }

    public static void AddProvince(Province province) {
        provinces.Add(province.GetID(), province);

    }

    public static void DisplayAllProvince() {
        foreach (KeyValuePair<string, Province> prov in provinces) {           
            Debug.Log("Name: " + prov.Value.GetName() + " Population: " );
            
        }
    }

    public static void AddProvID(string hex, string ID) {
        provID.Add(hex, ID);
    }

    public static Province getProvFromID(string hexid) {
        //Good standard handling of List Fetches here, reuse this code for other lists!
        string provid;
        Province prov;
        if (provID.TryGetValue(hexid, out provid)) {
            provinces.TryGetValue(provid, out prov);
        }
        else {
            prov = null;
        }

        return prov;
    }


}
