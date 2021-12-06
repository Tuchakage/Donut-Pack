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

    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;

    private Ray leftCatapultToProjectile;
    Touch touch;


    private void Start()
    {
        dm = GameObject.Find("DonutSpawner").GetComponent<SpawnDonuts>();
        //Make the next Donut the same one
        dm.NextDonut = this.gameObject;

        //Set the Rigidbody of this Donut
        rb = GetComponent<Rigidbody2D>();
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
        Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
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
        GetComponent<SpringJoint2D>().enabled = false;
        //Disable this script so that the Line Renderers dont continue to follow the Donut
        this.enabled = false;
        yield return new WaitForSeconds(0.1f);
        //Turn off the band
        BandScript.BandVisible = 0;

        //Wait a few seconds until spawning in the Next Donut
        yield return new WaitForSeconds(2f);
        //If the variable isnt null
        if (dm.NextDonut != null)
        {
            SpawnAfterRelease();
        }
    }

    public void SpawnAfterRelease() 
    {
        dm.SpawnDonut();
        //Turn the band back on
        BandScript.BandVisible = 1;
        Destroy(this.gameObject);
    }
}
