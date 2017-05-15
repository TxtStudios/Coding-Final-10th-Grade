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

This class is for the mechanics for the item blocks. It handles the collision with the player, 
and any texture and animation work, as well as the determining and spawning of the item to give 
to the player upon hitting the box.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlock : MonoBehaviour {

    bool blockHit = false;

    public Texture notHitTexture;
    public Texture hitTexture;

    public int boxid = 0;
    public string itemGiven;

    public GameController gameController;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.mainTexture = notHitTexture;

        //Look for GameController
        GameObject controllerObject = GameObject.FindWithTag("GameController");
        if(controllerObject != null)
        {
            gameController = controllerObject.GetComponent<GameController>();
        } else
        {
            Debug.Log("Failed to find Game Controller Error 01");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //If player hit block
        {
            if (!blockHit)
            {
                blockHit = true;
                Debug.Log("Itemblock hit");

                StartCoroutine(
                    moveBlock(
                        gameObject.transform.position,
                        new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z),
                        .5f
                    ) //end moveblock
                ); //end coroutine

                gameObject.GetComponent<Renderer>().material.mainTexture = hitTexture;
                Debug.Log(itemGiven);

                if (itemGiven == "coin")
                {
                    gameController.addCoin(1);
                    gameController.playSound("coin");
                } else
                {
                    gameController.playSound("powerUpAppear");
                }

            } else
            {
                Debug.Log("Block has already been hit. Doing nothing");
                return;
            }
        }

    }

    public void notifyForId() //Will be called by GameController to notify the block that it has been assigned an ID
    {
        Debug.Log("        Generating item for box " + boxid);
        itemGiven = getItem(boxid);
    }

    private IEnumerator moveBlock(Vector3 currentPosition, Vector3 newPosition, float waitTime)
    {
        Debug.Log("Moving block up");
        gameObject.transform.position = Vector3.MoveTowards(currentPosition, newPosition, 1f);
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Moving block down");
        gameObject.transform.position = Vector3.MoveTowards(newPosition, currentPosition, 1f);
        yield return new WaitForSeconds(waitTime);
    }

    private string getItem(int id)
    {

        switch(id)
        {
            case 0:
                return "coin";
            case 1:
                return "mushroom";
            default:
                return "coin";
        }

    } 

}
