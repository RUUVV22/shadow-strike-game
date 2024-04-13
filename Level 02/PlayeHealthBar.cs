using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayeHealthBar : MonoBehaviour
{
    public Slider slider;
    public Color High;
    public Color Low;
    public Vector3 offset;
    public void SetPlayerHealth(float health, float maxHealth)
    {
        //Debug.Log("ok");
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);//fill the slider
    }
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
