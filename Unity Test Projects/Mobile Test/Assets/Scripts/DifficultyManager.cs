using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField]
    private int difficulty;

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
            //Easy Difficulty
            if (difficulty == 0)
            {
                //Set the max amount of items for easy mode
                GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().SetMaxAmntOfItem(4);
                //Set The Conveyor Speed
                GameObject.Find("Conveyor").GetComponent<MovingConveyor>().SetConveyorSpeed(50);
            }
            else if (difficulty == 1) //Medium Difficulty
            {
                //Set the max amount of items for easy mode
                GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().SetMaxAmntOfItem(8);
                //Set The Conveyor Speed
                GameObject.Find("Conveyor").GetComponent<MovingConveyor>().SetConveyorSpeed(150);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void EasyMode() 
    {
        difficulty = 0;
    }

    public void MediumMode() 
    {
        difficulty = 1;
    }
}
