using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    GameObject player;
    private float radius;
    public GameObject bullet;
    float timer = 1.0f;
    float distance;
    public AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        radius = 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(distance <= radius) { timer -= Time.deltaTime; }
        CircleCollision();
    }

    private void CircleCollision()
    {
        //get the distance between the player and the enemey
        distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance <= radius && timer <= 0.0f)
        {
            if(player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(1, 1);
                shootSound.Play();
                GameObject bulletObj = Instantiate(bullet, new Vector3(transform.position.x + 0.5505215f, transform.position.y + (-0.02231844f), 0.0f), Quaternion.identity);
            }
            else if(player.transform.position.x < transform.position.x)
            {
                shootSound.Play();
                transform.localScale = new Vector2(-1, 1);
                GameObject bulletObj = Instantiate(bullet, new Vector3(transform.position.x - 0.5505215f, transform.position.y + (-0.02231844f), 0.0f), Quaternion.identity);
            }

            timer = 1.0f;
        }
    }
}
