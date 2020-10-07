using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//自定义类
public class Test
{
    public void Speak(string str)
    {
        Debug.Log("Test" + str);
    }
}

namespace CallCS
{
    public class Test1
    {
        public void Speak(string str)
        {
            Debug.Log("Test1" + str);
        }
    }
}

public class LuaCallCS : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
