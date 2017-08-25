-- ===========================
-- EquipConfigReader 的数据
-- 默认Menu: Game/Tool/xlsx->lua
-- autho:曾峰
-- email:zengfeng75@qq.com
-- qq:593705098
-- http://blog.ihaiu.com
-- ---------------------------



local M = EquipConfigReader



-- 读取数据
function M:ReadConfigs()
	self:ParseLine(1, {int, "string", int, int, "string"})
	self:ParseLine(2, {装备id, "英雄名称", 图标ID, 模型ID, "描述文字"})
	self:ParseLine(3, {equip_id, "name", icon_id, model_id, "tip"})
	self:ParseLine(4, {2001, "武器", 1, 1, "这是一件装备"})
	self:ParseLine(5, {2002, "护甲", 2, 2, "这是一件装备"})
	self:ParseLine(6, {2003, "头盔", 3, 3, "这是一件装备"})

end
