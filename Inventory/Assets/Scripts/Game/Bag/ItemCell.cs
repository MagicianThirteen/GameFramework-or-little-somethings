﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell :BasePanel
{
    private ItemInfo itemInfo;

    public void InitItem(ItemInfo info)
    {
        this.itemInfo = info;
        Item itemData = GameDataMgr.GetInstance().GetItemInfo(info.id);
        Sprite icon= ResMgr.GetInstance().Load<Sprite>("Icon/" + itemData.icon);
        GetUI<Image>("imgIcon").sprite = icon;
        GetUI<Text>("txtNum").text = info.num.ToString();
    }

    
}