using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTest : MonoBehaviour
{
    // Start is called before the first frame update
    TesPanel testPanel = null;
    void Start()
    {
        //GetUI<Button>("Button1").onClick.AddListener(ClickButton1);
        UIManager.GetInstance().ShowPanel<TesPanel>("TestPanel", UI_Layer.top, (panel) => {

            testPanel = panel;

            testPanel.InitData();
            Invoke("DelayHide", 3f);


        });
    }

    private void DelayHide()
    {
        UIManager.GetInstance().ClosePanel("TestPanel");
    }
   
}
