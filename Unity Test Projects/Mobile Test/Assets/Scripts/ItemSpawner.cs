using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List <GameObject> Items = new List<GameObject>();
    [SerializeField] private float randX, randY, randZ;

    [SerializeField]
    private int rand; //Used to Randomise Items
    [SerializeField]
    private int badmilk, goodmilk, goodflour, badflour, sugar, salt, goodyeast, badyeast; //Used to make a counter for each item

    public int maxAmntOfItem; //Max amount of an item that can spawn

    //Timer that indicates when the next item will spawn
    public float timer;
    //This variable indicates the cooldown between each item being spawned in
    public float cooldownTillNextItem;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomItem();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the Items list is empty, if its not proceed to spawn in Items
        if (Items.Count != 0)
        {
            //If an item has just been spawned then start counting down the timer 
            if (timer > 0)
            {
                //The timer will start counting down
                timer -= Time.deltaTime;

            }
            else //When the cooldown timer reaches 0
            {
                SpawnRandomItem();
            }
        }
        else //If Items list is empty then do nothing
        {
            Debug.Log("There are no more Items to spawn in");
        }
    }

    void SpawnRandomItem() 
    {
        //Randomises the Item that will be spawned
        RandomiseItem();
        //Spawns a random item in the Items List
        Instantiate(Items[rand], new Vector3(Random.Range(-randX, randX), randY, randZ), Quaternion.identity);
        //Adds a counter to the Item that has spawned (Counts how many times the item has spawned)
        ItemCounter(Items[rand]);
        //Once the other item has spawned reset the timer with the value inside the cooldownTillNextItem variable
        timer = cooldownTillNextItem;
    }

    void RandomiseItem() 
    {
        //Pick a random number between 0 and the number of items in the Items list
        rand = Random.Range(0, Items.Count);
    }

    //Count the number of items
    void ItemCounter(GameObject itemObject)
    {
        Debug.Log(itemObject.name);
        //Check Which Item has been spawned
        if (itemObject.name == "GoodMilkPrefab")
        {
            //Increment the amount of this item by 1
            goodmilk++;
            //Makes sure that the Item doesnt spawn too much
            if (goodmilk == maxAmntOfItem)
            {
                //Remove the Item from the list so it cant be spawned in again
                Items.RemoveAt(Items.IndexOf(itemObject));
            }
        }
        else if (itemObject.name == "BadMilkPrefab")
        {
            //Increment the amount of this item by 1
            badmilk++;
            //Makes sure that the Item doesnt spawn too much
            if (badmilk == maxAmntOfItem)
            {
                //Remove the Item from the list so it cant be spawned in again
                Items.RemoveAt(Items.IndexOf(itemObject));
            }
        }
        else if (itemObject.name == "FlourBagPrefab")
        {
            //Increment the amount of this item by 1
            goodflour++;
            //Makes sure that the Item doesnt spawn too much
            if (goodflour == maxAmntOfItem)
            {
                //Remove the Item from the list so it cant be spawned in again
                Items.RemoveAt(Items.IndexOf(itemObject));
            }
        }

        else if (itemObject.name == "BadFlourbagPrefab")
        {
            //Increment the amount of this item by 1
            badflour++;
            //Makes sure that the Item doesnt spawn too much
            if (badflour == maxAmntOfItem)
            {
                //Remove the Item from the list so it cant be spawned in again
                Items.RemoveAt(Items.IndexOf(itemObject));
            }
        }

        else if (itemObject.name == "yeastbagPrefab")
        {
            //Increment the amount of this item by 1
            goodyeast++;
            //Makes sure that the Item doesnt spawn too much
            if (goodyeast == maxAmntOfItem)
            {
                //Remove the Item from the list so it cant be spawned in again
                Items.RemoveAt(Items.IndexOf(itemObject));
            }
        }

        else if (itemObject.name == "badyeastPrefab")
        {
            //Increment the amount of this item by 1
            badyeast++;
            //Makes sure that the Item doesnt spawn too much
            if (badyeast == maxAmntOfItem)
            {
                //Remove the Item from the list so it cant be spawned in again
                Items.RemoveAt(Items.IndexOf(itemObject));
            }
        }

        else if (itemObject.name == "SugarJarPrefab")
        {
            //Increment the amount of this item by 1
            sugar++;
            //Makes sure that the Item doesnt spawn too much
            if (sugar == maxAmntOfItem)
            {
                //Remove the Item from the list so it cant be spawned in again
                Items.RemoveAt(Items.IndexOf(itemObject));
            }
        }

        else if (itemObject.name == "SaltjarPrefab")
        {
            //Increment the amount of this item by 1
            salt++;
            //Makes sure that the Item doesnt spawn too much
            if (salt == maxAmntOfItem)
            {
                //Remove the Item from the list so it cant be spawned in again
                Items.RemoveAt(Items.IndexOf(itemObject));
            }
        }
    }

    //If an item is put into the wrong container, make sure it can be spawned again
    public void IncreaseSpawn(GameObject go) 
    {
        Debug.Log(go);
        //Check The Item that is being sent from The "Container" Script
        if (go.name == "GoodMilkPrefab(Clone)")
        {
            //Make sure that if the list no longer exists then recreate it
            if (goodmilk == maxAmntOfItem) 
            {
                //add the item into the list
                Items.Add(go);
            }
            //Decrease the amount of this item by 1
            goodmilk--;

        }
        else if (go.name == "BadMilkPrefab(Clone)")
        {
            //Make sure that if the list no longer exists then recreate it
            if (badmilk == maxAmntOfItem)
            {
                //add the item into the list
                Items.Add(go);
            }
            //Decrease the amount of this item by 1
            badmilk--;
        }
        else if (go.name == "FlourBagPrefab(Clone)")
        {
            //Make sure that if the list no longer exists then recreate it
            if (goodflour == maxAmntOfItem)
            {
                //add the item into the list
                Items.Add(go);
            }
            //Decrease the amount of this item by 1
            goodflour--;
        }

        else if (go.name == "BadFlourbagPrefab(Clone)")
        {
            //Make sure that if the list no longer exists then recreate it
            if (badflour == maxAmntOfItem)
            {
                //add the item into the list
                Items.Add(go);
            }
            //Decrease the amount of this item by 1
            badflour--;
        }

        else if (go.name == "yeastbagPrefab(Clone)")
        {
            //Make sure that if the list no longer exists then recreate it
            if (goodyeast == maxAmntOfItem)
            {
                //add the item into the list
                Items.Add(go);
            }
            //Decrease the amount of this item by 1
            goodyeast--;
        }

        else if (go.tag == "badyeastPrefab(Clone)")
        {
            //Make sure that if the list no longer exists then recreate it
            if (badyeast == maxAmntOfItem)
            {
                //add the item into the list
                Items.Add(go);
            }
            //Decrease the amount of this item by 1
            badyeast--;
        }

        else if (go.name == "SugarJarPrefab(Clone)")
        {
            //Make sure that if the list no longer exists then recreate it
            if (sugar == maxAmntOfItem)
            {
                //add the item into the list
                Items.Add(go);
            }
            //Decrease the amount of this item by 1
            sugar--;
        }

        else if (go.name == "SaltjarPrefab(Clone)")
        {
            //Make sure that if the list no longer exists then recreate it
            if (salt == maxAmntOfItem)
            {
                //add the item into the list
                Items.Add(go);
            }
            //Decrease the amount of this item by 1
            salt--;
        }
    }
}
