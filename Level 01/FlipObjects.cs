using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipObjects : MonoBehaviour
{
    // Reference to the transform component of the game object
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        // Get the transform component
        _transform = GetComponent<Transform>();
    }

    // Function to flip the object
    public void Flip()
    {
        // Reverse the scale along the X-axis
        _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
    }
}
