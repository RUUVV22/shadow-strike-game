using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class decreasehealth : MonoBehaviour
{
    int hitcounter=0;
    // public Image health_system;
    Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "trabs")
        {
            hitcounter++;
            animator.SetTrigger("hit");
            //Debug.Log("health decrease");
            //collision..SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    
}
