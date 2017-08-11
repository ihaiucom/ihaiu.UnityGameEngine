
ModuleManager = class("ModuleManager", 
{
	-- 模块列表
	list = {},
	-- 模块字典
	dict = {},

})

-- 初始化
function ModuleManager:Install( ModuleManager_List_path )
	require (ModuleManager_List_path)
	self:GenerateList()
	self:GenerateDict()
end

-- 生成字典
function ModuleManager:GenerateDict( ... )
	print("===ModuleManager:GenerateDict")
	print("self.list", self, self.list, #self.list)
	for i, v in ipairs(self.list) do
		print("==========", i, v)
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


