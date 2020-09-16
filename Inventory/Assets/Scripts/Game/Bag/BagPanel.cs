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
    public Transform content;
    List<ItemCell> list = new List<ItemCell>();

    // Start is called before the first frame update
    void Start()
    {
        GetUI<Button>("Close_Img").onClick.AddListener(() =>{
            UIManager.GetInstance().ClosePanel("BagPanel");
        });

        GetUI<Toggle>("dg_img").onValueChanged.AddListener(ToggleValueChange);
        GetUI<Toggle>("zb_img").onValueChanged.AddListener(ToggleValueChange);
        GetUI<Toggle>("bs_img").onValueChanged.AddListener(ToggleValueChange);


    }

    public  void ToggleValueChange(bool value)
    {
        if (GetUI<Toggle>("dg_img").isOn)
        {
            ChangeType(E_Bag_Type.Item);

        }else if (GetUI<Toggle>("zb_img").isOn)
        {
            ChangeType(E_Bag_Type.equip);
        }
        else if (GetUI<Toggle>("bs_img"))
        {
            ChangeType(E_Bag_Type.Gem);
        }
    }

    private void ChangeType(E_Bag_Type type)
    {
        List<ItemInfo> tempInfo = GameDataMgr.playerInfo.items;
        switch (type)
        {
            case E_Bag_Type.equip:
                tempInfo = GameDataMgr.playerInfo.equips;
                break;
            case E_Bag_Type.Gem:
                tempInfo = GameDataMgr.playerInfo.gems;
                break;

        }

        for (int i = 0; i < list.Count; i++)
        {
            Destroy(list[i].gameObject);
        }

        list.Clear();
        for (int i = 0; i < tempInfo.Count; i++)
        {
            ItemCell cell = ResMgr.GetInstance().Load<GameObject>("UI/ItemCell").GetComponent<ItemCell>();
            cell.transform.parent = content;
            cell.InitItem(tempInfo[i]);
            list.Add(cell);
        }
    }
    


    
}
