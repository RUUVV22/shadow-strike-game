using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text Highscore;
    public Text YourScore;
    public static int HScore,recentScore;

    void Start()
    {
        //int level1score = PlayerPrefs.GetInt("score");
        //int level2score = PlayerPrefs.GetInt("score2");
        int level3score = PlayerPrefs.GetInt("score3");
        recentScore = PlayerPrefs.GetInt("recentScore");
        //HScore = PlayerPrefs.GetInt("score3");
        Highscore.text=level3score.ToString();
        YourScore.text= recentScore.ToString();
    }
    //if (playermanager.knifescount > PlayerPrefs.GetInt("score", 0))
    //{
    //    PlayerPrefs.SetInt("score", total);
    //    //HighScore.HScore = total;
    //}
}
