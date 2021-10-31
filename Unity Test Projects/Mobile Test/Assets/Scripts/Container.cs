using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public DragController dc;
    GameManager gm;
    public int addedtime = 3;
    public int losttime = 10;
    public int spoiledlosttime = 15;
    // Start is called before the first frame update
    void Start()
    {
        //Finds the DragController Game Object and gets the DragController script on it so it can use the variables within
        dc = GameObject.Find("DragController").GetComponent<DragController>();
        gm = GameObject.Find("GameplayController").GetComponent<GameManager>();

    }

    void OnTriggerStay2D(Collider2D col) 
    {
        
        if (this.gameObject.name == "Measuring Cup")
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodMilk" && !dc.isDragActive)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
            }
            else if (col.gameObject.tag != "GoodMilk" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
            }
        }



    }
}