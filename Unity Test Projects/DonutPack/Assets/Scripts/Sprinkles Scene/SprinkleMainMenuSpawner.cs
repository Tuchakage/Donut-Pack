using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinkleMainMenuSpawner : MonoBehaviour
{
    public GameObject packetSpawnObject;
    public float randX;
    public Vector2 whereToSpawn;
    public float spawnRate;
    public float nextSpawn;
    public float timeToDestroy;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            SpawnSprinkles();
        }
    }

    public void SpawnSprinkles()
    {
        nextSpawn = Time.time + spawnRate;
        randX = Random.Range(-14, 14);
        whereToSpawn = new Vector2(randX, transform.position.y);
        GameObject clonedPacket = Instantiate(packetSpawnObject, whereToSpawn, Quaternion.identity);
        clonedPacket.transform.parent = transform;
        Destroy(clonedPacket, timeToDestroy);
    }

}
