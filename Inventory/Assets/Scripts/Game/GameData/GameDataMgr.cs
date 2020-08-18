﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
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
