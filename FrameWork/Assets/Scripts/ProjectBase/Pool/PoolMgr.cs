using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 缓存池
/// </summary>
public class PoolMgr : BaseManage<PoolMgr>
{
    //定义衣柜的容器
    Dictionary<string, List<GameObject>> poolDic = new Dictionary<string, List<GameObject>>();
    //定义缓存池借的行为
    public GameObject GetObj(string name)
    {
        //分两种情况，1.有这个抽屉和抽屉有东西2.抽屉没东西
        GameObject obj = null;
        if (poolDic.ContainsKey(name) && poolDic[name].Count > 0 )//当这里containskey写后面时，就会报错，因为找不到这个key
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
    //定义缓存池还的行为(需要知道还到哪个抽屉，还了什么物体）
    public void pushObj(string name,GameObject obj)
    {
        //还回来的时候失活
        obj.SetActive(false);
        //分两种情况：衣柜有这个抽屉，衣柜没有这个抽屉
        if (poolDic.ContainsKey(name))
        {
            poolDic[name].Add(obj);
        }
        else
        {
            poolDic.Add(name, new List<GameObject> { obj });
        }
    }
}
