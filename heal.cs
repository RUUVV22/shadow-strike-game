using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    //public GameObject[] ep;
    
    // Start is called before the first frame update
    Animator animator;
    public static bool isheal;
    void Start()
    {
        animator = GetComponent<Animator>();
        isheal = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("on");
        //if (Health.ishealing)
        //{
        //    gameObject.SetActive(false);
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            isheal=true;
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            isheal = false;
        }
    }
}
