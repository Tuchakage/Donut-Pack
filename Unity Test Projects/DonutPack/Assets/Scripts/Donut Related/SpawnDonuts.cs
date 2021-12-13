using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnDonuts : MonoBehaviour
{
    public GameObject NextDonut;
    public int donutSpawned; //Tracks how many Donuts has been spawned
    public float maxDonut = 0; //Max Amount Of Donuts that can be spawned
    public float donutRemaining;
    public TextMeshProUGUI donutRemainingText;
    // Start is called before the first frame update
    void Start()
    {
        //Starts at 1 because 1 would have already been spawned
        donutSpawned = 1;
        donutRemaining = donutSpawned;
        donutRemainingText = GameObject.Find("DonutRemaining").GetComponent<TextMeshProUGUI>();
        donutRemainingText.text = $"Donuts Remaining: " + maxDonut;
    }

    // Update is called once per frame
    void Update()
    {
        donutRemaining = maxDonut;
    }

    public void SpawnDonut() 
    {
        if (donutSpawned < maxDonut)
        {
            //Spawn in another Donut
            GameObject donut = Instantiate(NextDonut, new Vector2(0.730080068f, -1.10299993f), Quaternion.identity);
            donut.transform.parent = null;           
            donut.name = "Donut";
            //Make it so we can see the Donut
            donut.SetActive(true);
            donut.GetComponent<Rigidbody2D>().isKinematic = true;
            //Enable SpringJoin2D Component
            donut.GetComponent<SpringJoint2D>().enabled = true;
            //Tells the game that a Donut has been spawned
            donutSpawned++;
            donutRemaining -= 1;
            donutRemainingText.text = $"Donuts Remaining: " + donutRemaining;
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
