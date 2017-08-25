-- ===========================
-- InitialHeroConfigReader 的数据
-- 默认Menu: Game/Tool/xlsx->lua
-- autho:曾峰
-- email:zengfeng75@qq.com
-- qq:593705098
-- http://blog.ihaiu.com
-- ---------------------------



local M = InitialHeroConfigReader



-- 读取数据
function M:ReadConfigs()
	self:ParseLine(1, {int, int})
	self:ParseLine(2, {ID, 可选英雄})
	self:ParseLine(3, {id, hero_id})
	self:ParseLine(4, {1, 1001})
	self:ParseLine(5, {2, 1002})
	self:ParseLine(6, {3, 1003})

end
