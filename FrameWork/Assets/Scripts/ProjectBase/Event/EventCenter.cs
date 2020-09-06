using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;//用unityaction要添加的命名空间
/// <summary>
/// 事件中心 单例模式
/// </summary>
/// 1.Dictionary 2.委托 3.观察者设计模式
/// 2.作用：分发事件                                                                                                                                       
public class EventCenter : BaseManager<EventCenter>
{
    //用来定义事件中心的数据结构字典
    //ps：这里定义的委托是public delegate void UnityAction<T0> (T0 arg0);需要一个参数可以传1个参数，需要多个参数可以传个数组
    public Dictionary<string, UnityAction<object>> eventDic = new Dictionary<string, UnityAction<object>>();

    /// <summary>
    /// 添加事件监听
    /// </summary>
    /// <param name="name">事件名字</param>
    /// <param name="action">委托</param>
    public void AddEventListener(string name, UnityAction<object> action)
    {
        if (eventDic.ContainsKey(name))
        {
            //当字典有这个事件时，找到这个事件的委托对象，添加新的委托函数
            eventDic[name] += action;
        }
        else
        {
            //当字典没有这个事件时，添加这个事件的委托函数
            eventDic.Add(name, action);
        }
    }

    /// <summary>
    /// 移除事件监听
    /// </summary>
    /// <param name="name">事件名字</param>
    /// <param name="action">委托</param>
    public void RemoveEventListener(string name, UnityAction<object> action)
    {
        if (eventDic.ContainsKey(name))
        {
            eventDic[name] -= action;
            if (eventDic[name] == null)
            {
                eventDic.Remove(name);
            }
        }
    }

    /// <summary>
    /// 触发事件或者说分发事件
    /// </summary>
    /// <param name="name">事件名字</param>
    public void EventTrigger(string name,object info)
    {
        //当有这个事件时
        if (eventDic.ContainsKey(name))
        {
            eventDic[name](info);
        }
    }

    /// <summary>
    /// 在切换场景的时候清空事件中心
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }
}
