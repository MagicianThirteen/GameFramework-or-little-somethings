using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener("MosterDead",PlayerAddCoin);
    }

    private void PlayerAddCoin(object info)
    {
        Debug.Log("杀死怪物后，玩家会得到金币" + (info as TestEvent).MosterName);
        // throw new NotImplementedException();
        //不知道为什么，写了这个就会报无法应用的错……
    }



    private void OnDestroy()
    {
        //当玩家死亡时，移除该监听
        EventCenter.GetInstance().RemoveEventListener("MosterDead",PlayerAddCoin);
    }
}
