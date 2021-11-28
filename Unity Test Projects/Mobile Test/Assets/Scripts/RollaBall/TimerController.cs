using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;
    [SerializeField] private FinishLineScript fl;
    [SerializeField] private LevelChanger lc;

    private void Start()
    {
        lc = GameObject.Find("GameController").GetComponent<LevelChanger>();
        fl = GameObject.Find("FinishLine").GetComponent<FinishLineScript>();
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                //If the timer is 0 and the player hasnt crossed the finish line then stop everything and they lose.
                if (timeRemaining <= 0 && fl.hasCrossedFinishLine == false)
                {
                    fl.StopEverything();
                    lc.ShowLosingScreen();
                }
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}

