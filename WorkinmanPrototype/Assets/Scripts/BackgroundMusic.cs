////////////////////////////////////////////////////////////////////////////
//Name: Breanna Henriquez 
//Purpose: to play background music, script will only be in the Title Scene
////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    //make the background Music a static variable of the class
    private static BackgroundMusic instance;


    private void Awake()
    {
        //check if their is already an instance of the class if so delete this game object
        if(instance != null)
        {
            Destroy(gameObject);
        }
        //else make this equal to the instance and don't destory this object anytime a scene is changed
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
