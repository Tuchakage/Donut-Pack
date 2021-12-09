using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    public SwipeControlsNew _playerControls;
    public TimerController tc;
    public bool hasCrossedFinishLine;
    [SerializeField] private LevelChanger lc;

    // Start is called before the first frame update
    void Start()
    {
        hasCrossedFinishLine = false;
        lc = GameObject.Find("GameController").GetComponent<LevelChanger>();
        tc = GameObject.Find("GameController").GetComponent<TimerController>();
        _playerControls = GameObject.Find("TouchManager").GetComponent<SwipeControlsNew>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //if the player collides with finish line then stop everything and they win
        if (other.gameObject.CompareTag("Player"))
        {
            if (tc.timeRemaining > 0)
            {
                Invoke("StopEverything", 1f);
                lc.ShowWinningScreen();
            }
        }
    }
    
    //Function to stop everything thats got to do with the player
    public float StopEverything()
    {
        hasCrossedFinishLine = true;
        tc.timerIsRunning = false;
        _playerControls._rb.velocity = new Vector2(0f, 0f);
        _playerControls.enabled = false;
        return tc.timeRemaining;
    }
}

