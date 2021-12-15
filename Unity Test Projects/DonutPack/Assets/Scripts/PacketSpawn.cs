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
        int rand = Random.Range(0, 2);
        Debug.Log(rand + " Position");
        if (rand == 0)
        {
            randX = Random.Range(-14, -6);
        }
        else 
        {
            randX = Random.Range(6, 14);
        }
        
        whereToSpawn = new Vector2(randX, transform.position.y);
        GameObject clonedPacket = Instantiate(packetSpawnObject, whereToSpawn, Quaternion.identity);
        clonedPacket.GetComponent<Animator>();
        clonedPacket.transform.parent = transform;
    }
    
    
}
