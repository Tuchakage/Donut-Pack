using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public bool isDragActive = false;

    //For the input the user puts in
    private Vector2 _screenPosition;
    //Final position of the dragged object
    private Vector3 _worldPosition;

    private Draggable _lastDragged;

    void Awake() 
    {
        //Makes sure there is only 1 DragController in the scene
        DragController[] controller = FindObjectsOfType<DragController>();
        if (controller.Length > 1) 
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //If we are dragging an object but then the user lets go
        if (isDragActive && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended) 
        {
            Drop();
            return;
        }

        //Checks the position that the user touched
        if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else 
        {
            return;
        }

        //Convert the 2D position on the screen to world coordinates
        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (isDragActive)
        {
            Drag();
        }
        else //If its not already dragging something then this code will detect the object we want to drag
        {
            //Checks if the user touches a draggable item on the screen
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);

            // If the ray hits an item that is a draggable object
            if (hit.collider != null) 
            {
                //draggable variable becomes the item that has been touched
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null) 
                {
                    //The last dragged object becomes the current dragged object
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }

    }

    void InitDrag() 
    {
        //Makes it so that the program knows when it is dragging
        isDragActive = true;
        //Tell the item it has been picked up
        _lastDragged.HasBeenPickedUp(true);
        //When Item has been picked up Disable colliders so it cant collide into the other items
        _lastDragged.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Drag() 
    {
        //Updates the position of the last dragged object
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
    }

    void Drop() 
    {
        //Makes it so the object will no longer follow the finger
        isDragActive = false;
        //Tell the item it has not been picked up
        _lastDragged.HasBeenPickedUp(false);
        //When item has been dropped Enable colliders so it can collide with the containers
        _lastDragged.GetComponent<BoxCollider2D>().enabled = true;
    }
}
