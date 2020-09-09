using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ohter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.GetInstance().AddEventListener<TestEvent>("MosterDead", DoSomethingOhters);
    }

    private void DoSomethingOhters(TestEvent info)
    {
        Debug.Log("杀死怪物后，还要做些别的" + info.MosterName);
    
       // throw new NotImplementedException();
      
    }

   
        
}
