using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 格子脚本
/// </summary>
public class ItemCell :BasePanel
{
    private ItemInfo itemInfo;

    private void Start()
    {
        //给图片添加事件监听
        EventTrigger trigger=GetUI<Image>("imgIcon").gameObject.AddComponent<EventTrigger>();
        //声明一个鼠标进入事件，鼠标移出事件
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener(EnterItemCell);
        trigger.triggers.Add(entry);//还要添加进事件

        EventTrigger.Entry exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerExit;
        exit.callback.AddListener(ExitItemCell);
        trigger.triggers.Add(exit);//还要添加进事件
        


    }

    //给鼠标点击和移除事件编写对应逻辑（显示面板，将面板的位置移到图片的中心点，然后设置提示面板的数据）
    private void EnterItemCell(BaseEventData data)
    {
       
        UIManager.GetInstance().ShowPanel<TipsPanel>("TipsPanel", UI_Layer.top, (panel) =>
        {
            panel.transform.position = GetUI<Image>("imgIcon").gameObject.transform.position;
            panel.InitTipsInfo(itemInfo);
        });
    }

    private void ExitItemCell(BaseEventData data)
    {
       
        UIManager.GetInstance().ClosePanel("TipsPanel");
    }

    public void InitItem(ItemInfo info)
    {
        this.itemInfo = info;
        Item itemData = GameDataMgr.GetInstance().GetItemInfo(info.id);//通过id找到该物品的详细信息
        Sprite icon= ResMgr.GetInstance().Load<Sprite>("Icon/" + itemData.icon);//找到该物品对应的图片
        GetUI<Image>("imgIcon").sprite = icon;//替换当前的图片
        GetUI<Text>("txtNum").text = info.num.ToString();//给物品数量赋值

    }

    
}
