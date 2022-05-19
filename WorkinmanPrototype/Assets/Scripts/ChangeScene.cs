////////////////////////////////////////////////////////////////
//Name: Breanna Henriquez 
//Purpose: To switch between scenes at the click of a button
////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //audio source for when a button is clicked
    public AudioSource click;

    //method to return to the title screen
    public void BackToStart()
    {
        StartCoroutine(playerSound(0));
    }

    //method to go to the lore screen
    public void GoToLorePage()
    {
        StartCoroutine(playerSound(1));
    }

    //method to go to the instruction screen
    public void GoToInstructionPage()
    {
        StartCoroutine(playerSound(2));
    }

    //method to go to the main game
    public void GoToMainGame()
    {
        StartCoroutine(playerSound(4));
    }

    //method to go to the credits screen
    public void GoToCredits()
    {
        StartCoroutine(playerSound(6));
    }

    //method to play the click sound then transition to the next scene
    IEnumerator playerSound(int sceneNumber)
    {
        click.Play();

        yield return new WaitWhile(() => click.isPlaying);

        SceneManager.LoadScene(sceneNumber);
    }
}
