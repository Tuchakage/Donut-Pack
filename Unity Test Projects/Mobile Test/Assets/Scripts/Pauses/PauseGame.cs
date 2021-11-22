using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _toBeDisabled;

    private void Start()
    {
        //Make sure that the game is not paused when a new scene is loaded
        Unpause();
    }
    public void Pause()
    {
        _pausePanel.SetActive(true);
        _toBeDisabled.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        _pausePanel.SetActive(false);
        _toBeDisabled.SetActive(true);
        Time.timeScale = 1f;
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Ingredients") 
        {
            SceneManager.LoadScene("Ingredients");
        }
    }
    
}
