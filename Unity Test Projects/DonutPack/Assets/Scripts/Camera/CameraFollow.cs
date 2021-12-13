using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTarget;

    [SerializeField] [Range(1,10)] private float _smoothSpeed;
    [SerializeField] private Vector3 _camOffset;

    private void FixedUpdate()
    {
        var desiredPos = _playerTarget.position + _camOffset;
        var _smoothPos = Vector3.Lerp(transform.position, desiredPos, _smoothSpeed * Time.fixedDeltaTime);
        transform.position = _smoothPos;
    }
}
