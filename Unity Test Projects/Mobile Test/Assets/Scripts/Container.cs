using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    //For changing the sprites for the containers
    public SpriteRenderer spriteRenderer;
    public Sprite[] bin;
    public Sprite halffull;
    public Sprite full;

    public DragController dc;
    GameManager gm;
    ItemSpawner items;
    [SerializeField]
    private int addedtime = 3;
    [SerializeField]
    private int losttime = 10;
    //Amount of good items that go into the right containers
    [SerializeField]
    private int amntgoodmilk, amntgoodyeast,amntsalt,amntsugar,amntflour;
    [SerializeField]
    private bool isItemWrong; //Check if the item put into the container was the wrong one
    private bool isComplete = false; // Checks if the container is full
    // Start is called before the first frame update
    void Start()
    {
        //Finds the DragController Game Object and gets the DragController script on it so it can use the variables within
        dc = GameObject.Find("DragController").GetComponent<DragController>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        items = GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>();

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
                //Increment this variable
                amntgoodmilk++;
                //Item that was put into this container was right
                isItemWrong = false;
                //If the milk container is half way full
                if (amntgoodmilk == items.maxAmntOfItem / 2)
                {
                    //Change into the Sprite with the measuring cup half full
                    spriteRenderer.sprite = halffull;
                }
                else if (amntgoodmilk == items.maxAmntOfItem) //If the container is full
                {
                    //Change into the Sprite with the measuring cup full
                    spriteRenderer.sprite = full;
                    //The container is full
                    isComplete = true;
                    //Tell the Game Manager that a container has been completed
                    gm.amntContainersComplete++;
                }
            }
            else if (col.gameObject.tag != "GoodMilk" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
                //Item that was put into this container was wrong
                isItemWrong = true;
            }
        }
        else if (this.gameObject.name == "Yeast Bowl") //If the gameObject this script is on is the Yeast bowl
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodYeast" && !dc.isDragActive)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
                //Item that was put into this container was right
                isItemWrong = false;
                //Increment this variable
                amntgoodyeast++;
                //If the milk container is half way full
                if (amntgoodyeast == items.maxAmntOfItem / 2)
                {
                    //Change into the Sprite with the Yeast bowl half full
                    spriteRenderer.sprite = halffull;
                }
                else if (amntgoodyeast == items.maxAmntOfItem) //If the container is full
                {
                    //Change into the Sprite with the Yeast bowl full
                    spriteRenderer.sprite = full;
                    //Set this container to being complete
                    isComplete = true;
                    //Tell the Game Manager that a container has been completed
                    gm.amntContainersComplete++;
                }


            }
            else if (col.gameObject.tag != "GoodYeast" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
                //Item that was put into this container was wrong
                isItemWrong = true;
            }
        }
        else if (this.gameObject.name == "Salt Bowl") //If the gameObject this script is on is the Salt bowl
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodSalt" && !dc.isDragActive)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
                //Item that was put into this container was right
                isItemWrong = false;
                //Increment this variable 
                amntsalt++;
                //If Contrainer is full
                if (amntsalt == items.maxAmntOfItem)
                {
                    //Set this container to being complete
                    isComplete = true;
                    //Tell the Game Manager that a container has been completed
                    gm.amntContainersComplete++;
                }
            }
            else if (col.gameObject.tag != "GoodSalt" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
                //Item that was put into this container was wrong
                isItemWrong = true;
            }
        }

        else if (this.gameObject.name == "Sugar Bowl") //If the gameObject this script is on is the Sugar bowl
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodSugar" && !dc.isDragActive)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
                //Item that was put into this container was right
                isItemWrong = false;
                //Increment this variable 
                amntsugar++;
                //If Contrainer is full
                if (amntsugar == items.maxAmntOfItem)
                {
                    //Set this container to being complete
                    isComplete = true;
                    //Tell the Game Manager that a container has been completed
                    gm.amntContainersComplete++;
                }
            }
            else if (col.gameObject.tag != "GoodSugar" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
                //Item that was put into this container was wrong
                isItemWrong = true;
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
                //Item that was put into this container was right
                isItemWrong = false;
                //Increment this variable 
                amntflour++;
                //If Contrainer is full
                if (amntflour == items.maxAmntOfItem)
                {
                    //Set this container to being complete
                    isComplete = true;
                    //Tell the Game Manager that a container has been completed
                    gm.amntContainersComplete++;
                }
            }
            else if (col.gameObject.tag != "GoodFlour" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
                //Item that was put into this container was wrong
                isItemWrong = true;
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
                //Item that was put into this container was right
                isItemWrong = false;
            }
            else if (col.gameObject.tag != "BadItems" && !dc.isDragActive) //If the gameobject is colliding with the wrong container
            {
                Destroy(col.gameObject);
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
                //Item that was put into this container was wrong
                isItemWrong = true;
            }

            if (dc.isDragActive) //If the player is hovering an item over the bin
            {
                //Enable the Bin Open Game Object
                spriteRenderer.sprite = bin[1];
            }
        }
        else if (this.gameObject.name == "Border") // If an item hits the borders of the game
        {
            Destroy(col.gameObject);
            //Set isItemWrong variable to true which means the item can be respawned
            isItemWrong = true;
        }



        //If the item has been dropped into the container
        if (!dc.isDragActive) 
        {
            //Check if the item that was dropped in was the wrong one
            if (isItemWrong) 
            {
                //Make sure the item can be respawned
                items.IncreaseSpawn(col.gameObject);
                Debug.Log(col.gameObject.name + "Dropped into " + this.gameObject.name+ " is wrong!");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (this.gameObject.name == "Bin") //If the gameObject this script is on is the bin
        {
            //Disables the Bin Open Game Object when the item leaves the collider of the bin
            spriteRenderer.sprite = bin[0];
        }
    }
}
