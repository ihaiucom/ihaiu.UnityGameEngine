-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- http://blog.ihaiu.com
-- --------------------------------------			

MsgConfig = class("MsgConfig", {
 	-- id
 	-- type:int
 	-- sample:1
 	id = 0,

 	-- 内容
 	-- type:string
 	-- sample:失败
 	content = nil,

 	-- "文字弹出框(1:只有确定 2:有确定
 	-- type:int
 	-- sample:0
 	type = 0,


})


local M = MsgConfig 

-- 获取键值
function M:GetKey()
 	return self.id
end
-- 构造方法
function M:ctor({id, content, type})
 	self.id = id
 	self.content = content
 	self.type = type

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/MsgConfig_Extend"
