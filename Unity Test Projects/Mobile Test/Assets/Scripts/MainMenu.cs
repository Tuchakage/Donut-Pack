using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        SceneManager.LoadScene("Roll-A-Ball - (1)");
    }

    public void PlayLevel3() 
    {
        SceneManager.LoadScene("Shake");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
