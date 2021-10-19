using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private GameObject Sprinkles;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other) 
    {
        //Puts the Sprinkle Particles that collided with the object into the Sprinkles variable
        Sprinkles = other.gameObject;
        //Save the current scale of the Sprinkle Particles
        Vector3 scale = Sprinkles.transform.localScale;
        //Make the Sprinkle particles a child object of the Donut
        Sprinkles.transform.parent = transform;
        //When the Sprinkle becomes a child object of the Donut its scale changes, so we prevent this by applying the scale of the Sprinkle before it was a child object of the Donut
        Sprinkles.transform.localScale = scale;
        Debug.Log("hi " + other.name);
    }
}
