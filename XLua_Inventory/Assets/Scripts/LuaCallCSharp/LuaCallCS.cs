using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

#region 自定义类
//自定义类
public class Test
{
    public void Speak(string str)
    {
        Debug.Log("Test" + str);
    }
}

namespace CallCS
{
    public class Test1
    {
        public void Speak(string str)
        {
            Debug.Log("Test1" + str);
        }
    }
}
#endregion 

#region 自定义枚举
//自定义枚举
public enum Enum_StateEnum
{
    idle1,
    walk2,
    run3,
}
#endregion


#region 数组，list，字典
public class Callarray
{
    public int[] arr = new int[5] { 1, 2, 3, 4, 5 };
    public List<int> list = new List<int>();
    public Dictionary<int, string> dic = new Dictionary<int, string>();
    public void Test()
    {
        
    }
}
#endregion


#region 拓展方法
/// <summary>
/// 想要在lua中使用拓展方法，一定要在工具类加特性
/// 建议lua中要使用的类都加上该特性，可以提升性能
/// 如果不加该特性，除了拓展方法对应的类，其它的类虽然不会报错
/// 但是lua是通过反射机制去调用c#类 效率较低
/// </summary>
[LuaCallCSharp]
public static class Tools
{
    //Testf的拓展方法
    public static void Move(this Testf obj)
    {
        Debug.Log(obj.name + "is Moving");
    }

}



public class Testf
{
    public string name = "wo";
    public void Speak(string str)
    {
        Debug.Log("wo speak " + str);
    }
    public static void Eat()
    {
        Debug.Log("eat something");
    }
}

#endregion


#region ref和out
public class RefOut
{
    public int RefFun(int a,ref int b,ref int c,int d)
    {
        b = a + d;
        c = a - d;
        return 100;
    }

    public int OutFun(int a,out int b,out int c,int d)
    {
        b = a;
        c = d;
        return 200;
    }

    public int RefOutFun(int a,out int b,ref int c)
    {
        b = a * 10;
        c = a * 20;
        return 300;
    }
}


#endregion

#region 函数重载
public class CallFun
{
    public int Calc()
    {
        return 100;
    }

    public int Calc(int a,int b)
    {
        return a + b;
    }

    public int Calc(int a)
    {
        return a;
    }

    public float Calc(float a)
    {
        return a;
    }
}
#endregion


#region 委托和事件
#endregion
public class LuaCallCS : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
