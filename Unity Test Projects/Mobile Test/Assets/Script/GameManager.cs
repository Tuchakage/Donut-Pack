using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //The text assigned here will change to the timer
    public TMP_Text timertext;

    public float timeRemaining = 60;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTime(timeRemaining);
        //If the timer is set to something that is more than 0
        if (timeRemaining > 0)
        {
            //Then timer it will start counting down
            timeRemaining -= Time.deltaTime;
        }
        else //When the timer runs out
        {
            //Makes sure the time is set to 0
            timeRemaining = 0;
            Debug.Log("GAME OVER");
        }
    }

    void DisplayTime(float time) 
    {
        //This calculates the minutes. Mathf.FloorToInt rounds them down to the largest integer value
        float minutes = Mathf.FloorToInt(time / 60);
        //This calculates the seconds e.g 62 % 60 would return the value 2 aka 1 minute and 2 seconds. 
        float seconds = Mathf.FloorToInt(time % 60);

        //string.Format allows us to place variables inside of a formatted string
        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //When this function is called then time will be added to the timer
    public void addTime(float addedtime) 
    {
        timeRemaining += addedtime;
    }

    //When this function is called then time will be taken away from the timer
    public void loseTime(float losttime) 
    {
        timeRemaining -= losttime;
    }
}
