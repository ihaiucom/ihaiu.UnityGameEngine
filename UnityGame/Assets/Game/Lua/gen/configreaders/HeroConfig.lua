-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- http://blog.ihaiu.com
-- --------------------------------------			

HeroConfig = class("HeroConfig", {
 	-- 英雄id
 	-- type:int
 	-- sample:1002
 	hero_id = 0,

 	-- 英雄名称
 	-- type:string
 	-- sample:女娲
 	name = nil,

 	-- 职业
 	-- type:int
 	-- sample:2
 	professional = 0,

 	-- 模型ID
 	-- type:int
 	-- sample:2
 	model_id = 0,

 	-- 描述文字
 	-- type:string
 	-- sample:这是一个英雄
 	tip = nil,

 	-- 技能1
 	-- type:int
 	-- sample:1001
 	skill_1 = 0,

 	-- 技能2
 	-- type:int
 	-- sample:1002
 	skill_2 = 0,

 	-- 技能3
 	-- type:int
 	-- sample:1003
 	skill_3 = 0,

 	-- 技能4
 	-- type:int
 	-- sample:1004
 	skill_4 = 0,

 	-- 技能5
 	-- type:int
 	-- sample:1005
 	skill_5 = 0,

 	-- 技能6
 	-- type:int
 	-- sample:1006
 	skill_6 = 0,


})


local M = HeroConfig 

-- 获取键值
function M:GetKey()
 	return self.hero_id
end
-- 构造方法
function M:ctor({hero_id, name, professional, model_id, tip, skill_1, skill_2, skill_3, skill_4, skill_5, skill_6})
 	self.hero_id = hero_id
 	self.name = name
 	self.professional = professional
 	self.model_id = model_id
 	self.tip = tip
 	self.skill_1 = skill_1
 	self.skill_2 = skill_2
 	self.skill_3 = skill_3
 	self.skill_4 = skill_4
 	self.skill_5 = skill_5
 	self.skill_6 = skill_6

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/HeroConfig_Extend"
