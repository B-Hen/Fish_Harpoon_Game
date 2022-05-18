using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    float forceSpeed;

    // Start is called before the first frame update
    void Start()
    {
        forceSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //movement for when the player not moving
        if (rigidBody.velocity == new Vector2(0.0f, 0.0f))
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0)
            * Time.deltaTime * 5.0f;
        }

        //change the sprite to face the proper direction
        if(Input.GetAxis("Horizontal") > 0.0f)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (Input.GetAxis("Horizontal") < 0.0f)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

    //add forces to rigidbody so you don't lose momemtum
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddForce(rigidBody.velocity * forceSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddForce(rigidBody.velocity * forceSpeed);
        }
    }
}
