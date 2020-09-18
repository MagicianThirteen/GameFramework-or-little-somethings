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

/// <summary>
/// 背包脚本
/// </summary>
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

    public override void Show()
    {
        base.Show();
        ChangeType(E_Bag_Type.Item);
    }
    /// <summary>
    /// 根据点击不同的toggle，且换不同的数据
    /// </summary>
    /// <param name="value"></param>
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

        //先销毁，再清空
        for (int i = 0; i < list.Count; i++)
        {
            Destroy(list[i].gameObject);
        }

        list.Clear();
        for (int i = 0; i < tempInfo.Count; i++)
        {
            GameObject itemCellObj = ResMgr.GetInstance().Load<GameObject>("UI/ItemCell");//获取实例化好的格子物体
        
            ItemCell cell = itemCellObj.GetComponent<ItemCell>();//获取格子上的脚本
       
            cell.transform.SetParent(content);//设置父对象
            cell.transform.localScale = new Vector3(1, 1, 1);//设置大小
     
            cell.InitItem(tempInfo[i]);//给格子数据初始化
            list.Add(cell);//添加进list，方便下次显示
        }
    }
    


    
}
