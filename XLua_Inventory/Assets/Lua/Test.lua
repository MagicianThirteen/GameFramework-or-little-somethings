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