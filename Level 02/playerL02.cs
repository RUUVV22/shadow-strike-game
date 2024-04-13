using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerL02 : MonoBehaviour
{
    private float Hor;
    private float ver;
    public float speed;
    public float JumpForce;
    Rigidbody2D rgd2;
    bool on_ground;
    SpriteRenderer spriteRenderer;
    public static int hitcounter = 3;
    Animator animator;
    /// <summary>
    [SerializeField] private AudioSource hitaudio, attackaudio, jumpaudio, kunai, dead;
    /// <summary>
    /// ////////////////move player in mobile
    public bool moveright = false;
    public bool moveleft = false;
    public bool isjump = false;
    /// </summary>
    // attack
    public bool isattack = false;
    //slide
    public PolygonCollider2D polygon;
    //public static Random random;
    //sliding 
    bool sliding = false;
    //slide time
    float slidetimer = 0;
    public float maxslidetime = 1.5f;

    [SerializeField]
    GameObject healthcollider;
    void Start()
    {
        animator = GetComponent<Animator>();
        rgd2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygon= GetComponent<PolygonCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        movePlayer();
        jump();
        flipplayer();
        attack();
        slideOn();
        ///Win();
        //climp();
        if (transform.position.x < -17)
        {
            transform.position = new Vector3(-17, transform.position.y, 0);
        }
        if (transform.position.x > 157)
        {

            transform.position = new Vector3(157, transform.position.y, 0);
        }
        if (transform.position.y >= 4.61)
        {
            transform.position = new Vector3(transform.position.x,4, 0);
        }
        if(Enemy.isdie)
        {
            animator.SetBool("hit", false);
        }
        ////////////////////////////////mobile movement
        //MovePlayer();
        //jumpmobile();
        
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
            transform.position += new Vector3(speed, 0, 0);
        }
        if (moveleft)
        {
            animator.SetBool("isRun", true);
            spriteRenderer.flipX = true;
            transform.position += new Vector3(-speed, 0, 0);
        }

    }
    public void jumpmobile()
    {
        Debug.Log("ok");
        isjump = true;
            rgd2.AddForce(new Vector2(0, JumpForce));
            animator.SetTrigger("jump");
            jumpaudio.Play();
        if (on_ground == true)
        {
        }
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
    //Enemy en;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ////////////////stay on ground
        if (collision.gameObject.tag == "blocks")
        {
            on_ground = true;
        }
        if (collision.gameObject.tag == "lake")
        {
            playerrmanager02.isDie = true;
            if (Health.isDie)
            {
                Die();
            }
        }
        if (collision.gameObject.tag == "catch")
        {
            kunai.Play();
        }
        var enemy = collision.collider.GetComponent<Enemy>();//check if the ninja hit the enemy
        if (enemy && isattack)
        {
            enemy.Hit(1);
        }
        if (collision.gameObject.tag == "enemy01")
        {
            if (Health.isEnemy)
            {
                Hit();
            }
        }
        if (collision.gameObject.tag == "enemy02")
        {
            if (Health.isEnemy)
            {
                Hit();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "blocks") 
        {
            on_ground = false;
        }
        if (collision.gameObject.tag == "enemy01")
        {
            animator.SetBool("hit", false);
        }
        if (collision.gameObject.tag == "enemy02")
        {
            animator.SetBool("hit", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "trabs")
        {
            playerrmanager02.isHit = true;
            if(Health.isHit)
            {
                Hit();
            }
        }
        if(collision.gameObject.tag == "ladder")
        {
            //isclimp = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "trabs")
        {
            playerrmanager02.isHit = true;
            animator.SetBool("hit",false);
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
        rgd2.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("dead");
        dead.Play();
        playerrmanager02.isGameOver = true;
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
        if (Hor > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isRun", true);
        }
        else if (Hor < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isRun", true);
        }
    }
    void movePlayer()
    {
        if (rgd2.bodyType == RigidbodyType2D.Dynamic)
        {
            Hor = Input.GetAxis("Horizontal");
            //transform.position += new Vector3(Hor *speed, 0, 0);
            rgd2.velocity = new Vector2(Hor * speed, rgd2.velocity.y);
        }
        if (Hor != 0)
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
            isattack = true;
            animator.SetTrigger("attack");
            attackaudio.Play();
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            isattack = false;
        }
    }
    public void slideOn()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !sliding && on_ground)
        {
            slidetimer = 0f;
            animator.SetBool("isSlide", true);
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            sliding = true;
        }
        if(sliding)
        {
            slidetimer += Time.deltaTime;
            if(slidetimer > maxslidetime) {
                sliding = false;
                animator.SetBool("isSlide", false);
                gameObject.GetComponent<PolygonCollider2D>().enabled = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
    public void slideOff()
    {
         animator.SetBool("isSlide", false);
    }
    void climp()
    {
        ver = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, ver * speed*Time.deltaTime, 0);
        //rgd2.AddForce(new Vector2(0, ver * speed * Time.deltaTime));
        //if (ver != 0)
        {
            animator.SetBool("isClimp", true);
        }
       // else
        {
            animator.SetBool("isClimp", false);
        }
    }
}
