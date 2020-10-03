using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallLuaClass
{
    //在这个类中去声明lua中的table里的成员变量，且名字一定要一致！！！
    //权限要是公共的！！！！，不然如果私有和保护的没法赋值
    //这个自定义类中的成员可以更多或者更少，反正都会被忽略
    public int testInt;
    public bool testBool;
    public float testFloat;
    public string testString;

    //函数无参无返回值可以用unityaction来接
    public UnityAction testFun;
    //lua表中的表的名字与这里的要定义一致
    public CallLuaInClass testInClass;
}

//lua表中还有一个表（类），表中表里的成员名字也要与这里对应一致
public class CallLuaInClass
{
    public int testInInt;
}

public class CallClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");

        //注意用这种方式还是浅拷贝，改变这里的内容，不会改变lua表里的内容
        CallLuaClass clc = LuaMgr.GetInstance().Global.Get<CallLuaClass>("testClass");
        Debug.Log(clc.testInt);
        Debug.Log(clc.testBool);
        Debug.Log(clc.testFloat);
        Debug.Log(clc.testString);
        clc.testFun();
        Debug.Log(clc.testInClass.testInInt+"lua表中的表");

       
        
    }

    
}
