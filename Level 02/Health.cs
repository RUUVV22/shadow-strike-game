using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static float HitPoints;
    public float MaxHitPoints = 5;
    public float damage;
    public float Enemy01damage;
    public float Enemy02damage;
    public float Cow01Damage;
    public float Cow02Damage;
    public float Enemy01heal;
    public float Enemy02heal;
    public static bool isHit;
    public static bool isDie;
    public static bool isEnemy;
    public static bool isEnemy1;
    public static bool isEnemy2;
    public static bool ishealing;
    public static bool isheal;
    public PlayeHealthBar playeHealthBar;
    public AudioSource healing;
    Animator animator;
    [SerializeField] private GameObject healing1;
    /// <summary>
    /// //
    //public Vector3 offsetpress;
    //public Text presse;
    /// </summary>
    void Start()
    {
        //////health
        isHit = false;
        isDie = false;
        isEnemy = false;
        isEnemy1 = false;
        isEnemy2 = false;
        ishealing = false;
        HitPoints = MaxHitPoints;
        Debug.Log(HitPoints);
        playeHealthBar.SetPlayerHealth(HitPoints, MaxHitPoints);
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        //presse.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offsetpress);
        checkhealstate();
        //if (bingbong.enemyweapon)
        //{
        //    isEnemy = true;
        //    isEnemy2 = true;
        //    HitPlayer(Enemy02damage);
        //}
    }
    public void HitPlayer(float damage)
    {
        Debug.Log("hit");
        HitPoints -= damage;
        playeHealthBar.SetPlayerHealth(HitPoints, MaxHitPoints);
        
    }
    public void HealPlayer(float heal)
    {
       // Debug.Log("hit");
        HitPoints += heal;
        playeHealthBar.SetPlayerHealth(HitPoints, MaxHitPoints);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "trabs")
        {
            isHit=true;
            HitPlayer(damage);
        }
        
    }
    private void checkhealstate()
    {
        if (heal.isheal)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                healing.Play();
                animator.SetTrigger("healing");
                HealPlayer(Enemy01heal);
                playerrmanager02.ishealicon = true;
                PlayermanagerL03.ishealicon = true;
                ishealing = true;
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                ishealing = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "lake")
        {
            isDie = true;
            HitPlayer(100);
        }
        if (collision.gameObject.tag == "enemy01")
        {
            isEnemy = true;
            isEnemy1 = true;
            HitPlayer(Enemy01damage);
        }
        if (collision.gameObject.tag == "enemy02")
        {
            isEnemy = true;
            HitPlayer(Enemy02damage);
        }
        if (collision.gameObject.tag == "Cow01")
        {
            isEnemy = true;
            HitPlayer(Cow01Damage);
        }
        if (collision.gameObject.tag == "Cow02")
        {
            isEnemy = true;
            HitPlayer(Cow02Damage);
        }
    }
}
