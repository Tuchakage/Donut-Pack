using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRot : MonoBehaviour
{
    public Transform _circleTransform;

    public Vector3 rotationDirection;
    public float durationTime;
    private float smooth;

    // Start is called before the first frame update
    void Start()
    {
        _circleTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.sqrMagnitude >= 25)
        {
            Debug.Log("Rotating");
            smooth = Time.deltaTime * durationTime;
            _circleTransform.Rotate(rotationDirection * smooth);
        }

    }
}
