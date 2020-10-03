using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

//接口只能用属性去接lua表里的成员，名字也要与lua中定义的一致,
//当接口中增加或者减少属性时，一定要清空生成的代码，然后再重新生成一遍，这个接口才能用，多的或者少的属性依旧会被忽略
//用接口接，是引用拷贝！！！！！，改了值，lua中的东西也会改变
[CSharpCallLua]
public interface ICallLuaClass
{
    
    int testInt
    {
        get;
        set;
    }

    bool testBool
    {
        get;
        set;
    }

    float testFloat
    {
        get;
        set;
    }

    string testString
    {
        get;
        set;
    }

    UnityAction testFun
    {
        get;
        set;
    }


}
public class CallInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");

        ICallLuaClass icc = LuaMgr.GetInstance().Global.Get<ICallLuaClass>("testClass");
        Debug.Log(icc.testInt);
        Debug.Log(icc.testBool);
        Debug.Log(icc.testFloat);
        Debug.Log(icc.testString);
        icc.testFun();
    }



}
