-- ===========================
-- ItemConfigReader 的数据
-- 默认Menu: Game/Tool/xlsx->lua
-- autho:曾峰
-- email:zengfeng75@qq.com
-- qq:593705098
-- http://blog.ihaiu.com
-- ---------------------------



local M = ItemConfigReader



-- 读取数据
function M:ReadConfigs()
	self:ParseLine(1, {int, "string", "string", int, "string"})
	self:ParseLine(2, {ID, "名称", "图标", 品质, "说明"})
	self:ParseLine(3, {id, "name", "icon", quality, "tip"})
	self:ParseLine(4, {1, "宝石", "宝石图片", 3, "游戏货币"})
	self:ParseLine(5, {2, "金币", "金币图片", 2, "游戏货币"})
	self:ParseLine(6, {3, "体力", "体力图片", 1, "PVE关卡消耗体力"})
	self:ParseLine(7, {1001, "英雄1碎片", "英雄1图片路径", 1, "英雄1升级材料"})
	self:ParseLine(8, {1002, "英雄2碎片", "英雄2图片路径", 1, "英雄2升级材料"})
	self:ParseLine(9, {1003, "英雄3碎片", "英雄3图片路径", 1, "英雄3升级材料"})
	self:ParseLine(10, {2001, "装备1碎片", "英雄11图片路径", 1, "装备1升级材料"})
	self:ParseLine(11, {2002, "装备2碎片", "英雄12图片路径", 1, "装备2升级材料"})
	self:ParseLine(12, {2003, "装备3碎片", "英雄13图片路径", 1, "装备3升级材料"})
	self:ParseLine(13, {3001, "机关1碎片", "英雄21图片路径", 1, "机关1升级材料"})
	self:ParseLine(14, {3002, "机关2碎片", "英雄22图片路径", 1, "机关2升级材料"})
	self:ParseLine(15, {3003, "机关3碎片", "英雄23图片路径", 1, "机关3升级材料"})
	self:ParseLine(16, {3004, "机关4碎片", "英雄24图片路径", 1, "机关4升级材料"})
	self:ParseLine(17, {3005, "机关5碎片", "英雄25图片路径", 1, "机关5升级材料"})
	self:ParseLine(18, {3006, "机关6碎片", "英雄26图片路径", 1, "机关6升级材料"})
	self:ParseLine(19, {3007, "机关7碎片", "英雄27图片路径", 1, "机关7升级材料"})
	self:ParseLine(20, {3008, "机关8碎片", "英雄28图片路径", 1, "机关8升级材料"})
	self:ParseLine(21, {3009, "机关9碎片", "英雄29图片路径", 1, "机关9升级材料"})
	self:ParseLine(22, {3010, "机关10碎片", "英雄30图片路径", 1, "机关10升级材料"})

end
