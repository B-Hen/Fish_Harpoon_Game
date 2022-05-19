/////////////////////////////////////////////////////////////
//Name: Breanna Henriquez
//Purpose: To take care of the bullet after its been shot
/////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavoir : MonoBehaviour
{
    //if the bullet is off screen destory it
    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //if the bullet hits the water or the player destory it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Water" || collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
