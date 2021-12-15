using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySystem : MonoBehaviour
{

    public static int maxamntitem, maxDonuts; //Set the Max amount of items for the Level in the button
    public static float maxTimeIngredients, maxTimeRollABall; //Set the Max amount of time you have for Ingredients and Roll A Ball Level
    public static float conveyorSpeed; //Set the speed of the Conveyor Belt
    public static int levelnumber; //Set the Level Number

    //Functions called by Buttons (Value is also set in the buttons)
    public void SetMaxAmntItems(int maxitems)
    {
        //Whatever value is put into the parameters will be set for the actual mini games
        maxamntitem = maxitems;
    }

    public void SetConveyorSpeed(float speed)
    {
        //Whatever value is put into the parameters will be set for the actual mini games
        conveyorSpeed = speed;
    }
    public void SetTimeForIngredients(float time)
    {
        //Whatever value is put into the parameters will be set for the actual mini games
        maxTimeIngredients = time;
    }

    public void SetTimeForRollABall(float time)
    {
        //Whatever value is put into the parameters will be set for the actual mini games
        maxTimeRollABall = time;
    }
    public void maxDonutSpawned(int maxD)
    {
        maxDonuts = maxD;
    }

    public void SetLevelNumber(int ln)
    {
        levelnumber = ln;
        DifficultyManager dm = GameObject.Find("DifficultyManager").GetComponent<DifficultyManager>();
        dm.SetLevelNumber(levelnumber);       
    }
}
