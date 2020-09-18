using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 用来显示格子信息的提示面板
/// </summary>
public class TipsPanel : BasePanel

{
    public void InitTipsInfo(ItemInfo info)
    {
        Item itemData = GameDataMgr.GetInstance().GetItemInfo(info.id);//通过id找到该物品的详细信息
        Sprite icon = ResMgr.GetInstance().Load<Sprite>("Icon/" + itemData.icon);//找到该物品对应的图片
        GetUI<Image>("imgIcon").sprite = icon;//替换当前的图片
        GetUI<Text>("txtNum").text = "数量："+info.num.ToString();//给物品数量赋值
        //得到物品的详细描述
        GetUI<Text>("txtTips").text = "描述：" + itemData.tips;
        //得到物品名字
        GetUI<Text>("txtName").text = "名字：" + itemData.name;
    }
}
