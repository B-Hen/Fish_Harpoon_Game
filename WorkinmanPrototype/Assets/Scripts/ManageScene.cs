using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageScene : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int score;
    public int fishAmount;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        fishAmount = 0;
    }
}
