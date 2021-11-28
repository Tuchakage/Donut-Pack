using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{

    [SerializeField] private SwipeControls sc;
    [SerializeField] private Transform _player;

    private void Start()
    {
        //grab components of player transform and controller
        _player = GameObject.Find("DoughBall").GetComponent<Transform>();
        sc = GameObject.Find("TouchManager").GetComponent<SwipeControls>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //If the player collides with the rocks change speed and scale of doughball
        if (other.gameObject.CompareTag("Player"))
        {
            if (sc._playerSpeed >= 7 && _player.transform.localScale.x > 1)
            {
                sc._rb.velocity = new Vector2(0, 0);
                sc._playerSpeed = 3.5f;
                _player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }
    }
}
