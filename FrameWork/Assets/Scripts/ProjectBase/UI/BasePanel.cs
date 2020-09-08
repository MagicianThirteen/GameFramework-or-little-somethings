using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 面板基类
/// 找到所有面板下的控件对象，以及提供显示，关闭的行为
/// </summary>
public class BasePanel : MonoBehaviour
{
    //以ui的名字为键，List<UIBehaviour>为值，存储ui控件，这样找ui可以直接通过字典找
    //为什么要用list呢？因为一个button可能不只有button组件还有image组件，同一个名字，存了不同的值是不允许在字典发生的。
    private Dictionary<string, List<UIBehaviour>> UIDic = new Dictionary<string, List<UIBehaviour>>();
    // Start is called before the first frame update
    void Awake()
    {
        FindChildrenControl<Button>();
        FindChildrenControl<Image>();
        FindChildrenControl<Text>();
        FindChildrenControl<Toggle>();
        FindChildrenControl<Slider>();
        FindChildrenControl<ScrollRect>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 找到子对象的对应ui控件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private void FindChildrenControl<T>() where T:UIBehaviour
    {
       
        T[] controls = this.GetComponentsInChildren<T>();
        string objName = null;
        for (int i = 0; i < controls.Length; i++)
        {
            objName = controls[i].gameObject.name;

            if (UIDic.ContainsKey(objName))
            {
                //如果字典有这个控件的名字了，就添加进该控件对应的list
                UIDic[objName].Add(controls[i]);
            }
            else
            {
                //如果字典没有这个控件，再添加到字典里
                UIDic.Add(objName, new List<UIBehaviour>() { controls[i] });
            }
            
        }

    }

    /// <summary>
    /// 得到对应名字的对应控件脚本
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="controlName"></param>
    /// <returns></returns>
    protected T GetUI<T>(string controlName) where T:UIBehaviour
    {
        if (UIDic.ContainsKey(controlName))
        {
            for(int i = 0; i < UIDic[controlName].Count; i++)
            {
                if(UIDic[controlName][i] is T)//is是用来判断的，as是用来转化的
                {
                    return UIDic[controlName][i] as T;
                }
            }
        }

        return null;
    }

    /// <summary>
    /// 虚方法给子类重写显示的方法
    /// </summary>
    public virtual void Show()
    {

    }

    /// <summary>
    /// 虚方法给子类重写关闭的方法
    /// </summary>
    public virtual void Close()
    {

    }
}
