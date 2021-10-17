using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeIndicator : MonoBehaviour
{
    GameManager gm;
    public Text timertext;
    public float lifetime = 0.6f;
    public float minDist = 2f;
    public float maxDist = 3f;

    private Vector3 iniPos;
    private Vector3 targetPos;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //Makes the Timer pop up look at the camera
        transform.LookAt(2 * transform.position - Camera.main.transform.position);

        //Direction of where the timer pop up text will move
        float direction = Random.rotation.eulerAngles.z;
        //The initial position of the timer pop up text
        iniPos = transform.position;
        //Distance the timer pop up text will go
        float dist = Random.Range(minDist, maxDist);
        //The target position the timer pop up text needs to go to
        targetPos = iniPos + (Quaternion.Euler(0, 0, direction) * new Vector3(dist, dist, 0f));
        //Finds the GameManager script in the scene
        gm = GameObject.Find("GameplayController").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //Timer starts counting
        timer += Time.deltaTime;

        //The fade animation will start playing depending on half of the lifetime value
        float fraction = lifetime / 2f;

        if (timer > lifetime)
        {
            //Depending of the life time value the timer pop up text will dissapear
            Destroy(gameObject);
        }
        else if (timer > fraction) 
        {
            //Fade out animation for the timer pop up text
            timertext.color = Color.Lerp(timertext.color, Color.clear, (timer - fraction) / (lifetime - fraction));
        }

        //Timer pop up text will move from the initial Position and the target Position
        transform.localPosition = Vector3.Lerp(iniPos, targetPos, Mathf.Sin(timer / lifetime));
        //Timer pop up text will scale
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Sin(timer / lifetime));
    }

    public void SetTimeText(float time, bool isLosingTime) 
    {
        //If the timer is being extended
        if (!isLosingTime)
        {
            //Turns the number value in the time variable into a string with a + sign infront of it 
            timertext.text = "+ " + time.ToString() + "s";
        }
        else //If the timer is being reduced
        {
            //Turns the number value in the time variable into a string with a - sign infront of it 
            timertext.text = "- " + time.ToString() + "s";
        }

    }
}
