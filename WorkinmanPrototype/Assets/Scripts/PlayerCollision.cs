using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private float playerHealth;
    public GameObject HealthBar;
    public GameObject Boat;
    public AudioSource playerHurt;
    public AudioSource splashSound;
    public AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check to see if the player has hit a bullet
        if(collision.collider.tag == "Bullet")
        {
            playerHurt.Play();
            //reduce the player health and update the health bar
            playerHealth -= 0.1f;

            if(playerHealth <= 0.0f) { playerHealth = 0.0f; SceneManager.LoadScene(5); }
            HealthBar.transform.localScale = new Vector3(playerHealth, 1f);
        }
        if(collision.collider.tag == "Water")
        {
            splashSound.Play();
            Boat.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(collision.collider.tag == "Door")
        {
            StartCoroutine(playerSound(3));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Water")
        {
            Boat.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator playerSound(int sceneNumber)
    {
        doorSound.Play();

        yield return new WaitWhile(() => doorSound.isPlaying);

        SceneManager.LoadScene(sceneNumber);
    }
}
