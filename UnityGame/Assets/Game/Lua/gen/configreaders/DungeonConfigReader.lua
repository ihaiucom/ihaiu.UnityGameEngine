-- ======================================
-- 该文件只会第一次生成，存在就不再生成。你可以在这扩展功能
-- DungeonConfig 读取器
-- 默认Menu: Game/Tool/xlsx->lua
-- http://blog.ihaiu.com
-- --------------------------------------			

DungeonConfigReader = class("DungeonConfigReader", ConfigReaderLua )
local M = DungeonConfigReader 



-- 结构体
M.StructClass = DungeonConfig

-- 属性(配置文件, 是否有属性表头)
M.attribute = ConfigAttribute.New( Dungeon, false ) 


-- 导入数据
require "gen/configreaders/DungeonConfigReader_Data"
