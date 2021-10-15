using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public DragController dc;
    // Start is called before the first frame update
    void Start()
    {
        //Finds the DragController Game Object and gets the DragController script on it so it can use the variables within
        dc = GameObject.Find("DragController").GetComponent<DragController>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col) 
    {

        if (this.gameObject.name == "Container")
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "Blue" && !dc.isDragActive)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
            }
            else if (col.gameObject.tag != "Blue" && !dc.isDragActive)
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
            }
        }
        else if (this.gameObject.name == "Container (1)")
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "Yellow" && !dc.isDragActive)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
            }
            else if (col.gameObject.tag != "Yellow" && !dc.isDragActive)
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
            }
        }

        
    }
}
