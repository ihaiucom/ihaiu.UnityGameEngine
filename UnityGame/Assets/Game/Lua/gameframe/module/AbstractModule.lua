AbstractModule = class("AbstractModule", 
{
	-- 模块ID
	menuId = 0,

	-- 返回模块
	backMenuId = -1,

	-- 视图Class,继承自AbstractView的。注意是Class，不是实例对象
	ViewClass = AbstractView,
})

-- ======================
-- 获取预加载资源
-- ----------------------
function AbstractModule:GetLoadAssets( ... )
	return nil
end



-- ======================
-- 打开
-- ----------------------
function AbstractModule:Open( ... )
	Game.menu:Open(self.menuId, ...)
end


-- ======================
-- 关闭
-- ----------------------
function AbstractModule:Close( ... )
	Game.menu:Close(self.menuId)
end



-- ======================
-- 后退
-- ----------------------
function AbstractModule:Back( ... )
	if self.backMenuId > 0 then
		Game.menu:Close(self.menuId)
		Game.menu:Open(self.backMenuId, ...)
	else
		Game.menu:Close(self.menuId)
	end
end



-- ======================
-- 设置后退要打开的面板
-- ----------------------
function AbstractModule:SetBackMenu(menuId)
	self.backMenuId = menuId
end

