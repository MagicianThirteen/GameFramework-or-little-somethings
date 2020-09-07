using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public string MosterName = "ha";
    void Start()
    {
        //一进来就怪物死亡
         Debug.Log(this.GetType());
         Dead(this);
        //测试公共类
        TestMonoController t = new TestMonoController();
        MonoMgr.GetInstance().AddUpdateEventsListener(t.Update);
        

    }

   void Dead(object info)
    {
        //触发，分发怪物死亡事件
        EventCenter.GetInstance().EventTrigger("MosterDead", info);
    }
}

public class TestMonoController
{
    public TestMonoController()
    {
        MonoMgr.GetInstance().StartCoroutine(testCoroutine());
    }
    public void Update()
    {
        Debug.Log("测试公共类成功");
    }
    IEnumerator testCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("测试协程成功");
    }


}