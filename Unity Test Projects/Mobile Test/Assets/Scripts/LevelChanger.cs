using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    string currentSceneName; //Gets the current Scene name
    public GameObject winScreen;
    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
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
            SceneManager.LoadScene("Roll-A-Ball - (1)");
        }

        if (currentSceneName == "Roll-A-Ball - (1)")
        {
            SceneManager.LoadScene("Shake");
        }
    }

    //Called when the mini game is lost
    public void MiniGameLost() 
    {
        SceneManager.LoadScene("Main Menu");
    }
}
