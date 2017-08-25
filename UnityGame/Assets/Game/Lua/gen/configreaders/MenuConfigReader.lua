-- ======================================
-- 该文件只会第一次生成，存在就不再生成。你可以在这扩展功能
-- MenuConfig 读取器
-- 默认Menu: Game/Tool/xlsx->lua
-- http://blog.ihaiu.com
-- --------------------------------------			

MenuConfigReader = class("MenuConfigReader", ConfigReaderLua )
local M = MenuConfigReader 



-- 结构体
M.StructClass = MenuConfig

-- 属性(配置文件, 是否有属性表头)
M.attribute = ConfigAttribute.New( Menu, false ) 


-- 导入数据
require "gen/configreaders/MenuConfigReader_Data"
