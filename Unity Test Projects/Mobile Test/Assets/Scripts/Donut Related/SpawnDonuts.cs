using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDonuts : MonoBehaviour
{
    public GameObject NextDonut;
    public int donutSpawned; //Tracks how many Donuts has been spawned
    public int maxDonut = 0; //Max Amount Of Donuts that can be spawned
    // Start is called before the first frame update
    void Start()
    {
        //Starts at 1 because 1 would have already been spawned
        donutSpawned = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDonut() 
    {
        if (donutSpawned < maxDonut)
        {
            //Spawn in another Donut
            GameObject donut = Instantiate(NextDonut, new Vector2(-0.381000012f, -0.666999996f), Quaternion.identity);
            donut.transform.parent = transform;
            donut.name = "Donut";
            //Make it so we can see the Donut
            donut.SetActive(true);
            donut.GetComponent<Rigidbody2D>().isKinematic = true;
            //Enable SpringJoin2D Component
            donut.GetComponent<SpringJoint2D>().enabled = true;
            //Enable Donut Control Script
            donut.GetComponent<DonutControl>().enabled = true;
            //Tells the game that a Donut has been spawned
            donutSpawned++;
        }
        else 
        {
            return;
        }

    }

    public void SetMaxDonuts(int d) 
    {
        maxDonut = d;
    }
}
