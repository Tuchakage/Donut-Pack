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
        donutRemaining = maxDonut;
        donutRemainingText = GameObject.Find("DonutRemaining").GetComponent<TextMeshProUGUI>();
        donutRemainingText.text = $"Donuts Remaining: " + maxDonut;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnDonut() 
    {
        if (donutSpawned <= maxDonut)
        {
            //Spawn in another Donut
            GameObject donut = Instantiate(NextDonut, new Vector2(0.730080068f, -1.10299993f), Quaternion.identity);
            Destroy(donut.GetComponent<DontDestroyOnLoad>());
            donut.transform.parent = null;           
            donut.name = "Donut";

            //Change Scale
            donut.transform.localScale = new Vector3(0.140325993f, 0.140325993f, 0.140325993f);
            //Rotate Donut
            donut.transform.rotation = Quaternion.Euler(0, 0, 0);
            //Change Position
            donut.transform.position = new Vector2(0.730080068f, -1.10299993f);

            //Add all the components so that the Donut can be shot from the sling shot
            donut.AddComponent<Rigidbody2D>();
            donut.AddComponent<SpringJoint2D>();
            donut.GetComponent<CircleCollider2D>().enabled = true;
            donut.GetComponent<SpringJoint2D>().connectedBody = GameObject.Find("Hook").GetComponent<Rigidbody2D>();
            donut.GetComponent<SpringJoint2D>().frequency = 1.5f;
            SpawnDonuts ds = GameObject.Find("DonutSpawner").GetComponent<SpawnDonuts>();

            //Make it so we can see the Donut
            donut.SetActive(true);
            //donut.GetComponent<Rigidbody2D>().isKinematic = true;
            ////Enable SpringJoin2D Component
            //donut.GetComponent<SpringJoint2D>().enabled = true;
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
