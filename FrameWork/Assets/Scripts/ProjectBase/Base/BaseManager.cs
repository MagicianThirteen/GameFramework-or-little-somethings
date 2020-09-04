using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

/// <summary>
/// 单例模式基类
/// </summary>
public class BaseManager<T> where T:new()
{
    private static T instance;
    public static T GetInstance()
    {
        if (instance == null)
        {
            instance = new T();
        }
        return instance;
    }
}

/// <summary>
/// 让管理类继承单例模式基类
/// </summary>
public class GameManager : BaseManager<GameManager>
{
    
}

/// <summary>
/// 测试
/// </summary>
public class test
{
    void main()
    {
        GameManager.GetInstance();
    }
}