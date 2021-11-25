using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcingCollision : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] Donuts; //An arroy of the different types of Donuts
    ShakeDetector sd;

    private void Start()
    {
        //Get the Sprite Renderer of the GameObject this script is attached to (The Donut Game Object)
        spriteRenderer = GetComponent<SpriteRenderer>();
        sd = GameObject.Find("GameManager").GetComponent<ShakeDetector>();
        //Disable the Shaking
        sd.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //If the Chocolate icing touches the Donut
        if (col.gameObject.name == "Chocolate_Icing(Clone)") 
        {
            //Make the Donut a Chocolate Donut
            //spriteRenderer.sprite = Donuts[1];
            Debug.Log("This is now a Chocolate Donut");
        }
        else if (col.gameObject.name == "Strawberry_Icing(Clone)")
        {
            //Make the Donut a Chocolate Donut
            //spriteRenderer.sprite = Donuts[2];
            Debug.Log("This is now a Strawberry Donut");
        }

        //If any type of icing touches the Donut
        if (col.gameObject.tag == "Icing") 
        {
            //Re enable the shaking mechanics
            sd.enabled = true;
        }
    }
}
