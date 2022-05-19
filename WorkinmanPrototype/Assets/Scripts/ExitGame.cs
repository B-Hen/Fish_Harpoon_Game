////////////////////////////////////////////////////////////
//Name: Breanna Henriquez 
//Purpose: To exit the game when the escape key is pressed
////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    //sound to play before game ends
    public AudioSource exitSound;

    // Update is called once per frame
    void Update()
    {
        //check to see if the escape key has been pressed
        if(Input.GetKey(KeyCode.Escape))
        {
            StartCoroutine(playExitSound());
        }
    }

    //Coroutine method to play exit sound before closing the game
    IEnumerator playExitSound()
    {
        //play the sound then  wait until the sound has finished
        exitSound.Play();

        yield return new WaitWhile(() => exitSound.isPlaying);

        //Exit the game
        Application.Quit();
    }
}
