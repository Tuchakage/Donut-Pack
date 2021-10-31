using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List <GameObject> Items = new List<GameObject>();

    [SerializeField]
    private int rand;

    //Timer that indicates when the next item will spawn
    public float timer = 3;

    //This variable indicates the cooldown between each item being spawned in
    public float cooldownTillNextItem = 3;

    // Start is called before the first frame update
    void Start()
    {
        RandomiseItem();
        //Spawns a random item in the Items List
        Instantiate(Items[rand], new Vector3(Random.Range(-3.89f, 3.24f), -3, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        //If an item has just been spawned then start counting down the timer 
        if (timer > 0)
        {
            //The timer will start counting down
            timer -= Time.deltaTime;

        }
        else //When the cooldown timer reaches 0
        {
            RandomiseItem();
            //Spawn in another random item
            Instantiate(Items[rand], new Vector3(Random.Range(-0.59f, 1.37f), 4.18f, 0), Quaternion.identity);

            //Once the other item has spawned reset the timer with the value inside the cooldownTillNextItem variable
            timer = cooldownTillNextItem;

        }
    }

    void RandomiseItem() 
    {
        //Pick a random number between 0 and the number of items in the Items list
        rand = Random.Range(0, Items.Count);
    }
}
