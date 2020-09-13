using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;//用unityaction要添加的命名空间
/// <summary>
/// 事件中心 单例模式
/// </summary>
/// 1.Dictionary 2.委托 3.观察者设计模式 4.泛型
/// 2.作用：分发事件

///这里这样写，是为了在字典中给泛型包裹一层，让它可以使用特定特定类型
public class EventInfo<T>:IEventInfo
{
    public UnityAction<T> actions;
    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}
/// <summary>
/// 为了给不要参数的监听准备的
/// </summary>
public class EventInfo : IEventInfo
{
    public UnityAction actions;
    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}
public interface IEventInfo
{

}

public class EventCenter : BaseManager<EventCenter>
{
    //用来定义事件中心的数据结构字典
    //ps：这里定义的委托是public delegate void UnityAction<T0> (T0 arg0);需要一个参数可以传1个参数，需要多个参数可以传个数组
    public Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

    /// <summary>
    /// 添加事件监听1，当需要参数时
    /// </summary>
    /// <param name="name">事件名字</param>
    /// <param name="action">委托</param>
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            //当字典有这个事件时，找到这个事件的委托对象，添加新的委托函数
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            //当字典没有这个事件时，添加这个事件的委托函数
            eventDic.Add(name, new EventInfo<T>(action));
        }
    }

    /// <summary>
    /// 添加监听事件2，当不需要参数，不需要泛型
    /// 利用了重载
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void AddEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            //当字典有这个事件时，找到这个事件的委托对象，添加新的委托函数
            (eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            //当字典没有这个事件时，添加这个事件的委托函数
            eventDic.Add(name, new EventInfo(action));
        }
    }



    /// <summary>
    /// 移除事件监听1
    /// </summary>
    /// <param name="name">事件名字</param>
    /// <param name="action">委托</param>
    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions -= action;
            if (eventDic[name] == null)
            {
                eventDic.Remove(name);
            }
        }
    }

    /// <summary>
    /// 移除事件监听2，当不需要参数，不需要泛型
    /// </summary>
    /// <param name="name">事件名字</param>
    /// <param name="action">委托</param>
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions -= action;
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
    public void EventTrigger<T>(string name,T info)
    {
        //当有这个事件时
        if (eventDic.ContainsKey(name)&& (eventDic[name] as EventInfo<T>).actions!=null)
        {
            (eventDic[name] as EventInfo<T>).actions.Invoke(info);
        }
    }

    /// <summary>
    /// 触发事件或者说分发事件，当不需要参数，不需要泛型时
    /// </summary>
    /// <param name="name">事件名字</param>
    public void EventTrigger(string name)
    {
        //当有这个事件时
        if (eventDic.ContainsKey(name) && (eventDic[name] as EventInfo).actions != null)
        {
            (eventDic[name] as EventInfo).actions.Invoke();
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
