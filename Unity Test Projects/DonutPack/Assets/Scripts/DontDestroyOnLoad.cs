using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{

    public static DontDestroyOnLoad Instance
    {
        get
        {
            return instance;
        }
    }

    private static DontDestroyOnLoad instance = null;

    void Awake()
    {
        //if (instance)
        //{
        //    Debug.Log("already an instance so destroying new one");
        //    DestroyImmediate(gameObject);
        //    return;

        //}

        //instance = this;

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
