using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //测试同步加载
            GameObject obj=ResMgr.GetInstance().Load<GameObject>("Test/Cube");
            obj.transform.localScale = Vector3.one * 3;
        }
        if (Input.GetMouseButtonDown(1))
        {
            //测试异步加载
            ResMgr.GetInstance().LoadResAsync<GameObject>("Test/Cube",(obj)=> {
                obj.transform.localScale = Vector3.one * 3;
            });
        }
    }

    void DoSomeThing(GameObject obj)
    {
        obj.transform.localScale = Vector3.one * 3;
    }

    //这里的DoSomeThing还可以用lambda表达式简化
}
