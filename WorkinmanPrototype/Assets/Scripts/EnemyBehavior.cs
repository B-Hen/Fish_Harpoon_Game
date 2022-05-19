using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //GameObjects
    GameObject player;
    public GameObject bullet;

    //Floats
    private float radius;
    private float timer = 1.0f;
    private float distance;

    //Audio
    public AudioSource shootSound;

    //Transforms
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        //find the play object and set the radius on start
        player = GameObject.Find("Player");
        radius = 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if the player is within the radius if so decrease the timer
        if(distance <= radius) { timer -= Time.deltaTime; }

        //check to see if there is a collision
        CircleCollision();
    }

    //method to check if the player is in range of the  enemey
    private void CircleCollision()
    {
        //get the distance between the player and the enemey
        distance = Vector3.Distance(player.transform.position, transform.position);

        //check to see if the distance is less than radius and that the time for bullet is less or equal to 0
        if(distance <= radius && timer <= 0.0f)
        {
            //check to see what way the sprites need to face
            if(player.transform.position.x > transform.position.x)
            {
                //create a bullet at the tip of the gun of the enemy and then make it move with the rb using force
                transform.localScale = new Vector2(1, 1);
                shootSound.Play();
                GameObject bulletObj = Instantiate(bullet, firePoint.position, firePoint.rotation);
                bulletObj.transform.localScale = new Vector2(1, 1);
                firePoint.up = player.transform.position - firePoint.position;
                bulletObj.GetComponent<Rigidbody2D>().AddForce(firePoint.up * 10.0f, ForceMode2D.Impulse);
            }
            else if(player.transform.position.x < transform.position.x)
            {
                //create a bullet at the tip of the gun of the enemy and then make it move with the rb using force
                shootSound.Play();
                transform.localScale = new Vector2(-1, 1);
                GameObject bulletObj = Instantiate(bullet, firePoint.position, firePoint.rotation);
                bulletObj.transform.localScale = new Vector2(-1, 1);
                firePoint.up = player.transform.position - firePoint.position;
                bulletObj.GetComponent<Rigidbody2D>().AddForce(firePoint.up * 10.0f, ForceMode2D.Impulse);
            }

            //reset the timer when the a bullet is shot
            timer = 1.0f;
        }
    }
}
