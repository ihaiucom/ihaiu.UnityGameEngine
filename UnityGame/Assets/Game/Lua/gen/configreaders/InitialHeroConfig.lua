-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- email:zengfeng75@qq.com
-- qq: 593705098
-- http://blog.ihaiu.com
-- --------------------------------------			

InitialHeroConfig = class("InitialHeroConfig", {
 	-- ID
 	-- type:int
 	-- sample:2
 	id = 0,

 	-- 可选英雄
 	-- type:int
 	-- sample:1002
 	hero_id = 0,


})


local M = InitialHeroConfig 

-- 获取键值
function M:GetKey()
 	return self.id
end
-- 构造方法
function M:ctor({id, hero_id})
 	self.id = id
 	self.hero_id = hero_id

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/InitialHeroConfig_Extend"
