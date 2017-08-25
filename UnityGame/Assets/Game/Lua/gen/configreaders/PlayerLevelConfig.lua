-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- email:zengfeng75@qq.com
-- qq: 593705098
-- http://blog.ihaiu.com
-- --------------------------------------			

PlayerLevelConfig = class("PlayerLevelConfig", {
 	-- 等级
 	-- type:int
 	-- sample:2
 	level = 0,

 	-- 经验值
 	-- type:int
 	-- sample:25
 	exp = 0,

 	-- 体力
 	-- type:int
 	-- sample:100
 	physical_strength = 0,


})


local M = PlayerLevelConfig 

-- 获取键值
function M:GetKey()
 	return self.level
end
-- 构造方法
function M:ctor({level, exp, physical_strength})
 	self.level = level
 	self.exp = exp
 	self.physical_strength = physical_strength

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/PlayerLevelConfig_Extend"
