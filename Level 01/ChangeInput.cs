using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeInput : MonoBehaviour
{
    EventSystem System;
    public Selectable firstinput;
    public Button submit;
    // Start is called before the first frame update
    void Start()
    {
        System=EventSystem.current;
        firstinput.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && Input.GetKeyDown(KeyCode.LeftShift)) {
           Selectable previous=System.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if(previous != null)
            {
                previous.Select();
            }
         }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = System.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
        }else if (Input.GetKeyDown(KeyCode.Return))
        {
            submit.onClick.Invoke();
            Debug.Log("Button pressed!");
        }
    }
}
