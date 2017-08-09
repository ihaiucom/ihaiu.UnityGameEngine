
MenuManager = {
	dict = {}, -- <int, MenuCtl>
}

local M = MenuManager
setmetatable(M, {__index = _G})
setfenv(1, M)

-- 获取指定菜单控制器
function GetMenuCtl( menuId )
	if dict[menuId] then
		return dict[menuId]
	end
	error("MenuManager:GetMenuCtl dict 不存在menuId=")
	return nil
end

-- 获取菜单控制器列表
function GetMenuCtlDic()
	return dict
end




-- 打开模块
function Open(menuId, ...)
	local menuCtl = GetMenuCtl(menuId)

	if menuCtl == nil then

	end


	OpenMenuCtl(menuCtl)
end


function OpenMenuCtl(menuCtl )
	-- body
end


-- 关闭模块
function Close( menuId )
	
end


-- 更新
function OnUpdate( ... )
	
end

-- 初始化
function Install( ... )
	
end
