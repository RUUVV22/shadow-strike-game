using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HitPoints;
    public float MaxHitPoints = 5;
    public HealthBar HealthBar;
    public GameObject enemyheal;
    public GameObject enemyheal2;
    public static bool show;
    public static bool isdie;

    //public AnimatorController controller;
    void Start()
    {
        //animator = GetComponent<Animator>();
        HitPoints = MaxHitPoints;
        HealthBar.SetHealth(HitPoints, MaxHitPoints);
        show = false;
        isdie = false;
        //g = GetComponent<GameObject>();
    }
    private void Update()
    {
        //Vector3 eposition = gameObject.transform.position;
        //g.transform.position = eposition;
    }
    public void Hit(float damage)
    {
        Debug.Log(HitPoints);
        HitPoints -= damage;
        HealthBar.SetHealth(HitPoints, MaxHitPoints);
        if (HitPoints <= 0)
        {
            Vector3 eposition = gameObject.transform.position;
            Debug.Log(HitPoints);
            //HitPoints = MaxHitPoints;
            gameObject.SetActive(false);
            //enemyheal.SetActive(true);
            playerrmanager02.ishealicon = false;
            PlayermanagerL03.ishealicon = false;
            show = true;
            isdie = true;
            enemyheal.transform.position = eposition;
        }        
    }
}        
