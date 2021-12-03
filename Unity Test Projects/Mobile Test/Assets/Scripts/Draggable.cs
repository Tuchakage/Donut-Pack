using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool pickedUp; //Check if the item this Script is attached to has been picked up
    // Start is called before the first frame update
    void Start()
    {
        //When the item has just spawned in make sure this variable is false
        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Use this in DragController so that the item knows it has been picked up or not
    public void HasBeenPickedUp(bool picked) 
    {
        pickedUp = picked;
    }
}
