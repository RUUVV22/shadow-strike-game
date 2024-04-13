using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float Hor;
    public float speed;
    public float JumpForce;
    Rigidbody2D rgd2;
    bool on_ground;
    SpriteRenderer spriteRenderer;
    public static int hitcounter = 3;
    Animator animator;
    /// <summary>
    [SerializeField] private AudioSource hitaudio,attackaudio,jumpaudio,kunai,dead;
    /// <summary>
    /// ////////////////move player in mobile
    public bool moveright=false;
    public bool moveleft = false;
    public bool isjump = false;
    /// </summary>
    // catch vars
    void Start()
    {
        animator = GetComponent<Animator>(); 
        rgd2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movePlayer();
        jump();
        flipplayer();
        attack();
        slide();
        ///Win();
        if (transform.position.x < -9)
        {
            transform.position = new Vector3(-9, transform.position.y, 0);
        }
        if (transform.position.x > 72)
        {

            transform.position = new Vector3(72, transform.position.y, 0);
        }
        if (transform.position.y >= 4.61)
        {
            transform.position = new Vector3(transform.position.x,4, 0);
        }
        ////////////////////////////////mobile movement
        //MovePlayer();
        
        
    }
    public void islam()
    {
        //animator.SetBool("isRun", true);
        //spriteRenderer.flipX = false;
        transform.position += new Vector3(speed, 0, 0);
    }
    public void MovePlayer()
    {
        if (moveright)
        {
            animator.SetBool("isRun", true);
            spriteRenderer.flipX = false;
            Debug.Log("right");
            //transform.position += new Vector3(speed, 0, 0);
            rgd2.velocity = new Vector2(Hor * speed, rgd2.velocity.y);
        }
        if (moveleft)
        {
            animator.SetBool("isRun", true);
            spriteRenderer.flipX = true;
            //transform.position += new Vector3(-speed, 0, 0);
            rgd2.velocity = new Vector2(Hor * -speed, rgd2.velocity.y);
        }

    }
    
    public void jumpmobile()
    {
        if (on_ground&&isjump)
        {
            Debug.Log("jump");
            rgd2.AddForce(new Vector2(0, JumpForce));
            animator.SetTrigger("jump");
            jumpaudio.Play();
        }
    }
    public void makeittrue()
    {
        isjump = true;
    }
    public void attackmobile()
    {
        //animator.SetTrigger("attack");
        //attackaudio.Play();
    }
    public void istriggerright(bool canmoveright)
    {
        moveright = canmoveright;
    }
    public void istriggerleft(bool canmoveleft)
    {
        moveleft = canmoveleft;
    }
    /// <summary>
    /// end mobile movement code
    /// </summary> 
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ////////////////stay on ground
        if (collision.gameObject.tag == "blocks")
        {
            on_ground = true;
        }
        if(collision.gameObject.tag == "lake")
        {
            Die();
        }
        if (collision.gameObject.tag == "catch")
        {
            kunai.Play();
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "blocks")
        {
            on_ground = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "trabs")
        {
            if (Health.isHit)
            {
                Hit();
            }
        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "trabs")
        {
            animator.SetBool("hit", false);
        }
    }
    public void Hit()
    {
        hitaudio.Play();
        animator.SetBool("hit",true);
        if (Health.HitPoints <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        dead.Play();
        rgd2.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("dead");
        playermanager.isGameOver = true;

    }
    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && on_ground == true)
        {
            rgd2.AddForce(new Vector2(0, JumpForce));
            animator.SetTrigger("jump");
            jumpaudio.Play();
        }
    }
    void flipplayer()
    {
        if(Hor>0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isRun", true);
        }
        else if ( Hor<0)
        {
            spriteRenderer.flipX=true;
            animator.SetBool("isRun", true);
        }
    }
    //public Joystick movementJoystick;
    private void FixedUpdate()
    {
        //if (movementJoystick.Direction.y != 0)
        //{
        //    rgd2.velocity = new Vector2(movementJoystick.Direction.x * speed, 0);
        //    animator.SetBool("isRun", true);
        //}
        //else
        //{
        //    //animator.SetBool("isRun", false);
        //    rgd2.velocity = Vector2.zero;
        //}
    }
    void movePlayer()
    {
        if (rgd2.bodyType == RigidbodyType2D.Dynamic)
        {
            Hor = Input.GetAxis("Horizontal");
            //rgd2.velocity = new Vector2(movementJoystick.Direction.x * speed, 0);
            //transform.position += new Vector3(Hor * speed, 0, 0);
            rgd2.velocity = new Vector2(Hor*speed,rgd2.velocity.y);
        }
        if(Hor!=0)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);

        }
    }
    void attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("attack");
            attackaudio.Play();
        }
    }
    void slide()
    {
        if (Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("slide");
        }
    }
    
}
