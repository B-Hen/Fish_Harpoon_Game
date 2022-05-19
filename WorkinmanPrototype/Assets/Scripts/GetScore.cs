//////////////////////////////////////////////////////////////////
//Name:Breanna Henriquez 
//Purpose: to hold variables that will be needed across scenes
///////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetScore : MonoBehaviour
{
    //Text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI fishText;
    
    // Start is called before the first frame update
    void Start()
    {
        //set the text to the variables for the score and fish amaount
        scoreText.text = "Score: " + ManageScene.score;
        fishText.text = "Fish: " + ManageScene.fishAmount;
    }
}
