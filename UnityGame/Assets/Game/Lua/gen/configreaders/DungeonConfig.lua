-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- http://blog.ihaiu.com
-- --------------------------------------			

DungeonConfig = class("DungeonConfig", {
 	-- 关卡id
 	-- type:int
 	-- sample:2
 	dungeon_id = 0,

 	-- 关卡名称
 	-- type:string
 	-- sample:教学2
 	name = nil,

 	-- 体力需求
 	-- type:int
 	-- sample:10
 	physical_strength_cost = 0,

 	-- 怪物预览
 	-- type:string
 	-- sample:1022;1027;1021
 	monster_id = nil,

 	-- 随机产出id
 	-- type:int
 	-- sample:
 	random_output = 0,

 	-- 固定产出id
 	-- type:string
 	-- sample:2x20;3001x1
 	fixed_output = nil,


})


local M = DungeonConfig 

-- 获取键值
function M:GetKey()
 	return self.dungeon_id
end
-- 构造方法
function M:ctor({dungeon_id, name, physical_strength_cost, monster_id, random_output, fixed_output})
 	self.dungeon_id = dungeon_id
 	self.name = name
 	self.physical_strength_cost = physical_strength_cost
 	self.monster_id = monster_id
 	self.random_output = random_output
 	self.fixed_output = fixed_output

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/DungeonConfig_Extend"
