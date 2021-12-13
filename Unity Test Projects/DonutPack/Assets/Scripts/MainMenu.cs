using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    LevelData ld;
    private string currentSceneName;
    private int result = 0;


    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Main Menu") 
        {
            //When the main Menu is open load up the Level Ratings
            LoadLevel();
        }

    }

    public void ShowLevels() 
    {
        ld = GameObject.Find("LevelManager").GetComponent<LevelData>();
        LoadLevel();
        //Find how many Levels there are
        int amntofLevels = GameObject.FindGameObjectsWithTag("Level").Length;


        foreach (GameObject level in GameObject.FindGameObjectsWithTag("Level")) 
        {

            LevelNumber ln = level.GetComponent<LevelNumber>();
            //Check the Level Number
            //Debug.Log(level.name+" "+ln.levelNumber);

            //Disable All Child Game Objects of the Level button object
            for (int i = 0; i < level.transform.childCount; i++)
            {
                //Find the Child Game Object
                GameObject child = level.transform.GetChild(i).gameObject;
                //If the Child Game Object is a star disable it
                if (child.tag == "Stars") 
                {
                    child.gameObject.SetActive(false);
                }
                
            }
            //Debug.Log(ld.isLevelComplete["Level " + ln.levelNumber.ToString()]);
            
            if (ld.levelRating.TryGetValue("Level " + ln.levelNumber.ToString(), out result))
            {
                Debug.Log("Found " + "Level " + ln.levelNumber.ToString());

                //Check if the Level is complete
                if (ld.isLevelComplete["Level " + ln.levelNumber.ToString()] == 1)
                {

                    Debug.Log("RATING FOR LEVEL: " + ld.levelRating["Level " + ln.levelNumber.ToString()]);
                    //Check the level rating the player got for the level and then re enable the stars depending on how many stars they got
                    for (int i = 0; i < ld.levelRating["Level " + ln.levelNumber.ToString()]; i++)
                    {
                        //Find the Child Game Object
                        GameObject child = level.transform.GetChild(i).gameObject;
                        //If the Child Game Object is a star then enable it
                        if (child.tag == "Stars")
                        {
                            child.gameObject.SetActive(true);

                        }
                    }
                }
            }
            else //If we couldnt find a level
            {
                Debug.Log("Couldn't Find " + "Level " + ln.levelNumber.ToString());
            }
    
        }
    }
    public void ShowTutorialForLevel1() 
    {
        SceneManager.LoadScene("IngredientsTutorial");
    }
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Ingredients");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Roll-A-Ball");
    }

    public void PlayLevel3() 
    {
        SceneManager.LoadScene("Shake");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SaveLevel() 
    {
        RatingManager rm = GameObject.Find("RatingManager").GetComponent<RatingManager>();
        ld = GameObject.Find("LevelManager").GetComponent<LevelData>();
        SaveSystem.SaveLevel(rm);
        SaveDict.SaveDictionary(ld);
    }

    public void LoadLevel() 
    {
        PlayerData data = SaveSystem.LoadPlayer();
        ld = GameObject.Find("LevelManager").GetComponent<LevelData>();
        RatingManager rm = GameObject.Find("RatingManager").GetComponent<RatingManager>();
        rm.finalRating = data.finalRating;
        SaveDict.LoadDictionary(ld.levelRating,ld.isLevelComplete);
    }

    public void pretendPlayLevel1() 
    {
        //If there is no key for this Level
        if (!ld.levelRating.TryGetValue("Level 1", out result))
        {
            //Then add a key for the level and the rating the Player got
            ld.levelRating.Add("Level 1", 1);
            //Lets the game know that the level has been completed
            ld.isLevelComplete.Add("Level 1", 1);
        }
        else //If the Level already has a key
        {
            int newrating = 2;
            //If the rating from playing again is higher than the current rating
            if (newrating > ld.levelRating["Level 1"])
            {
                //Change the rating
                ld.levelRating["Level 1"] = 1;
            }
        }
    }

    public void pretendPlayLevel2()
    {

        //If there is no key for this Level
        if (!ld.levelRating.TryGetValue("Level 2", out result))
        {
            //Then add a key for the level and the rating the Player got
            ld.levelRating.Add("Level 2", 1);
            //Lets the game know that the level has been completed
            ld.isLevelComplete.Add("Level 2", 1);
        }
        else //If the Level already has a key
        {
            int newrating = 3;
            //If the rating from playing again is higher than the current rating
            if (newrating > ld.levelRating["Level 2"]) 
            {
                //Change the rating
                ld.levelRating["Level 2"] = 1;
            }         
        }

        
        Debug.Log(ld.levelRating["Level 2"]);
    }

    public void CheckDictionaries() 
    {
        ld = GameObject.Find("LevelManager").GetComponent<LevelData>();
        foreach (var pair in ld.levelRating)
        {
            Debug.Log("Ibjec" + pair);
            //Load the data of the dictionaries text file back into the actual Dictionaries

        }
    }
}
