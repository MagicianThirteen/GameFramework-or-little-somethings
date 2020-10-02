using System;//Action命名空间
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;//UnityAction的命名空间
using XLua;//LuaFunction的命名空间

public class CallFunction : MonoBehaviour
{
    //定义无参无返回值的委托，无参无返回值不需要加上特性是因为xlua能自动识别
    public delegate void customDelegate();

    //定义有参有返回值的委托，注意这里要加上特性CSharpCallLua，而且还要在编辑器里点击generate code在xlua工具栏下，
    //这样xlua才会识别这个委托
    [CSharpCallLua]//这个在命名空间里
    public delegate int customDele2(int i);

    //用out定义多返回值的委托，注意这里要加上特性CSharpCallLua，而且还要在编辑器里点击generate code在xlua工具栏下
    [CSharpCallLua]
    //第一个返回值为int，第一个参数为int，第二到第五个返回值为a，b，c，e，根据定义的lua函数来的
    public delegate int customDele3(int i, out int a, out bool b, out string c, out int e);
    //用ref定义多返回值的委托
    [CSharpCallLua]
    public delegate int customDele4(int i1, ref int a1, ref bool b1, ref string c1, ref int e1);

    [CSharpCallLua]
    //注意如果已经知道变长参数的类型可以用确定的类型比如int【】，如果是混合的，就用object【】
    public delegate void customDele5(int a3, params object[] args);

    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");

        //获取无参无返回全局函数，有四种方式，自己定义委托，unityaction(尽量用这个），action，luafunction(这个是xlua自带的少用）
        customDelegate cd= LuaMgr.GetInstance().Global.Get<customDelegate>("testfun");
        cd();

        UnityAction uc = LuaMgr.GetInstance().Global.Get<UnityAction>("testfun");
        uc();

        Action at = LuaMgr.GetInstance().Global.Get<Action>("testfun");
        at();

        LuaFunction lf= LuaMgr.GetInstance().Global.Get<LuaFunction>("testfun");
        lf.Call();

        //获取有参有返回的全局函数：自定义委托，Func（c#自带的，一般用这个，在system命名空间里），LuaFunction 
        customDele2 cd2 = LuaMgr.GetInstance().Global.Get<customDele2>("testfun1");
        Debug.Log(cd2(3));

        Func<int,int> f2= LuaMgr.GetInstance().Global.Get<Func<int, int>>("testfun1");
        Debug.Log(f2(3));

        LuaFunction lf2 = LuaMgr.GetInstance().Global.Get<LuaFunction>("testfun1");
        lf2.Call(3);//注意这里返回的是个object【】数组，当只有一个返回值时，获取第【0】个就可以了
        Debug.Log(lf2.Call(3)[0]);

        //多返回值，官方建议用自定义的委托用out接,或者用自定义的委托用ref接，还有官方定义的luafunction（这个不要用，会产生一些垃圾）
        customDele3 cd3= LuaMgr.GetInstance().Global.Get<customDele3>("testfun3");
        //这些是要输出的返回值
        int a;
        bool b;
        string c;
        int e;
        Debug.Log("返回值：" + cd3(4, out a, out b, out c, out e) + "_" + a + "_" + b + "_" + c + "_" + e);

        customDele4 cd4 = LuaMgr.GetInstance().Global.Get<customDele4>("testfun3");
        int a1=1;
        bool b1=false;
        string c1="";
        int e1=1;
        Debug.Log("返回值：" + cd4(100, ref a1, ref b1, ref c1, ref e1) + "_" + a1 + "_" + b1 + "_" + c1 + "_" + e1);

        LuaFunction lf4= LuaMgr.GetInstance().Global.Get<LuaFunction>("testfun3");
        object[] objs = lf4.Call(1000);
        for(int i = 0; i < objs.Length; i++)
        {
            Debug.Log(objs[i]+"luafunction");
        }

        //变长参数，用自定义的委托（官方建议），或者用luafunction（不建议用，有垃圾）
        customDele5 cd5 = LuaMgr.GetInstance().Global.Get<customDele5>("testfun2");
        cd5(13, "13", true, 7);
        LuaFunction lf5= LuaMgr.GetInstance().Global.Get<LuaFunction>("testfun2");
        lf5.Call(14, "133", false, 13);


    }


}
