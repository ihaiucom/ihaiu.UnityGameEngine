
ModuleManager = class("ModuleManager", 
{
	-- 模块列表
	list = {},
	-- 模块字典
	dict = {},

})

-- 初始化
function ModuleManager.Install( ... )
	ModuleManager.GenerateList()
	ModuleManager.GenerateDict()
end

-- 生成字典
function ModuleManager.GenerateDict( ... )
	for i, v in ipairs(ModuleManager.list) do
		dict[v.menuId] = v
	end
end


-- 获取模块
function ModuleManager.GetModule( menuId )
	if dict[menuId] then
		return dict[menuId]
	end

	error("ModuleManager.GetModule 不存在该模块 menuId=" .. menuId)
	return nil
end



require "gameframe/module/ModuleManager_List"