using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;



//这个写法错误，没有私有化构造，小游戏可以用
public class BaseManage<T> where T:new()
{
    private static T instance;
    private BaseManage()
    {

    }
    public static T GetInstance()
    {
        if (instance == null)
            instance = new T();
        return instance;
    }
    

}


////加了线程安全和构造私有的写法
//public class DyhSingleton<T> where T : class
//{
//    private static T instance;
//    private static object initLock = new object();
//    public static T GetInstance()
//    {
//        if (instance == null)
//            CreateInstance();

//        return instance;
//    }
//    private static void CreateInstance()
//    {
//        lock (initLock)
//        {
//            if (instance == null)
//            {
//                Type t = typeof(T);

//                // Ensure there are no public constructors...
//                // 这里确保没有其它的public构造函数了，既没有可以通过其它方法new这个类
//                ConstructorInfo[] ctors = t.GetConstructors();
//                if (ctors.Length > 0)
//                {
//                    throw new InvalidOperationException(String.Format("{0} has at least one accesible ctor making it impossibleto enforce DyhSingleton behaviour", t.Name));
//                }
//                // Create an instance via the private constructor
//                instance = (T)Activator.CreateInstance(t, true);
//            }
//        }
//    }
//}

