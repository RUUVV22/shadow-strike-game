using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    public GameObject image;
    public GameObject[] images;
    private int selectedimage = 0;
    public GameObject imageselected;

    public void NextOption()
    {
        images[selectedimage].SetActive(false);
        selectedimage++;
        if (selectedimage == images.Length)
            selectedimage = 0;

        images[selectedimage].SetActive(true);
    }

    public void BackOption()
    {
        images[selectedimage].SetActive(false);
        selectedimage--;
        if (selectedimage < 0)
        {
            selectedimage = images.Length - 1;
        }
        images[selectedimage].SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
