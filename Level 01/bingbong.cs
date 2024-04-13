using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bingbong : MonoBehaviour
{
    bool moveRight = true;
    bool attack = false;
    public static bool enemyweapon;
    public float speed = 2f;
    public float mover;
    public float movel;
    //SpriteRenderer spriteRenderer;
    public FlipObjects flip;
    public Animator animator;
    public AudioSource audio;
    public GameObject gm;
    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        enemyweapon = false;
        gm = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            //spriteRenderer.flipX = false;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            //spriteRenderer.flipX = true;
        }
        //(moveRight ? transform.Translate(Vector2.right * speed * Time.deltaTime) :
          //  transform.Translate(Vector2.left * speed * Time.deltaTime));
        
        if (transform.position.x >= mover) 
        {
            moveRight = false;
            flip.Flip();
            attack = true; 
        }

        if (transform.position.x <= movel) 
        {
            moveRight = true;
            attack = false;
            flip.Flip();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player"&&attack)
        {
            enemyweapon=true;
            audio.Play();
            animator.SetBool("IsAttack", true);
            if (moveRight)
            {
                flip.Flip();
            }
            speed = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player"&&attack)
        {
            animator.SetBool("IsAttack", false);
            audio.Stop();
            speed = 2;
            enemyweapon = false;
        }
    }
}
