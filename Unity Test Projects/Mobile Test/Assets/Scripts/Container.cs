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
        if (this.gameObject.name == "Measuring Cup")//If the gameObject this script is on is the Measuring Cup
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
        else if (this.gameObject.name == "YeastBowl") //If the gameObject this script is on is the Yeast bowl
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodYeast" && !dc.isDragActive)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
            }
            else if (col.gameObject.tag != "GoodYeast" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
            }
        }
        else if (this.gameObject.name == "saltbowl") //If the gameObject this script is on is the Salt bowl
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodSalt" && !dc.isDragActive)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
            }
            else if (col.gameObject.tag != "GoodSalt" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
            }
        }

        else if (this.gameObject.name == "SUGARBOWL") //If the gameObject this script is on is the Sugar bowl
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodSugar" && !dc.isDragActive)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
            }
            else if (col.gameObject.tag != "GoodSugar" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
            }
        }

        else if (this.gameObject.name == "Wide Bowl") //If the gameObject this script is on is the Flour bowl
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodFlour" && !dc.isDragActive)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
            }
            else if (col.gameObject.tag != "GoodFlour" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
            }
        }

        else if (this.gameObject.name == "Bin") //If the gameObject this script is on is the bin
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "BadItems" && !dc.isDragActive)
            {
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);

            }
            else if (col.gameObject.tag != "BadItems" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
            }

            if (dc.isDragActive) //If the player is hovering an item over the bin
            {
                //Enable the Bin Open Game Object
                this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (this.gameObject.name == "Bin") //If the gameObject this script is on is the bin
        {
            //Disables the Bin Open Game Object when the item leaves the collider of the bin
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
