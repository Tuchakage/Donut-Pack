using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{

    [SerializeField]
    private int maxamntitem; //Set the Max amount of items for the Level in the button
    [SerializeField]
    private float maxTimeIngredients, maxTimeRollABall; //Set the Max amount of time you have for Ingredients and Roll A Ball Level
    [SerializeField]
    private float conveyorSpeed; //Set the speed of the Conveyor Belt
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
            GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().SetMaxAmntOfItem(maxamntitem);
            //Set The Conveyor Speed
            GameObject.Find("Conveyor").GetComponent<MovingConveyor>().SetConveyorSpeed(conveyorSpeed);
        }
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SetMaxAmntItems(int maxitems) 
    {
        //Whatever value is put into the parameters will be set for the actual mini games
        maxamntitem = maxitems;
    }

    public void SetConveyorSpeed(float speed) 
    {
        //Whatever value is put into the parameters will be set for the actual mini games
        conveyorSpeed = speed;
    }
    public void SetTimeForIngredients(float time) 
    {
        //Whatever value is put into the parameters will be set for the actual mini games
        maxTimeIngredients = time;
    }

    public void SetTimeForRollABall(float time) 
    {
        //Whatever value is put into the parameters will be set for the actual mini games
        maxTimeRollABall = time;
    }
}

