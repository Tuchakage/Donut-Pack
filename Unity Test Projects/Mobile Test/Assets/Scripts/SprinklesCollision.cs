using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklesCollision : MonoBehaviour
{
    private GameObject Sprinkles;
    private int numofParticles = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Sprinkles") 
        {
            //if there is less than 6 sprinkles in the spot, then sprinkles can stick onto that space of the Donut
            if (numofParticles < 6)
            {
                //Make the Sprinkle Object a child object of the Donut
                col.gameObject.transform.parent = this.transform;
                col.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                //Makes it so the game knows 1 particle is on the collider
                numofParticles++;
            }
            else
            {
                //Disable the circle colliders so no more sprinkles can go on it
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }

            if (this.gameObject.name == "Border")
            {
                Destroy(col.gameObject);
            }
        }

    }
}
