-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- email:zengfeng75@qq.com
-- qq: 593705098
-- http://blog.ihaiu.com
-- --------------------------------------			

MenuConfig = class("MenuConfig", {
 	-- 面板ID
 	-- type:int
 	-- sample:1
 	id = 0,

 	-- 面板名称
 	-- type:string
 	-- sample:登录界面
 	name = nil,

 	-- 资源路径
 	-- type:string
 	-- sample:PrefabUI/GameLogin/LoginWindow
 	path = nil,

 	-- 模块类型
 	-- type:int
 	-- sample:0
 	menuType = 0,

 	-- 层级
 	-- type:int
 	-- sample:4
 	layer = 0,

 	-- 布局类型
 	-- type:int
 	-- sample:0
 	layout = 0,

 	-- 关闭其他面板包含哪些
 	-- type:int
 	-- sample:2
 	closeOtherType = 0,

 	-- 缓存时间
 	-- type:int
 	-- sample:
 	cacheTime = 0,

 	-- 加载面板类型
 	-- type:int
 	-- sample:0
 	loaderType = 0,


})


local M = MenuConfig 

-- 获取键值
function M:GetKey()
 	return self.id
end
-- 构造方法
function M:ctor({id, name, path, menuType, layer, layout, closeOtherType, cacheTime, loaderType})
 	self.id = id
 	self.name = name
 	self.path = path
 	self.menuType = menuType
 	self.layer = layer
 	self.layout = layout
 	self.closeOtherType = closeOtherType
 	self.cacheTime = cacheTime
 	self.loaderType = loaderType

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/MenuConfig_Extend"
