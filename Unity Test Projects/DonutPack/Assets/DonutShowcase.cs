using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutShowcase : MonoBehaviour
{
    public Transform _circleTransform;
    GameObject Donut;
    public Vector3 rotationDirection;
    public float speed;
    private float smooth;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Clapping");
        //Since the game is paused from the last scene, Unpause it
        Time.timeScale = 1f;
        Donut = GameObject.FindGameObjectWithTag("Donut");
        _circleTransform = Donut.GetComponent<Transform>();
        //Destroy Components
        Destroy(Donut.GetComponent<IcingCollision>());
        Destroy(Donut.GetComponent<BoxCollider2D>());
        //Set Position Of Donut
        Donut.transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Make the Donut Rotate
        smooth = Time.deltaTime * speed;
        _circleTransform.Rotate(rotationDirection * smooth);
    }
}
