using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingConveyor : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private Vector3 _moveDir;
    [SerializeField] private List<GameObject> _onBelt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= _onBelt.Count - 1; i++)
        {
            _onBelt[i].GetComponent<Rigidbody2D>().velocity = _movingSpeed * Time.deltaTime * _moveDir;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _onBelt.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _onBelt.Remove(other.gameObject);
    }
}
