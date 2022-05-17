using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private float playerHealth;
    public GameObject HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check to see if the player has hit a bullet
        if(collision.collider.tag == "Bullet")
        {
            //reduce the player health and update the health bar
            playerHealth -= 0.1f;
            HealthBar.transform.localScale = new Vector3(playerHealth, 1f);
            Debug.Log(playerHealth);
            Debug.Log(HealthBar.transform.localScale.x);
        }
    }
}
