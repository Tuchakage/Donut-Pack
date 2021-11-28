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

    void OnParticleCollision(GameObject col) 
    {
        

        ParticleSystem.MainModule psm = col.gameObject.GetComponent<ParticleSystem>().main;
        //Disable the gravity
        psm.gravityModifier = 0;
        //if there is less than 1 sprinkles in the spot, then sprinkles can stick onto that space of the Donut
        if (numofParticles < 1)
        {
            //Puts the Sprinkle Particles that collided with the object into the Sprinkles variable
            Sprinkles = col.gameObject;
            //Save the current scale of the Sprinkle Particles
            Vector3 scale = Sprinkles.transform.localScale;
            //Make the Sprinkle particles a child object of the Donut
            Sprinkles.transform.parent = this.transform;
            //When the Sprinkle becomes a child object of the Donut its scale changes, so we prevent this by applying the scale of the Sprinkle before it was a child object of the Donut
            Sprinkles.transform.localScale = scale;
            //Makes it so the game knows 1 particle is on the collider
            numofParticles++;
        }
        else 
        {
            //Disable the particles so no more sprinkles can go on it
            gameObject.GetComponent<CircleCollider2D>().enabled= false;
        }
    }
}
