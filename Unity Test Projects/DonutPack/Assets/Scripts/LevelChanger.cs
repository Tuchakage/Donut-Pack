using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    RatingManager rm;
    string currentSceneName; //Gets the current Scene name
    public GameObject winScreen;
    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        //Get Current Scene Name
        currentSceneName = SceneManager.GetActiveScene().name;
        //Get Rating Manager
        rm = GameObject.Find("RatingManager").GetComponent<RatingManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowWinningScreen() 
    {
        //Pause Game
        Time.timeScale = 0f;
        //Show Winning Screen
        winScreen.SetActive(true);
    }

    public void ShowLosingScreen()
    {
        //Pause Game
        Time.timeScale = 0f;
        //Show Losing Screen
        loseScreen.SetActive(true);
    }

    //To be called when a mini game has been won
    public void MiniGameWon()
    {
        //Make a pop up screen that gives you option to go to next mini game
        //Win Screen will pop up which allows you to go to next level
        if (currentSceneName == "Ingredients")
        {
            //Go To Next Mini Game
            SceneManager.LoadScene("Roll-A-Ball-Tutorial");
        }
        else if (currentSceneName == "Roll-A-Ball")
        {
            SceneManager.LoadScene("ShakeTutorial");
        }
        else if (currentSceneName == "Shake")
        {
            //Find the Donut that was created
            GameObject donut = GameObject.FindGameObjectWithTag("Donut");
            //Make it so it cant be destroyed when a new scene is loaded
            donut.AddComponent<DontDestroyOnLoad>();
            SceneManager.LoadScene("DonutShowcase");
        }
        else if (currentSceneName == "DonutShowcase")
        {
            SceneManager.LoadScene("PackingTutorial");
        }
        else if (currentSceneName == "Packing")
        {
            Destroy(GameObject.FindGameObjectWithTag("Donut"));
            SceneManager.LoadScene("FinalRating");
        }


    }

    public void PracticeLevels() 
    {
        //For Practice Levels
        if (currentSceneName == "IngredientsTutorialPractice")
        {
            SceneManager.LoadScene("Ingredients Practice");
        }
        else if (currentSceneName == "Roll-A-Ball-TutorialPractice")
        {
            SceneManager.LoadScene("Roll A Ball Practice");
        }
        else if (currentSceneName == "ShakeTutorialPractice") 
        {
            SceneManager.LoadScene("Shake Practice");
        }
        else if (currentSceneName == "Shake Practice")
        {
            //Find the Donut that was created
            GameObject donut = GameObject.FindGameObjectWithTag("Donut");
            //Make it so it cant be destroyed when a new scene is loaded
            donut.AddComponent<DontDestroyOnLoad>();
            SceneManager.LoadScene("DonutShowcase Practice");
        }
        else if (currentSceneName == "DonutShowcase Practice")
        {
            SceneManager.LoadScene("PackingTutorial Practice");
        }
        else if (currentSceneName == "PackingTutorial Practice")
        {
            SceneManager.LoadScene("Packing Practice");
        }
    }

    //Called when the mini game is lost
    public void MiniGameLost() 
    {
        SceneManager.LoadScene("Main Menu");
    }
}
