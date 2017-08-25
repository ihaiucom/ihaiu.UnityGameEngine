-- ===========================
-- DungeonConfigReader 的数据
-- 默认Menu: Game/Tool/xlsx->lua
-- autho:曾峰
-- email:zengfeng75@qq.com
-- qq:593705098
-- http://blog.ihaiu.com
-- ---------------------------



local M = DungeonConfigReader



-- 读取数据
function M:ReadConfigs()
	self:ParseLine(1, {int, "string", int, "string", int, "string"})
	self:ParseLine(2, {关卡id, "关卡名称", 体力需求, "怪物预览", 随机产出id, "固定产出id"})
	self:ParseLine(3, {dungeon_id, "name", physical_strength_cost, "monster_id", random_output, "fixed_output"})
	self:ParseLine(4, {1, "教学1", 10, "1022;1027;1021", , "2x20;3001x1"})
	self:ParseLine(5, {2, "教学2", 10, "1022;1027;1021", , "2x20;3001x1"})
	self:ParseLine(6, {1001, "主线1", 10, "1022;1027;1021", , "2x20;1001x1"})
	self:ParseLine(7, {1002, "主线2", 10, "1022;1027;1021", , "2x20;1001x1"})
	self:ParseLine(8, {1003, "主线3", 10, "1022;1027;1021", , "2x30;3002x2"})
	self:ParseLine(9, {1004, "主线4", 10, "1022;1027;1021", , "2x30;2001x2"})
	self:ParseLine(10, {1005, "主线5", 10, "1022;1027;1021", , "2x40;3003x1;3004x1;3005x1"})
	self:ParseLine(11, {1006, "主线6", 10, "1022;1027;1021", , "2x40;3004x1;3005x1;3006x1"})

end
