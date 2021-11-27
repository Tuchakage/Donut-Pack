using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    public SwipeControls _playerControls;

    // Start is called before the first frame update
    void Start()
    {
        _playerControls = GameObject.Find("TouchManager").GetComponent<SwipeControls>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("StopEverything", 3.5f);
        }
    }

    public void StopEverything()
    {
        _playerControls._rb.velocity = new Vector2(0f, 0f);
        _playerControls.enabled = false;
    }
}

