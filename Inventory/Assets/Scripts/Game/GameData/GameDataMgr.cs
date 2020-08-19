using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    //最终用字典存储items的信息
    private Dictionary<int, Item> itemInfos = new Dictionary<int, Item>();
    private static GameDataMgr _instance;
    public static GameDataMgr Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameDataMgr();

            }
            return _instance;
        }
    }

    /// <summary>
    /// 加载资源里的json文件
    /// </summary>
    public void Init()
    {
        string info = Resources.Load<TextAsset>("Json/itemInfo").text;
        Debug.Log(info);
        //根据json文件，解析成对应的数据结构，并存储
        Items items = JsonUtility.FromJson<Items>(info);
        Debug.Log(items.info.Count);
        //将解析好的list添加进字典中
        for(int i = 0; i < items.info.Count; i++)
        {
            itemInfos.Add(items.info[i].id, items.info[i]);
        }
    }

    /// <summary>
    /// 通过字典里的id获取具体道具信息
    /// </summary>
    /// <param name="id">道具id</param>
    /// <returns></returns>
    public Item GetItemInfo(int id)
    {
        if (itemInfos.ContainsKey(id))
        {
            return itemInfos[id];
        }
        return null;
        
    }


}

/// <summary>
/// 首先要有对应的数据结构去装这个json里的数据，这个是单个item的数据结构
/// </summary>
[System.Serializable]//序列化之后才能被unity自带的json解析出来
public class Item
{
    //注意这里的命名要和json里对应的键一摸一样
    public int id;
    public string name;
    public string icon;
    public int type;
    public int price;
    public string tips;
}


/// <summary>
/// 用来装items的数据结构
/// </summary>
public class Items
{
    //这里的info取名和json中的一样
    public List<Item> info;
}
