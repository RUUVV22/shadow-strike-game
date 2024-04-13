using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManages : MonoBehaviour
{
    public void RestartBtn()
    {
        playerrmanager02.knifescount = 0;
        playerL02.hitcounter = 3;
        //playermanager.hearts = 3;
        SceneManager.LoadSceneAsync(3);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
