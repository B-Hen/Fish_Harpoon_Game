using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavoir : MonoBehaviour
{
    private GameObject player;
    Vector3 targetPosition;
    float moveSpeed;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        targetPosition = player.transform.position;
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        //if the bullet reaches the target positon without hitting the target destory it
        if(transform.position == targetPosition) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
