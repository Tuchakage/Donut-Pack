using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //The text assigned here will change to the timer
    public TMP_Text timertext;

    public float timeRemaining = 60;

    //The GameObject assigned here will be the pop up timer text that will spawn in
    public GameObject popupText;

    //This decides whether or not there will be a + or a - infront of the timer pop up text
    bool isLosingTime;

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
    public void addTime(float addedtime, Vector3 pos) 
    {
        //This will be set to false because they are gaining time
        isLosingTime = false;

        //Extends the timer by the value of addedtime variable
        timeRemaining += addedtime;

        //It will spawn the pop up timer text in the position of the container
        TimeIndicator indicator = Instantiate(popupText, pos, Quaternion.identity).GetComponent<TimeIndicator>();

        //Sets the number that will pop up
        indicator.SetTimeText(addedtime, isLosingTime);

    }

    //When this function is called then time will be taken away from the timer
    public void loseTime(float losttime, Vector3 pos) 
    {
        //This will be set to true because they are losing time
        isLosingTime = true;

        //Reduces the timer by the value of losttime variable
        timeRemaining -= losttime;

        //It will spawn the pop up timer text in the position of the container
        TimeIndicator indicator = Instantiate(popupText, pos, Quaternion.identity).GetComponent<TimeIndicator>();

        //Sets the number that will pop up
        indicator.SetTimeText(losttime, isLosingTime);
    }
}