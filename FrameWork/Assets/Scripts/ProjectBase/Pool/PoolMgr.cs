using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PollData
{
    //用来分组游戏物体的父物体，与抽屉同名，fatherObj
    public GameObject fatherObj;
    //用来装游戏物体的容器,List<GameObject>
    public List<GameObject> poolList;
    //用来初始化抽屉的构造函数
    public PollData(GameObject pool,GameObject obj)
    {
        //创建父物体，把父物体放到pool空物体下,且与游戏物体同名，因为游戏物体是与抽屉同名的
        fatherObj = new GameObject(obj.name);
        fatherObj.transform.parent = pool.transform;
        obj.transform.parent = fatherObj.transform;
        obj.SetActive(false);
        poolList = new List<GameObject>() { obj };
    }
    //用来从抽屉中取物体的方法Get
    public GameObject Get()
    {
        GameObject obj = null;
        Debug.Log(poolList.Count);
        if (poolList.Count > 0)
        {
            //从缓存池中取一个
            obj = poolList[0];
            //取完后移除
            poolList.RemoveAt(0);
            //然后激活
            obj.SetActive(true);
            //设置其父对象
            obj.transform.parent = null;
        }
        return obj;
    }
    //用来从抽屉中放物体的方法push
    public void Push(GameObject obj)
    {
        //首先失活
        obj.SetActive(false);
        //把失活的物体放到fatherObj下
        obj.transform.parent = fatherObj.transform;
        //添加进poolList
        poolList.Add(obj);
    }
}





/// <summary>
/// 缓存池
/// </summary>
public class PoolMgr :BaseManager<PoolMgr>
{
    //缓存池
    Dictionary<string, PollData> poolDic = new Dictionary<string, PollData>();
    //空物体，用来整理失活的游戏物体
    private GameObject poolObj;


    /// <summary>
    /// 往衣柜里拿东西
    /// </summary>
    /// <param name="name">衣柜名字</param>
    /// <returns>游戏物体</returns>
    public GameObject GetObj(string name)
    {
        
        GameObject obj = null;

        if (poolDic.ContainsKey(name))
        {

            obj=poolDic[name].Get();
           
        }
        else
        {

            obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            //obj = Resources.Load<GameObject>(name);
            //GameObject.Instantiate(obj);
            obj.name = name;//这里不要用它的原始名字原始名字是cube（clone），这里用路径名作为游戏物体的名字，这样放到缓存池中也好对应名字放。
                            //这里的名字会变成Test/Cube(Clone)

            obj.SetActive(true);

        }
        return obj;
    }

    /// <summary>
    /// 往衣柜放东西
    /// </summary>
    /// <param name="name">衣柜名字</param>
    /// <param name="obj">衣柜里的东西</param>
    public void PushObj(string name,GameObject obj)
    {
        if (poolObj == null)
            poolObj = new GameObject("pool");

        if (!poolDic.ContainsKey(name))
        {
            
            poolDic.Add(name, new PollData(poolObj,obj));
            
        }
        else
        {
            poolDic[name].Push(obj);

        }
    }

    /// <summary>
    /// 切换场景时给外界调用的清空缓存池的方法
    /// </summary>
    public void ClearPool()
    {
        poolDic.Clear();
        poolObj = null;
    }
}
