////////////////////////////////////////////////////////////
//Name: Breanna Henriquez 
//Purpose: Script for the camerma to follow the player
////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //GameObject
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        //set the position to the player position
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
