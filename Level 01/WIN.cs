using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WIN : MonoBehaviour
{
    public static bool isWin;
    public static bool isDone;
    public int scenenumber;
    //public Slider slider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //slider.gameObject.SetActive(true);
            isWin = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //slider.gameObject.SetActive(false);
            //slider.value = 0;
            isWin = false;
        }
    }
    void Start()
    {
        isWin = false;
        isDone = false;
    }
    
    void Update()
    {
        if (isDone)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(scenenumber);
        }
    }

}
