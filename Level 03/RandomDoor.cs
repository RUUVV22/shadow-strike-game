using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;

public class RandomDoor : MonoBehaviour
{
    public Vector3 firstloc = new Vector3(61, -2.82f, 0);
    public Vector3 secondloc = new Vector3(87, -2.82f, 0);
    private int timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("StartTimer", 5f); // Start the timer every 1000 seconds and repeat every 1000 seconds
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer==100)
        {
            randDoor();
            Debug.Log("work!!");
            timer = 0;
        }
        // Add your timer logic here
        //timer += Time.deltaTime;
        //Debug.Log("Timer: " + timer);
        //if (timer == 5f)
        //{
            
        //}
    }
    void randDoor()
    {
        int first = 61;
        int second = 87;
        int randdoor = Random.Range(first, second);
        transform.position = new Vector3(randdoor, -2.82f,0);
        Debug.Log(randdoor);
    }
    void StartTimer()
    {
        Debug.Log("Timer started!");
        //timer = 0f; // Reset the timer
    }
}
