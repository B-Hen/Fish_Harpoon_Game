using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavoir : MonoBehaviour
{
    private GameObject player;
    Vector3 targetPosition;
    float moveSpeed;
    float speed;
    Rigidbody2D rigidBody;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        targetPosition = player.transform.position;
        speed = 10f;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        timer = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        if(timer <= 0) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
