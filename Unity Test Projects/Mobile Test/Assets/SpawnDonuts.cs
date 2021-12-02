using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDonuts : MonoBehaviour
{
    public GameObject NextDonut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDonut() 
    {
        //Spawn in another Donut
        GameObject donut = Instantiate(NextDonut, new Vector2(0.468f, -0.909f), Quaternion.identity);
        //Enable SpringJoin2D Component
        donut.GetComponent<SpringJoint2D>().enabled = true;
        //Enable Donut Control Script
        donut.GetComponent<DonutControl>().enabled = true;
    }
}
