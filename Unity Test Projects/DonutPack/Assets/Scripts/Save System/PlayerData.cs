using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Makes it so that we will be able to save this data into a file
[System.Serializable]
public class PlayerData //Constructor
{
    //Variables that should be saved
    public int finalRating;

    //It will hold the data of the Player
    public PlayerData(RatingManager rating) 
    {
        //Store the variables into this constructor
        finalRating = rating.finalRating;
    }
}

