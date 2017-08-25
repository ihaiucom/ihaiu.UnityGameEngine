-- ===========================
-- HeroConfigReader 的数据
-- 默认Menu: Game/Tool/xlsx->lua
-- autho:曾峰
-- email:zengfeng75@qq.com
-- qq:593705098
-- http://blog.ihaiu.com
-- ---------------------------



local M = HeroConfigReader



-- 读取数据
function M:ReadConfigs()
	self:ParseLine(1, {int, "string", int, int, "string", int, int, int, int, int, int})
	self:ParseLine(2, {英雄id, "英雄名称", 职业, 模型ID, "描述文字", 技能1, 技能2, 技能3, 技能4, 技能5, 技能6})
	self:ParseLine(3, {hero_id, "name", professional, model_id, "tip", skill_1, skill_2, skill_3, skill_4, skill_5, skill_6})
	self:ParseLine(4, {1001, "后裔", 1, 1, "这是一个英雄", 1001, 1002, 1003, 1004, 1005, 1006})
	self:ParseLine(5, {1002, "女娲", 2, 2, "这是一个英雄", 1001, 1002, 1003, 1004, 1005, 1006})
	self:ParseLine(6, {1003, "夸父", 3, 3, "这是一个英雄", 1001, 1002, 1003, 1004, 1005, 1006})

end
