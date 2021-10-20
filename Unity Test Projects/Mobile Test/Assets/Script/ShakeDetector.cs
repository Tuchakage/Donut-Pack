using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsController))]
public class ShakeDetector : MonoBehaviour
{
    //If the Acceleration is above the threshold in this variable then the shake will happen
    public float ShakeDetectionThreshold;
    //Makes it so we detect shakes a certain amount of time per second
    public float MinShakeInterval;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;

    //The GameObject assigned here will be the pop up timer text that will spawn in
    public GameObject Sprinkles;
    private PhysicsController physicsController;
    // Start is called before the first frame update
    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        physicsController = GetComponent<PhysicsController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval) 
        {
            physicsController.ShakeRigidbodies(Input.acceleration);
            timeSinceLastShake = Time.unscaledTime;
        }

        if (Input.acceleration.sqrMagnitude >= 25) 
        {
            Debug.Log("Shake Detected");
            //Randomly spawns in Sprinkles between 2 points
            TimeIndicator indicator = Instantiate(Sprinkles, new Vector3(Random.Range(-3.89f, 3.24f), 3, 0), Quaternion.identity).GetComponent<TimeIndicator>();
        }
    }
}
