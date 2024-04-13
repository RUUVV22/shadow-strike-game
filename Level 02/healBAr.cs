using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healBAr : MonoBehaviour
{
    public Vector3 offsetpress;
    public Text presse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerrmanager02.showtext||PlayermanagerL03.showtext)
        {
            presse.gameObject.SetActive(true);
        }
        presse.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offsetpress);
    }
}
