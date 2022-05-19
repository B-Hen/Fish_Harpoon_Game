////////////////////////////////////////////////////////////////
//Name: Breanna Henriquez 
//Purpose: To handle the grappling aspect of the game
////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleOnto : MonoBehaviour
{
    //Variables
    private GameObject player;
    private LineRenderer line;
    private DistanceJoint2D joint;
    public Sprite enemyDead;
    private GameObject trout;
    public AudioSource harpoonSound;
    public AudioSource enemyDeadSound;
    public AudioSource cloudTouchSound;
    public AudioSource[] fishSounds;

    // Start is called before the first frame update
    void Start()
    {
        //find the different components
        player = GameObject.Find("Player");
        line = player.GetComponent<LineRenderer>();
        joint = player.GetComponent<DistanceJoint2D>();
    }

    private void OnMouseDown()
    {
        harpoonSound.Play();
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
        if (gameObject.tag == "Enemy" && gameObject.GetComponent<EnemyBehavior>().enabled)
        {
            enemyDeadSound.Play();
            gameObject.GetComponent<SpriteRenderer>().sprite = enemyDead;
            gameObject.GetComponent<EnemyBehavior>().enabled = false;
            ManageScene.score += 25;
            player.GetComponent<ManageScene>().scoreText.text = "Score: " + ManageScene.score;
        }

        //check to see if you grappled onto the fish is so disable the sprite and play a random fish sound
        if(gameObject.tag == "Trout" && gameObject.GetComponent<Animator>().enabled)
        {
            int index = Random.Range(0, 3);
            fishSounds[index].Play();

            trout = gameObject;
            trout.GetComponent<Animator>().SetBool("TroutSpin", true);
            ManageScene.score += 100;
            player.GetComponent<ManageScene>().scoreText.text = "Score: " + ManageScene.score;
            ManageScene.fishAmount++;
            player.GetComponent<ManageScene>().fishText.text = "Fish: " + ManageScene.fishAmount;
        }
        //check to see if the game object is a cloud if so play cloud sound
        if(gameObject.tag == "Cloud")
        {
            cloudTouchSound.Play();
        }
    }

    private void OnMouseUp()
    {
        //disable the line and the joint
        joint.enabled = false;
        line.enabled = false;
        
        //if its a trout disable the ani,ation playing and gray out the fish
        if(trout != null) 
        { 
            trout.GetComponent<Animator>().SetBool("TroutSpin", false);
            trout.GetComponent<Animator>().enabled = false;
            trout.transform.localRotation = Quaternion.identity;
            trout.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
    }
}
