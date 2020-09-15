using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell :BagPanel
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitItem(ItemInfo itemInfo)
    {
        Sprite icon = GetUI<Image>("imgIcon").sprite;
        Text numtxt = GetUI<Text>("txtNum");
        Item item= GameDataMgr.GetInstance().GetItemInfo(itemInfo.id);
        icon=ResMgr.GetInstance().Load<Sprite>("Icon/" + itemInfo.id);
        numtxt.text = itemInfo.num.ToString();

       
    }
}
