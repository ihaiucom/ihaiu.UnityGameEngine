-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- email:zengfeng75@qq.com
-- qq: 593705098
-- http://blog.ihaiu.com
-- --------------------------------------			

PropertyConfig = class("PropertyConfig", {
 	-- ID
 	-- type:int
 	-- sample:2
 	id = 0,

 	-- 常量名称
 	-- type:string
 	-- sample:Level
 	const = nil,

 	-- 字段名称
 	-- type:string
 	-- sample:level
 	field = nil,

 	-- 英文名称
 	-- type:string
 	-- sample:level
 	enName = nil,

 	-- 中文名称
 	-- type:string
 	-- sample:等级
 	cnName = nil,

 	-- 图标
 	-- type:string
 	-- sample:ImageSprites/Icon/icon_prop_level
 	icon = nil,

 	-- 描述
 	-- type:string
 	-- sample:达到特定经验节点会提升等级，并带来战斗属性的提升，和其他收益（如天赋点）
 	note = nil,


})


local M = PropertyConfig 

-- 获取键值
function M:GetKey()
 	return self.id
end
-- 构造方法
function M:ctor({id, const, field, enName, cnName, icon, note})
 	self.id = id
 	self.const = const
 	self.field = field
 	self.enName = enName
 	self.cnName = cnName
 	self.icon = icon
 	self.note = note

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/PropertyConfig_Extend"
