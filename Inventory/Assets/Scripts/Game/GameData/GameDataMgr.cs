using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataMgr:BaseManager<GameDataMgr>
{
    //用来存储玩家信息文件的路径
    private static string playerInfo_url = Application.persistentDataPath + "/PlayerInfo.txt";
    //玩家对象
    public static player playerInfo;
 
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
    /// 初始化道具信息和玩家信息
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

        //从本地文件读取玩家信息，如果没有就创建
        if (File.Exists(playerInfo_url))
        {
            //读取文件的所有字节数组，转换成字符串json，然后还原成player对象
            byte[] bytes = File.ReadAllBytes(playerInfo_url);
            string json = System.Text.Encoding.UTF8.GetString(bytes);
            playerInfo = JsonUtility.FromJson<player>(json);
            //测试有没有读对，打印下玩家名字
            Debug.Log(playerInfo.name);
            
        }
        else
        {
            //没有这个文件，就先创建player对象(对象的构造函数会给玩家信息赋值一个初始值，然后转成json字符串，通过字节数组存入文件中
            playerInfo = new player();
            SavePlayerInfo();
            //测试打印下这个路径，查看下文件有没有写入成功
            Debug.Log(playerInfo_url);

        }
        
    }

    /// <summary>
    /// 可以把存储json文件的部分提取成一个公共方法，方便更新玩家信息
    /// </summary>
    public static void SavePlayerInfo()
    {
        string json = JsonUtility.ToJson(playerInfo);
        File.WriteAllBytes(playerInfo_url, System.Text.Encoding.UTF8.GetBytes(json));
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
/// 玩家信息数据结构
/// </summary>
public class player
{
    public string name;
    public int lev;
    public int money;
    public int gem;
    public int pro;
    public List<ItemInfo> items;
    public List<ItemInfo> equips;
    public List<ItemInfo> gems;

    //给玩家构造函数初始化一个玩家信息
    public player(){
        name = "root";
        lev = 99;
        money = 999;
        gem = 0;
        pro = 99;
        items = new List<ItemInfo>() { new ItemInfo() {id= 2,num=1} };
        equips = new List<ItemInfo>() { new ItemInfo() { id = 1, num = 3 } };
        gems = new List<ItemInfo>() {  };

    }


   
}



/// <summary>
/// 玩家持有的道具信息的数据结构
/// </summary>
[System.Serializable]//为的是unity自带json读取时能够识别，要序列化的是json里的数据，而不是容器list
public class ItemInfo
{
    public int id;
    public int num;
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
