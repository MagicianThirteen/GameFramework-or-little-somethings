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
    /// 往衣柜里拿东西
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

            obj = Resources.Load<GameObject>(name);
            obj.name = name;//这里不要用它的原始名字原始名字是cube（clone），这里用路径名作为游戏物体的名字，这样放到缓存池中也好对应名字放。
                            //这里的名字会变成Test/Cube(Clone)
            GameObject.Instantiate(obj);
            

        }
        
        obj.SetActive(true);
        return obj;
    }

    /// <summary>
    /// 往衣柜放东西
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
