
print("调用c#里的数组，list，字典")
--[[
c#里的数组在lua中
相当于userdata
保留了其结构
c#怎么用，lua就怎么用
]]

--CS.CallArray_list_Dic
--ps:c#那边的类取名少用下划线
local ca=CS.Callarray()
--获取数组长度
print(ca.arr.Length)
--获取数组元素
print(ca.arr[0])
--遍历数组，注意c#下标从0开始到length-1结束
for i=0,ca.arr.Length-1 do
	print(ca.arr[i])
end
--lua中创建一个c#的数组 lua中表示数组和list可以用表
--但如果要创建c#中的数组，使用Array类中的静态方法即可
--[[
	
	[SecuritySafeCritical]
	public static Array CreateInstance (Type elementType, int length);

]]
--ps:如果要打印lua的值，不要在uinty编辑器中用collapse选项，这样
--相同的值会重叠起来，不按时间顺序
local arr1=CS.System.Array.CreateInstance(typeof(CS.System.Int32),5)
print(arr1.Length)
print(arr1[0])


--用cs那边的list，通c#规则一样
ca.list:Add(1)
print(ca.list[0])
print(ca.list.Count)
for i=0,ca.list.Count-1 do
	print(ca.list[i])
end
--创建新的cs中的list
--老版本
local list2=CS.System.Collections.Generic["List`1[System.String]"]()
print(list2)
list2:Add("nihaoalist2")
print(list2[0])
--新版本 >v2.1.12
local list_String=CS.System.Collections.Generic.List(CS.System.String)
local list3=list_String()
list3:Add("nihaoahahahahhahah")
print(list3[0])

print("test dictionary****")
--操作c#里的字典
--添加
ca.dic:Add(1,"nihao")
print(ca.dic[1])
--遍历
for k,v in pairs(ca.dic) do
	print(k,v)
end
--lua自己创建c#中的字典
--相当于得到了一个Dictionary<string,Vector3>的一个类别名，需要实例化

local dic_string_vector3=CS.System.Collections.Generic.Dictionary(CS.System.String,CS.UnityEngine.Vector3)
local dic2=dic_string_vector3()
dic2:Add("right",CS.UnityEngine.Vector3.right)
for k,v in pairs(dic2) do
	print(k,v)
end

--！！lua中创建字典，直接通过键中括号是得不到的，值为nil
print(dic2["right"])
--lua中创建的字典，获取和设置值有固定的写法（get_Item,set_Item)
print(dic2:get_Item("right"))
dic2:set_Item("123",nil)
print(dic2:get_Item("123"))
--TryGetValue有两个返回值一个bool表示是否找到，一个是找到的值
print(dic2:TryGetValue("right"))




















