using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject rocks;
    [SerializeField] private float randX;
    [SerializeField] private Vector2 spawnPoint;
    [SerializeField] private float spawnRate;
    [SerializeField] private float nextSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-10f, 10f);
            spawnPoint = new Vector2(randX, transform.position.y);
            GameObject clone = Instantiate(rocks, spawnPoint, Quaternion.identity);
            Destroy(clone, 6f);
        }
    }
}
