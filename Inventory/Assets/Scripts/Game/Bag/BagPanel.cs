using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum E_Bag_Type
{
    Item,
    equip,
    Gem,
}


public class BagPanel : BasePanel
{
    List<ItemInfo> playerItemInfo = new List<ItemInfo>();
    public Transform content;


    // Start is called before the first frame update
    void Start()
    {
        GetUI<Button>("Close_Img").onClick.AddListener(() =>{
            UIManager.GetInstance().ClosePanel("BagPanel");
        });
        //给这三个页签添加函数监听事件
        GetUI<Toggle>("dg_img").onValueChanged.AddListener(OnValueChange);
        GetUI<Toggle>("zb_img").onValueChanged.AddListener(OnValueChange);
        GetUI<Toggle>("bs_img").onValueChanged.AddListener(OnValueChange);

        ChangeType(E_Bag_Type.Item);
    }

    void OnValueChange(bool value)
    {
        if (GetUI<Toggle>("dg_img").isOn)
        {
            ChangeType(E_Bag_Type.Item);
        }else if (GetUI<Toggle>("zb_img").isOn)
        {
            ChangeType(E_Bag_Type.equip);
        }
        else if (GetUI<Toggle>("bs_img").isOn)
        {
            ChangeType(E_Bag_Type.Gem);
        }
    }

    void ChangeType(E_Bag_Type type)
    {
        playerItemInfo = GameDataMgr.playerInfo.items;
        switch (type)
        {
           
            case E_Bag_Type.equip:
                playerItemInfo = GameDataMgr.playerInfo.equips;
                break;
            case E_Bag_Type.Gem:
                playerItemInfo = GameDataMgr.playerInfo.gems;
                break;
           
        }
        //清空背包
        playerItemInfo.Clear();
        //循环遍历将对应物品添加到content下。
        for(int i = 0; i < playerItemInfo.Count; i++)
        {
            GameObject cellobj = ResMgr.GetInstance().Load<GameObject>("UI/ItemCell");
            ItemCell cell=cellobj.GetComponent<ItemCell>();
            cell.InitItem(playerItemInfo[i]);
            cell.transform.parent = content;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
