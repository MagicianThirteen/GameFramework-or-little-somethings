using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 缓存池
/// </summary>
public class PoolMgr :BaseManager<PoolMgr>
{

    Dictionary<string, List<GameObject>> poolDic = new Dictionary<string, List<GameObject>>();

    /// <summary>
    /// 往衣柜里放东西
    /// </summary>
    /// <param name="name">衣柜名字</param>
    /// <returns>游戏物体</returns>
    public GameObject GetObj(string name)
    {
        GameObject obj = null;
        if (poolDic.ContainsKey(name) && poolDic[name].Count > 0)
        {
            obj = poolDic[name][0];
            poolDic[name].RemoveAt(0);
        }
        else
        {
            obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
        }
        
        obj.SetActive(true);
        return obj;
    }

    /// <summary>
    /// 往衣柜添加东西
    /// </summary>
    /// <param name="name">衣柜名字</param>
    /// <param name="obj">衣柜里的东西</param>
    public void PushObj(string name,GameObject obj)
    {
        obj.SetActive(false);
        if (!poolDic.ContainsKey(name))
        {
            poolDic.Add(name, new List<GameObject>() { obj});
        }
        else
        {
            poolDic[name].Add(obj);
        }
    }
}
