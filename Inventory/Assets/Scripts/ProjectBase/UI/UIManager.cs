using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// UI管理器
/// </summary>
///
//ui层级
public enum UI_Layer
{
    bot,
    mid,
    top,
    system,
}

public class UIManager : BaseManager<UIManager>
{
    private Transform canvas;

    //不同层级，因为有些面板永远显示在最上面
    private Transform bot;
    private Transform mid;
    private Transform top;
    private Transform system;

    //管理所有打开的面板
    public Dictionary<string, BasePanel> panelsDic = new Dictionary<string, BasePanel>();

    public UIManager()
    {
        //加载找到canvas,EventSystem,让其过场景不被移除
        GameObject obj = ResMgr.GetInstance().Load<GameObject>("UI/Canvas");
        canvas = obj.transform;
        GameObject.DontDestroyOnLoad(obj);

        //找到各层
        bot = canvas.Find("bot");
        mid = canvas.Find("mid");
        top = canvas.Find("top");
        system = canvas.Find("system");

        GameObject objEvent=ResMgr.GetInstance().Load<GameObject>("UI/EventSystem");
        GameObject.DontDestroyOnLoad(objEvent);
    }

   /// <summary>
   /// 打开面板
   /// </summary>
   /// <param name="panelName">面板名字</param>
   /// <param name="layer">面板层级</param>
    public void ShowPanel<T>(string panelName,UI_Layer layer=UI_Layer.mid,UnityAction<T> callback=null)where T:BasePanel
    {
        ResMgr.GetInstance().LoadResAsync<GameObject>("UI/" + panelName, (obj) => {

            //如果打开这个面板了
            if (panelsDic.ContainsKey(panelName))
            {
                //使用子类的show方法，做额外子类需要做的事
                panelsDic[panelName].Show();
                if (callback != null)
                    callback(panelsDic[panelName] as T);
            }
            
            //找到该面板对应的层级
            Transform parent = bot;
            switch (layer)
            {
                case UI_Layer.mid:
                    parent = mid;
                    break;
                case UI_Layer.top:
                    parent = top;
                    break;
                case UI_Layer.system:
                    parent = system;
                    break;
            }
            //将该层级设置为父对象,设置相对位置和大小
            obj.transform.SetParent(parent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            (obj.transform as RectTransform).offsetMax = Vector2.zero;
            (obj.transform as RectTransform).offsetMin = Vector2.zero;

            //得到预设体上的面板脚本
            T panel = obj.GetComponent<T>();
            if (panel == null)
            {
                Debug.Log("lost panel");
            }
            //把得到的面板脚本传给callback委托，方便外面利用脚本里的函数操作
            if (callback != null)
            {
                
                callback(panel);
            }
            //使用子类的show方法，做额外子类需要做的事
            panel.Show();
            //添加进打开列表
            
            panelsDic.Add(panelName, panel);
        });
    }

    /// <summary>
    /// 关闭面板
    /// </summary>
    /// <param name="panelName"></param>
    public void ClosePanel(string panelName)
    {
        if (panelsDic.ContainsKey(panelName))
        {
            //关闭的时候子类要做的额外的事
            panelsDic[panelName].Close();
            //删除挂在脚本上的游戏物体
            GameObject.Destroy(panelsDic[panelName].gameObject);
            panelsDic.Remove(panelName);
        }
    }
}
