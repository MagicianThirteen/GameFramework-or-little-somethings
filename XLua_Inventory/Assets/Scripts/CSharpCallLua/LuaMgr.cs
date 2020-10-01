using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

/// <summary>
/// 保证解析器的唯一性，先继承单例模式，也提供些解析器的函数
/// </summary>
public class LuaMgr :BaseManager<LuaMgr>
{
    //定义解析器对象
    private LuaEnv luaEnv;

    /// <summary>
    /// 声明了一个属性，得到lua中得_G
    /// </summary>
    public LuaTable Global
    {
        get
        {
            return luaEnv.Global;
        }
    }

    //初始化解析器
    public void Init()
    {
        if (luaEnv != null)
            return;
        luaEnv = new LuaEnv();
        //添加自定义加载器
        luaEnv.AddLoader(MyCustomLoader);
        //添加自定义的ab包加载器
        luaEnv.AddLoader(MyCustomABLoader);

    }

    /// <summary>
    /// 普通加载器
    /// </summary>
    /// <param name="filepath">lua文件名</param>
    /// <returns></returns>
    private byte[] MyCustomLoader(ref string filepath)
    {
        
        string path = Application.dataPath + "/Lua/" + filepath + ".lua";
       
        
        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else
        {
            Debug.Log("MyCustomLoader加载器加载lua文件失败");
            return null;
        }

    }

    /// <summary>
    /// 用ab包的方式加载lua文件的加载器
    /// </summary>
    /// <param name="filepath">lua文件名</param>
    /// <returns></returns>
    private byte[] MyCustomABLoader(ref string filepath)
    {
        Debug.Log("用ab包加载lua文件");
        //找到ab包的路径
        string path = Application.streamingAssetsPath + "/lua";
        //加载含有lua文件的ab包
        AssetBundle luaab = AssetBundle.LoadFromFile(path);
        //加载ab包里的lua文件，读成txt，这里注意，因为打包的时候后缀是.lua.txt所以文件名还要加上个.lua
        TextAsset txt = luaab.LoadAsset<TextAsset>(filepath + ".lua");
        return txt.bytes;
        
    }

    //执行lua文件
    public void DoString(string str)
    {
        if (luaEnv == null)
        {
            Debug.Log("lua解析器未初始化");
            return;
        }
        luaEnv.DoString(str);
    }

    /// <summary>
    /// 拼接require不用写那么多次require
    /// </summary>
    /// <param name="filepath">lua文件名</param>
    public void DoLuaFile(string filepath)
    {
        string str = string.Format("require('{0}')", filepath);
        DoString(str);
    }

    //清空垃圾
    public void Tick()
    {
        if (luaEnv == null)
        {
            Debug.Log("lua解析器未初始化");
            return;
        }
        luaEnv.Tick();
    }
    //销毁解析器
    public void Dispose()
    {
        if (luaEnv == null)
        {
            Debug.Log("lua解析器未初始化");
            return;
        }
        luaEnv.Dispose();
        luaEnv = null;
    }
}
