using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour
{
    bool moveRight = true;
    public float speed = 2f;
    public float mover;
    public float movel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (transform.position.x >= mover)
        {
            moveRight = false;
        }

        if (transform.position.x <= movel)
        {
            moveRight = true;
        }
    }
}
