using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    /// <summary>
    /// 给外部开启协程的方法
    /// </summary>
    /// <param name="routine"></param>
    /// <returns></returns>
    public Coroutine StartCoroutine(IEnumerator routine)
    {
        return controller.StartCoroutine(routine);
    }
    //同上
    public Coroutine StartCoroutine(string methodName)
    {
        return controller.StartCoroutine(methodName);
    }

    /// <summary>
    /// 给外部停止协程的方法
    /// </summary>
    /// <param name="routine"></param>
    public void StopCoroutine(IEnumerator routine)
    {
        controller.StartCoroutine(routine);
    }

    public void StopCoroutine(string methodName)
    {
        controller.StopCoroutine(methodName);
    }


}
