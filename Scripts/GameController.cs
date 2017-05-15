/*-------------------------------------------------------------------------------------------------
       dP          dP                                     dP                          dP       
       88          88                                     88                          88       
       88 .d8888b. 88d888b. 88d888b. 88d888b. dP    dP    88        .d8888b. .d8888b. 88  .dP  
       88 88'  `88 88'  `88 88'  `88 88'  `88 88    88    88        88ooood8 88ooood8 88888"   
88.  .d8P 88.  .88 88    88 88    88 88    88 88.  .88    88        88.  ... 88.  ... 88  `8b. 
 `Y8888'  `88888P' dP    dP dP    dP dP    dP `8888P88    88888888P `88888P' `88888P' dP   `YP 
                                                   .88                                         
                                               d8888P                                         
-------------------------------------------------------------------------------------------------

This is arguably the most important class in the game. It is the main hub for every aspect of the
game. It gives the item blocks their id's, which tells them what item to give, as well as handling
the main mechanics of the game, counting score, keeping track of enemy movements, and keeping the
game running in general. It handles most of the startup code, and initializes most of the game.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject itemBlockContainer;
    public Text coinText;

    private void Start()
    {
        Debug.Log("Initializing Game.");
        DontDestroyOnLoad(transform.gameObject); //Keep this instance of the object running so that variables don't change.

        Debug.Log("Found " + itemBlockContainer.transform.childCount + " children for " + itemBlockContainer.name);
        Debug.Log("    Assigning ids to children");
        for(int i = 0; i < itemBlockContainer.transform.childCount; i++)
        {
            Debug.Log("    Child " + i + " of " + itemBlockContainer.name + " found.");
            ItemBlock newblock = itemBlockContainer.transform.GetChild(i).gameObject.GetComponent<ItemBlock>();
            Debug.Log("        Giving child box id: " + i);
            newblock.boxid = i;
            newblock.notifyForId();
        }

        coinText = coinText.GetComponent<Text>();
        coinText.text = "Coins: " + 0;

    }
    
}
