-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- email:zengfeng75@qq.com
-- qq: 593705098
-- http://blog.ihaiu.com
-- --------------------------------------			

UpgradeConfig = class("UpgradeConfig", {
 	-- ID
 	-- type:int
 	-- sample:1002
 	id = 0,

 	-- 名称
 	-- type:string
 	-- sample:英雄2级
 	name = nil,

 	-- 碎片需求
 	-- type:int
 	-- sample:2
 	piece = 0,

 	-- 金币
 	-- type:int
 	-- sample:50
 	gold = 0,

 	-- 水晶经验
 	-- type:int
 	-- sample:6
 	crystal_exp = 0,


})


local M = UpgradeConfig 

-- 获取键值
function M:GetKey()
 	return self.id
end
-- 构造方法
function M:ctor({id, name, piece, gold, crystal_exp})
 	self.id = id
 	self.name = name
 	self.piece = piece
 	self.gold = gold
 	self.crystal_exp = crystal_exp

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/UpgradeConfig_Extend"
