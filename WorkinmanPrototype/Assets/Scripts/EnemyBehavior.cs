using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    GameObject player;
    private float radius;
    public GameObject bullet;
    float timer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        radius = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        CircleCollision();
    }

    private void CircleCollision()
    {
        //get the distance between the player and the enemey
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance <= radius && timer <= 0.0f)
        {
            if(player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(1, 1);
                GameObject bulletObj = Instantiate(bullet, new Vector3(transform.position.x + 0.5505215f, transform.position.y + (-0.02231844f), 0.0f), Quaternion.identity);
                bulletObj.transform.localScale = new Vector2(1, 1);
            }
            else if(player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
                GameObject bulletObj = Instantiate(bullet, new Vector3(transform.position.x - 0.5505215f, transform.position.y + (-0.02231844f), 0.0f), Quaternion.identity);
                bulletObj.transform.localScale = new Vector2(-1, 1);
            }

            timer = 5.0f;
        }
    }
}
