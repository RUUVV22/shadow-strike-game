using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.CinemachineOrbitalTransposer;

public class playerrmanager02 : MonoBehaviour
{
    /// <summary>
    /// score system
    public static int knifescount;
    public Text scoretext;
    //gameoverscreen
    public static bool isGameOver;
    public static bool ishealicon;
    public GameObject gameoverscreen,healicon;
    public Text pointsgameover;
    /// </summary>
    /// character selection system
    /// -17
    public static Vector3 lastCheckPointPos = new Vector3(-17, -4, 0);
    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    int characterIndex;
    /// <summary>
    //heart system
    public static bool isHit;
    public static bool isDie;
    public static bool showtext;
    public Image[] hearts;
    public Sprite emptyhearts;
    /// </summary>
   
    void Start()
    {
        healicon.gameObject.SetActive(false);
        ishealicon = true;
        isGameOver = false;
        showtext = false;
        isHit = false;
        isDie = false;
        characterIndex = PlayerPrefs.GetInt("selctedskin", 0);
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        //int level1score=PlayerPrefs.GetInt("recentScore");
        VCam.m_Follow = player.transform;
       // scoretext.text = level1score.ToString();
    }
    void Update()
    {
        //scoretext.text = "ok";
        scoretext.text = knifescount.ToString();//add score to text
        // gameoverscreen
        if (isGameOver)
        {
            gameoverscreen.SetActive(true);
            pointsgameover.text = scoretext.text + " POINTS";
        }
        if (ishealicon)
        {
            healicon.gameObject.SetActive(false);
        }
        else if (!ishealicon)
        {
            healicon.gameObject.SetActive(true);
            showtext = true;
        }
        ////hit
        //if (isHit)
        //{
        //    setEmptyHearts(playerL02.hitcounter);
        //}
        ////die check
        //if (isDie)
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
        for (int i = hearts.Length-1; i >=0; i--)
        {
            hearts[i].sprite = emptyhearts;
        }
    }
}
