using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climping : MonoBehaviour
{
    private float vertical;
    private float speed = 1f;
    private bool isLadder;
    private bool isClimbing;

    public Animator animator;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder)
        {
            //animator.SetBool("IsStop", false);
            if (Mathf.Abs(vertical) > 0f)
            {
                isClimbing = true;
                animator.SetBool("IsStop", false);
                animator.SetBool("isClimp", true);
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("IsStop", true);
            }
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            
            rb.gravityScale = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            isLadder = false;
            isClimbing = false;
            animator.SetBool("IsStop", false);
            animator.SetBool("isClimp", false);
        }
    }
}
