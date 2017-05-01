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
        //debug Method
        foreach (KeyValuePair<string, Province> prov in provinces) {           
            Debug.Log("Name: " + prov.Value.GetName() + " Unemployed: " + prov.Value.getUnemployedPop());            
        }
    }

    public static void DisplayWorldPop() {
        //debug method
        int pop = 0;
        foreach (KeyValuePair<string, Province> prov in provinces) {
            pop = pop + prov.Value.getUnemployedPop();
            List<Producer> producers = prov.Value.GetProducers();
            foreach (Producer p in producers) {
                pop = pop + p.GetEmployeeCount();
                }
            }
        Debug.Log("World Pop is: " + pop);
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

    public static void CheckForJobs() {
        //This method will run frequently (daily?) to check if any jobs are available for unemployed people within the Province
        //Eventually it should check for jobs within the country (eventually global-ish). Hence why it is here and not within the Provinces themselves

        foreach (KeyValuePair<string, Province> prov in provinces) {           
            int unemployedCount = prov.Value.getUnemployedPop();
            if(unemployedCount > 0) {
                List<Producer> producers = prov.Value.GetProducers();
                foreach (Producer p in producers) {
                    int availableJobs = p.GetAvailableJobs();
                    if (availableJobs > 0 && unemployedCount > 0) {
                        if (availableJobs > unemployedCount) {
                            //Chuck all unemployed into this producer if the count is low & producer jobs available are high
                            p.AddNewEmployees(unemployedCount);
                            unemployedCount = 0;                            
                        }
                        else {
                            //Otherwise split and slowly distribute jobs between producers
                            int unemployedPercent = (int)System.Math.Round((double)(unemployedCount * 5) / 100);
                            unemployedCount = unemployedCount - unemployedPercent;
                            p.AddNewEmployees(unemployedPercent);

                        }
                    }
                }
            }
            prov.Value.SetUnemployedPop(unemployedCount);
        }

    }


}
