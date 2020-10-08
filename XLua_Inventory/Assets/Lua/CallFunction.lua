
local Testf=CS.Testf
local tf=Testf()
--使用静态方法
Testf.Eat()
--使用成员方法
tf:Speak("nihao")
--使用拓展方法，与使用普通成员方法一致，用冒号,尽管这个拓展方法是静态方法，也用冒号，将传入调用者当参数
--当调用c#中的拓展方法时，c#那个类一定要加上csharpcalllua特性
tf:Move()


