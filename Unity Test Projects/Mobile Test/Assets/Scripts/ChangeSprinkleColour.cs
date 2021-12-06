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
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //Choose A Shape
        sr.sprite = sprinkleShape[randomShape];
        //Choose A Colour
        sr.material = materials[randomColour];
        //Change Scale Of Object
        this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //Change Rotation
        this.gameObject.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, -90));
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
}
