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
        GameObject item = Instantiate(Items[rand], new Vector3(Random.Range(-randX, randX), randY, randZ), Quaternion.identity);
        item.transform.parent = transform;
        //Once the other item has spawned reset the timer with the value inside the cooldownTillNextItem variable
        timer = cooldownTillNextItem;
    }

    void RandomiseItem() 
    {
        //Pick a random number between 0 and the number of items in the Items list
        rand = Random.Range(0, Items.Count);
    }

}
