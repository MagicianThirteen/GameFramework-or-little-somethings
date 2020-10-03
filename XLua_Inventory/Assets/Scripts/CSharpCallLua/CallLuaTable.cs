using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CallLuaTable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");

        LuaTable table = LuaMgr.GetInstance().Global.Get<LuaTable>("testClass");
        Debug.Log(table.Get<int>("testInt"));
        Debug.Log(table.Get<bool>("testBool"));
        Debug.Log(table.Get<string>("testString"));
        Debug.Log(table.Get<float>("testFloat"));

        table.Get<LuaFunction>("testFun").Call();

    }

    
}
