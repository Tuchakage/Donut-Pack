using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public float ShakeForceMultiplier;
    public List<Rigidbody2D> rb = new List<Rigidbody2D>();

    public void ShakeRigidbodies(Vector3 deviceAcceleration)
    {
        // For each Rigid body in the ShakingRigidbodies Array
        foreach (var rigidbody in rb) 
        {
            //We are going to add Force to the rigidbody depending on how much the device is shaking and depending on the ShakeForceMultiplier
            rigidbody.AddForce(deviceAcceleration * ShakeForceMultiplier, ForceMode2D.Impulse);
        }
    }

    void Update() 
    {
        //Keeps Checking the list
        for (int i =0; i < rb.Count; i++) 
        {
            //If anything in the list has been destroyed
            if (rb[i] == null) 
            {
                //Remove it from the list
                rb.RemoveAt(i);
            }
        }
    }
}
