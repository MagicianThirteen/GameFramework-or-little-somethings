print("lua调用c#类相关知识点")

--lua中使用c#的类非常简单
--固定套路
--CS.命名空间.类名
--unity的类 比如GameObject Transform等等 --  CS.UnityEngine.类名
--CS.UnityEngine.GameObject

--通过c#中的类，实例化一个对象 lua中没有new 所以我们直接类名括号就是实例化对象
--默认调用的是相当于无参构造函数
local obj1=CS.UnityEngine.GameObject()
local obj2=CS.UnityEngine.GameObject("这是一个有名字的游戏物体")

--为了方便使用 并且节约性能 定义全局变量存储 c#中的类
--相当于给这些命名空间取了个别名
GameObject=CS.UnityEngine.GameObject
local obj3=GameObject("这是用别名实力化的一个有名字的游戏物体")

--类中的静态对象（静态对象和静态方法） 可以直接使用.来调用
local obj4=GameObject.Find("这是一个有名字的游戏物体")
--得到对象中的成员变量 直接对象 . 即可
print(obj4.transform.position)
Debug=CS.UnityEngine.Debug
Debug.Log(obj4.transform.position)

--如果使用对象中的成员方法！！！一定要用冒号，
Vector3=CS.UnityEngine.Vector3
obj4.transform:Translate(Vector3.right)
Debug.Log(obj4.transform.position)

--使用自定义类（有命名空间的，无命名空间的），没有继承mono的
--自定义类 使用方法 相同 只是命名空间不同
local t1=CS.CallCS.Test1()
t1:Speak("t1")

local t=CS.Test()
t:Speak("t")


--继承了Mono的类
--继承了mono的类 是不能直接new，是通过gameobject对象来使用
--通过gameObject的AddComponent添加脚本
--xlua提供了一个重要方法 typeof 可以得到类的type
--xlua中不支持 无参泛型函数 所以 我们要使用addcomponent另一个重载

local obj5 = GameObject("加脚本测试")
obj5:AddComponent(typeof(CS.LuaCallCS))
