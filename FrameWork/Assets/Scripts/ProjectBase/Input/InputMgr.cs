using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 输入控制 管理
/// </summary>
public class InputMgr : BaseManager<InputMgr>
{
    private bool isStart=true;
    //控制输入要不要开启，比如剧情开启的时候，输入控制就无效了
    public void InputOpenOrNotCheck(bool isOpen)
    {
        isStart = isOpen;
        Debug.Log(isStart);
    }

    public InputMgr()
    {
        //让输入事件在update中检测更新
        MonoMgr.GetInstance().AddUpdateEventsListener(InputUpdate);
    }

    void InputUpdate()
    {
        if (!isStart)
            return;
        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.D);
        
    }

    void CheckKeyCode(KeyCode key)
    {
        if (Input.GetKey(key))
        {
            //利用事件中心模块，触发事件
            EventCenter.GetInstance().EventTrigger("EnterKey", key);
        }
    }
}
