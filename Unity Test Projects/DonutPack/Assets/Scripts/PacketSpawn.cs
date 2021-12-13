using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketSpawn : MonoBehaviour
{
    public GameObject packetSpawnObject;
    public float randX;
    public Vector2 whereToSpawn;
    public float spawnRate;
    public float nextSpawn;
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = packetSpawnObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            SpawnPacket();
        }
    }

    public void SpawnPacket()
    {
        nextSpawn = Time.time + spawnRate;
        randX = Random.Range(-8, 8);
        whereToSpawn = new Vector2(randX, transform.position.y);
        GameObject clonedPacket = Instantiate(packetSpawnObject, whereToSpawn, Quaternion.identity);
        clonedPacket.GetComponent<Animator>();
        clonedPacket.transform.parent = transform;
    }
    
    
}
