-- ===========================
-- MenuConfigReader 的数据
-- 默认Menu: Game/Tool/xlsx->lua
-- autho:曾峰
-- email:zengfeng75@qq.com
-- qq:593705098
-- http://blog.ihaiu.com
-- ---------------------------



local M = MenuConfigReader



-- 读取数据
function M:ReadConfigs()
	self:ParseLine(1, {int, "string", "string", int, int, int, int, int, int})
	self:ParseLine(2, {面板ID, "面板名称", "资源路径", 模块类型, 层级, 布局类型, 关闭其他面板包含哪些, 缓存时间, 加载面板类型})
	self:ParseLine(3, {id, "name", "path", menuType, layer, layout, closeOtherType, cacheTime, loaderType})
	self:ParseLine(4, {1, "登录界面", "PrefabUI/GameLogin/LoginWindow", 0, 4, 0, 2, , 0})

end
