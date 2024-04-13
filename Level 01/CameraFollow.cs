using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //private vector3 offset = new vector3(0f, 0f,- 10f);
    //private float smoothtime = 0.25f;
    //private vector3 velocity= vector3.zero;
    //[SerializeField] private Transform target;
    public float FollowSpeed = 2f;
    public float YOffset = 1f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //target.position.y + YOffset
        Vector3 targetPosittion =new Vector3( target.position.x,0,-10f);
        transform.position = Vector3.Slerp(transform.position,targetPosittion,FollowSpeed*Time.deltaTime);
    }
}
