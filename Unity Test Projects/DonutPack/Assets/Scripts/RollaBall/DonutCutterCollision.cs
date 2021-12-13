using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutCutterCollision : MonoBehaviour
{
    [SerializeField] private SwipeControlsNew sc;
    [SerializeField] private Transform player;    
    [SerializeField] private LevelChanger lc;
    
    // Start is called before the first frame update
    void Start()
    {
        //grab components of player transform and controller
        player = GameObject.Find("DoughBall").GetComponent<Transform>();
        sc = GameObject.Find("TouchManager").GetComponent<SwipeControlsNew>();
        lc = GameObject.Find("GameController").GetComponent<LevelChanger>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sc._rb.velocity = new Vector2(0f, 0f);
            sc._playerSpeed = 0f;
            lc.ShowLosingScreen();
            Destroy(other, 2f);
        }
    }
}
