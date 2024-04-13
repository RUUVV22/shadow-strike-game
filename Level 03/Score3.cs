using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score3 : MonoBehaviour
{
    //public static int total = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            PlayermanagerL03.knifescount++;
            int total = PlayermanagerL03.knifescount;
            PlayerPrefs.SetInt("recentScore", PlayermanagerL03.knifescount);
            PlayerPrefs.SetInt("score3", total);
            if (PlayermanagerL03.knifescount > PlayerPrefs.GetInt("score3", 0))
            {
                PlayerPrefs.SetInt("score3", total);
                //HighScore.HScore = total;
            }
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        int level2score=PlayermanagerL03.knifescount = PlayerPrefs.GetInt("score2");
        PlayerPrefs.SetInt("recentScore", level2score);
    }
}
