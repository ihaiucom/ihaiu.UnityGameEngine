-- ===========================
-- LoaderConfigReader 的数据
-- 默认Menu: Game/Tool/xlsx->lua
-- autho:曾峰
-- email:zengfeng75@qq.com
-- qq:593705098
-- http://blog.ihaiu.com
-- ---------------------------



local M = LoaderConfigReader



-- 读取数据
function M:ReadConfigs()
	self:ParseLine(1, {int, "string", "string", true})
	self:ParseLine(2, {id, "名称", "路径", true})
	self:ParseLine(3, {id, "name", "path", true})
	self:ParseLine(4, {0, "没视图", "", false})
	self:ParseLine(5, {1, "转圈", "PrefabUI/GameSystem/GameCirclePanel", false})
	self:ParseLine(6, {2, "进入游戏", "PrefabUI/GameSystem/GameCirclePanel", true})
	self:ParseLine(7, {3, "加载战斗", "PrefabUI/GameSystem/GameCirclePanel", true})

end
