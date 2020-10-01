using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;//要添加这个命名空间
using System.IO;

public class LuaEnvTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        LuaMgr.GetInstance().Init();
        //LuaMgr.GetInstance().DoString("require('Main')");
        LuaMgr.GetInstance().DoLuaFile("Main");
    }

   
}
