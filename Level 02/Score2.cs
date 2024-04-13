using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2 : MonoBehaviour
{
    //public static int total = 0;
    public Text text;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playerrmanager02.knifescount++;
            int total = playerrmanager02.knifescount;
            PlayerPrefs.SetInt("recentScore", playerrmanager02.knifescount);
            PlayerPrefs.SetInt("score2", total);
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        int level1score=playerrmanager02.knifescount=PlayerPrefs.GetInt("score");
        PlayerPrefs.SetInt("recentScore", level1score);
    }
    
}
