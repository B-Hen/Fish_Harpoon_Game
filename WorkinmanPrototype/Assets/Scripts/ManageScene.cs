///////////////////////////////////////////////////////
//Name: Breanna Henriquez
//Purpose: Variables for different scenes
///////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageScene : MonoBehaviour
{
    //Text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI fishText;

    //Ints
    public static int score;
    public static int fishAmount;

    // Start is called before the first frame update
    void Start()
    {
        //set them to 0
        score = 0;
        fishAmount = 0;
    }
}
