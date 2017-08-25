-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- email:zengfeng75@qq.com
-- qq: 593705098
-- http://blog.ihaiu.com
-- --------------------------------------			

LoaderConfig = class("LoaderConfig", {
 	-- id
 	-- type:int
 	-- sample:1
 	id = 0,

 	-- 名称
 	-- type:string
 	-- sample:转圈
 	name = nil,

 	-- 路径
 	-- type:string
 	-- sample:PrefabUI/GameSystem/GameCirclePanel
 	path = nil,

 	-- 打开加载面前是否转圈圈
 	-- type:bool
 	-- sample:0
 	isShowCircle = false,


})


local M = LoaderConfig 

-- 获取键值
function M:GetKey()
 	return self.id
end
-- 构造方法
function M:ctor({id, name, path, isShowCircle})
 	self.id = id
 	self.name = name
 	self.path = path
 	self.isShowCircle = string.IsNullOrEmpty( isShowCircle ) == false and isShowCircle ~= 0 or false

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/LoaderConfig_Extend"
