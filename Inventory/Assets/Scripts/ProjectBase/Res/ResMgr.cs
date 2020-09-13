using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResMgr : BaseManager<ResMgr>
{
    /// <summary>
    /// 同步加载资源
    /// </summary>
    /// <typeparam name="T">加载资源的类型为object</typeparam>
    /// <param name="name">加载资源的路径</param>
    /// <returns>返回要用的资源</returns>
    
    public T Load<T>(string name) where T : Object
    {

        T res=Resources.Load<T>(name);
        if(res as GameObject)
        {
            return GameObject.Instantiate(res);
        }
        else
        {
            return res;
        }
    }

    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <typeparam name="T">加载资源的类型</typeparam>
    /// <param name="name">加载资源的路径</param>
    /// <param name="callback">加载资源后要做的事，因为不知道什么时候加载完，做的事情要在加载完之后做，所以把加载完成后的资源当成参数</param>
    /// public delegate void UnityAction<T0> (T0 arg0);
    /// 这里的委托可以传1个参数，正好可以把需要的资源传出去，是gameobject的实例化，不是的直接返回
    public void LoadResAsync<T>(string name,UnityAction<T> callback) where T:Object
    {
        MonoMgr.GetInstance().StartCoroutine(LoadAsync<T>(name,callback));
    }

    IEnumerator LoadAsync<T>(string name,UnityAction<T> callback) where T : Object
    {
       ResourceRequest request= Resources.LoadAsync<T>(name);
        yield return request;
        if(request.asset as GameObject)
        {
            callback(GameObject.Instantiate(request.asset) as T);
        }
        else
        {
            callback(request.asset as T);
        }
    }
}
