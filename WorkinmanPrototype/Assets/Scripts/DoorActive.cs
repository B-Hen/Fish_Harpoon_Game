//////////////////////////////////////////////////////////////////////
//Name: Breanna Henriquez 
//Purpose: To check if the door is active for the player
//////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActive : MonoBehaviour
{
    //GameObject
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        //check to fish amount and if it is equal to  6 (the amount of fish in the scene)
        if(ManageScene.fishAmount == 6)
        {
            //enable the door components
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
