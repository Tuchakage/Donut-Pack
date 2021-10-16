using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public DragController dc;
    GameManager gm;
    public int addedtime = 5;
    public int losttime = 5;
    // Start is called before the first frame update
    void Start()
    {
        //Finds the DragController Game Object and gets the DragController script on it so it can use the variables within
        dc = GameObject.Find("DragController").GetComponent<DragController>();
        gm = GameObject.Find("GameplayController").GetComponent<GameManager>();

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
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime);
            }
            else if (col.gameObject.tag != "Blue" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime);
            }
        }
        else if (this.gameObject.name == "Container (1)")
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "Yellow" && !dc.isDragActive)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime);
            }
            else if (col.gameObject.tag != "Yellow" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime);
            }
        }

        else if (this.gameObject.name == "Container (2)")
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "Red" && !dc.isDragActive)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime);
            }
            else if (col.gameObject.tag != "Red" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime);
            }
        }



    }
}
