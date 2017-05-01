using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Contains initial game setup, most of which will be in ReadInData
 * Then contains the main game logic loop i guess. 
 * Main loop will be what actions to perform each day, unity will call this when appropriate
 */
 //Test username

public static class Main{

    public static void Setup() {

        ReadInData.ReadInProvinces();
        ReadInData.ConnectHexToProv();
        ReadInData.ReadInCountries();
        
        

    }

    public static void GameLoop() {

        //ListMaster.DisplayAllProvince();
        ListMaster.DisplayWorldPop();
        ListMaster.CheckForJobs();

    }


	
}
