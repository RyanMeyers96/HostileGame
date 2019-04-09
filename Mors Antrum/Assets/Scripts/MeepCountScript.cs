using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeepCountScript : MonoBehaviour
{
    public int meepCount;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        meepCount = 0;
    }

    
    void Update()
    {
        
    }
}
