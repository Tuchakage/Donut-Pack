using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Roll-A-Ball Test");
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
