using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandScript : MonoBehaviour
{
    //This variable is seen through all the classes
    public static int BandVisible;
    // Start is called before the first frame update
    void Start()
    {
        BandVisible = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (BandVisible == 0)
        {
            GetComponent<LineRenderer>().enabled = false;
        }
        else 
        {
            GetComponent<LineRenderer>().enabled = true;
        }
    }
}
