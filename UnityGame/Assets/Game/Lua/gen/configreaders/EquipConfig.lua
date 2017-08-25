-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- email:zengfeng75@qq.com
-- qq: 593705098
-- http://blog.ihaiu.com
-- --------------------------------------			

EquipConfig = class("EquipConfig", {
 	-- 装备id
 	-- type:int
 	-- sample:2002
 	equip_id = 0,

 	-- 英雄名称
 	-- type:string
 	-- sample:护甲
 	name = nil,

 	-- 图标ID
 	-- type:int
 	-- sample:2
 	icon_id = 0,

 	-- 模型ID
 	-- type:int
 	-- sample:2
 	model_id = 0,

 	-- 描述文字
 	-- type:string
 	-- sample:这是一件装备
 	tip = nil,


})


local M = EquipConfig 

-- 获取键值
function M:GetKey()
 	return self.equip_id
end
-- 构造方法
function M:ctor({equip_id, name, icon_id, model_id, tip})
 	self.equip_id = equip_id
 	self.name = name
 	self.icon_id = icon_id
 	self.model_id = model_id
 	self.tip = tip

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/EquipConfig_Extend"
