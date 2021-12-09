using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    //For The Container Fill Sprite Array Element 0 = Empty, Element 1 = Half Full, Element 2 = Full, Element 3 = 25% full, Element 4 = 75% full
    //For changing the sprites for the containers
    public SpriteRenderer spriteRenderer;
    public Sprite[] bin;
    public Sprite[] containerFill; //Sprites for how full the Containers will show as

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
    private bool isComplete = false; // Checks if the container is full
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        items = GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Used so we can check if the Item is currently being dragged or not
        Draggable isBeingDragged = col.gameObject.GetComponent<Draggable>();
        if (this.gameObject.name == "Measuring Cup")//If the gameObject this script is on is the Measuring Cup
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodMilk" && !isBeingDragged.pickedUp)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
                //If the container is not full yet
                if (amntgoodmilk < items.maxAmntOfItem) 
                {
                    //Increment this variable
                    amntgoodmilk++;
                    //If the container is 25% full
                    if (amntgoodmilk == items.maxAmntOfItem / 4)
                    {
                        spriteRenderer.sprite = containerFill[3];
                    }
                    //If the milk container is half way full
                    else if (amntgoodmilk == items.maxAmntOfItem / 2)
                    {
                        //Change into the Sprite with the measuring cup half full
                        spriteRenderer.sprite = containerFill[1];
                    }
                    else if (amntgoodmilk == items.maxAmntOfItem / 4 * 3)  //75% of a container
                    {
                        spriteRenderer.sprite = containerFill[4];
                    }
                    else if (amntgoodmilk == items.maxAmntOfItem) //If the container is full
                    {
                        //Change into the Sprite with the measuring cup full
                        spriteRenderer.sprite = containerFill[2];
                        //The container is full
                        isComplete = true;
                        //Tell the Game Manager that a container has been completed
                        gm.amntContainersComplete++;
                    }
                }

            }
            else if (col.gameObject.tag != "GoodMilk" && !isBeingDragged.pickedUp) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                FindObjectOfType<AudioManager>().Play("Bad Ingredient");
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
                //If there is already ingredients in this container and then a wrong item is put into the container
                if (amntgoodmilk > 0) 
                {
                    //Decrease the amount of Milk
                    amntgoodmilk--;
                    if (amntgoodmilk == items.maxAmntOfItem / 4 * 3)  //75% of a container
                    {
                        //Tell the game manager that the container is no longer full
                        gm.amntContainersComplete--;
                        spriteRenderer.sprite = containerFill[4];
                    }
                    else if (amntgoodmilk == items.maxAmntOfItem / 2)
                    {
                        //Change the sprite to being half full again
                        spriteRenderer.sprite = containerFill[1];
                    }
                    //If the container is 25% full
                    else if (amntgoodmilk == items.maxAmntOfItem / 4)
                    {
                        spriteRenderer.sprite = containerFill[3];
                    }
                    else if (amntgoodmilk < 1) //If the amount in this container is back to 0
                    {
                        //Make the Measuring Cup Sprite Empty again
                        spriteRenderer.sprite = containerFill[0];
                    }
                }
            }
        }
        else if (this.gameObject.name == "Yeast Bowl") //If the gameObject this script is on is the Yeast bowl
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodYeast" && !isBeingDragged.pickedUp)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
                //If the container is not full yet
                if (amntgoodyeast < items.maxAmntOfItem)
                {
                    //Increment this variable
                    amntgoodyeast++;
                    //If the container is 25% full
                    if (amntgoodyeast == items.maxAmntOfItem / 4)
                    {
                        spriteRenderer.sprite = containerFill[3];
                    }
                    //If the container is half way full
                    else if (amntgoodyeast == items.maxAmntOfItem / 2)
                    {
                        //Change into the Sprite with the Yeast bowl half full
                        spriteRenderer.sprite = containerFill[1];
                    }
                    else if (amntgoodyeast == items.maxAmntOfItem / 4 * 3)  //75% of a container
                    {
                        spriteRenderer.sprite = containerFill[4];
                    }
                    else if (amntgoodyeast == items.maxAmntOfItem) //If the container is full
                    {
                        //Change into the Sprite with the Yeast bowl full
                        spriteRenderer.sprite = containerFill[2];
                        //Set this container to being complete
                        isComplete = true;
                        //Tell the Game Manager that a container has been completed
                        gm.amntContainersComplete++;
                    }
                }

            }
            else if (col.gameObject.tag != "GoodYeast" && !isBeingDragged.pickedUp) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                FindObjectOfType<AudioManager>().Play("Bad Ingredient");
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
                //If there is already ingredients in this container and then a wrong item is put into the container
                if (amntgoodyeast > 0)
                {
                    //Decrease the amount of Yeast
                    amntgoodyeast--;
                    if (amntgoodyeast == items.maxAmntOfItem / 4 * 3)  //75% of a container
                    {
                        //Tell the game manager that the container is no longer full
                        gm.amntContainersComplete--;
                        spriteRenderer.sprite = containerFill[4];
                    }
                    else if (amntgoodyeast == items.maxAmntOfItem / 2)
                    {
                        //Change the sprite to being half full again
                        spriteRenderer.sprite = containerFill[1];
                    }
                    //If the container is 25% full
                    else if (amntgoodyeast == items.maxAmntOfItem / 4)
                    {
                        spriteRenderer.sprite = containerFill[3];
                    }
                    else if (amntgoodyeast < 1) //If the amount in this container is back to 0
                    {
                        //Make the Measuring Cup Sprite Empty again
                        spriteRenderer.sprite = containerFill[0];
                    }
                }
            }
        }
        else if (this.gameObject.name == "Salt Bowl") //If the gameObject this script is on is the Salt bowl
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodSalt" && !isBeingDragged.pickedUp)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
                //If the container is not full yet
                if (amntsalt < items.maxAmntOfItem) 
                {

                    //Increment this variable 
                    amntsalt++;
                    //If the container is 25% full
                    if (amntsalt == items.maxAmntOfItem / 4)
                    {
                        spriteRenderer.sprite = containerFill[3];
                    }
                    //If the container is half way full
                    else if (amntsalt == items.maxAmntOfItem / 2)
                    {
                        //Change into the Sprite with the Yeast bowl half full
                        spriteRenderer.sprite = containerFill[1];
                    }
                    else if (amntsalt == items.maxAmntOfItem / 4 * 3)  //75% of a container
                    {
                        spriteRenderer.sprite = containerFill[4];
                    }
                    else if (amntsalt == items.maxAmntOfItem) //If the container is full
                    {
                        //Change into the Sprite with the Yeast bowl full
                        spriteRenderer.sprite = containerFill[2];
                        //Set this container to being complete
                        isComplete = true;
                        //Tell the Game Manager that a container has been completed
                        gm.amntContainersComplete++;
                    }
                }

            }
            else if (col.gameObject.tag != "GoodSalt" && !isBeingDragged.pickedUp) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                FindObjectOfType<AudioManager>().Play("Bad Ingredient");
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
                //If there is already ingredients in this container and then a wrong item is put into the container
                if (amntsalt > 0)
                {
                    //Decrease the amount of Salt
                    amntsalt--;
                    if (amntsalt == items.maxAmntOfItem / 4 * 3)  //75% of a container
                    {
                        //Tell the game manager that the container is no longer full
                        gm.amntContainersComplete--;
                        spriteRenderer.sprite = containerFill[4];
                    }
                    else if (amntsalt == items.maxAmntOfItem / 2)
                    {
                        //Change the sprite to being half full again
                        spriteRenderer.sprite = containerFill[1];
                    }
                    //If the container is 25% full
                    else if (amntsalt == items.maxAmntOfItem / 4)
                    {
                        spriteRenderer.sprite = containerFill[3];
                    }
                    else if (amntsalt < 1) //If the amount in this container is back to 0
                    {
                        //Make the Measuring Cup Sprite Empty again
                        spriteRenderer.sprite = containerFill[0];
                    }
                }
            }
        }

        else if (this.gameObject.name == "Sugar Bowl") //If the gameObject this script is on is the Sugar bowl
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodSugar" && !isBeingDragged.pickedUp)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
                //If the container is not full yet
                if (amntsugar < items.maxAmntOfItem) 
                {
                    //Increment this variable 
                    amntsugar++;
                    //If the container is 25% full
                    if (amntsugar == items.maxAmntOfItem / 4)
                    {
                        spriteRenderer.sprite = containerFill[3];
                    }
                    //If the container is half way full
                    else if (amntsugar == items.maxAmntOfItem / 2)
                    {
                        //Change into the Sprite with the Yeast bowl half full
                        spriteRenderer.sprite = containerFill[1];
                    }
                    else if (amntsugar == items.maxAmntOfItem / 4 * 3)  //75% of a container
                    {
                        spriteRenderer.sprite = containerFill[4];
                    }
                    else if (amntsugar == items.maxAmntOfItem) //If the container is full
                    {
                        //Change into the Sprite with the Yeast bowl full
                        spriteRenderer.sprite = containerFill[2];
                        //Set this container to being complete
                        isComplete = true;
                        //Tell the Game Manager that a container has been completed
                        gm.amntContainersComplete++;
                    }
                }

            }
            else if (col.gameObject.tag != "GoodSugar" && !isBeingDragged.pickedUp) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                FindObjectOfType<AudioManager>().Play("Bad Ingredient");
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
                //If there is already ingredients in this container and then a wrong item is put into the container
                if (amntsugar > 0)
                {
                    //Decrease the amount of Sugar
                    amntsugar--;
                    if (amntsugar == items.maxAmntOfItem / 4 * 3)  //75% of a container
                    {
                        //Tell the game manager that the container is no longer full
                        gm.amntContainersComplete--;
                        spriteRenderer.sprite = containerFill[4];
                    }
                    else if (amntsugar == items.maxAmntOfItem / 2)
                    {
                        //Change the sprite to being half full again
                        spriteRenderer.sprite = containerFill[1];
                    }
                    //If the container is 25% full
                    else if (amntsugar == items.maxAmntOfItem / 4)
                    {
                        spriteRenderer.sprite = containerFill[3];
                    }
                    else if (amntsugar < 1) //If the amount in this container is back to 0
                    {
                        //Make the Measuring Cup Sprite Empty again
                        spriteRenderer.sprite = containerFill[0];
                    }
                }
            }
        }

        else if (this.gameObject.name == "Wide Bowl") //If the gameObject this script is on is the Flour bowl
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "GoodFlour" && !isBeingDragged.pickedUp)
            {
                Debug.Log("Correct Item");
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
                //If the container is not full yet
                if (amntflour < items.maxAmntOfItem)
                {
                    //Increment this variable 
                    amntflour++;
                    //If the container is 25% full
                    if (amntflour == items.maxAmntOfItem / 4)
                    {
                        spriteRenderer.sprite = containerFill[3];
                    }
                    //If the container is half way full
                    else if (amntflour == items.maxAmntOfItem / 2)
                    {
                        //Change into the Sprite with the Yeast bowl half full
                        spriteRenderer.sprite = containerFill[1];
                    }
                    else if (amntflour == items.maxAmntOfItem / 4 * 3)  //75% of a container
                    {
                        spriteRenderer.sprite = containerFill[4];
                    }
                    else if (amntflour == items.maxAmntOfItem) //If the container is full
                    {
                        //Change into the Sprite with the Yeast bowl full
                        spriteRenderer.sprite = containerFill[2];
                        //Set this container to being complete
                        isComplete = true;
                        //Tell the Game Manager that a container has been completed
                        gm.amntContainersComplete++;
                    }
                }

            }
            else if (col.gameObject.tag != "GoodFlour" && !isBeingDragged.pickedUp) //If the gameobject is colliding with the wrong container
            {
                Debug.Log("Wrong Item");
                Destroy(col.gameObject);
                FindObjectOfType<AudioManager>().Play("Bad Ingredient");
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
                if (amntflour > 0)
                {
                    //Decrease the amount of Flour
                    amntflour--;
                    if (amntflour == items.maxAmntOfItem / 4 * 3)  //75% of a container
                    {
                        //Tell the game manager that the container is no longer full
                        gm.amntContainersComplete--;
                        spriteRenderer.sprite = containerFill[4];
                    }
                    else if (amntflour == items.maxAmntOfItem / 2)
                    {
                        //Change the sprite to being half full again
                        spriteRenderer.sprite = containerFill[1];
                    }
                    //If the container is 25% full
                    else if (amntflour == items.maxAmntOfItem / 4)
                    {
                        spriteRenderer.sprite = containerFill[3];
                    }
                    else if (amntflour < 1) //If the amount in this container is back to 0
                    {
                        //Make the Measuring Cup Sprite Empty again
                        spriteRenderer.sprite = containerFill[0];
                    }
                }
            }
        }

        else if (this.gameObject.name == "Bin") //If the gameObject this script is on is the bin
        {
            //If the gameobject that is colliding with the container is the right one and dragging is not active (So its been dropped)
            if (col.gameObject.tag == "BadItems" && !isBeingDragged.pickedUp)
            {
                Destroy(col.gameObject);
                //If you put the right object in the right container you get more time
                gm.addTime(addedtime, this.transform.position);
            }
            else if (col.gameObject.tag != "BadItems" && !isBeingDragged.pickedUp) //If the gameobject is colliding with the wrong container
            {
                Destroy(col.gameObject);
                FindObjectOfType<AudioManager>().Play("Bad Ingredient");
                //If you put the wrong object into the wrong container then you lose time
                gm.loseTime(losttime, this.transform.position);
            }

            if (isBeingDragged.pickedUp) //If the player is hovering an item over the bin
            {
                //Enable the Bin Open Game Object
                spriteRenderer.sprite = bin[1];
            }
        }
        else if (this.CompareTag("Border")) // If an item hits the borders of the game
        {
            Destroy(col.gameObject, 2f);
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
