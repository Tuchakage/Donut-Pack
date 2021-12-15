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
        if (currentSceneName == "Packing" || currentSceneName == "Packing Practice")
        {
            //Find the Donut Object and save it
            Donut = GameObject.FindGameObjectWithTag("Donut");
            Donut.name = "Pretend DonutPrefab(Used To Spawn in multiple of this Donut";
            //Spawn The Donut far away from scene
            Donut.transform.position = new Vector2(1000, 1000);
            SpawnDonuts ds = GameObject.Find("DonutSpawner").GetComponent<SpawnDonuts>();
            ds.NextDonut = Donut;
            //Spawn in another Donut
            ds.SpawnDonut();
  
        }
        else if (currentSceneName == "DonutShowcase" || currentSceneName == "DonutShowcase Practice") 
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


