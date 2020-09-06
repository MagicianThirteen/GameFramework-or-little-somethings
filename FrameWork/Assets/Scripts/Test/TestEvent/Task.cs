using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener("MosterDead", TaskComplete);
    }

    private void TaskComplete(object info)
    {
        Debug.Log("杀死怪物后，任务完成" + (info as TestEvent).MosterName);
        //throw new NotImplementedException();
    }

    
}
