﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TestPool();
    }

    void TestPool()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            PoolMgr.GetInstance().GetObj("Test/Cube",(o)=> {
                Debug.Log("create cube");
            });
        }
        if (Input.GetMouseButtonDown(1))
        {
            PoolMgr.GetInstance().GetObj("Test/Sphere",(o)=> {
                Debug.Log("create sphere");
            });
        }
    }
}
