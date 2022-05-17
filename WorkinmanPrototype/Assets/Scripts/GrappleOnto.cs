using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleOnto : MonoBehaviour
{
    private GameObject player;
    private LineRenderer line;
    private DistanceJoint2D joint;
    public Sprite enemyDead;

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

        if (gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = enemyDead;
            gameObject.GetComponent<EnemyBehavior>().enabled = false;
        }
    }

    private void OnMouseUp()
    {
        //disable the line and the joint
        joint.enabled = false;
        line.enabled = false;
    }
}
