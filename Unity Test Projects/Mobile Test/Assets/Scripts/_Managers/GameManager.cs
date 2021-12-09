using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    RatingManager rm;
    LevelChanger lc; //Script that changes Level
    //The text assigned here will change to the timer
    public TMP_Text timertext;
    [SerializeField]
    private float timeRemaining; //This variable will change
    [SerializeField]
    private float maxTimer; //This variable wont change
    //The GameObject assigned here will be the pop up timer text that will spawn in
    public GameObject popupText;

    //This decides whether or not there will be a + or a - infront of the timer pop up text
    bool isLosingTime;

    public int amntContainersComplete; //Indicates how many of the containers have been completed

    public bool startTimer; //For the sprinkles mini games to start the timer

    public bool isGameFinished; //Tells the game when the mini game is finished
    private void Start()
    {
        //Start the timer from the value in the maxTimer variable
        timeRemaining = maxTimer;
        lc = GetComponent<LevelChanger>();
        rm = GameObject.Find("RatingManager").GetComponent<RatingManager>();
        //Only for the shaker scene
        startTimer = false;
        if (SceneManager.GetActiveScene().name == "Shake") 
        {
            //Disable the timer text
            timertext.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTime(timeRemaining);
        //Win Condition for Ingredients Scene
        if (SceneManager.GetActiveScene().name == "Ingredients")
        {
            Timer();
            //If all the containers have been filled up, the player has won the game
            if (amntContainersComplete == 5)
            {
                //The Game is finished
                isGameFinished = true;
                //Tell Level Changer script that the game has been won
                lc.ShowWinningScreen();
                //The Rating Of The Player depends on the time remaining in the game
                rm.RatingForIngredients(timeRemaining, maxTimer);
                //Debug.Log("GAME COMPLETE");
            }
        }
        else if (SceneManager.GetActiveScene().name == "Shake") //If we are in Shaker scene
        {
            //When this is set to true then start the timer (Will be set to true by the IcingCollision script)
            if (startTimer) 
            {
                timertext.enabled = true;
                Timer();
            }
        }

    }

    void Timer() 
    {
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
            //The Game is finished
            isGameFinished = true;
            //If not on the Shaking Scene
            if (SceneManager.GetActiveScene().name != "Shake")
            {          
                lc.ShowLosingScreen();
            }
            else //On the Shaking Scene
            {
                lc.ShowWinningScreen();
                //Disable Timer Text
                timertext.enabled = false;
            }

            //Debug.Log("GAME OVER");
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