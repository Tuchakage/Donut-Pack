using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DonutManager : MonoBehaviour
{
    GameManager gm;
    [SerializeField]
    private string currentSceneName;
    public GameObject Donut;
    // This is a C# property - the code below isn't using it
    // as it is accessing the private static instance directly.
    // Use this property from other classes.
    public static DonutManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static DonutManager instance = null;

    void Awake()
    {
        //Get the name of the curretn scene
        currentSceneName = SceneManager.GetActiveScene().name;
        if (instance)
        {
            Debug.Log("already an instance so destroying new one");
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (currentSceneName == "Shake") 
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
    }
    private void Update()
    {
        if (gm.isGameFinished) 
        {
            //If the game is finished then change the position of this Donut
            this.gameObject.transform.position = new Vector3(-0.05f, 0.79f, 0);
        }
    }
    public void SetDonut(GameObject go) 
    {
        Donut = go;
    }
}


