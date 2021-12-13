using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostingMachine : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnLocation; //Where the Icing Will Spawn from
    [SerializeField]
    private List<GameObject> Icing = new List<GameObject>(); //List Of Icing
    [SerializeField]
    private bool pressedButton; //Makes it so you can only press the button once
    //Press on Chocolate button to activate this function
    public void SpawnChoccyIcing() 
    {
        if (!pressedButton)     
        {
            Debug.Log("Chocolate");
            //Spawn the Chocolate Icing
            Instantiate(Icing[0], spawnLocation.transform.position, Quaternion.identity);
            pressedButton = true;
        }
    }

    //Press on Strawberry button to activate this function
    public void SpawnStrawberryIcing()
    {
        if (!pressedButton) 
        {
            //Spawn in Icing Depending On Button Pressed
            Debug.Log("Strawberry");
            //Spawn the Strawberry Icing
            Instantiate(Icing[1], spawnLocation.transform.position, Quaternion.identity);
            pressedButton = true;
        }
    }

    //Press on Blue Glaze button to activate this function
    public void SpawnBlueGlazeIcing()
    {
        if (!pressedButton) 
        {
            //Spawn in Icing Depending On Button Pressed
            Instantiate(Icing[2], spawnLocation.transform.position, Quaternion.identity);
            pressedButton = true;
        }
    }

    //Press on Rainbow button to activate this function
    public void SpawnRainbowIcing()
    {
        if (!pressedButton) 
        {
            //Spawn in Icing Depending On Button Pressed
            Instantiate(Icing[3], spawnLocation.transform.position, Quaternion.identity);
            pressedButton = true;
        }
    }
}
