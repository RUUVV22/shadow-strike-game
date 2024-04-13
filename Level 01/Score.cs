using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Score : MonoBehaviour
{
    //public static int total = 0;
    int score = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playermanager.knifescount++;
            int total = playermanager.knifescount;
            PlayerPrefs.SetInt("recentScore", playermanager.knifescount);
            PlayerPrefs.SetInt("score", total);
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayerPrefs.SetInt("recentScore", 0);
    }
}
