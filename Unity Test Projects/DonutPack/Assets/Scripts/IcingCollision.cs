using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IcingCollision : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] Donuts; //An array of the different types of Donuts
    [SerializeField]
    private GameObject[] disableElements; //List of Game Objects that need to be disabled when an icing has been chosen for the Donuts
    ShakeDetector sd;
    [SerializeField]
    private GameObject sprinkles; //Sprinkles Colliders
    [SerializeField]
    private GameObject tutorial;
    GameManager gm;
    private void Start()
    {
        //Get the Sprite Renderer of the GameObject this script is attached to (The Donut Game Object)
        spriteRenderer = GetComponent<SpriteRenderer>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>(); 
        sd = GameObject.Find("GameManager").GetComponent<ShakeDetector>();

        //Disable the Shaking
        sd.enabled = false;
        //Disable the Sprinkles Colliders
        sprinkles.SetActive(false);
    }

    private void Update()
    {
        //If Game is finished then disable the tutorial text
        if (gm.isGameFinished) 
        {
            tutorial.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //If the Chocolate icing touches the Donut
        if (col.gameObject.name == "Chocolate_Icing(Clone)") 
        {
            //Make the Donut a Chocolate Donut
            spriteRenderer.sprite = Donuts[1];
            Debug.Log("This is now a Chocolate Donut");
        }
        else if (col.gameObject.name == "Strawberry_Icing(Clone)")
        {
            //Make the Donut a Strawberry Donut
            spriteRenderer.sprite = Donuts[2];
            Debug.Log("This is now a Strawberry Donut");
        }
        else if (col.gameObject.name == "BlueGlaze_Icing(Clone)")
        {
            //Make the Donut a Blue Glaze Donut
            spriteRenderer.sprite = Donuts[3];

        }
        else if (col.gameObject.name == "Rainbow_Icing(Clone)")
        {
            //Make the Donut a Rainbow Donut
            spriteRenderer.sprite = Donuts[4];

        }

        //If any type of icing touches the Donut
        if (col.gameObject.tag == "Icing") 
        {
            //Re enable the shaking mechanics
            sd.enabled = true;
            //Re enable Sprinkles Colliders
            sprinkles.SetActive(true);
            Destroy(col.gameObject);
            //Disable all the GameObjects in the "disableElements" array (In this case disable everything related to the icing machine)
            foreach (GameObject ui in disableElements) 
            {
                ui.SetActive(false);
            }
            //Enable the text that tells players to shake their phone
            tutorial.SetActive(true);
            //Start the timer
            gm.startTimer = true;
        }
    }
}
