CallFun=CS.CallFun
local cf=CallFun()

--[[
	虽然lua自己不支持写重载函数
	但是lua支持调用c#中的重载函数
	lua虽然支持调用c#中的重载函数
	但是因为lua中只有number的数值类型
	对c#中多精度的重载函数支持不好，分不清
	在使用时，尽量避免c#中出现不同精度的重载函数，尽量避免多精度的重载函数
	不过xlua也有解决方案，是用反射机制，但是尽量别用，效率低

]]
print(cf:Calc())
print(cf:Calc(10,30))
print(cf:Calc(19))
print(cf:Calc(19.3))

--[[
 要解决重载函数精度不同的问题，xlua提供了反射机制
 

]]
--type是反射的关键类
--得到指定函数的相关信息
local m1=typeof(CallFun):GetMethod("Calc",{typeof(CS.System.Int32)})
local m2=typeof(CallFun):GetMethod("Calc",{typeof(CS.System.Single)})
--通过xlua提供的一个方法 把它转成lua函数来使用
--一般转一次然后重复使用
local f1=xlua.tofunction(m1)
local f2=xlua.tofunction(m2)
print(f1(cf,10))
print(f2(cf,10.3))