using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _toBeDisabled;
    public GameObject Sprinkles;
    private void Start()
    {
        //Make sure that the game is not paused when a new scene is loaded
        Unpause();
    }
    public void Pause()
    {
        if (SceneManager.GetActiveScene().name == "Ingredients" || SceneManager.GetActiveScene().name == "Ingredients Practice")
        {
            DragController dc = GameObject.Find("DragController").GetComponent<DragController>();
            if (!dc.isDragActive)
            {
                _pausePanel.SetActive(true);
                _toBeDisabled.SetActive(false);
                Time.timeScale = 0f;
            }
        }
        else 
        {
            _pausePanel.SetActive(true);
            _toBeDisabled.SetActive(false);
            Time.timeScale = 0f;
        }

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
        if (SceneManager.GetActiveScene().name == "Packing" || SceneManager.GetActiveScene().name == "Packing Practice") 
        {
            //Make sure to delete the Donut in the scene already
            GameObject donut = GameObject.Find("Donut");
            Destroy(donut);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //JUST HERE TO TEST OUT SPAWNING OFF SPRINKLES
    public void Spawn()
    {
        FindObjectOfType<AudioManager>().Play("Shaker");
        //Randomly spawns in Sprinkles between 2 points
        GameObject indicator = Instantiate(Sprinkles, new Vector3(Random.Range(-1.85f, 2.6f), 3, 0), Quaternion.identity);
    }
}
