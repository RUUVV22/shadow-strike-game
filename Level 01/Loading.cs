using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    //private bool isDone;
    public Slider slider;
    [SerializeField] private int scentnnum;
    [SerializeField] private float slidervalue;
    // Start is called before the first frame update
    void Start()
    {
        //isDone = false;
        //slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LoadDone();
        
    }
    public void LoadDone()
    {
        slider.value += slidervalue;
        if(slider.value ==1)
        {
            SceneManager.LoadScene(scentnnum);
        }
    }
}
