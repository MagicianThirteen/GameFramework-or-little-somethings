using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : BasePanel
{
    // Start is called before the first frame update
    void Start()
    {
        GetUI<Button>("RoleButton").onClick.AddListener(()=> {
            UIManager.GetInstance().ShowPanel<BagPanel>("BagPanel");
        });
    }

    public override void Show()
    {
        base.Show();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
