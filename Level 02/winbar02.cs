using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winbar02 : MonoBehaviour
{
    public Slider slider;
    public Text presse;
    public Color Low;
    public Color High;
    public Vector3 offset;
    public Vector3 offsetpress;
    public float State = 0.005f;
    public float Max = 1;
    public void SetWinState(float State, float max)
    {
        slider.value = State;
        slider.maxValue = max;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);//fill the slider
    }
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        presse.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offsetpress);
        CheckWinState();
    }
    void CheckWinState()
    {
        if (WIN.isWin)
        {
            slider.gameObject.SetActive(true);
            presse.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                slider.value += State;
                slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);//fill the slider
                if (slider.value == Max)
                {
                    WIN.isDone = true;
                }
            }
        }
        else
        {
            slider.gameObject.SetActive(false);
            presse.gameObject.SetActive(false);
            slider.value = 0;
        }
    }
}
