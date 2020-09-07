﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这个是挂到物体上的测试放入缓存池消失用的。延迟1秒执行
/// </summary>
public class DelayPush : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("Push", 1);
    }

    void Push()
    {
        PoolMgr.GetInstance().PushObj(this.gameObject.name, this.gameObject);
        
    }
}