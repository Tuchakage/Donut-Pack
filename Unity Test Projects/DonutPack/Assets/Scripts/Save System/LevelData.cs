using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The purpose of this script is to hold the Level Ratings of each level

public class LevelData : MonoBehaviour
{
    public Dictionary<string, int> levelRating = null;
    public Dictionary<string, int> isLevelComplete = null;
    // Start is called before the first frame update
    void Awake()
    {
        levelRating = new Dictionary<string, int>();
        isLevelComplete = new Dictionary<string, int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
