using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesPanel : BasePanel
{
    // Start is called before the first frame update
    //TesPanel testPanel = null;
    void Start()
    {
        ////GetUI<Button>("Button1").onClick.AddListener(ClickButton1);
        //UIManager.GetInstance().ShowPanel<TesPanel>("TestPanel", UI_Layer.top,(panel)=> {
            
        //    testPanel = panel;

        //    testPanel.InitData();           
            
        //});
    }
    public void InitData()
    {
        Debug.Log("打开面板后初始化数据");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickButton1()
    {
        Debug.Log("ENTER BUTTON1");
    }
}
