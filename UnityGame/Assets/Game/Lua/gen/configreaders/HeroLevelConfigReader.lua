-- ======================================
-- 该文件只会第一次生成，存在就不再生成。你可以在这扩展功能
-- HeroLevelConfig 读取器
-- 默认Menu: Game/Tool/xlsx->lua
-- http://blog.ihaiu.com
-- --------------------------------------			

HeroLevelConfigReader = class("HeroLevelConfigReader", ConfigReaderLua )
local M = HeroLevelConfigReader 



-- 结构体
M.StructClass = HeroLevelConfig

-- 属性(配置文件, 是否有属性表头)
M.attribute = ConfigAttribute.New( HeroLevel, false ) 


-- 导入数据
require "gen/configreaders/HeroLevelConfigReader_Data"
