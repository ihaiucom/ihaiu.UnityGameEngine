
ModuleManager = class("ModuleManager", 
{
	-- 模块列表
	list = {},
	-- 模块字典
	dict = {},

})

-- 初始化
function ModuleManager:Install( ModuleManager_List )
	-- require "gameframe/module/ModuleManager_List"
	require ModuleManager_List
	self:GenerateList()
	self:GenerateDict()
end

-- 生成字典
function ModuleManager:GenerateDict( ... )
	for i, v in ipairs(self:list) do
		self.dict[v.menuId] = v
	end
end


-- 获取模块
function ModuleManager:GetModule( menuId )
	if self.dict[menuId] then
		return self.dict[menuId]
	end

	error("ModuleManager.GetModule 不存在该模块 menuId=" .. menuId)
	return nil
end


