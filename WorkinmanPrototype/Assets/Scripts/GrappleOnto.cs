using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleOnto : MonoBehaviour
{
    private GameObject player;
    private LineRenderer line;
    private DistanceJoint2D joint;
    public Sprite enemyDead;
    private GameObject trout;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        line = player.GetComponent<LineRenderer>();
        joint = player.GetComponent<DistanceJoint2D>();
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.tag);

        //get the position of the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //set the position of the line
        line.SetPosition(0, mousePos);
        line.SetPosition(1, transform.position);

        //connect the anchor of the joint and enable it
        joint.connectedAnchor = mousePos;
        joint.enabled = true;

        //set the line renderer to true as well
        line.enabled = true;

        //check to see if you grappled onto the enemy if so change the sprite and disable the enemy
        if (gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = enemyDead;
            gameObject.GetComponent<EnemyBehavior>().enabled = false;
        }

        if(gameObject.tag == "Trout")
        {
            trout = gameObject;
            trout.GetComponent<Animator>().SetBool("TroutSpin", true);
        }
    }

    private void OnMouseUp()
    {
        //disable the line and the joint
        joint.enabled = false;
        line.enabled = false;
        
        if(trout != null) 
        { 
            trout.GetComponent<Animator>().SetBool("TroutSpin", false);
            trout.GetComponent<Animator>().enabled = false;
            trout.transform.localRotation = Quaternion.identity;
            trout.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
    }
}
