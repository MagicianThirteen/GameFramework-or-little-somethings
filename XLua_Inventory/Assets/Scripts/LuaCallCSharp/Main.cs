using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// lua没有办法直接访问c#，一定是先从c#调用lua脚本后
/// 才把核心逻辑交给lua编写
/// mian相当于是入口一样
/// </summary>
public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
