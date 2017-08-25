-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- email:zengfeng75@qq.com
-- qq: 593705098
-- http://blog.ihaiu.com
-- --------------------------------------			

OutputConfig = class("OutputConfig", {
 	-- ID
 	-- type:int
 	-- sample:2
 	id = 0,

 	-- 注释
 	-- type:string
 	-- sample:教学2固定产出
 	tip = nil,

 	-- 产物1
 	-- type:string
 	-- sample:金币
 	item1 = nil,

 	-- 产物1
 	-- type:int
 	-- sample:2
 	item1 = 0,

 	-- 数量1
 	-- type:int
 	-- sample:20
 	num1 = 0,

 	-- 产物2
 	-- type:string
 	-- sample:机关1碎片
 	item2 = nil,

 	-- 产物2
 	-- type:int
 	-- sample:3001
 	item2 = 0,

 	-- 数量2
 	-- type:int
 	-- sample:1
 	num2 = 0,

 	-- 产物3
 	-- type:string
 	-- sample:
 	item3 = nil,

 	-- 产物3
 	-- type:int
 	-- sample:
 	item3 = 0,

 	-- 数量3
 	-- type:int
 	-- sample:
 	num3 = 0,

 	-- 产物4
 	-- type:string
 	-- sample:
 	item4 = nil,

 	-- 产物4
 	-- type:int
 	-- sample:
 	item4 = 0,

 	-- 数量4
 	-- type:int
 	-- sample:
 	num4 = 0,

 	-- 产物5
 	-- type:string
 	-- sample:
 	item5 = nil,

 	-- 产物5
 	-- type:int
 	-- sample:
 	item5 = 0,

 	-- 数量5
 	-- type:int
 	-- sample:
 	num5 = 0,

 	-- 产物6
 	-- type:string
 	-- sample:
 	item6 = nil,

 	-- 产物6
 	-- type:int
 	-- sample:
 	item6 = 0,

 	-- 数量6
 	-- type:int
 	-- sample:
 	num6 = 0,

 	-- 产物7
 	-- type:string
 	-- sample:
 	item7 = nil,

 	-- 产物7
 	-- type:int
 	-- sample:
 	item7 = 0,

 	-- 数量7
 	-- type:int
 	-- sample:
 	num7 = 0,

 	-- 产物8
 	-- type:string
 	-- sample:
 	item8 = nil,

 	-- 产物8
 	-- type:int
 	-- sample:
 	item8 = 0,

 	-- 数量8
 	-- type:int
 	-- sample:
 	num8 = 0,

 	-- 产物9
 	-- type:string
 	-- sample:
 	item9 = nil,

 	-- 产物9
 	-- type:int
 	-- sample:
 	item9 = 0,

 	-- 数量9
 	-- type:int
 	-- sample:
 	num9 = 0,

 	-- 产物10
 	-- type:string
 	-- sample:
 	item10 = nil,

 	-- 产物10
 	-- type:int
 	-- sample:
 	item10 = 0,

 	-- 数量10
 	-- type:int
 	-- sample:
 	num10 = 0,


})


local M = OutputConfig 

-- 获取键值
function M:GetKey()
 	return self.id
end
-- 构造方法
function M:ctor({id, tip, item1, item1, num1, item2, item2, num2, item3, item3, num3, item4, item4, num4, item5, item5, num5, item6, item6, num6, item7, item7, num7, item8, item8, num8, item9, item9, num9, item10, item10, num10})
 	self.id = id
 	self.tip = tip
 	self.item1 = item1
 	self.item1 = item1
 	self.num1 = num1
 	self.item2 = item2
 	self.item2 = item2
 	self.num2 = num2
 	self.item3 = item3
 	self.item3 = item3
 	self.num3 = num3
 	self.item4 = item4
 	self.item4 = item4
 	self.num4 = num4
 	self.item5 = item5
 	self.item5 = item5
 	self.num5 = num5
 	self.item6 = item6
 	self.item6 = item6
 	self.num6 = num6
 	self.item7 = item7
 	self.item7 = item7
 	self.num7 = num7
 	self.item8 = item8
 	self.item8 = item8
 	self.num8 = num8
 	self.item9 = item9
 	self.item9 = item9
 	self.num9 = num9
 	self.item10 = item10
 	self.item10 = item10
 	self.num10 = num10

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/OutputConfig_Extend"
