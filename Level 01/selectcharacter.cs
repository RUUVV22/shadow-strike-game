using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class selectcharacter : MonoBehaviour
{
    public GameObject[] skins;
    private int selctedskin = 0;
    public GameObject playerskin;

    public void NextOption()
    {
        skins[selctedskin].SetActive(false);
        selctedskin++;
        if (selctedskin == skins.Length)
            selctedskin = 0;

        skins[selctedskin].SetActive(true);
        PlayerPrefs.SetInt("selctedskin", selctedskin);
    }

    public void BackOption()
    {
        skins[selctedskin].SetActive(false);
        selctedskin--;
        if(selctedskin < 0)
        {
            selctedskin = skins.Length - 1;
        }
        skins[selctedskin].SetActive(true);
        PlayerPrefs.SetInt("selctedskin", selctedskin);
    }
    public void playgame()
    {
        //PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/ninjaboy.prefab");
        SceneManager.LoadScene(2);
    }
    // Start is called before the first frame update
    void Start()
    {
        //image = GetComponent<Image>();
        //VCam.m_Follow = player.transform;
    }
    private void Awake()
    {
        selctedskin = PlayerPrefs.GetInt("selctedskin", 0);
        foreach (GameObject player in skins)
            player.SetActive(false);

        skins[selctedskin].SetActive(true);
        //VCam.m_Follow = player.transform;
    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    
    
}
