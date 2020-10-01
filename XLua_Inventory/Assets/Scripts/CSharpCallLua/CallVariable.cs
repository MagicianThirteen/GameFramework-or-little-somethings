using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallVariable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");

        //获取Lua文件里的全局变量，要用到之前定义的属性，本质是luaenv.Global,获取到存储全局变量的表
        //这里获取变量的名字要与lua文件中的一致
        int i=LuaMgr.GetInstance().Global.Get<int>("testNumber");
        Debug.Log("testNumber:" + i);

        LuaMgr.GetInstance().Global.Set("testNumber", 13);
        int i3 = LuaMgr.GetInstance().Global.Get<int>("testNumber");
        Debug.Log("testNumber:" + i3);


        bool b = LuaMgr.GetInstance().Global.Get<bool>("testBool");
        Debug.Log("testBool:" + b);

        //这里用double装也可以，但是浪费
        float f = LuaMgr.GetInstance().Global.Get<float>("testFloat");
        Debug.Log("testFloat:" + f);

        string s = LuaMgr.GetInstance().Global.Get<string>("testString");
        Debug.Log("testString:" + s);
    }

   
}
