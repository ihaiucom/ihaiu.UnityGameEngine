-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- email:zengfeng75@qq.com
-- qq: 593705098
-- http://blog.ihaiu.com
-- --------------------------------------			

ItemConfig = class("ItemConfig", {
 	-- ID
 	-- type:int
 	-- sample:2
 	id = 0,

 	-- 名称
 	-- type:string
 	-- sample:金币
 	name = nil,

 	-- 图标
 	-- type:string
 	-- sample:金币图片
 	icon = nil,

 	-- 品质
 	-- type:int
 	-- sample:2
 	quality = 0,

 	-- 说明
 	-- type:string
 	-- sample:游戏货币
 	tip = nil,


})


local M = ItemConfig 

-- 获取键值
function M:GetKey()
 	return self.id
end
-- 构造方法
function M:ctor({id, name, icon, quality, tip})
 	self.id = id
 	self.name = name
 	self.icon = icon
 	self.quality = quality
 	self.tip = tip

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/ItemConfig_Extend"
