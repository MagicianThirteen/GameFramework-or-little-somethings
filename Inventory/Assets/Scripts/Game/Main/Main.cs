using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameDataMgr.Instance.Init();
        //Debug.Log(GameDataMgr.Instance.GetItemInfo(1).name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
