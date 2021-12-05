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
    //public static DonutManager Instance
    //{
    //    get
    //    {
    //        return instance;
    //    }
    //}

    //private static DonutManager instance = null;

    //void Awake()
    //{
    //    //Get the name of the curretn scene
    //    currentSceneName = SceneManager.GetActiveScene().name;
    //    if (instance)
    //    {
    //        Debug.Log("already an instance so destroying new one");
    //        DestroyImmediate(gameObject);
    //        return;
    //    }

    //    instance = this;

    //    DontDestroyOnLoad(gameObject);
    //}

    private void Start()
    {
        //Find the Donut Object and save it
        Donut = GameObject.FindGameObjectWithTag("Donut");
        //Change Scale
        Donut.transform.localScale = new Vector3(0.0645455122f, 0.0787723586f, 0.583067f);
        //Change Position
        Donut.transform.position = new Vector2(-0.381000012f, -0.666999996f);
        //Destroy Components
        Destroy(Donut.GetComponent<IcingCollision>());
        Destroy(Donut.GetComponent<BoxCollider2D>());

        //Add all the components so that the Donut can be shot from the sling shot
        Donut.AddComponent<Rigidbody2D>();
        Donut.AddComponent<DonutControl>();
        Donut.AddComponent<SpringJoint2D>();
        Donut.GetComponent<SpringJoint2D>().connectedBody = GameObject.Find("Hook").GetComponent<Rigidbody2D>();
        Donut.GetComponent<SpringJoint2D>().frequency = 1.5f;
        SpawnDonuts ds = GameObject.Find("DonutSpawner").GetComponent<SpawnDonuts>();
        //Destroy the DontDestroyOnLoad so we can keep respawning the Donut
        Destroy(Donut.GetComponent<DontDestroyOnLoad>());


        //Disable The Donut
        // Donut.SetActive(false);
        //Spawn Donut
        //Instantiate(Donut, new Vector2(-0.381000012f, -0.666999996f), Quaternion.identity);
    }
    private void Update()
    {

    }
    public void SetDonut(GameObject go) 
    {
        Donut = go;
    }
}


