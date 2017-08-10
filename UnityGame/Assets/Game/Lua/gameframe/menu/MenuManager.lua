
MenuManager = {
	dict = {}, -- <int, MenuCtl>
}

local M = MenuManager

-- 获取指定菜单控制器
function M:GetMenuCtl( menuId )
	if self.dict[menuId] then
		return self.dict[menuId]
	end
	error("MenuManager:GetMenuCtl dict 不存在menuId=")
	return nil
end

-- 获取菜单控制器列表
function M:GetMenuCtlDic()
	return self.dict
end




-- 打开模块
function M:Open(menuId, ...)
	local menuCtl = self:GetMenuCtl(menuId)

	if menuCtl == nil then
		local menuConfig = Game.config.menu:GetConfig(menuId)
		if menuConfig == nil then
			error(string.format("找不到MenuConfig MenuManager.Open menuId=%s", menuId))
			return
		end

		if menuConfig.menuType == menuType.Panel then
			menuCtl = MenuCtlForPanel.New()
		else
			menuCtl = MenuCtlForScene.New()
		end

		menuCtl.menuId = menuId
		menuCtl.config = menuConfig
		menuCtl.moduleCtl = Game.modules:GetModule(menuId)
		if menuCtl.module == nil then
			error(string.format("找不到Module MenuManager.Open menuId=%s", menuId))
		end

		dict[menuId] = menuCtl

	end

	menuCtl:Open(...)
end




-- 关闭模块
function M:Close( menuId )
	
	local menuCtl = self:GetMenuCtl(menuId)
	if menuCtl then
		menuCtl:Close()
	end
end


-- 更新
function M:OnUpdate(  )
	for menuId, menuCtl in pairs(dict) do
		if menuCtl.state == MenuCtlStateType.Closed then
			menuCtl.cacheTime = menuCtl.cacheTime + Time.unscaledDeltaTime

			if menuCtl.config.chacheTime >= 0 and menuCtl.cacheTime > menuCtl.config.chacheTime then
				menuCtl:Destory()
			end

		end
	end
end

-- 初始化
function M:Install( ... )
	Game.mainThread:AddUpdateListen(self, OnUpdate )
end
