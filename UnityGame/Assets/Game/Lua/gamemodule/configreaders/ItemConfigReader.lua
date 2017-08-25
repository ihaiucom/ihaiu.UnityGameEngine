ItemConfigReader = class("ItemConfigReader", ConfigReaderLua)

local M = ItemConfigReader

-- 结构体 
M.StructClass 	= ItemConfig

-- 属性(配置路径， 是否有属性表头)
M.attribute 	= ConfigAttribute.New("", false)

-- 导入数据
require "gamemodule/configreaders/ItemConfigReader_Data"