using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playermanager : MonoBehaviour
{

    /// <summary>
    /// score system
    public static int knifescount;
    public Text scoretext;
    //gameoverscreen
    public static bool isGameOver;
    public GameObject gameoverscreen;
    public Text pointsgameover;
    /// </summary>
    /// character selection system
    /// 
    public static Vector3 lastCheckPointPos = new Vector3(-9,-4, 0);
    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    int characterIndex;
    /// <summary>
    //heart system
    public static bool isHit;
    public static bool isDie;
    public Image[] hearts;
    public Sprite emptyhearts;
    /// </summary>
    
    void Start()
    {
        isGameOver = false;
        isHit = false;
        isDie = false;
        characterIndex = PlayerPrefs.GetInt("selctedskin", 0);
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
    }
    void Update()
    {
        scoretext.text = knifescount.ToString();//add score to text
        // gameoverscreen
        if(isGameOver)
        {
            gameoverscreen.SetActive(true);
            pointsgameover.text = scoretext.text+" POINTS";
        }
        ////hit
        //if(isHit)
        //{
        //    setEmptyHearts(Player.hitcounter);
        //}
        ////die check
        //if(isDie)
        //{
        //    Die();
        //}
    }
    public void setEmptyHearts(int index)
    {
        hearts[index].sprite = emptyhearts;
    }
    public void Die()
    {
        for (int i = 0; i <= hearts.Length - 1; i++)
        {
            hearts[i].sprite = emptyhearts;
        }
    }

}
