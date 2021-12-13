using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RatingManager : MonoBehaviour
{
    GameManager gm;

    public Dictionary<string, int> ratingsForLevel = null;
    public List<GameObject> stars = new List<GameObject>();
    GameObject Thirdstar;
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private bool ratingApplied;
    public int finalRating; //Used to save the final rating
    private string currentSceneName;
    private int result = 0;
    public int totalscore;
    public static RatingManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static RatingManager instance = null;

    void Awake()
    {
        if (instance)
        {
            Debug.Log("already an instance so destroying new one");
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;

        //Create a Dictionary so we can hold the ratings for each level
        ratingsForLevel = new Dictionary<string, int>();
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log("OnSceneLoaded: " + scene.name);
        //Everytime a Mini Game is loaded make sure this is false so that the rating can be applied once
        ratingApplied = false;
        //If the Scene has Gameplay
        if (currentSceneName == "Ingredients" || currentSceneName == "Shake" || currentSceneName == "Roll-A-Ball" || currentSceneName == "Packing")
        {
            ClearList();         
            FindStars();
            
            //Then disable the Win Screen
            winScreen = GameObject.Find("Win Screen");
            winScreen.SetActive(false);
        }
        else if (currentSceneName == "FinalRating") 
        {
            ClearList();
            FindStars();
            FinalRatingCalc();
        }

    }


    // Start is called before the first frame update
    void Start()
    {

        //FOR TESTING DELETE LATER
        if (currentSceneName == "FinalRating") 
        {
            ratingsForLevel.Add("Ingredients", 3);
            ratingsForLevel.Add("RollABall", 3);
            ratingsForLevel.Add("Packing", 3);
            FinalRatingCalc();
        }
        

    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void FindStars()
    {
        //Find all the Stars in the canvas and disable them
        foreach (GameObject ratingStars in GameObject.FindGameObjectsWithTag("Stars"))
        {
            //Add the stars to the list
            stars.Add(ratingStars);
            //Disable them so they cant be seen
            ratingStars.SetActive(false);
        }

    }

    void ClearList() 
    {
        //If there is things in the Stars list when a mini game is loaded, clear the list
        if (stars != null)
        {
            stars.Clear();
        }
    }

    public void RatingForIngredients(float timeRemaining, float maxTime) 
    {
        //If the rating hasnt been applied yet and the time remaining is more than the max time (Consistently putting the ingredients into the right place in good time)
        if (timeRemaining > maxTime && !ratingApplied)
        {
            //If there is no Key
            if (!ratingsForLevel.TryGetValue("Ingredients", out result))
            {
                //Keep note of the rating for this level
                ratingsForLevel.Add("Ingredients", 3);
            }
            else //If there is a key
            {
                ratingsForLevel["Ingredients"] = 3;
            }
            //Set the rating for this level
            setRating(3);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
        else if ((timeRemaining > maxTime / 2 && timeRemaining < maxTime) && !ratingApplied) //If the time left is more than half of the max time and less than max time then you get 2 stars
        {
            //If there is no Key
            if (!ratingsForLevel.TryGetValue("Ingredients", out result))
            {
                //Keep note of the rating for this level
                ratingsForLevel.Add("Ingredients", 2);
            }
            else //If there is a key
            {
                ratingsForLevel["Ingredients"] = 2;
            }

            //Set the rating for this level
            setRating(2);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
        else if (timeRemaining < maxTime / 2 && !ratingApplied) // If time left is less than half of the max time
        {
            //If there is no Key
            if (!ratingsForLevel.TryGetValue("Ingredients", out result))
            {
                //Keep note of the rating for this level
                ratingsForLevel.Add("Ingredients", 1);
            }
            else //If there is a key
            {
                ratingsForLevel["Ingredients"] = 1;
            }
            //Set the rating for this level
            setRating(1);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
    }

    public void RatingForRollABall(float timeRemaining, float maxTime)
    {
        //If the rating hasnt been applied yet and the time remaining is more than the max time (Consistently putting the ingredients into the right place in good time)
        if (timeRemaining > maxTime && !ratingApplied)
        {
            //If there is no Key
            if (!ratingsForLevel.TryGetValue("RollABall", out result))
            {
                //Keep note of the rating for this level
                ratingsForLevel.Add("RollABall", 3);
            }
            else //If there is a key
            {
                ratingsForLevel["RollABall"] = 3;
            }
            //Set the rating for this level
            setRating(3);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
        else if (timeRemaining > maxTime / 2 && timeRemaining < maxTime && !ratingApplied) //If the time left is more than half of the max time and less than max time then you get 2 stars
        {
            //If there is no Key
            if (!ratingsForLevel.TryGetValue("RollABall", out result))
            {
                //Keep note of the rating for this level
                ratingsForLevel.Add("RollABall", 2);
            }
            else //If there is a key
            {
                ratingsForLevel["RollABall"] = 2;
            }
            //Set the rating for this level
            setRating(2);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
        else if (timeRemaining < maxTime / 2 && !ratingApplied) // If time left is less than half of the max time
        {
            //If there is no Key
            if (!ratingsForLevel.TryGetValue("RollABall", out result))
            {
                //Keep note of the rating for this level
                ratingsForLevel.Add("RollABall", 1);
            }
            else //If there is a key
            {
                ratingsForLevel["RollABall"] = 1;
            }
            //Set the rating for this level
            setRating(1);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
    }

    public void RatingForPacking(float maxamntdonuts, float score) 
    {
        //If the player gets all the Donuts in the Packages
        if (score == maxamntdonuts && !ratingApplied)
        {
            //If there is no Key
            if (!ratingsForLevel.TryGetValue("Packing", out result))
            {
                //Keep note of the rating for this level
                ratingsForLevel.Add("Packing", 3);
            }
            else //If there is a key
            {
                ratingsForLevel["Packing"] = 3;
            }
            //Set the rating for this level
            setRating(3);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
        else if ((score >= maxamntdonuts / 2 && score < maxamntdonuts) && !ratingApplied) //Score is more than or equal to half of the max amount of donuts and its less than the max amount
        {
            //If there is no Key
            if (!ratingsForLevel.TryGetValue("Packing", out result))
            {
                //Keep note of the rating for this level
                ratingsForLevel.Add("Packing", 2);
            }
            else //If there is a key
            {
                ratingsForLevel["Packing"] = 2;
            }
            //Set the rating for this level
            setRating(2);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
        else if ((score > 0 && score < maxamntdonuts / 2) && !ratingApplied) //The score is more than 0 and less than half of the max Amount of donuts
        {
            //If there is no Key
            if (!ratingsForLevel.TryGetValue("Packing", out result))
            {
                //Keep note of the rating for this level
                ratingsForLevel.Add("Packing", 1);
            }
            else //If there is a key
            {
                ratingsForLevel["Packing"] = 1;
            }
            //Set the rating for this level
            setRating(1);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
    }

    //Makes The Stars Show Up
    void setRating(int amntofStars) 
    {
        //Depending on the rating the player got, re enable the star game Objects 
        for (int i = 0; i < amntofStars; i++) 
        {
            Debug.Log(i);
            stars[i].SetActive(true);
        }
    }

    void FinalRatingCalc() 
    {

        //Add up the Total Score for all the ratings
        //totalscore = ratingsForLevel["Ingredients"] + ratingsForLevel["RollABall"] +ratingsForLevel["Packing"];
        Debug.Log(totalscore);
        if (totalscore <= 9)
        {
            //They Get 3 Stars for that level
            setRating(1);
            finalRating = 1;

            LevelData ld = GameObject.Find("LevelManager").GetComponent<LevelData>();
            DifficultyManager dm = GameObject.Find("DifficultyManager").GetComponent<DifficultyManager>();
            //Add the final rating to the Dictionary (Gets the Level number and convert it into a string and then give the level the rating the player got)

            //If there is no key for this Level (Check If The Level Has Been completed before)
            if (!ld.levelRating.TryGetValue("Level " + dm.GetLevelNumber().ToString(), out result))
            {
                //Then add a key for the level and then tell the game that this level has been completed
                ld.isLevelComplete.Add("Level " + dm.GetLevelNumber().ToString(), 1);
                Debug.Log("Creating Key.....");
            }


            //If there is no key for this Level (Check If The Level Has a rating already)
            if (!ld.levelRating.TryGetValue("Level " + dm.GetLevelNumber().ToString(), out result))
            {
                //Then add a key for the level and the rating the Player got
                ld.levelRating.Add("Level " + dm.GetLevelNumber().ToString(), finalRating);
                Debug.Log("Creating Key.....");
            }
            else //If the Level already has a key
            {
                //Find the old rating of this level
                int oldrating = ld.levelRating["Level " + dm.GetLevelNumber().ToString()];
                //If the rating from playing again is higher than the current rating
                if (finalRating > oldrating)
                {
                    //Change the rating to the final rating
                    ld.levelRating["Level " + dm.GetLevelNumber().ToString()] = finalRating;
                    Debug.Log("Changing Key.......");
                }
            }
            //Save The Rating
            SaveDict.SaveDictionary(ld);
            Debug.Log("Level " + dm.GetLevelNumber().ToString());
        }
        else 
        {
            //They Get 3 Stars for that level
            setRating(3);
            finalRating = 3;

            LevelData ld = GameObject.Find("LevelManager").GetComponent<LevelData>();
            DifficultyManager dm = GameObject.Find("DifficultyManager").GetComponent<DifficultyManager>();
            //Add the final rating to the Dictionary (Gets the Level number and convert it into a string and then give the level the rating the player got)

            //If there is no key for this Level (Check If The Level Has Been completed before)
            if (!ld.levelRating.TryGetValue("Level " + dm.GetLevelNumber().ToString(), out result))
            {
                //Then add a key for the level and then tell the game that this level has been completed
                ld.isLevelComplete.Add("Level " + dm.GetLevelNumber().ToString(), 1);
                Debug.Log("Creating Key.....");
            }


            //If there is no key for this Level (Check If The Level Has a rating already)
            if (!ld.levelRating.TryGetValue("Level " + dm.GetLevelNumber().ToString(), out result))
            {
                //Then add a key for the level and the rating the Player got
                ld.levelRating.Add("Level " + dm.GetLevelNumber().ToString(), finalRating);
                Debug.Log("Creating Key.....");
            }
            else //If the Level already has a key
            {
                //Find the old rating of this level
                int oldrating = ld.levelRating["Level " + dm.GetLevelNumber().ToString()];
                //If the rating from playing again is higher than the current rating
                if (finalRating > oldrating)
                {
                    //Change the rating to the final rating
                    ld.levelRating["Level " + dm.GetLevelNumber().ToString()] = finalRating;
                    Debug.Log("Changing Key.......");
                }
            }
            //Save The Rating
            SaveDict.SaveDictionary(ld);
            Debug.Log("Level " + dm.GetLevelNumber().ToString());
        }
    }
}
