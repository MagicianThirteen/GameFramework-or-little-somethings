print("主lua脚本启动")

--整个文件算所有lua文件的主入口
--只要执行lua文件，xlua都会去找自定义的加载器去加载整个lua文件
require("CallClass")