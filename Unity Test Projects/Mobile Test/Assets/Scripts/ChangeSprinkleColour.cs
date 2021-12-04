using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprinkleColour : MonoBehaviour
{
    public List <Material> materials = new List<Material>(); //So we can add new Colours by making the material and adding it to the list
    public List<Sprite> sprinkleShape = new List<Sprite>(); //So we can add new shapes for the Sprinkles
    private int randomColour = 0;
    private int randomShape = 0;
    // Start is called before the first frame update
    void Start()
    {;
        //Pick a random Colour and Shape
        RandomSprinkle();
        //Find the particle System
        ParticleSystem ps = GetComponent<ParticleSystem>();
        //Change the sprite shape
        ps.textureSheetAnimation.SetSprite(0, sprinkleShape[randomShape]);
        //Get the Particle System Main Module 
        var main = ps.main;
        ChangeSprinkleSize(main, randomShape);
        //Find the Particle System Renderer
        ParticleSystemRenderer psr = GetComponent<ParticleSystemRenderer>();
        //Change the colour
        psr.material = materials[randomColour];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomSprinkle() 
    {
        //Pick a number between 0 and the amount of colours in the Sprinkles Colour List
        randomColour = Random.Range(0, materials.Count);
        //Pick a number between 0 and the amount of shapes in the list
        randomShape = Random.Range(0, sprinkleShape.Count);
    }


    //Changes the sprinkle size depending on the shape of the sprinkle
    void ChangeSprinkleSize(ParticleSystem.MainModule psmain, int ShapeOfSprinkle) 
    {
        if (ShapeOfSprinkle == 0)
        {
            psmain.startSize = 0.25f;
        }
        else if (ShapeOfSprinkle == 1) 
        {
            psmain.startSize = 0.5f;
        }
    }
}
