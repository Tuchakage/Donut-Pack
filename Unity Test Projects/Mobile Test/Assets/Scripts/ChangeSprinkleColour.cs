using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprinkleColour : MonoBehaviour
{
    Dictionary<int, Material> sprinklecolour = null;
    public List <Material> materials = new List<Material>(); //So we can add new Colours by making the material and adding it to the list
    private int randomColour = 0;
    // Start is called before the first frame update
    void Start()
    {

        //Create a dictionary for Sprinkle Colours
        sprinklecolour = new Dictionary<int, Material>();
        AddColoursToDictionary();
        //Pick a random Colour
        RandomColour();
        //Find the Particle System Renderer
        ParticleSystemRenderer psr = GetComponent<ParticleSystemRenderer>();
        //Change the colour
        psr.material = sprinklecolour[randomColour];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomColour() 
    {
        //Pick a number between 0 and the amount of colours in the Sprinkles Colour Dictionary
        randomColour = Random.Range(0, sprinklecolour.Count);
    }

    void AddColoursToDictionary() 
    {
        //For each item in the Material list
        for (int i = 0; i < materials.Count; i++) 
        {
            //Add them into the Dictionary for sprinkle colours
            sprinklecolour.Add(i, materials[i]);

            Debug.Log(materials[i]);
        }
    }
}
