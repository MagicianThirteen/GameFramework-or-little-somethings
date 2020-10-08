RefOut=CS.RefOut
local rf=RefOut()

--[[

	ref参数 会以多返回值的形式返回给lua
	如果函数存在返回值 那么第一个值就是该返回值
	之后的返回值，就是ref的结果 从左到右一一对应
	ref参数 需要传入一个默认值 占位置，int类型可以都传0
	a相当于是函数的返回值
	b第一个ref
	c第二个ref
]]
local a,b,c=rf:RefFun(1,0,0,4)
print(a)
print(b)
print(c)

--[[
	out参数 会以多返回值的形式返回给lua
	如果函数存在返回值 那么第一个值就是该函数的返回值
	之后的返回值 就是out的结果 从左到右一一对应
	out参数 不需要传占位置的值，和ref不一样，ref要传占位置的值
]]
local d,e,f=rf:OutFun(10,30)
print(d)
print(e)
print(f)

--如果是ref，out混用的函数，就遵循各自的规则
--ref占位，out不用传
--第一个函数是返回值，从左到右依次对应ref或者out
local g,h,i=rf:RefOutFun(10,0)
print(g)
print(h)
print(i)