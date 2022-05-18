using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public AudioSource click;

    public void BackToStart()
    {
        StartCoroutine(playerSound(0));
    }

    public void GoToLorePage()
    {
        StartCoroutine(playerSound(1));
    }

    public void GoToInstructionPage()
    {
        StartCoroutine(playerSound(2));
    }

    public void GoToMainGame()
    {
        StartCoroutine(playerSound(4));
    }

    IEnumerator playerSound(int sceneNumber)
    {
        click.Play();

        yield return new WaitWhile(() => click.isPlaying);

        SceneManager.LoadScene(sceneNumber);
    }
}
