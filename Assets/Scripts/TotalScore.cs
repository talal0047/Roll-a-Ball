using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    public Text totalScore;
    //private int Score;
    private int tempScore;
    // Start is called before the first frame update
    void Start()
    {
        //Score = PlayerPrefs.GetInt("Count", 0);
        tempScore = PlayerPrefs.GetInt("TotalScore", 0);
        //Score = Score + tempScore;
        totalScore.text = "Total Captured: " + tempScore.ToString();
        //PlayerPrefs.SetInt("TotalScore", Score);    
    }

}
