///////////////////////////////////////////////////////
//Name:Breanna Henriquez 
//Purpose: handle player collison
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    //Float
    private float playerHealth;

    //GameObject
    public GameObject HealthBar;
    public GameObject Boat;

    //Audio
    public AudioSource playerHurt;
    public AudioSource splashSound;
    public AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        //set the starting health = 1 = 100
        playerHealth = 1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check to see if the player has hit a bullet
        if(collision.collider.tag == "Bullet")
        {
            //destory the bullet
            Destroy(collision.collider);

            //play the player hurt sound
            playerHurt.Play();

            //reduce the player health and update the health bar
            playerHealth -= 0.1f;

            //check to see if the health is 0 or below then load the game over scene
            if(playerHealth <= 0.0f) { playerHealth = 0.0f; SceneManager.LoadScene(5); }

            //update the health bar
            HealthBar.transform.localScale = new Vector3(playerHealth, 1f);
        }
        //check to see if the player hit the water
        if(collision.collider.tag == "Water")
        {
            //play the splash sound effect
            splashSound.Play();

            //enable the boat sprite
            Boat.GetComponent<SpriteRenderer>().enabled = true;
        }
        //check to see if the player hit the door play the sound before moving scenes
        if(collision.collider.tag == "Door")
        {
            StartCoroutine(playerSound(3));
        }
    }

    //check to see if the player leaves the water if so disable the boat sprite
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Water")
        {
            Boat.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    //method to play sound before switch scene
    IEnumerator playerSound(int sceneNumber)
    {
        doorSound.Play();

        yield return new WaitWhile(() => doorSound.isPlaying);

        SceneManager.LoadScene(sceneNumber);
    }
}
