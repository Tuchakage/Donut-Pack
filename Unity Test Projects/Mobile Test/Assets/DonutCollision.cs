using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Donut") 
        {
            Debug.Log("Ok");
            //Make the Package fall down quicker
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3f;
            //Make the Donut invisible
            col.gameObject.SetActive(false);
            //Spawn Another Donut In and delete the one that collided with the Package
            StartCoroutine(RespawnDonut(col.gameObject));
        }
    }

    IEnumerator RespawnDonut(GameObject go) 
    {
        //Gives the Donut enough time to be launched
        yield return new WaitForSeconds(0.5f);
        //Respawn Donut
        go.GetComponent<DonutControl>().SpawnAfterRelease();
    }
}
