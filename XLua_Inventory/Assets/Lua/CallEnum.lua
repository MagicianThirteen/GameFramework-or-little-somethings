--[[
	枚举调用
	1.调用unity当中的枚举
	枚举的调用规则和类调用规则是一样的
	CS.命名空间.枚举名.枚举成员
	也支持取别名
	小技巧：不记得函数的具体写法就在c#里写一遍，有提示
]]
PrimitiveType=CS.UnityEngine.PrimitiveType
GameObject=CS.UnityEngine.GameObject
local obj = GameObject.CreatePrimitive(PrimitiveType.Cube)

--[[
	枚举转换相关
	数值转枚举（c#中的下标）
	字符串转枚举
]]
StateEnum=CS.Enum_StateEnum
local idle=StateEnum.idle1
print(idle)
local s1=StateEnum.__CastFrom(1)--注意这里的1是c#中的下标，枚举第2个
print(s1)
local s3=StateEnum.__CastFrom("run3")
print(s3)