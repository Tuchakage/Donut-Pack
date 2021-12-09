using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutCollision : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] packets;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GameObject.Find("ParentPacket").GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = packets[0];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Donut") 
        {
            Debug.Log("Ok");
            spriteRenderer.sprite = packets[1];
            //Make the Package fall down quicker
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3f;
            //Make the Donut invisible
            col.gameObject.SetActive(false);
            //Increment Score
            ScoreManager.IncrementScore(1);
            //Spawn Another Donut In and delete the one that collided with the Package
            StartCoroutine(RespawnDonut(col.gameObject));
            Destroy(this.gameObject, 5f);
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
