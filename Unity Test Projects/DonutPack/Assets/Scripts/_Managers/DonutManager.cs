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
        currentSceneName = currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Packing")
        {
            //Find the Donut Object and save it
            Donut = GameObject.FindGameObjectWithTag("Donut");
            //Change Scale
            Donut.transform.localScale = new Vector3(0.140325993f, 0.140325993f, 0.140325993f);
            //Rotate Donut
            Donut.transform.rotation = Quaternion.Euler(0, 0, 0);
            //Change Position
            Donut.transform.position = new Vector2(0.730080068f, -1.10299993f);

            //Add all the components so that the Donut can be shot from the sling shot
            Donut.AddComponent<Rigidbody2D>();
            Donut.AddComponent<SpringJoint2D>();
            Donut.GetComponent<CircleCollider2D>().enabled = true;
            Donut.GetComponent<SpringJoint2D>().connectedBody = GameObject.Find("Hook").GetComponent<Rigidbody2D>();
            Donut.GetComponent<SpringJoint2D>().frequency = 1.5f;
            SpawnDonuts ds = GameObject.Find("DonutSpawner").GetComponent<SpawnDonuts>();
            //Destroy the DontDestroyOnLoad so we can keep respawning the Donut
            Destroy(Donut.GetComponent<DontDestroyOnLoad>());
        }
        else if (currentSceneName == "DonutShowcase") 
        {
            //Find the Donut Object and save it
            Donut = GameObject.FindGameObjectWithTag("Donut");
            //Change Scale
            Donut.transform.localScale = new Vector3(0.138480365f, 0.169003621f, 1.25095189f);
            //Rotate Donut
            Donut.transform.rotation = Quaternion.Euler(0, 0, 0);
            //Change Position
            Donut.transform.position = new Vector2(0.13f, 1.3f);
        }

    }

    public void SetDonut(GameObject go) 
    {
        Donut = go;
    }
}


