using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public AudioSource exitSound;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            StartCoroutine(playExitSound());
        }
    }

    IEnumerator playExitSound()
    {
        exitSound.Play();

        yield return new WaitWhile(() => exitSound.isPlaying);

        Debug.Log("Quit");
        Application.Quit();
    }
}
