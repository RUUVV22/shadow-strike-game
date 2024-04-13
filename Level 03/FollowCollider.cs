using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCollider : MonoBehaviour
{
    private Transform targettransform;
    // Start is called before the first frame update
    void Start()
    {
        targettransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if(targettransform != null)
        {
            targettransform.position = transform.position;
        }
    }
}
