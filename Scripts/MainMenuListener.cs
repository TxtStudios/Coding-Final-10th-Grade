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

This class is for the Main Menu. It handles the button clicks and changes scenes / ui accordingly

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuListener : MonoBehaviour {

    private Button playButton;

    private void Start()
    {
        
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        playButton.onClick.AddListener(PlayButtonClick);
    }

    void PlayButtonClick()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
