using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutControl : MonoBehaviour
{
    public float maxDragDistance = 5f;
    public float releaseTime = 0.15f;

    private float circleRadius;

    public Rigidbody2D rb;
    public Rigidbody2D Hook;

    SpawnDonuts dm;
    GameManager gm;

    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;

    private Ray leftCatapultToProjectile;
    Touch touch;

    [SerializeField]
    private GameObject donut;

    private void Start()
    {
        SetupDonut();
    }

    public void SetupDonut() 
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        dm = GameObject.Find("DonutSpawner").GetComponent<SpawnDonuts>();
        donut = GameObject.FindGameObjectWithTag("Donut");
        Debug.Log("Found "+donut);
        //Make the next Donut the same one
        dm.NextDonut = donut.gameObject;

        //Set the Rigidbody of this Donut
        rb = donut.GetComponent<Rigidbody2D>();
        //Makes sure Kinematic is enabled
        rb.isKinematic = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        //Get The Rigidbody of the hook
        Hook = GameObject.Find("Hook").GetComponent<Rigidbody2D>();
        //Find The Catapults line renderer
        catapultLineBack = GameObject.Find("Backpoint").GetComponent<LineRenderer>();
        catapultLineFront = GameObject.Find("Frontpoint").GetComponent<LineRenderer>();
        LineRendererSetup();

        circleRadius = 0.3f;
        //Create a line based on the front catapult
        leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
    }

    private void Update()
    {
        //Check if there is a finger touching the screen
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
        LineRendererUpdate();
    }


    void DragStart()
    {
        //Enabled Kinematic when you touch the screen
        rb.isKinematic = true;
        FindObjectOfType<AudioManager>().Play("Slingshot Pull");
    }
    void Dragging()
    {

        Vector2 dragPos = Camera.main.ScreenToWorldPoint(touch.position);
        //Drag the ball to the position of the mouse but make sure it doesnt go too far
        if (Vector3.Distance(dragPos, Hook.position) > maxDragDistance)
        {
            rb.position = Hook.position + (dragPos - Hook.position).normalized * maxDragDistance;
        }
        else
        {
            rb.position = dragPos;
        }
    }

    void DragRelease()
    {
        //Disable Kinematic when you stop touching the screen
        rb.isKinematic = false;
        FindObjectOfType<AudioManager>().Stop("Slingshot Pull");
        FindObjectOfType<AudioManager>().Play("Slingshot Release");
        StartCoroutine(Release());
    }

    void LineRendererSetup()
    {
        catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
        catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

        catapultLineFront.sortingLayerName = "Foreground";
        catapultLineBack.sortingLayerName = "Foreground";

        catapultLineFront.sortingOrder = 3;
        catapultLineBack.sortingOrder = 1;
    }

    void LineRendererUpdate()
    {
        Transform d = donut.transform;

        Vector2 catapultToProjectile = d.position - catapultLineFront.transform.position;
        leftCatapultToProjectile.direction = catapultToProjectile;
        Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + circleRadius);
        catapultLineFront.SetPosition(1, holdPoint);
        catapultLineBack.SetPosition(1, holdPoint);
    }

    IEnumerator Release()
    {
        //Gives the Donut enough time to be launched
        yield return new WaitForSeconds(releaseTime);
        //Detachs the Donut from the Sling shot (If this wasnt here the Donut would never get launched)
        donut.GetComponent<SpringJoint2D>().enabled = false;
        //Disable this script so that the Line Renderers dont continue to follow the Donut
        this.enabled = false;
        yield return new WaitForSeconds(0.1f);
        //Turn off the band
        BandScript.BandVisible = 0;

        dm.donutRemaining--;
        dm.donutRemainingText.text = $"Donuts Remaining: " + dm.donutRemaining;

        //Wait a few seconds until spawning in the Next Donut
        yield return new WaitForSeconds(2f);
        //If the variable isnt null
        if (dm.NextDonut != null)
        {
            SpawnAfterRelease();
        }

        yield return new WaitForEndOfFrame();
        //Wait for a tiny bit until you setup Donut (Otherwise it wont get the new Donut that was spawned)
        SetupDonut();
    }

    public void SpawnAfterRelease() 
    {
        dm.SpawnDonut();
        this.enabled = true;  
        //Turn the band back on
        BandScript.BandVisible = 1;
        Destroy(donut.gameObject);
          
        //Tell The Game Manager that i have shot a Donut from the Slingshot
        gm.IncreaseDonutShots();
    }

}
