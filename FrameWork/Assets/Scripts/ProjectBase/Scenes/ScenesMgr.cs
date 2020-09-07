using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;//加载场景需要的命名空间
/// <summary>
/// 场景切换模块
/// </summary>
public class ScenesMgr :BaseManager<ScenesMgr>
{
    /// <summary>
    /// 同步的场景加载
    /// </summary>
    /// <param name="name">场景名字</param>
    /// <param name="fun">加载场景过后要做的事情的函数</param>
    public void LoadScenes(string name, UnityAction fun)
    {

        SceneManager.LoadScene(name);
        fun();

    }



    /// <summary>
    /// 异步的场景加载
    /// </summary>
    /// <param name="name">场景名字</param>
    /// <param name="fun">加载场景过后要做的事情的函数</param>
    public void LoadScenesAsync(string name,UnityAction fun)
    {

        MonoMgr.GetInstance().StartCoroutine(LoadingScenesAsync(name,fun));
    }

    IEnumerator LoadingScenesAsync(string name,UnityAction fun)
    {
        AsyncOperation op= SceneManager.LoadSceneAsync(name);
        
        while (!op.isDone)
        {
            //每一次进度更新都触发这个加载进度条事件,知道当前加载进度
            EventCenter.GetInstance().EventTrigger("LoadingScene", op.progress);
            yield return op.progress;
        }
        //在场景加载完成后，去做fun
        fun();
    }
}
