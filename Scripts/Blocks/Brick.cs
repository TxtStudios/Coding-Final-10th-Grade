using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameController gameController;
    public GameObject playerObject;

    Player player;

    bool blockHit = false;

    private void Start()
    {
        //Look for GameController
        GameObject controllerObject = GameObject.FindWithTag("GameController");
        if (controllerObject != null)
        {
            gameController = controllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Failed to find Game Controller Error 01");
        }

        //Get player variables
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(player.isBig)
            {
                StartCoroutine(moveBlock(
                        gameObject.transform.position,
                        new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f, gameObject.transform.position.z),
                        0.5f
                    ));
                Destroy(gameObject);
                gameController.playSound("brickSmash");
            }
            else
            {
                if (!blockHit)
                {
                    blockHit = true;
                    //Player not big, so dont destroy brick
                    StartCoroutine(moveBlock(
                        gameObject.transform.position,
                        new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f, gameObject.transform.position.z),
                        0.5f
                        ));
                }
            }
        }
        else
        {
            return;
        }
    }

    private IEnumerator moveBlock(Vector3 currentPosition, Vector3 newPosition, float waitTime)
    {
        Debug.Log("Moving block up");
        gameObject.transform.position = Vector3.MoveTowards(currentPosition, newPosition, 1f);
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Moving block down");
        gameObject.transform.position = Vector3.MoveTowards(newPosition, currentPosition, 1f);
        yield return new WaitForSeconds(waitTime);
        blockHit = false;
    }

}
