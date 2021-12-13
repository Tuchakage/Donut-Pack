using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Purpose of this script is to set the Difficulty of each level
public class DifficultyManager : MonoBehaviour
{
    [SerializeField]
    private int levelNumber;
    private string currentSceneName;
    public static DifficultyManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static DifficultyManager instance = null;

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
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log("OnSceneLoaded: " + scene.name);

        //If the Scene that is loading is the Ingredients Scene
        if (currentSceneName == "Ingredients")
        {
            //Set the max amount of items for Ingredients Level depending on value of buttons
            GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().SetMaxAmntOfItem(DifficultySystem.maxamntitem);
            //Set The Conveyor Speed
            GameObject.Find("Conveyor").GetComponent<MovingConveyor>().SetConveyorSpeed(DifficultySystem.conveyorSpeed);
        }
        else if (currentSceneName == "Packing") 
        {
            GameObject.Find("DonutSpawner").GetComponent<SpawnDonuts>().SetMaxDonuts(DifficultySystem.maxDonuts);
        }
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SetLevelNumber(int number) 
    {
        levelNumber = number;
    }

    public int GetLevelNumber() 
    {
        return levelNumber;
    }
}

