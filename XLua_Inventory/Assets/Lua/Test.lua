print("Test.lua")
testNumber=1
testBool=true
testFloat=1.3
testString="13"

local testLocal=14

testfun=function()
	-- body
	print("no args")
end

testfun1=function(a)
	-- body
	print("args returns")
	return a+1
end

testfun2=function( a,... )
	-- body
	print("many args")
	print(a)
	args={...}
	for k,v in pairs(args) do
		print(k,v)
	end
end

testfun3=function (a)
	print("many returns")
	return 1,2,false,"13",a
end

--List
testList={1,23,4,5,7,8}
testList2={"1",true,23,"13"}

--dictionary
testDic={
	["1"]=1,
	["2"]=2,
	["3"]=3,
	["4"]=4,
	["5"]=5
}

testDic2={
	["true"]=true,
	["1"]=13,
	["false"]= -1,
	["13"]=true
}


--class
--这样定义的表相当于是个自定义的类，有成员变量和成员函数
testClass={
	testInt=1,
	testBool=true,
	testFloat=1.3,
	testString="13",
	testFun=function ()
		-- body
		print("nihaoyahahahahha")
	end,
	

}


































