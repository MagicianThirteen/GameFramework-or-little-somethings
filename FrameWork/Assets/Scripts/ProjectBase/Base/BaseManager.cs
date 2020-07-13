using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;



//这个写法错误，没有私有化构造，小游戏可以用
public class BaseManage<T> where T:new()
{
    private static T instance;
  
    public static T GetInstance()
    {
        if (instance == null)
            instance = new T();
        return instance;
    }
    

}


