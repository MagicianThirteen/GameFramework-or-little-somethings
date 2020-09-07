using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// mono控制器的管理者，可以提供给外部添加和移除update函数的接口
/// </summary>
public class MonoMgr : BaseManager<MonoMgr>
{
    private MonoController controller;
    public MonoMgr()
    {
        GameObject obj = new GameObject("MonoController");
        controller= obj.AddComponent<MonoController>();
    }

    public void AddUpdateEventsListener(UnityAction fun)
    {
        controller.AddUpdateEventsListener(fun);
    }

    public void RemoveUpdateEventsListener(UnityAction fun)
    {
        controller.RemoveUpdateEventsListener(fun);
    }
}
