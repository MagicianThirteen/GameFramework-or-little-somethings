using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CallListDic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");

        //同种类型的list,注意list是值拷贝，是浅拷贝，修改这里list的值不会影响lua文件里的值
        List<int> list1 = LuaMgr.GetInstance().Global.Get<List<int>>("testList");
        for (int i = 0; i < list1.Count; i++)
        {
            Debug.Log(list1[i]);
        }

        //不同类型的list用object
        List<object> list2 = LuaMgr.GetInstance().Global.Get<List<object>>("testList2");
        for (int i = 0; i < list2.Count; i++)
        {
            Debug.Log(list2[i]);
        }

        //确定键值对类型的dictionary，注意dictionary也是值拷贝，是浅拷贝，修改这里dictionary里的值不回影响lua文件里的值
        Dictionary<string, int> dic1 = LuaMgr.GetInstance().Global.Get<Dictionary<string, int>>("testDic");
        foreach (string s in dic1.Keys)
        {
            Debug.Log(s + "_" + dic1[s]);
        }

        //不确定键值对类型的dictionary用object, 注意这里的遍历顺序不一定与lua文件中写的一致，但是都能遍历
        Dictionary<object, object> dic2 = LuaMgr.GetInstance().Global.Get<Dictionary<object, object>>("testDic2");
        foreach (object o in dic2.Keys)
        {
            Debug.Log(o + "_" + dic2[o]);

        }
    }

    }
