using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutControl : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;

    Vector3 dragStartPos;
    Touch touch;

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
    }

    void DragStart() 
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
    }
    void Dragging() 
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;
    }

    void DragRelease() 
    {
        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;
        
        Vector3 force = dragStartPos - dragReleasePos;
        //Clamps the force(Makes sure item cant be launched too far)
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
        //Launches The Item
        rb.AddForce(clampedForce, ForceMode2D.Impulse);
    }
}
