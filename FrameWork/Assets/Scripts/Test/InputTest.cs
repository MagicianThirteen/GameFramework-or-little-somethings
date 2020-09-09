using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //开启输入
        InputMgr.GetInstance().InputOpenOrNotCheck(true);
        //按下键的处理
        EventCenter.GetInstance().AddEventListener<InputTest>("EnterKey", EnterKey);
    }


    public void EnterKey(object Key)
    {
        //keycode是枚举，不要强转
        KeyCode keyCode = (KeyCode)Key;
        switch (keyCode)
        {
            case KeyCode.W:
                Debug.Log("往上");
                break;
            case KeyCode.S:
                Debug.Log("往下");
                break;
            case KeyCode.A:
                Debug.Log("往左");
                break;
            case KeyCode.D:
                Debug.Log("往右");
                break;
        }
    }
}
