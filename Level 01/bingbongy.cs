using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bingbongy : MonoBehaviour
{
    bool moveup = false;
    public float speed = 2f;
    public float moved;
    public float moveu;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveup)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        //(moveRight ? transform.Translate(Vector2.right * speed * Time.deltaTime) :
        //  transform.Translate(Vector2.left * speed * Time.deltaTime));

        if (transform.position.y >= moveu)
        {
            moveup = false;
        }

        if (transform.position.y <= moved)
        {
            moveup = true;
        }
    }
}
