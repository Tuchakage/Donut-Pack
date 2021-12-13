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

    private void Start()
    {
        //Find the Donut Object and save it
        Donut = GameObject.FindGameObjectWithTag("Donut");
        Debug.Log(Donut);
        //Change Scale
        Donut.transform.localScale = new Vector3(0.0645455122f, 0.0787723586f, 0.583067f);
        //Rotate Donut
        Donut.transform.rotation = Quaternion.Euler(0, 0, 0);
        //Change Position
        Donut.transform.position = new Vector2(-0.381000012f, -0.666999996f);

        //Add all the components so that the Donut can be shot from the sling shot
        Donut.AddComponent<Rigidbody2D>();
        Donut.AddComponent<DonutControl>();
        Donut.AddComponent<SpringJoint2D>();
        Donut.GetComponent<CircleCollider2D>().enabled = true;
        Donut.GetComponent<SpringJoint2D>().connectedBody = GameObject.Find("Hook").GetComponent<Rigidbody2D>();
        Donut.GetComponent<SpringJoint2D>().frequency = 1.5f;
        SpawnDonuts ds = GameObject.Find("DonutSpawner").GetComponent<SpawnDonuts>();
        //Destroy the DontDestroyOnLoad so we can keep respawning the Donut
        Destroy(Donut.GetComponent<DontDestroyOnLoad>());
    }

    public void SetDonut(GameObject go) 
    {
        Donut = go;
    }
}


