using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RatingManager : MonoBehaviour
{
    GameManager gm;

    public Dictionary<string, int> ratingsForLevel = null;
    public List<GameObject> stars = new List<GameObject>();
    GameObject Thirdstar;
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private bool ratingApplied;

    private string currentSceneName;

    public static RatingManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static RatingManager instance = null;

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
        //Everytime a Mini Game is loaded make sure this is false so that the rating can be applied once
        ratingApplied = false;
        //If the Scene has Gameplay
        if (currentSceneName == "Ingredients" || currentSceneName == "Shake" || currentSceneName == "Roll-A-Ball" || currentSceneName == "Packing")
        {
            DisableWinScreen();

        }


    }


    // Start is called before the first frame update
    void Start()
    {
        //Create a Dictionary so we can hold the ratings for each level
        ratingsForLevel = new Dictionary<string, int>();
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

    void DisableWinScreen()
    {
        //Find all the Stars in the canvas and disable them
        foreach (GameObject ratingStars in GameObject.FindGameObjectsWithTag("Stars"))
        {
            //Add the stars to the list
            stars.Add(ratingStars);
            //Disable them so they cant be seen
            ratingStars.SetActive(false);
        }
        //Then disable the Win Screen
        winScreen = GameObject.Find("Win Screen");
        winScreen.SetActive(false);
    }

    public void RatingForIngredients(float timeRemaining, float maxTime) 
    {
        //If the rating hasnt been applied yet and the time remaining is more than the max time (Consistently putting the ingredients into the right place in good time)
        if (timeRemaining > maxTime && !ratingApplied)
        {
            //Keep note of the rating for this level
            ratingsForLevel.Add("Ingredients", 3);
            //Set the rating for this level
            setRating(3);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
        else if (timeRemaining > maxTime / 2 && timeRemaining < maxTime && !ratingApplied) //If the time left is more than half of the max time and less than max time then you get 2 stars
        {
            //Keep note of the rating for this level
            ratingsForLevel.Add("Ingredients", 2);
            //Set the rating for this level
            setRating(2);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
        else if (timeRemaining < maxTime / 2 && !ratingApplied) // If time left is less than half of the max time
        {
            //Keep note of the rating for this level
            ratingsForLevel.Add("Ingredients", 1);
            //Set the rating for this level
            setRating(1);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
    }

    public void RatingForRollABall(float timeRemaining, float maxTime)
    {
        //If the rating hasnt been applied yet and the time remaining is more than the max time (Consistently putting the ingredients into the right place in good time)
        if (timeRemaining > maxTime && !ratingApplied)
        {
            //Keep note of the rating for this level
            ratingsForLevel.Add("RollABall", 3);
            //Set the rating for this level
            setRating(3);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
        else if (timeRemaining > maxTime / 2 && timeRemaining < maxTime && !ratingApplied) //If the time left is more than half of the max time and less than max time then you get 2 stars
        {
            //Keep note of the rating for this level
            ratingsForLevel.Add("Ingredients", 2);
            //Set the rating for this level
            setRating(2);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
        else if (timeRemaining < maxTime / 2 && !ratingApplied) // If time left is less than half of the max time
        {
            //Keep note of the rating for this level
            ratingsForLevel.Add("Ingredients", 1);
            //Set the rating for this level
            setRating(1);
            //Tell the GameManager that the rating has been applied so it cant call it again
            ratingApplied = true;
        }
    }

    void setRating(int amntofStars) 
    {
        //Depending on the rating the player got, re enable the star game Objects 
        for (int i = 0; i < amntofStars; i++) 
        {
            stars[i].SetActive(true);
        }


    }
}
